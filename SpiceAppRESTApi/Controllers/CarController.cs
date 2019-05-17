using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SpiceApp.Models.Entities;
using SpiceApp.BusinessLayer.Concretes;
using SpiceAppRESTApi.Responses;

namespace SpiceAppRESTApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Car")]
    public class CarController : ApiController
    {

        // GET: api/Car/Company/id
        // url parameter = company id
        // Brings cars of any company with given company id
        // SOAP Name = FetchAllCarsByCompanyId
        [Route("Company/{id}")]
        [HttpGet]
        public IHttpActionResult Company(int id)
        {
            var content = new Response<Car>();
            try
            {
                using(var carBusiness = new CarBusiness())
                {
                    content = carBusiness.FetchAllCarsByCompany(id);
                }
            }
            catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Car>(content, Request);
        }

        // POST: api/Car
        // body = Car object
        // adds a new car 
        // SOAP Name = AddNewCar
        public IHttpActionResult Post([FromBody] Car car)
        {
            var content = new Response<Car>();
            try
            {
                using (var carBusines = new CarBusiness())
                {
                    content = carBusines.AddNewCar(car);
                } 
            }
            catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Car>(content, Request);
        }

        // GET: api/Car/id
        // url parameter = id of the needed car
        // brings car with given car id
        // SOAP Name = FetchOneCarById
        public IHttpActionResult Get(int id)
        {
            var content = new Response<Car>();
            try
            {
                using (var carBusines = new CarBusiness())
                {
                    content = carBusines.FetchCarById(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Car>(content, Request);
        }

        // DELETE: api/Car/id
        // url parameter = id of the car to be deleted
        // deletes the car with given id
        // SOAP Name = DeleteCarById
        public IHttpActionResult Delete(int id)
        {
            var content = new Response<Car>();
            try
            {
                using (var carBusines = new CarBusiness())
                {
                    content = carBusines.DeleteCarById(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Car>(content, Request);
        }


        // GET: api/Car/Activate/id
        // url parameter = id of the car to be activated
        // activates the car with given id
        // SOAP Name = ActivateCarById
        // This endpoint won't return Data.(even if it's get request)
        [Route("Activate/{id}")]
        [HttpGet]
        public IHttpActionResult Activate(int id)
        {
            var content = new Response<Car>();
            try
            {
                using (var carBusines = new CarBusiness())
                {
                    content = carBusines.ActivateCarById(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Car>(content, Request);
        }

        // PUT: api/Car
        // body = Car object
        // updates car information
        // SOAP Name = UpdateCar
        public IHttpActionResult Put([FromBody] Car car)
        {
            var content = new Response<Car>();
            try
            {
                using (var carBusines = new CarBusiness())
                {
                    content = carBusines.UpdateCar(car);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Car>(content, Request);
        }


    }
}
