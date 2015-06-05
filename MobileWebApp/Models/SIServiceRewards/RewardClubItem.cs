using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardClubItem
    {
        public int SiteRewardPlanId { get; set; }
        public string MemberNumber { get; set; }
        public bool NotPurchased { get; set; }
    }
}