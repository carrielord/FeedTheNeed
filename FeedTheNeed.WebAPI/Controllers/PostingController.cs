using FeedTheNeed.Models.Posting;
using FeedTheNeed.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeedTheNeed.WebAPI.Controllers
{
    public class PostingController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            PostingService postingService = new PostingService();
            var postings = postingService.ViewAllPostings();
            return Ok(postings);
        }

        [Authorize]
        [Route("Posting/Details/{id}")]
        public IHttpActionResult GetWhenLoggedIn(int id)
        {
            PostingService postingService = CreatePostingService();
            var posting = postingService.GetPostingByID(id);
            return Ok(posting);
        }
        [Route("Posting/DetailsNLI/{id}")]
        public IHttpActionResult GetNotLoggedIn(int id)
        {
            PostingService postingService = new PostingService();
            var posting = postingService.GetPostingByIDNoGuid(id);
            return Ok(posting);
        }


        [Authorize]
        public IHttpActionResult Post(PostingCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            PostingService postingService = CreatePostingService();
            if (!postingService.CreatePosting(model)) return InternalServerError();
            return Ok();
        }

        [Authorize]
        public IHttpActionResult Put(PostingUpdate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            PostingService postingService = CreatePostingService();
            if (!postingService.UpdatePosting(model)) return InternalServerError();
            return Ok();
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            PostingService postingService = CreatePostingService();
            if (!postingService.DeletePosting(id)) return InternalServerError();
            return Ok();
        }

        private PostingService CreatePostingService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var postingService = new PostingService(userID);
            return postingService;
        }
        
    }
}
