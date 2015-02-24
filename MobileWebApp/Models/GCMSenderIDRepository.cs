using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class GCMSenderIDRepository
    {
        private static List<GCMSenderID> responses;

        static GCMSenderIDRepository()
        {
            responses = new List<GCMSenderID>();
            //responses.Add(new GCMSenderID
            //{
            //    GcmSenderId = "GCMSenderID A"
            //});
            //responses.Add(new GCMSenderID
            //{
            //    GcmSenderId = "GCMSenderID B"
            //});
        }

        public static IEnumerable<GCMSenderID> Responses
        {
            get { return responses; }
        }

        public static void Add(GCMSenderID newResponse)
        {
            responses.Add(newResponse);
        }

    }
}