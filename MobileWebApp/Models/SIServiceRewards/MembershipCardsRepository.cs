using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class MembershipCardsRepository
    {
        private static List<MembershipCard> responses;

        static MembershipCardsRepository()
        {
            responses = new List<MembershipCard>();
            responses.Add(new MembershipCard
            {
                MemberCardNo = "abcdefghij"
            });
            responses.Add(new MembershipCard
            {
                MemberCardNo = "bcdefghija"
            });
            responses.Add(new MembershipCard
            {
                MemberCardNo = "cdefghijab"
            });
            responses.Add(new MembershipCard
            {
                MemberCardNo = "defghijabc"
            });
        }

        public static IEnumerable<MembershipCard> Responses
        {
            get { return responses; }
        }

        public static void Add(MembershipCard newResponse)
        {
            responses.Add(newResponse);           
        }
    }
}