using FeedTheNeed.Data;

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
        
        public bool ModifyUser(ApplicationUser user)
        {
            if (user.Id == _userId.ToString())
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var userToChange = ctx.Users.Find(user.Id);
                   
                    userToChange.FirstName = user.FirstName;
                    userToChange.LastName = user.LastName;
                    //userToChange.PhoneNumber = user.PhoneNumber;
                    
                    return ctx.SaveChanges() == 1;
                }
            }
            return false;
        }

        public ApplicationUser DetailUser(ApplicationUser user)
        {
            if (user.Id == _userId.ToString())
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var completeUserInfo = ctx.Users.Find(user.Id);
                    user.Email = completeUserInfo.Email;
                    user.FirstName = completeUserInfo.FirstName;
                    user.LastName = completeUserInfo.LastName;
                    user.PhoneNumber = completeUserInfo.PhoneNumber;
                    //user.HelpfulRating = completeUserInfo.HelpfulRating;
                    return user;

                }
            }
            return null;
        }

        // public DetailUser
        public bool UpdateUser(ApplicationUser userToUpdate)
        {
            if(userToUpdate.Id == _userId.ToString())
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var userToChange = ctx.Users.Find(userToUpdate.Id);
                    //             public int UserID { get; set; }
                    //public string FirstName { get; set; }
                    //public string LastName { get; set; }
                    //public string OrganizationName { get; set; }
                    //public string PhoneNumber { get; set; }
                    //public string Email { get; set; }
                    userToChange.FirstName = userToUpdate.FirstName;
                    userToChange.LastName = userToUpdate.LastName;
                    userToChange.PhoneNumber = userToUpdate.PhoneNumber;
                    userToChange.Email = userToUpdate.Email;
                    return ctx.SaveChanges() == 1;
                }
            }
            return false;
        }
            public bool RemoveUser(Guid userid)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.Find(userid);
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
