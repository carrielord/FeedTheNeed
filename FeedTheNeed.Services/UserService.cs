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
        public readonly Guid _userId;
        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public UserService() { }
        public bool ModifyUser(UserUpdate user)
        {
            
                using (var ctx = new ApplicationDbContext())
                {
                    var userToChange = ctx.Users.Find(user.UserID.ToString());
                    userToChange.Id = user.UserID.ToString();
                    userToChange.FirstName = user.FirstName;
                    userToChange.LastName = user.LastName;
                    userToChange.Email = user.Email;
                    userToChange.PhoneNumber = user.PhoneNumber;

                    //userToChange.PhoneNumber = user.PhoneNumber;

                    return ctx.SaveChanges() == 1;
                
            }
            
        }

        public UserDetail DetailUser()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var completeUserInfo = ctx.Users.Find(_userId.ToString());
                // Guid tempGuid = Guid.Parse(completeUserInfo.Id);
                return new UserDetail
                {
                    UserID = _userId,
                    FirstName = completeUserInfo.FirstName,
                    LastName = completeUserInfo.LastName,
                    Email = completeUserInfo.Email,
                    PhoneNumber = completeUserInfo.PhoneNumber

                };
            }
            //user.HelpfulRating = completeUserInfo.HelpfulRating;

        }

        // public DetailUser

        public UserDetail GetUserByID(Guid id)
        {
            //string stringID = id.ToString();
            using (var ctx = new ApplicationDbContext())
            {
            Guid tempguid = id;

                var entity = ctx.Users.Single(u => u.Id == tempguid.ToString());
                return
                    new UserDetail
                    {
                        UserID = tempguid,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber
                    };

            }
        }

        public bool RemoveUser(UserDetail user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userToDelete = ctx.Users.Find(user.UserID.ToString());
                var postingsToRemove = ctx.PostingTable.Where(u => u.UserID == user.UserID);
                foreach (var posting in postingsToRemove)
                {
                    ctx.PostingTable.Remove(posting);
                }
                ctx.Users.Remove(userToDelete);
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
