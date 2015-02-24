using MobileWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MobileWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GCMSenderIDController : ApiController
    {    
        public HttpResponseMessage Post(GCMSenderID RegistrationId)
        {
            if (!String.IsNullOrEmpty(RegistrationId.GcmSenderId))
            {
                GCMSenderIDRepository.Add(RegistrationId);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }

            throw new HttpResponseException(HttpStatusCode.BadRequest); 
        }
    }
}
