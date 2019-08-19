using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Data
{
    public enum StateList
    {
        [Display(Name = "Alabama")]
        Alabama,
        [Display(Name = "Alaska")]
        Alaska,
        [Display(Name = "Arizona")]
        Arizona,
        [Display(Name = "Arkansas")]
        Arkansas,
        [Display(Name = "California")]
        California,
        [Display(Name = "Colorado")]
        Colorado,
        [Display(Name = "Connecticut")]
        Connecticut,
        [Display(Name = "Delaware")]
        Delaware,
        [Display(Name = "Florida")]
        Florida,
        [Display(Name = "Georgia")]
        Georgia,
        [Display(Name = "Hawaii")]
        Hawaii,
        [Display(Name = "Idaho")]
        Idaho,
        [Display(Name = "Illinois")]
        Illinois,
        [Display(Name = "Indiana")]
        Indiana,
        [Display(Name = "Iowa")]
        Iowa,
        [Display(Name = "Kansas")]
        Kansas,
        [Display(Name = "Kentucky")]
        Kentucky,
        [Display(Name = "Louisiana")]
        Louisiana,
        [Display(Name = "Maine")]
        Maine,
        [Display(Name = "Maryland")]
        Maryland,
        [Display(Name = "Massachusetts")]
        Massachusetts,
        [Display(Name = "Michigan")]
        Michigan,
        [Display(Name = "Minnesota")]
        Minnesota,
        [Display(Name = "Mississippi")]
        Mississippi,
        [Display(Name = "Missouri")]
        Missouri,
        [Display(Name = "Montana")]
        Montana,
        [Display(Name = "Nebraska")]
        Nebraska,
        [Display(Name = "Nevada")]
        Nevada,
        [Display(Name = "NewHampshire")]
        NewHampshire,
        [Display(Name = "NewJersey")]
        NewJersey,
        [Display(Name = "NewMexico")]
        NewMexico,
        [Display(Name = "NewYork")]
        NewYork,
        [Display(Name = "NorthCarolina")]
        NorthCarolina,
        [Display(Name = "NorthDakota")]
        NorthDakota,
        [Display(Name = "Ohio")]
        Ohio,
        [Display(Name = "Oklahoma")]
        Oklahoma,
        [Display(Name = "Oregon")]
        Oregon,
        [Display(Name = "Pennsylvania")]
        Pennsylvania,
        [Display(Name = "RhodeIsland")]
        RhodeIsland,
        [Display(Name = "SouthCarolina")]
        SouthCarolina,
        [Display(Name = "SouthDakota")]
        SouthDakota,
        [Display(Name = "Tennessee")]
        Tennessee,
        [Display(Name = "Texas")]
        Texas,
        [Display(Name = "Utah")]
        Utah,
        [Display(Name = "Vermont")]
        Vermont,
        [Display(Name = "Virginia")]
        Virginia,
        [Display(Name = "Washington")]
        Washington,
        [Display(Name = "WestVirginia")]
        WestVirginia,
        [Display(Name = "Wisconsin")]
        Wisconsin,
        [Display(Name = "Wyoming")]
        Wyoming
    }
    public enum DonationCategory
    {
        [Display(Name = "Food")]
        Food,
        [Display(Name = "Items")]
        Items,
        [Display(Name = "Services")]
        Services
    }
    public class Posting
    {
        [Key]
        public int PostID { get; set; }
        public Guid UserID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required]
        public StateList State { get; set; }
        //[ForeignKey(nameof(User))]
        //public string PhoneNumber { get; set; }
        ////public virtual User User { get; set; }
        //[Required]
        ////[ForeignKey(nameof(User))]
        //public string Email { get; set; }
        //public virtual User User { get; set; }

        public string NameOfProvider { get; set; }
        [Required]
        public DonationCategory Category { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateAvailable { get; set; }
        public bool IsCompleted { get; set; }
    }
}
