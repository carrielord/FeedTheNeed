using FeedTheNeed.Data;
using FeedTheNeed.Models.User;
using FeedTheNeed.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Services
{
    public class UserService
    {
        private readonly Guid _userId;
        public UserService(Guid userid)
        {
            _userId = userid;
        }

        public bool ModifyUser(UserUpdate user)
        {
            if (user.UserID == _userId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var userToChange = ctx.Users.Find(user.UserID.ToString());

                    userToChange.FirstName = user.FirstName;
                    userToChange.LastName = user.LastName;
                    userToChange.Id = user.UserID.ToString();
                    userToChange.Email = user.Email;
                    userToChange.PhoneNumber = user.PhoneNumber;

                    //userToChange.PhoneNumber = user.PhoneNumber;

                    return ctx.SaveChanges() == 1;
                }
            }
            return false;
        }

        public UserDetail DetailUser(Guid id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var completeUserInfo = ctx.Users.Find(id.ToString());
                Guid tempGuid = Guid.Parse(completeUserInfo.Id);
                return new UserDetail {
                    UserID = tempGuid,
                FirstName = completeUserInfo.FirstName,
                LastName = completeUserInfo.LastName,
                Email = completeUserInfo.Email,
                PhoneNumber = completeUserInfo.PhoneNumber

            };
            }
            //user.HelpfulRating = completeUserInfo.HelpfulRating;

        }

    // public DetailUser

            public bool RemoveUser(Guid userid)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.Find(userid.ToString());
                var postingsToRemove = ctx.PostingTable.Where(u => u.UserID == userid);
                foreach(var posting in postingsToRemove)
                {
                    ctx.PostingTable.Remove(posting);
                }
                ctx.Users.Remove(user);
                ctx.SaveChanges();
                var didItSaveChanges = ctx.SaveChanges();
                return didItSaveChanges == ctx.SaveChanges();
                
            }

        }


    }
}
