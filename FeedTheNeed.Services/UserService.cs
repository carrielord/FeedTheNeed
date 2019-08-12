using FeedTheNeed.Data;
using FeedTheNeed.Models.User;
using FeedTheNeed.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Services
{
    public class UserService
    {
        

        public bool ModifyUser(UserUpdate user)
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

        public UserDetail DetailUser(Guid id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var completeUserInfo = ctx.Users.Find(id.ToString());
                Guid tempGuid = Guid.Parse(completeUserInfo.Id);
                return new UserDetail
                {
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
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.Find(userid.ToString());
                var postingsToRemove = ctx.PostingTable.Where(u => u.UserID == userid);
                foreach (var posting in postingsToRemove)
                {
                    ctx.PostingTable.Remove(posting);
                }
                ctx.Users.Remove(user);
                ctx.SaveChanges();
                var didItSaveChanges = ctx.SaveChanges();
                return didItSaveChanges == ctx.SaveChanges();

            }

        }
        public bool AddUser(ApplicationUser user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try{
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
                
                
                return true;

            }
        }


    }
}
