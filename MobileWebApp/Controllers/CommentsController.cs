using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MobileWebApp.Models.CommentingSystem;

namespace MobileWebApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommentsController : ApiController
    {        
        public HttpResponseMessage GetComments() 
        {
            int count;
            IEnumerable<Comment> returnValue = CommentsRepository.Responses;
            count = CommentsRepository.Responses.Count();

            if (returnValue == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            var data = new
            {
                Data = returnValue,
                Count = count
            };

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
            return response;
                        
        }

        // POST api/comments
        public HttpResponseMessage Post([FromBody]Comment comment)
        {
            // TODO - DAL            
            CommentsRepository.Add(comment);
            return new HttpResponseMessage(HttpStatusCode.Created);  

            
        }

    }
}
