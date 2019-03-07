using Dapper;
using System;

namespace GivingDataDemo.Core.Models
{
    [Table("BookReviews")]
    public class BookReview
    {
        [Key]
        public int BookReviewId { get; set; }

        public string GoogleBookId { get; set; }

        public string ReviewText { get; set; }

        public int Rating { get; set; }

        public string ReviewerName { get; set; }
        
        [IgnoreInsert, IgnoreUpdate]
        public DateTime? CreatedDate { get; set; }
    }
}

