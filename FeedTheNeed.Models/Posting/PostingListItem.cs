using FeedTheNeed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheNeed.Models.Posting
{
    public class PostingListItem
    {
        public int PostID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public StateList State { get; set; }
        public DateTime DateAvailable { get; set; }
        public bool IsCompleted { get; set; }
    }
}
