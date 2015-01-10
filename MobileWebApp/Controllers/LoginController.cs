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
        //

        public HttpResponseMessage Post(UserLogin user)
        {
            //var userFound = _repositoryUserRegister.GetUserRegisters().FirstOrDefault(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);
            var userFound = _repositoryUserRegister.GetUserRegisters().FirstOrDefault(u => u.EmailAddress == user.EmailAddress && u.UserPassword == user.UserPassword);
            if (userFound != null)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + userFound.UserRegisterId.ToString());
                //msg.Content = new StringContent(userFound.UserRegisterId.ToString());

                //char[] splitchar = { '-' };
                //string[] result = userFound.UserRegisterId.ToString().Split(splitchar);
                //msg.Content = new StringContent(result[0] + "," + userFound.FirstName + "," + userFound.LastName);

                msg.Content = new StringContent(userFound.UserRegisterId.ToString() + "," + userFound.FirstName + "," + userFound.LastName);

                return msg;
            }
            throw new HttpResponseException(HttpStatusCode.Conflict);
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}