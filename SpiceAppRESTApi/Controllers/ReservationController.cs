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
using Newtonsoft.Json.Linq;

namespace SpiceAppRESTApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Reservation")]
    public class ReservationController : ApiController
    {

        // GET: api/Reservation/Available/userID/StartingDateAsTicks/EndDateAsTicks
        // brings available cars for given user
        // SOAP Name = FetchAvailableCarsForResv
        [Route("Available/{Id}/{StartingDate}/{EndDate}")]
        [HttpGet]
        public IHttpActionResult Available(int Id, Int64 StartingDate, Int64 EndDate)
        {
            var content = new Response<Car>();
            try
            {
                using(var reservationBusiness = new ReservationBusiness())
                {
                    content = reservationBusiness.FetchAvailableCarsForResv(Id, new DateTime(StartingDate), new DateTime(EndDate));
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Car>(content, Request);
        }


        // GET: api/Reservation/id
        // url parameter = id of user
        // brings all reservation of given user
        // SOAP Name = FetchAllById
        public IHttpActionResult Get(int id)
        {
            var content = new Response<Reservation>();
            try
            {
                using(var reservationBusiness = new ReservationBusiness())
                {
                    content = reservationBusiness.FetchAllResvById(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Reservation>(content, Request);
        }

        // POST: api/Reservation
        // body = { CarID = int, UserID = int, StartingDate = DateTime, EndDate = DateTime }
        // makes reservation to given car id for given user id with given dates
        // SOAP Name = MakeReservation
        public IHttpActionResult Post([FromBody] JObject data)
        {
            var content = new Response<Reservation>();
            try
            {
                using (var reservationBusiness = new ReservationBusiness())
                {
                    content = reservationBusiness.MakeReservation(
                        Convert.ToInt32(data["CarID"]),
                        Convert.ToInt32(data["UserID"]),
                        Convert.ToDateTime(data["StartingDate"]),
                        Convert.ToDateTime(data["EndDate"])
                    );
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Reservation>(content, Request);
        }

        // DELETE: api/Reservation/id
        // url parameter = id of reservation
        // cancels reservation with given id
        // SOAP Name = CancelReservation
        public IHttpActionResult Delete(int id)
        {
            var content = new Response<Reservation>();
            try
            {
                using (var reservationBusiness = new ReservationBusiness())
                {
                    content = reservationBusiness.CancelReservation(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Reservation>(content, Request);
        }

    }
}
