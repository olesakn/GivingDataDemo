using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GivingDataDemo.Core.Models;

namespace GivingDataDemo.Core.Interfaces
{
    public interface IBookReviewRepository
    {
        Task<IEnumerable<BookReview>> GetBookReviewsAsync(string googleBookId);

        Task<BookReview> GetBookReviewAsync(int bookReviewId);

        Task<BookReview> AddBookReviewAsync(BookReview bookReview);
    }
}
