using System;
using System.Collections.Generic;

namespace GivingDataDemo.Core.Models
{
    public class Book
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? PublishedYear { get; set; }

        public string Publisher { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string ISBN10 { get; set; }

        public string ISBN13 { get; set; }

        public int? PageCount { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public string GoogleProductUrl { get; set; }

        public string ThumbnailImageUrl { get; set; }
    }
}