using FeedTheNeed.Data;
using FeedTheNeed.Models.Organization;
using FeedTheNeed.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Services
{
    public class OrganizationService
    {
        private readonly Guid _userId;

        public OrganizationService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateOrganization(OrganizationCreate model)
        {
            var entity =
                new Organization()
                {
                    OwnerID = _userId,
                    OrganizationName = model.OrganizationName,
                    OrganizationLink = model.OrganizationLink,
                    OrganizationBio = model.OrganizationBio
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.OrganizationTable.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<OrganizationListItem> GetOrganization()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .OrganizationTable
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new OrganizationListItem
                                {
                                    OrganizationID = e.OrganizationID,
                                    OrganizationName = e.OrganizationName,
                                    OrganizationLink = e.OrganizationLink,
                                    OrganizationBio = e.OrganizationBio
                                }
                       );
                return query.ToArray();
            }
        }
        public OrganizationDetail GetOrganizationById(int organizationsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OrganizationTable
                        .Single(e => e.OrganizationID == organizationsId && e.OwnerID == _userId);
                return
                    new OrganizationDetail
                    {
                        OrganizationID = entity.OrganizationID,
                        OrganizationName = entity.OrganizationName,
                        OrganizationLink = entity.OrganizationLink,
                        OrganizationBio = entity.OrganizationBio
                    };
            }
        }
        public bool UpdateOrganization(OrganizationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OrganizationTable
                        .Single(e => e.OrganizationID == model.OrganizationID && e.OwnerID == _userId);

                entity.OrganizationName = model.OrganizationName;
                entity.OrganizationLink = model.OrganizationLink;
                entity.OrganizationBio = model.OrganizationBio;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteOrganization(int organizationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OrganizationTable
                        .Single(e => e.OrganizationID == organizationId && e.OwnerID == _userId);

                ctx.OrganizationTable.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
