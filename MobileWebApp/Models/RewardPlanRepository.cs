using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class RewardPlanRepository
    {
        private static List<GetRewardPlanResult> responses;
        static RewardPlanRepository()
        {
            responses = new List<GetRewardPlanResult>();
            responses.Add(new GetRewardPlanResult
            {
                Id = 1,
                Name = "Reward 1",
                Type = 0,
                PointsRequired = 50,
                Description = "Reward 1 Free Appetizer",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 2,
                Name = "Reward 2",
                Type = 0,
                PointsRequired = 80,
                Description = "Reward 2 Free Sandwich or Small Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 3,
                Name = "Reward 3",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 3 $10 off Any Food Purchase",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 4,
                Name = "Reward 4",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 4 Free 22 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 5,
                Name = "Reward 5",
                Type = 0,
                PointsRequired = 125,
                Description = "Reward 5 Free 3-topping Large Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 6,
                Name = "Reward 6",
                Type = 0,
                PointsRequired = 150,
                Description = "Reward 6 Free Entree & 16 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 7,
                Name = "Reward 7",
                Type = 0,
                PointsRequired = 50,
                Description = "Reward 7 Free Appetizer",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 8,
                Name = "Reward 8",
                Type = 0,
                PointsRequired = 80,
                Description = "Reward 8 Free Sandwich or Small Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 9,
                Name = "Reward 9",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 9 $10 off Any Food Purchase",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 10,
                Name = "Reward 10",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 10 Free 22 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 11,
                Name = "Reward 11",
                Type = 0,
                PointsRequired = 125,
                Description = "Reward 11 Free 3-topping Large Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 12,
                Name = "Reward 12",
                Type = 0,
                PointsRequired = 150,
                Description = "Reward 12 Free Entree & 16 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 1,
                Name = "Reward 11",
                Type = 0,
                PointsRequired = 50,
                Description = "Reward 1 Free Appetizer",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 2,
                Name = "Reward 22",
                Type = 0,
                PointsRequired = 80,
                Description = "Reward 2 Free Sandwich or Small Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 3,
                Name = "Reward 33",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 3 $10 off Any Food Purchase",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 4,
                Name = "Reward 44",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 4 Free 22 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 5,
                Name = "Reward 55",
                Type = 0,
                PointsRequired = 125,
                Description = "Reward 5 Free 3-topping Large Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 6,
                Name = "Reward 66",
                Type = 0,
                PointsRequired = 150,
                Description = "Reward 6 Free Entree & 16 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 7,
                Name = "Reward 77",
                Type = 0,
                PointsRequired = 50,
                Description = "Reward 7 Free Appetizer",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 8,
                Name = "Reward 88",
                Type = 0,
                PointsRequired = 80,
                Description = "Reward 8 Free Sandwich or Small Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 9,
                Name = "Reward 99",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 9 $10 off Any Food Purchase",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 10,
                Name = "Reward 1010",
                Type = 0,
                PointsRequired = 100,
                Description = "Reward 10 Free 22 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 11,
                Name = "Reward 1111",
                Type = 0,
                PointsRequired = 125,
                Description = "Reward 11 Free 3-topping Large Pizza",
                PointsNeeded = 0
            });
            responses.Add(new GetRewardPlanResult
            {
                Id = 12,
                Name = "Reward 1212",
                Type = 0,
                PointsRequired = 150,
                Description = "Reward 12 Free Entree & 16 oz. Lager or Micro Brew",
                PointsNeeded = 0
            });
        }

        public static IEnumerable<GetRewardPlanResult> Responses
        {
            get { return responses; }
        }
    }
}