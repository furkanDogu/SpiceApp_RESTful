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
    [RoutePrefix("api/Brand")]
    public class BrandController : ApiController
    {

        // GET: api/Brand
        // Brings all brands
        // SOAP Name = FetchAllBrands
        public IHttpActionResult Get()
        {
            var content = new Response<Brand>();
            try
            {
                using (var brandBusiness = new BrandBusiness())
                {
                    content = brandBusiness.FetchAllBrands();
                }
            } catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Brand>(content, Request);
        }

        // POST: api/Brand
        // Adds new brand
        // body = Brand object
        // SOAP Name = AddBrand
        public IHttpActionResult Post([FromBody] Brand brand)
        {
            var content = new Response<Brand>();
            try
            {
                using(var brandBusiness = new BrandBusiness())
                {
                    content = brandBusiness.AddBrand(brand);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Brand>(content, Request);
        }

        // PUT: api/Brand
        // updates a brand
        // body = Brand object
        // SOAP Name = UpdateBrand
        public IHttpActionResult Put([FromBody] Brand brand)
        {
            var content = new Response<Brand>();
            try
            {
                using(var brandBusiness =new BrandBusiness())
                {
                    content = brandBusiness.UpdateBrand(brand);
                }
            }
            catch(Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Brand>(content, Request);
        }

        // GET: api/Brand/id
        // brings one brand with given id
        // url parameter: id of needed Brand
        // SOAP Name = FetchOneBrandById
        public IHttpActionResult Get(int id)
        {
            var content = new Response<Brand>();
            try
            {
                using (var brandBusiness = new BrandBusiness())
                {
                    content = brandBusiness.FetchOneBrandById(id);
                }
            }
            catch (Exception ex)
            {
                content.isSuccess = false;
                content.Message += ex.Message;
            }
            return new StandartResult<Brand>(content, Request);
        }
    }
}
