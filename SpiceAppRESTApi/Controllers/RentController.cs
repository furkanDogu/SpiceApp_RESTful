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
    [RoutePrefix("api/Rent")]
    public class RentController : ApiController
    {

        // GET: api/Rent/CompleteRez/id
        // url parameter = id of reservation to be completed
        // completes reservation with given id
        // SOAP Name = CompleteReservation
        [Route("CompleteRez/{id}")]
        [HttpGet]
        public IHttpActionResult CompleteRez(int id)
        {
            var content = new Response<RentDetail>();
            try
            {
                using(var rentDetailBusiness = new RentDetailBusiness())
                {
                    content = rentDetailBusiness.CompleteReservation(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<RentDetail>(content, Request);
        }

        // GET: api/Rent/id
        // url parameter = id of rent detail to be shown with details
        // brings details of rent with given rent id
        // SOAP Name = FetchOneById
        public IHttpActionResult Get(int id)
        {
            var content = new Response<RentDetail>();
            try
            {
                using(var rentDetailBusiness = new RentDetailBusiness())
                {
                    content = rentDetailBusiness.FetchOneById(id);
                }
            }
            catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<RentDetail>(content, Request);
        }


        // GET: api/Rent/GetByCst/id
        // url parameter = id of customer
        // brings all rents of customer with given id 
        // SOAP Name = FetchAllRentDetailById
        [Route("GetByCst/{id}")]
        [HttpGet]
        public IHttpActionResult GetByCst(int id)
        {
            var content = new Response<RentDetail>();
            try
            {
                using(var rentDetailBusiness = new RentDetailBusiness())
                {
                    content = rentDetailBusiness.FetchAllRentDetailById(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<RentDetail>(content, Request);
        }


        // POST: api/Rent
        // body = { RentID = int, KmInfo = int, Score = int }
        // returns the car to the company
        // SOAP Name = ReturnCarToCompany
        public IHttpActionResult Post([FromBody] JObject data)
        {
            var content = new Response<RentDetail>();
            try
            {
                using(var rentDetailBusiness = new RentDetailBusiness())
                {
                    content = rentDetailBusiness.ReturnCarToCompany(
                        Convert.ToInt32(data["RentID"]),
                        Convert.ToInt32(data["KmInfo"]),
                        Convert.ToInt32(data["Score"])                        
                    );
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<RentDetail>(content, Request);
        }



    }
}
