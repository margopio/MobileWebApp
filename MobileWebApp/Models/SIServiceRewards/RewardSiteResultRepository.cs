using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardSiteResultRepository
    {
        private static List<RewardSiteResult> responses;
        static RewardSiteResultRepository()
        {
            responses = new List<RewardSiteResult>();
            responses.Add(new RewardSiteResult
            {
                Name = "Reward Site 1",
                Type = 1,
                PointsRequired = 100,
                Description = "A short description for Reward Site 1"
            });
            responses.Add(new RewardSiteResult
            {
                Name = "Reward Site 2",
                Type = 2,
                PointsRequired = 200,
                Description = "A short description for Reward Site 2"
            });
            responses.Add(new RewardSiteResult
            {
                Name = "Reward Site 3",
                Type = 3,
                PointsRequired = 300,
                Description = "A short description for Reward Site 3"
            });
            responses.Add(new RewardSiteResult
            {
                Name = "Reward Site 4",
                Type = 4,
                PointsRequired = 400,
                Description = "A short description for Reward Site 4"
            });
            responses.Add(new RewardSiteResult
            {
                Name = "Reward Site 5",
                Type = 5,
                PointsRequired = 500,
                Description = "A short description for Reward Site 5"
            });
        }

        public static IEnumerable<RewardSiteResult> Responses
        {
            get { return responses; }
        }
    }
}