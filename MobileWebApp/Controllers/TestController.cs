using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileWebApp.Models;
using System.Web.Http.Cors;

namespace MobileWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message - Remote 1")               
            };
        }

        public HttpResponseMessage Post()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("POST: Test message - Remote 1")
            };
        }

        public HttpResponseMessage Put()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("PUT: Test message - Remote 1")
            };
        }        
    }
}
