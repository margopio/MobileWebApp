using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardInfoResult
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int PointsRequired { get; set; }
        public string Description { get; set; }
    }
}