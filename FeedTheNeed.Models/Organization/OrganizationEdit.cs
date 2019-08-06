using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Models.Organization
{
    public class OrganizationEdit
    {
        [Display(Name = "Organization ID")]
        public int OrganizationID { get; set; }
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }
        [Display(Name = "Organization Link")]
        public string OrganizationLink { get; set; }
        [Display(Name = "Organization Bio")]
        public string OrganizationBio { get; set; }
    }
}
