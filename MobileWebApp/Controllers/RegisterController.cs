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

        public HttpResponseMessage Post(UserRegister userRegisterFrom)
        {
            UserRegister userRegisterTo = new UserRegister();
            userRegisterTo.UserRegisterId = Guid.NewGuid();
            userRegisterTo.FirstName = userRegisterFrom.FirstName;
            userRegisterTo.LastName = userRegisterFrom.LastName;
            //userRegisterTo.Gender = userRegisterFrom.Gender;
            userRegisterTo.Birthday = userRegisterFrom.Birthday;
            //userRegisterTo.Month = userRegisterFrom.Month;
            //userRegisterTo.Day = userRegisterFrom.Day;
            userRegisterTo.Phone = userRegisterFrom.Phone;
            userRegisterTo.PhoneType = userRegisterFrom.PhoneType;
            userRegisterTo.TextMsg = userRegisterFrom.TextMsg;            
            userRegisterTo.EmailAddress = userRegisterFrom.EmailAddress;
            //userRegisterTo.UserName = userRegisterFrom.UserName;
            userRegisterTo.UserPassword = userRegisterFrom.UserPassword;
            //userRegisterTo.FavoriteFood = userRegisterFrom.FavoriteFood;
            //userRegisterTo.FavoriteDrink = userRegisterFrom.FavoriteDrink;
            var status = _repositoryUserRegister.Add(userRegisterTo);

            if (status)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + userRegisterTo.UserRegisterId.ToString());
                //msg.Content = new StringContent(userRegisterTo.UserRegisterId.ToString());

                msg.Content = new StringContent(userRegisterTo.UserRegisterId.ToString() + "," + userRegisterTo.FirstName + "," + userRegisterTo.LastName);

                //
                var ctx = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
                ctx.Clients.All.greetings("reload");
                //

                return msg;
            }
            throw new HttpResponseException(HttpStatusCode.Conflict);          
        }        

        public HttpResponseMessage Put(UserRegister userRegisterFrom)
        {
            UserRegister userRegisterTo = new UserRegister();
            var userId = userRegisterFrom.UserRegisterId;            
            if (userId != Guid.Empty)
            {
                var user = _repositoryUserRegister.GetUserRegister(userId);
                if (user != null)
                {
                    _repositoryUserRegister.Delete(userId);                    
                    userRegisterTo.UserRegisterId = userId;
                    userRegisterTo.FirstName = userRegisterFrom.FirstName;
                    userRegisterTo.LastName = userRegisterFrom.LastName;
                    //userRegisterTo.Gender = userRegisterFrom.Gender;
                    userRegisterTo.Birthday = userRegisterFrom.Birthday;
                    userRegisterTo.Phone = userRegisterFrom.Phone;
                    userRegisterTo.PhoneType = userRegisterFrom.PhoneType;
                    userRegisterTo.TextMsg = userRegisterFrom.TextMsg;
                    userRegisterTo.EmailAddress = userRegisterFrom.EmailAddress;
                    //userRegisterTo.UserName = userRegisterFrom.UserName;
                    userRegisterTo.UserPassword = userRegisterFrom.UserPassword;
                    //userRegisterTo.FavoriteFood = userRegisterFrom.FavoriteFood;
                    //userRegisterTo.FavoriteDrink = userRegisterFrom.FavoriteDrink;
                    var status = _repositoryUserRegister.Add(userRegisterTo);

                    if (status)
                    {
                        var msg = new HttpResponseMessage(HttpStatusCode.OK);
                        msg.Headers.Location = new Uri(Request.RequestUri + userRegisterTo.UserRegisterId.ToString());
                        //msg.Content = new StringContent(userRegisterTo.UserRegisterId.ToString());

                        msg.Content = new StringContent(userRegisterTo.UserRegisterId.ToString() + "," + userRegisterTo.FirstName + "," + userRegisterTo.LastName);

                        //
                        var ctx = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
                        ctx.Clients.All.greetings("reload");
                        //

                        return msg;
                    }
                    throw new HttpResponseException(HttpStatusCode.NotFound);  
                }                
            }

            throw new HttpResponseException(HttpStatusCode.NotFound); 
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}