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
        public async void GetBooks_PopulatesExpectedFields_ReturnsEmpty()
        {

        }

    }
}
