using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.CommentingSystem
{
    public class CommentsRepository
    {
        private static List<Comment> responses;

        static CommentsRepository()
        {
            responses = new List<Comment>();
        }

        public static IEnumerable<Comment> Responses
        {
            get { return responses; }
        }

        public static void Add(Comment newResponse)
        {
            responses.Add(newResponse);           
        }
    }
}