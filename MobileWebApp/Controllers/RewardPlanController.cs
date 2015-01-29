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
    [RoutePrefix("api/rewardplan")]
    public class RewardPlanController : ApiController
    {
        public HttpResponseMessage GetRewardPlanResult(string userId, int page = 1, int pageSize = 10)
        {
            // TODO - Get from database for production
            int userInitialCouponPoints = 75;
            //

            IEnumerable<GetRewardPlanResult> returnValue;
            int count;
            returnValue = RewardPlanRepository.Responses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            count = RewardPlanRepository.Responses.Count();

            if (returnValue != null)
            {
                foreach (var item in returnValue)
                {
                    if (item.PointsRequired > userInitialCouponPoints)
                    {
                        item.PointsNeeded = item.PointsRequired - userInitialCouponPoints;
                    }
                    else
                    {
                        item.PointsNeeded = 0;
                    }

                }

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
