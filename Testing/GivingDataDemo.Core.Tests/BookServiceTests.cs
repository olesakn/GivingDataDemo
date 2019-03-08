using GivingDataDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GivingDataDemo.Core.Tests
{
    public class BookServiceTests
    {
        private readonly IBookService _bookService;

        public BookServiceTests()
        {
            _bookService = new BookService();
        }

        [Theory]
        [InlineData("national parks")]
        [InlineData("programming")]
        public async void GetBooks_WithKeywords_ReturnsBooks(string keywords)
        {
            var result = await _bookService.GetBooksByKeywordsAsync(keywords, 10);
            Assert.NotNull(result);
            Assert.True(result.Any());
        }

        [Fact]
        public async void GetBooks_WithEmptyKeyword_ReturnsEmpty()
        {
            var result = await _bookService.GetBooksByKeywordsAsync(string.Empty, 10);
            Assert.NotNull(result);
            Assert.False(result.Any());
        }

        [Fact]
        public async void GetBooks_WithNullKeyword_ReturnsEmpty()
        {
            var result = await _bookService.GetBooksByKeywordsAsync(null, 10);
            Assert.NotNull(result);
            Assert.False(result.Any());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(30)]
        [InlineData(39)]
        [InlineData(40)]
        [InlineData(41)]
        [InlineData(9999)]
        [InlineData(-9999)]
        public async void GetBooks_WithMaxRecords_BookCountDoesNotExceedMaxRecords(int maxRecords)
        {
            var result = await _bookService.GetBooksByKeywordsAsync("national parks", maxRecords);
            Assert.NotNull(result);
            Assert.True(result.Count() <= Math.Max(0, maxRecords));
        }

        [Fact]
        public async void GetBooks_PopulatesExpectedFields_ReturnsBooksWithExpectedFields()
        {
            var result = await _bookService.GetBooksByKeywordsAsync("national parks", 10);
            Assert.True(result?.Any());
            Assert.NotNull(result.First().Id);
            Assert.NotNull(result.First().Title);
            Assert.NotNull(result.First().Description);
            Assert.NotNull(result.First().PublishedYear);
        }


        [Fact]
        public async void GetBook_PopulatesExpectedFields_ReturnsBookWithExpectedFields()
        {
            var result = await _bookService.GetByIdAsync("EbmxDQAAQBAJ");

            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.Title);
            Assert.NotNull(result.Description);
            Assert.NotNull(result.PublishedYear);
            Assert.NotNull(result.Publisher);
            Assert.NotNull(result.Authors);
            Assert.NotNull(result.PageCount);
            Assert.NotNull(result.Categories);
            Assert.NotNull(result.GoogleProductUrl);
            Assert.NotNull(result.ThumbnailImageUrl);
        }
    }
}
