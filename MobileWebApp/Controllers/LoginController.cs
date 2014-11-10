using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileWebApp.Models;

namespace MobileWebApp.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "Testing", "123" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "Testing 123";
        }

        // POST api/<controller>
        //public void Post(UserLogin user)
        public UserLogin Post(UserLogin user)
        {
            return user;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}