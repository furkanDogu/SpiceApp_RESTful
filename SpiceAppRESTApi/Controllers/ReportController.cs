using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SpiceAppRESTApi.Responses;
using SpiceApp.Models.Entities;
using SpiceApp.Models.Templates;
using SpiceApp.BusinessLayer.Concretes;

namespace SpiceAppRESTApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Report")]
    public class ReportController : ApiController
    {
        // GET: api/Report/DailyKm/id
        // url parameter = id of User
        // lists daily km infos of all cars of the company
        [Route("DailyKm/{id}")]
        [HttpGet]
        public IHttpActionResult DailyKm(int id)
        {
            var content = new Response<DailyKmInfo>();
            try
            {
                using (var reportBusiness = new ReportBusiness())
                {
                    content = reportBusiness.DailyKmReport(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<DailyKmInfo>(content, Request);
        }

        // GET: api/Report/Balance/id
        // url parameter = id of User
        // lists balance info of the company
        [Route("Balance/{id}")]
        [HttpGet]
        public IHttpActionResult Balance(int id)
        {
            var content = new Response<CompanyBalanceInfo>();
            try
            {
                using (var reportBusiness = new ReportBusiness())
                {
                    content = reportBusiness.CompanyBalanceInfo(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<CompanyBalanceInfo>(content, Request);
        }

        // GET: api/Report/DailyKmByRent
        // urlParameters: userId = id of User, rentId = id of Rent
        // brings daily km info of given rent
        [Route("DailyKmByRent/{userId}/{rentId}")]
        [HttpGet]
        public IHttpActionResult DailyKmByRent(int userId, int rentId)
        {
            var content = new Response<DailyKmInfo>();

            try
            {
                using (var reportBusiness = new ReportBusiness())
                {
                    content = reportBusiness.DailyKmReportByRentID(userId, rentId);
                }
            }
            catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<DailyKmInfo>(content, Request);
        }

        // GET: api/Report/OverKm/id
        // url parameter = id of User
        // brings over km rate of the company
        [Route("OverKm/{id}")]
        [HttpGet]
        public IHttpActionResult OverKm(int id)
        {
            var content = new Response<OverKmInfo>();
            try
            {
                using(var reportBusiness = new ReportBusiness())
                {
                    content = reportBusiness.OverKmInfo(id);
                }
            }
            catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<OverKmInfo>(content,Request);
        }

        // GET: api/Report/MonthlyRent
        // body = { UserID = int, Term = DateTime }
        // brings rent rates of the given month
        [Route("MonthlyRent/{id}/{ticks}")]
        [HttpGet]
        public IHttpActionResult MonthlyRent(int id, Int64 ticks)
        {
            var content = new Response<RentRate>();
            try
            {
                using(var reportBusiness = new ReportBusiness())
                {
                    content = reportBusiness.RentRateMonthly(id,new DateTime(ticks));
                }
            }
            catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<RentRate>(content, Request);
        }




    }
}
