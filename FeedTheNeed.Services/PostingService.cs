using FeedTheNeed.Data;
using FeedTheNeed.Models.Posting;
using FeedTheNeed.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Services
{
    public class PostingService
    {
        private readonly Guid _userID;

        public PostingService (Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePosting (PostingCreate model)
        {
            var entity = new Posting()
            {
                UserID = _userID,
                Title = model.Title,
                Details = model.Details,
                Address = model.Address,
                City = model.City,
                State = model.State,
                NameOfProvider = model.NameOfProvider,
                Category = model.Category,
                DatePosted = DateTime.Now,
                DateAvailable = model.DateAvailable
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PostingTable.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostingListItem> ViewAllPostings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PostingTable.Where
                    (e => e.UserID == _userID).Select
                    (e => new PostingListItem
                {
                    PostID=e.PostID,
                    Title=e.Title,
                    State=e.State,
                    DateAvailable=e.DateAvailable,
                    IsCompleted=e.IsCompleted
                }
                );
                return query.ToArray();
            }
        }

        public PostingDetails GetPostingByID (int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PostingTable.Single(e => e.PostID == id && e.UserID == _userID);
                return new PostingDetails
                {
                    PostID = entity.PostID,
                    Title = entity.Title,
                    Details = entity.Details,
                    Address = entity.Address,
                    City = entity.City,
                    State = entity.State,
                    NameOfProvider = entity.NameOfProvider,
                    Category = entity.Category,
                    DatePosted = entity.DatePosted,
                    DateAvailable = entity.DateAvailable
                };

            }
        }

        public bool UpdatePosting (PostingUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PostingTable.Single(e => e.PostID == model.PostID && e.UserID == _userID);

                entity.Title = model.Title;
                entity.Details = model.Details;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.NameOfProvider = model.NameOfProvider;
                entity.Category = model.Category;
                entity.DateAvailable = model.DateAvailable;
                entity.IsCompleted = model.IsCompleted;
                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeletePosting (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PostingTable.Single(e => e.PostID == id && e.UserID == _userID);
                ctx.PostingTable.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
