using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class BeerTypeRepository
    {
        private static List<BeerType> responses;
        static BeerTypeRepository()
        {
            responses = new List<BeerType>();

            //Random random = new Random();            
            //for (int i = 1; i < 100; i++)
            //{
            //    var number = random.Next(0, 100);
            //    if (responses.Find(x => x.Id == number) == null)
            //    {
            //        responses.Add(new BeerType
            //        {
            //            Id = number,
            //            ImageUrl = "http://placehold.it/70x50",
            //            Name = "Beer Type " + number,
            //            Description = "Put a short description here.",
            //            DateAdded = DateTime.Now.ToString("M/d/yyyy"),
            //            Letter = ((char)('a' + (new Random().Next(0, 26)))).ToString()
            //            //Letter = "a"
            //        });                 
            //    }
            //}

            Random random1 = new Random();
            Random random2 = new Random();
            for (int i = 1; i < 100; i++)
            {
                var number = random1.Next(0, 100);
                if (responses.Find(x => x.Id == number) == null)
                {
                    responses.Add(new BeerType
                    {
                        Id = number,
                        ImageUrl = "http://placehold.it/70x50",
                        Name = "Beer Type " + number,
                        Description = "Put a short description here.",
                        DateAdded = DateTime.Now.ToString("M/d/yyyy"),
                        Letter = ((char)('A' + (random2.Next(0, 26)))).ToString()
                        //Letter = "a"
                    });
                }
            }

        }

        public static IEnumerable<BeerType> Responses
        {
            get { return responses; }
        }
        
    }
}