using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardMemberResultRepository
    {
        private static List<RewardMemberResult> responses;
        static RewardMemberResultRepository()
        {
            responses = new List<RewardMemberResult>();
            responses.Add(new RewardMemberResult
            {                
                MemberLevel = 1,                
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardMemberResult
            {                
                MemberLevel = 2,               
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardMemberResult
            {                
                MemberLevel = 3,                
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardMemberResult
            {                
                MemberLevel = 4,                
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
            responses.Add(new RewardMemberResult
            {                
                MemberLevel = 5,                
                CurrentPoints = 100,
                StartDate = new DateTime(2014, 07, 31),
                RenewalDate = new DateTime(2015, 08, 01),
            });
        }

        public static IEnumerable<RewardMemberResult> Responses
        {
            get { return responses; }
        }
    }
}