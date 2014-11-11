using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileWebApp.Models;
using System.Web.Http.Cors;
using Microsoft.AspNet.SignalR;

namespace MobileWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegisterController : ApiController
    {
        private UserRegisterRepository _repositoryUserRegister;

        public RegisterController()
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

        // POST api/<controller>
        //public void Post([FromBody]string value)
        public void Post(UserRegister userRegisterFrom)
        {
            UserRegister userRegisterTo = new UserRegister();
            userRegisterTo.UserRegisterId = Guid.NewGuid();
            userRegisterTo.FirstName = userRegisterFrom.FirstName;
            userRegisterTo.LastName = userRegisterFrom.LastName;
            userRegisterTo.Gender = userRegisterFrom.Gender;
            userRegisterTo.Birthday = userRegisterFrom.Birthday;
            userRegisterTo.Phone = userRegisterFrom.Phone;
            userRegisterTo.EmailAddress = userRegisterFrom.EmailAddress;
            userRegisterTo.UserName = userRegisterFrom.UserName;
            userRegisterTo.UserPassword = userRegisterFrom.UserPassword;
            userRegisterTo.FavoriteFood = userRegisterFrom.FavoriteFood;
            userRegisterTo.FavoriteDrink = userRegisterFrom.FavoriteDrink;
            _repositoryUserRegister.Add(userRegisterTo);

            //
            var ctx = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
            ctx.Clients.All.greetings("reload");
            //
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