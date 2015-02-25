using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.SignalR;
using MobileWebApp.Models;
using PushSharp;
using PushSharp.Android;

namespace MobileWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private UserRegisterRepository _repositoryUserRegister;

        public AccountController()
        {
            _repositoryUserRegister = new UserRegisterRepository();
        }

        [Route("~/api/Account/register")]
        public HttpResponseMessage Register(AddRegistration model)
        {
            AddRegistration userRegisterTo = new AddRegistration();
            userRegisterTo.UserId = Guid.NewGuid();
            userRegisterTo.Firstname = model.Firstname;
            userRegisterTo.Lastname = model.Lastname;
            userRegisterTo.Birthday = model.Birthday;
            userRegisterTo.Phone = model.Phone;
            userRegisterTo.DeviceType = model.DeviceType;
            userRegisterTo.TextMsg = model.TextMsg;
            userRegisterTo.Email = model.Email;
            userRegisterTo.Password = model.Password;           
            var status = _repositoryUserRegister.Add(userRegisterTo);
            UserToken userToken = new UserToken();
            
            if (status)
            {
                userToken.MemberNumber = userRegisterTo.UserId.ToString();
                userToken.SiteID = 0;
                userToken.UserType = 0;
                userToken.FirstName = userRegisterTo.Firstname;
                userToken.LastName = userRegisterTo.Lastname;

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, userToken);

                //
                var ctx = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
                ctx.Clients.All.greetings("reload");
                //

                return response;
            }
            throw new HttpResponseException(HttpStatusCode.Conflict);          
        }

        [Route("~/api/Account/accountinfoupdate")]
        [HttpPut]
        public HttpResponseMessage AccountInfoUpdate(AddRegistration model)
        {
            AddRegistration userRegisterTo = new AddRegistration();
            var userId = model.UserId;
            if (userId != Guid.Empty)
            {
                var user = _repositoryUserRegister.GetUserRegister(userId);
                if (user != null)
                {
                    _repositoryUserRegister.Delete(userId);
                    userRegisterTo.UserId = userId;
                    userRegisterTo.Firstname = model.Firstname;
                    userRegisterTo.Lastname = model.Lastname;
                    userRegisterTo.Birthday = model.Birthday;
                    userRegisterTo.Phone = model.Phone;
                    userRegisterTo.DeviceType = model.DeviceType;
                    userRegisterTo.TextMsg = model.TextMsg;
                    userRegisterTo.Email = model.Email;
                    userRegisterTo.Password = model.Password;                    
                    var status = _repositoryUserRegister.Add(userRegisterTo);
                    UserToken userToken = new UserToken();

                    if (status)
                    {
                        userToken.MemberNumber = userRegisterTo.UserId.ToString();
                        userToken.SiteID = 0;
                        userToken.UserType = 0;
                        userToken.FirstName = userRegisterTo.Firstname;
                        userToken.LastName = userRegisterTo.Lastname;

                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, userToken);

                        //
                        var ctx = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
                        ctx.Clients.All.greetings("reload");
                        //

                        return response;
                    }
                    throw new HttpResponseException(HttpStatusCode.Conflict);               
                }
            }

            throw new HttpResponseException(HttpStatusCode.NotFound); 
        }


        [Route("~/api/Account/accountinfo")]
        public HttpResponseMessage AccountInfo(AccountInfo UserId)
        {
            if (UserId.UserId != Guid.Empty)
            {
                var user = _repositoryUserRegister.GetUserRegister(UserId.UserId);
                if (user != null)
                {
                    var data = new 
                    {
                        FirstName = user.Firstname,
                        LastName = user.Lastname,
                        Birthday = user.Birthday,
                        Phone = user.Phone,
                        PhoneType = user.DeviceType,
                        TextMsg = user.TextMsg,
                        Email = user.Email,
                        Password = user.Password
                    };
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
                    return response;
                }
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);           
        }
        
        [Route("~/api/Account/login")]        
        public UserToken Login(LoginUser model)
        {
            UserToken userToken = new UserToken();

            var userFound = _repositoryUserRegister.GetUserRegisters().FirstOrDefault(u => u.Email == model.LoginId && u.Password == model.Password);
            if (userFound != null)
            {
                userToken.MemberNumber = userFound.UserId.ToString();
                userToken.SiteID = 0;
                userToken.UserType = 0;
                userToken.FirstName = userFound.Firstname;
                userToken.LastName = userFound.Lastname;

                //
                var ctx = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
                ctx.Clients.All.greetings("reload");
                //

                // TODO GCM Routines                
                var registrationId = GCMSenderIDRepository.Responses.LastOrDefault().GcmSenderId;                
                PushBroker pushBroker = new PushBroker();
                pushBroker.RegisterGcmService(new GcmPushChannelSettings("AIzaSyAHUKVH5UiYorEg_ewoMQGkDVyI3uI46W8"));               
                pushBroker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(registrationId)
                      .WithJson(@"{""message"":""" + "GCM notice" + @"""}"));
                pushBroker.StopAllServices();
                //

                return userToken;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);            
        }
        
    }
}
