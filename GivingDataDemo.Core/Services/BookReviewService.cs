using GivingDataDemo.Core.Interfaces;
using GivingDataDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GivingDataDemo.Core.Services
{
    public interface IBookReviewService
    {
        Task<IEnumerable<BookReview>> GetBookReviewsByBookIdAsync(string bookId);

        Task<BookReview> AddBookReviewAsync(BookReview bookReview);
    }


    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _bookReviewRepo;
        public BookReviewService(IBookReviewRepository bookReviewRepo)
        {
            _bookReviewRepo = bookReviewRepo;
        }


        public async Task<IEnumerable<BookReview>> GetBookReviewsByBookIdAsync(string bookId)
        {
            return await _bookReviewRepo.GetBookReviewsAsync(bookId);
        }

        public async Task<BookReview> AddBookReviewAsync(BookReview bookReview)
        {
            return await _bookReviewRepo.AddBookReviewAsync(bookReview);
        }
    }
}
