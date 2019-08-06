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
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        NewHampshire,
        NewJersey,
        NewMexico,
        NewYork,
        NorthCarolina,
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        RhodeIsland,
        SouthCarolina,
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        WestVirginia,
        Wisconsin,
        Wyoming
    }
    public enum DonationCategory
    {
        Food,
        Items,
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
