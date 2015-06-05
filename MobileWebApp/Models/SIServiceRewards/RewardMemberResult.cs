using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardMemberResult
    {
        public int MemberLevel { get; set; }
        public int CurrentPoints { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RenewalDate { get; set; }
    }
}