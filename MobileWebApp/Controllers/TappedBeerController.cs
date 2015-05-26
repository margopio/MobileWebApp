using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.SignalR;
using MobileWebApp.Models;

namespace MobileWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/tappedbeer")]
    public class TappedBeerController : ApiController
    {
        //public HttpResponseMessage GetBeerType(string userId, int page = 1, int pageSize = 10)
        public HttpResponseMessage GetBeerType(string userId)
        {
            IEnumerable<BeerType> returnValue;
            int count;
            //returnValue = BeerTypeRepository.Responses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            returnValue = BeerTypeRepository.Responses.ToList();
            //count = RewardPlanRepository.Responses.Count();
            count = returnValue.Count();

            if (returnValue != null)
            {                
                var data = new
                {
                    Count = count,
                    Data = returnValue
                };

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
                return response;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound); 
        }
    }
}
