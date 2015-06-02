using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RewardClubItemResult_MobileRepository
    {
        private static List<RewardClubItemResult_Mobile> responses;
        static RewardClubItemResult_MobileRepository()
        {
            responses = new List<RewardClubItemResult_Mobile>();

            
            Random random1 = new Random();
            Random random2 = new Random();
            for (int i = 1; i < 300; i++)
            {
                var number = random1.Next(0, 300);
                var numberToString = "Beer Type " + number;
                if (responses.Find(x => x.MenuItemName == numberToString) == null)
                {
                    responses.Add(new RewardClubItemResult_Mobile
                    {
                        MenuItemName = "Beer Type " + number,
                        Letter = ((char)('A' + (random2.Next(0, 26)))).ToString()                       
                    });
                }
            }

        }

        public static IEnumerable<RewardClubItemResult_Mobile> Responses
        {
            get { return responses; }
        }
        

    }
}