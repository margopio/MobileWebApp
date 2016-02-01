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
using MobileWebApp.Models.SIServiceRewards;

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
            //if (!MembershipCardsRepository.Responses.Any(x => x.MemberCardNo == model.CardNo))
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);    
            //}

            AddRegistration userRegisterTo = new AddRegistration();
            userRegisterTo.UserId = Guid.NewGuid();
            userRegisterTo.CardNo = model.CardNo;
            userRegisterTo.Firstname = model.Firstname;
            userRegisterTo.Lastname = model.Lastname;
            userRegisterTo.Birthday = model.Birthday;
            userRegisterTo.Phone = model.Phone;
            userRegisterTo.DeviceType = 1;
            userRegisterTo.TextMsg = "";
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
            else
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
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
                    userRegisterTo.DeviceType = user.DeviceType;
                    userRegisterTo.TextMsg = user.TextMsg;
                    userRegisterTo.Email = user.Email;
                    userRegisterTo.Password = user.Password;                    
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
                    else
                    {
                        throw new HttpResponseException(HttpStatusCode.Conflict);
                    }
                }
            }

            throw new HttpResponseException(HttpStatusCode.NotFound); 
        }


        [Route("~/api/Account/accountinfo")]
        [HttpGet]
        public HttpResponseMessage AccountInfo([FromUri]string userId)
        {
            if (!String.IsNullOrEmpty(userId))
            {
                var userGuid = new Guid(userId);
                var user = _repositoryUserRegister.GetUserRegister(userGuid);
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
        
        [Route("~/api/Account/member/beer/first/validate")]        
        [HttpGet]
        public HttpResponseMessage Validate([FromUri]ValidateUserLogin data)
        {
            if (String.IsNullOrEmpty(data.Email))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
                
            }
            return Request.CreateResponse(HttpStatusCode.OK, "");
            
        }

        [Route("~/api/Account/member/beer/second/validate")]
        [HttpGet]
        public HttpResponseMessage Validate([FromUri]ValidateMember data)
        {
            if (data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            int memberNumber = 1234567890;
            return Request.CreateResponse(HttpStatusCode.OK, memberNumber);

        }

        [HttpPost]
        [Route("~/api/Account/member/beer")]
        public HttpResponseMessage Register(RegisterCommand model)
        {
            if (model == null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);

            }
                        
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }
        
        [Route("~/api/Account/login")]
        public HttpResponseMessage Login(LoginUser model)
        {            
            var userFound = _repositoryUserRegister.GetUserRegisters().FirstOrDefault(u => u.Email == model.LoginId && u.Password == model.Password);
            if (userFound != null)
            {
                UserToken userToken = new UserToken();                
                userToken.MemberNumber = userFound.UserId.ToString();
                userToken.SiteID = 0;
                userToken.UserType = 0;
                userToken.FirstName = userFound.Firstname;
                userToken.LastName = userFound.Lastname;

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, userToken);                

                return response;
             }
             else 
             {
                throw new HttpResponseException(HttpStatusCode.NotFound);    
             }                

            //
            //var ctx = GlobalHost.ConnectionManager.GetHubContext<EchoHub>();
            //ctx.Clients.All.greetings("reload");
            //

            // TODO GCM Routines                
            //var registrationId = GCMSenderIDRepository.Responses.LastOrDefault().GcmSenderId;
            //PushBroker pushBroker = new PushBroker();
            //pushBroker.RegisterGcmService(new GcmPushChannelSettings("AIzaSyAHUKVH5UiYorEg_ewoMQGkDVyI3uI46W8"));
            //pushBroker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(registrationId)
            //      .WithJson(@"{""message"":""" + "GCM notice" + @"""}"));
            //pushBroker.StopAllServices();
            //
         
        }
        
    }
}
