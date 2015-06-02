using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardClubSaleResultRepository
    {
        private static List<RewardClubSaleResult> responses;
        static RewardClubSaleResultRepository()
        {
            responses = new List<RewardClubSaleResult>();
            responses.Add(new RewardClubSaleResult
            {
               MemberRewardPlan = 1,
               MenuItemName = "Menu Item 1",
               SiteName = "The Beer Market",
               Quantity = 1,
               Price = 10.00M,
               SaleDate = new DateTime(2015, 03, 01)
            });
            responses.Add(new RewardClubSaleResult
            {
                MemberRewardPlan = 1,
                MenuItemName = "Menu Item 2",
                SiteName = "The Beer Market",
                Quantity = 1,
                Price = 10.00M,
                SaleDate = new DateTime(2015, 03, 02)
            });
            responses.Add(new RewardClubSaleResult
            {
                MemberRewardPlan = 1,
                MenuItemName = "Menu Item 3",
                SiteName = "The Beer Market",
                Quantity = 1,
                Price = 10.00M,
                SaleDate = new DateTime(2015, 03, 03)
            });
            responses.Add(new RewardClubSaleResult
            {
                MemberRewardPlan = 1,
                MenuItemName = "Menu Item 4",
                SiteName = "The Beer Market",
                Quantity = 1,
                Price = 10.00M,
                SaleDate = new DateTime(2015, 03, 04)
            });
            responses.Add(new RewardClubSaleResult
            {
                MemberRewardPlan = 1,
                MenuItemName = "Menu Item 5",
                SiteName = "The Beer Market",
                Quantity = 1,
                Price = 10.00M,
                SaleDate = new DateTime(2015, 03, 05)
            });
        }

        public static IEnumerable<RewardClubSaleResult> Responses
        {
            get { return responses; }
        }
    }
}