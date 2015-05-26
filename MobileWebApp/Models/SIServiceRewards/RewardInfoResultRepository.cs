using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardInfoResultRepository
    {
        private static List<RewardInfoResult> responses;
        static RewardInfoResultRepository()
        {
            responses = new List<RewardInfoResult>();
            responses.Add(new RewardInfoResult
            {
                Name = "Reward Info 1",
                Type = 1,
                PointsRequired = 100,
                Description = "A short description for Reward Info 1"
            });
            responses.Add(new RewardInfoResult
            {
                Name = "Reward Info 2",
                Type = 2,
                PointsRequired = 200,
                Description = "A short description for Reward Info 2"
            });
            responses.Add(new RewardInfoResult
            {
                Name = "Reward Info 3",
                Type = 3,
                PointsRequired = 300,
                Description = "A short description for Reward Info 3"
            });
            responses.Add(new RewardInfoResult
            {
                Name = "Reward Info 4",
                Type = 4,
                PointsRequired = 400,
                Description = "A short description for Reward Info 4"
            });
            responses.Add(new RewardInfoResult
            {
                Name = "Reward Info 5",
                Type = 5,
                PointsRequired = 500,
                Description = "A short description for Reward Info 5"
            });
        }

        public static IEnumerable<RewardInfoResult> Responses
        {
            get { return responses; }
        }
    }
}