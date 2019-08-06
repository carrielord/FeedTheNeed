using FeedTheNeed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Models.Posting
{
    public class PostingDetails
    {
        public int PostID { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public StateList State { get; set; }
        public string NameOfProvider { get; set; }
        public DonationCategory Category { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateAvailable { get; set; }
        public bool IsCompleted { get; set; }
    }
}
