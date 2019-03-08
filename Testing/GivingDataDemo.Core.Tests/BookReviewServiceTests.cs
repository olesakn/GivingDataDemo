using GivingDataDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using GivingDataDemo.Core.Interfaces;
using GivingDataDemo.Core.Models;

namespace GivingDataDemo.Core.Tests
{
    public class BookReviewServiceTests
    {
        private static readonly Random random = new Random();

        private readonly IBookReviewService _bookReviewService;
        private Mock<IBookReviewRepository> _bookRepoMock;

        public BookReviewServiceTests()
        {
            _bookRepoMock = new Mock<IBookReviewRepository>();

            _bookReviewService = new BookReviewService(_bookRepoMock.Object);
        }
        
        [Fact]
        public async void GetBookReviews_ReturnsBookReviews()
        {
            var mockBooks = new List<BookReview>()
            {
                GetFakeBookReview(),
                GetFakeBookReview(),
                GetFakeBookReview(),
            };

            _bookRepoMock.Setup(x =>
                x.GetBookReviewsAsync(It.IsAny<string>()))
                    .ReturnsAsync(mockBooks);

            var books = await _bookReviewService.GetBookReviewsByBookIdAsync("fakeid");
            
            Assert.Equal(mockBooks, books);
        }
        

        /// <summary>
        /// Test Helper => Generate a fake book review object
        /// </summary>
        /// <returns></returns>
        private BookReview GetFakeBookReview()
        {
            return new BookReview()
            {
                BookReviewId = random.Next(1, 30),
                GoogleBookId = "fakeid",
                Rating = random.Next(1, 5),
                ReviewerName = "John Doe",
                ReviewText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
            };
        }
    }
}
