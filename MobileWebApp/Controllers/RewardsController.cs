using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileWebApp.Models;
using System.Web.Http.Cors;
using MobileWebApp.Models.SIServiceRewards;

namespace MobileWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Rewards")]
    public class RewardsController : ApiController
    {
        //
        //public object GetRewards(int page = 1, int pageSize = 10)
        //{
        //    IEnumerable<Reward> returnValue;
        //    int count;
        //    returnValue = RewardRepository.Responses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //    count = RewardRepository.Responses.Count();
           
        //    return new
        //    {
        //        Count = count,
        //        Data = returnValue
        //    };
        //}
        //

        [Route("~/api/Rewards/Info")]        
        public IList<RewardInfoResult> Info(RewardInfo model)
        {
            var returnValue = RewardInfoResultRepository.Responses;
            
            if (returnValue == null)
            {
                throw new Exception();
            }

            var result = returnValue.ToList();
            return result;
        }

        [Route("~/api/Rewards/Site")]
        public IList<RewardSiteResult> Site(RewardSite model)
        {
            var returnValue = RewardSiteResultRepository.Responses;

            if (returnValue == null)
            {
                throw new Exception();
            }

            var result = returnValue.ToList();
            return result;            
        }

        [Route("~/api/Rewards/Info/Member")]
        //public RewardInfoMemberResult InfoMember(RewardInfoMember model)
        public object InfoMember(RewardInfoMember model)
        {
            var returnValue1 = RewardInfoMemberResultRepository.Responses;

            if (returnValue1 == null)
            {
                throw new Exception();
            }

            string rewardPlan = model.RewardPlan.ToString();
            var returnValue2 = returnValue1.Where(x => x.MemberNumber == rewardPlan).FirstOrDefault();
            if (returnValue2 == null)
            {
                throw new Exception();
            }
                        
            string date1 = String.Format("{0:00}/{1:00}/{2:0000}", returnValue2.RenewalDate.Month, returnValue2.RenewalDate.Day, returnValue2.RenewalDate.Year);
            string date2 = String.Format("{0:00}/{1:00}/{2:0000}", returnValue2.StartDate.Month, returnValue2.StartDate.Day, returnValue2.StartDate.Year);

            //var result = returnValue2;
            var result = new
            {
                MemberNumber = returnValue2.MemberNumber,
                MemberLevel = returnValue2.MemberLevel,
                SiteRewardPlanId = returnValue2.SiteRewardPlanId,
                CurrentPoints = returnValue2.CurrentPoints,
                StartDate = date2,
                RenewalDate = date1
            };            
            return result;            
        }

        [Route("~/api/Rewards/Club/Sales")]
        [HttpGet]
        //public IList<RewardClubSaleResult> ClubSales(RewardClubSale model)
        public List<object> ClubSales(RewardClubSale model)
        {
            var returnValue = RewardClubSaleResultRepository.Responses;

            if (returnValue == null)
            {
                throw new Exception();
            }

            //var result = returnValue.ToList();
            List<object> result = new List<object>();
            foreach (var item in returnValue)
            {
                result.Add(new
                {
                    MemberRewardPlan = item.MemberRewardPlan,
                    MenuItemName = item.MenuItemName,
                    SiteName = item.SiteName,
                    SaleDate = item.SaleDate.ToString("M/d/yyyy"),
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            return result;
        }
        
        [Route("~/api/Rewards/Club/Items")]
        public IList<RewardClubItemResult> ClubItems(RewardClubItem model)
        {
            var returnValue = RewardClubItemResultRepository.Responses;

            if (returnValue == null)
            {
                throw new Exception();
            }

            var result = returnValue.ToList();
            return result;
        }

        [Route("~/api/Rewards/Club/ItemsMobile")]
        [HttpGet]
        public IList<RewardClubItemResult_Mobile> ClubItemsMobile(RewardClubItem model)
        {
            var returnValue = RewardClubItemResult_MobileRepository.Responses;

            if (returnValue == null)
            {
                throw new Exception();
            }

            var result = returnValue.ToList();
            return result;
        }
                
        [Route("~/api/Rewards/Rating/Update")]
        public HttpResponseMessage RatingUpdate(RewardUpdateRating model)
        {
            if (model == null)
            {
                throw new Exception();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
               
    }
}
