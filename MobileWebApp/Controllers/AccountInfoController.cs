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
    public class AccountInfoController : ApiController
    {
        private UserRegisterRepository _repositoryUserRegister;

        public AccountInfoController()
        {
            _repositoryUserRegister = new UserRegisterRepository();
        }

        public object Post(AccountInfo UserId)
        {

            if (UserId.UserId != Guid.Empty)           
            {
                var user = _repositoryUserRegister.GetUserRegister(UserId.UserId);
                if (user != null)
                {
                    return new
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Birthday = user.Birthday,
                        Phone = user.Phone,
                        PhoneType = user.PhoneType,
                        TextMsg = user.TextMsg,
                        EmailAddress = user.EmailAddress,
                        UserPassword = user.UserPassword
                    };                   
                }
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);           
        }        

    }
}
