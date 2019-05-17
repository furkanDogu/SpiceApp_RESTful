using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SpiceApp.Models.Entities;
using SpiceAppRESTApi.Responses;

namespace SpiceAppRESTApi.Responses
{
    public class StandartResult<T> : IHttpActionResult where T : class
    {
        public Response<T> _data; 
        public HttpRequestMessage _request;

        public StandartResult(Response<T> data, HttpRequestMessage request)
        {
            _data = data;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = ConvertStatusCode(_data.isSuccess),
                Content = new ObjectContent<Response<T>>(_data, new JsonMediaTypeFormatter()),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }

        protected HttpStatusCode ConvertStatusCode(bool result)
        {
            if (result) return HttpStatusCode.OK;
            else return HttpStatusCode.BadRequest;
        }
    }
}