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
    public class RewardsController : ApiController
    {
        public object GetRewards(int page = 1, int pageSize = 10)
        {
            IEnumerable<Reward> returnValue;
            int count;
            returnValue = RewardRepository.Responses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            count = RewardRepository.Responses.Count();
           
            return new
            {
                Count = count,
                Data = returnValue
            };
        }

    }
}
