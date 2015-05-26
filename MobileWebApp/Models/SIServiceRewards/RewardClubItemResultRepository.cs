using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardClubItemResultRepository
    {
        private static List<RewardClubItemResult> responses;
        static RewardClubItemResultRepository()
        {
            responses = new List<RewardClubItemResult>();
            responses.Add(new RewardClubItemResult
            {
                MenuItemName = "Menu Item Name 1"
            });
            responses.Add(new RewardClubItemResult
            {
                MenuItemName = "Menu Item Name 2"
            });
            responses.Add(new RewardClubItemResult
            {
                MenuItemName = "Menu Item Name 3"
            });
            responses.Add(new RewardClubItemResult
            {
                MenuItemName = "Menu Item Name 4"
            });
            responses.Add(new RewardClubItemResult
            {
                MenuItemName = "Menu Item Name 5"
            });
        }

        public static IEnumerable<RewardClubItemResult> Responses
        {
            get { return responses; }
        }
    }
}