using FeedTheNeed.Models;
using FeedTheNeed.Models.Organization;
using FeedTheNeed.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FeedTheNeed.WebAPI.Controllers
{
    [Authorize]
    public class OrganizationController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            OrganizationService organizationService = CreateOrganizationService();
            var OrganizationTable = organizationService.GetOrganization();
            return Ok(OrganizationTable);
        }
        public IHttpActionResult Get(int id)
        {
            OrganizationService organizationService = CreateOrganizationService();
            var OrganizationTable = organizationService.GetOrganizationById(id);
            return Ok(OrganizationTable);
        }
        public IHttpActionResult Post(OrganizationCreate organization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrganizationService();

            if (!service.CreateOrganization(organization))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(OrganizationEdit organization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOrganizationService();

            if (!service.UpdateOrganization(organization))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateOrganizationService();

            if (!service.DeleteOrganization(id))
                return InternalServerError();

            return Ok();
        }

        private OrganizationService CreateOrganizationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var organizationService = new OrganizationService(userId);
            return organizationService;
        }
    }
}