using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Data
{
    public class Organization
    {
        [Key]
        public int OrganizationID { get; set; }
        public Guid OwnerID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationLink { get; set; }
        public string OrganizationBio { get; set; }
    }
}
