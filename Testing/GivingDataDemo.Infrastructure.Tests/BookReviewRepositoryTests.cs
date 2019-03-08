using GivingDataDemo.Core.Models;
using GivingDataDemo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GivingDataDemo.Infrastructure.Tests
{
    public class BookReviewRepositoryTests
    {
        private readonly BookReviewRepository _bookRepo;
        public BookReviewRepositoryTests()
        {
            _bookRepo = new BookReviewRepository();
        }

        [Fact]
        public async void AddBookReview_ReturnsNewBookReviewWithId()
        {
            var bookReview = new BookReview()
            {
                GoogleBookId = "fakeid",
                Rating = 3,
                ReviewerName = "Test Reviewer",
                ReviewText = "Fake review text from unit test AddBookReview_ReturnsNewBookReviewWithId."
            };

            var newBookReview = await _bookRepo.AddBookReviewAsync(bookReview);
            Assert.True(newBookReview.BookReviewId > 0);
        }

        [Fact]
        public async void AddBookReview_ReturnsNewBookReviewWithMatchingValues()
        {
            var bookReview = new BookReview()
            {
                GoogleBookId = "fakeid",
                Rating = 3,
                ReviewerName = "Test Reviewer",
                ReviewText = "Fake review text from unit test AddBookReview_ReturnsNewBookReviewWithMatchingValues"
            };

            var newBookReview = await _bookRepo.AddBookReviewAsync(bookReview);

            Assert.Equal(newBookReview.GoogleBookId, bookReview.GoogleBookId);
            Assert.Equal(newBookReview.Rating, bookReview.Rating);
            Assert.Equal(newBookReview.ReviewerName, bookReview.ReviewerName);
            Assert.Equal(newBookReview.ReviewText, bookReview.ReviewText);
        }

        [Fact]
        public async void AddBookReview_WithNewBookExistingInDb()
        {
            var bookReview = new BookReview()
            {
                GoogleBookId = "fakeid",
                Rating = 5,
                ReviewerName = "Test Reviewer",
                ReviewText = "Fake review text from unit test AddBookReview_ReturnsNewBookReviewWithId."
            };

            var newBookReview = await _bookRepo.AddBookReviewAsync(bookReview);

            var newBookReviewFromDb = await _bookRepo.GetBookReviewAsync(newBookReview.BookReviewId);

            Assert.NotNull(newBookReview);
            Assert.Equal(newBookReviewFromDb.BookReviewId, newBookReview.BookReviewId);
        }

        [Fact]
        public async void GetBookReviews_ReturnsBookReviews()
        {
            var booksReviews = await _bookRepo.GetBookReviewsAsync("fakeid");

            Assert.NotNull(booksReviews);
            Assert.True(booksReviews.Count() > 0);
        }


    }
}
