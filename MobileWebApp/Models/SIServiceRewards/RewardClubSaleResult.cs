using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardClubSaleResult
    {
        public int MemberRewardPlan { get; set; }
        public string MenuItemName { get; set; }
        public string SiteName { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}