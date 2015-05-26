using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardInfoMemberResultRepository
    {
        private static List<RewardInfoMemberResult> responses;
        static RewardInfoMemberResultRepository()
        {
            responses = new List<RewardInfoMemberResult>();
            responses.Add(new RewardInfoMemberResult
            {
                MemberNumber = "1001",
                MemberLevel = 1,
                SiteRewardPlanId = 1,
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardInfoMemberResult
            {
                MemberNumber = "1002",
                MemberLevel = 2,
                SiteRewardPlanId = 1,
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardInfoMemberResult
            {
                MemberNumber = "1003",
                MemberLevel = 3,
                SiteRewardPlanId = 1,
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardInfoMemberResult
            {
                MemberNumber = "1004",
                MemberLevel = 4,
                SiteRewardPlanId = 1,
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardInfoMemberResult
            {
                MemberNumber = "1005",
                MemberLevel = 5,
                SiteRewardPlanId = 1,
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
        }

        public static IEnumerable<RewardInfoMemberResult> Responses
        {
            get { return responses; }
        }
    }
}