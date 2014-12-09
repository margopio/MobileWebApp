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
    public class LoginController : ApiController
    {
        private UserRegisterRepository _repositoryUserRegister;

        public LoginController()
        {
            _repositoryUserRegister = new UserRegisterRepository();
        }
        
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

        public HttpResponseMessage Post(UserLogin user)
        {
            var userFound = _repositoryUserRegister.GetUserRegisters().FirstOrDefault(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);
            if (userFound != null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + userFound.UserRegisterId.ToString());
                msg.Content = new StringContent(userFound.UserRegisterId.ToString());
                return msg;
            }
            throw new HttpResponseException(HttpStatusCode.Conflict);
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