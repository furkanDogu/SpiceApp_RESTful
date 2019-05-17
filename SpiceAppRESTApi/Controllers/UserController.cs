using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SpiceAppRESTApi.Responses;
using SpiceApp.Models.Entities;
using Newtonsoft.Json.Linq;
using SpiceApp.BusinessLayer.Concretes;

namespace SpiceAppRESTApi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // POST: api/User/Login
        /*
           body = { Username: String, Password: String }  
        */
        // SOAP Name = Login
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login([FromBody]JObject data)
        {
            var content = new Response<User>();
            try
            {
                using (var userBusiness = new UserBusiness())
                {
                    content = userBusiness.Login(data["Username"].ToString(), data["Password"].ToString());
                }
            }
            catch(Exception ex)
            {
                content.Message += ex.Message;
                content.isSuccess = false;
            }
            return new StandartResult<User>(content, Request);
        }

        // POST: api/User/Register
        // body = User object
        // SOAP Name = RegisterUser
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register([FromBody] User user)
        {
            var content = new Response<User>();
            try
            {
                using (var userBusiness = new UserBusiness())
                {
                    content = userBusiness.RegisterUser(user);
                }
            }
            catch (Exception ex)
            {
                content.Message += ex.Message;
                content.isSuccess = false;

            }
            return new StandartResult<User>(content, Request);
        }

        // GET: api/User/
        // Brings customer list 
        // SOAP Name = FetchAllCustomers
        public IHttpActionResult Get()
        {
            var content = new Response<User>();
            try
            {
                using (var userBusiness = new UserBusiness())
                {
                    content = userBusiness.FetchAllCustomers();
                }
            }
            catch (Exception ex)
            {
                content.Message += ex.Message;
                content.isSuccess = false;
            }
            return new StandartResult<User>(content, Request);
        }


        // PUT: api/User
        // body = User object
        // SOAP Name = UpdateInfo
        public IHttpActionResult Put([FromBody] User user)
        {
            var content = new Response<User>();
            try
            {
                
                using (var userBusiness = new UserBusiness())
                {
                    content = userBusiness.UpdateInfo(user);
                }
            }
            catch(Exception ex)
            {
                content.Message += ex.Message;
                content.isSuccess = false;
            }
            return new StandartResult<User>(content, Request);
        }


        // POST: api/User/ChangePassword
        /*
           body = { UserID = int, Password = String } 
        */
        // SOAP Name = ChangePassword
        [HttpPost]
        [Route("ChangePassword")]
        public IHttpActionResult ChangePassword([FromBody]JObject data)
        {
            var content = new Response<User>();
            try
            {
                using (var userBusiness = new UserBusiness())
                {
                    content = userBusiness.ChangePassword(Convert.ToInt32(data["UserID"]), data["Password"].ToString());
                }
            }
            catch (Exception ex)
            {
                content.Message += ex.Message;
                content.isSuccess = false;
            }
            return new StandartResult<User>(content, Request);
        }



    }
}
