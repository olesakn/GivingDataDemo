using GivingDataDemo.Core.Models;
using GivingDataDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace GivingDataDemo.Web.Controllers
{
    public class BookReviewsController : ApiController
    {
        private readonly IBookReviewService _bookReviewService;

        /// <summary>
        /// Constructor
        /// </summary>
        public BookReviewsController(IBookReviewService bookReviewService)
        {
            _bookReviewService = bookReviewService;
        }

        [HttpGet]
        public Task<IEnumerable<BookReview>> Get(string id)
        {
            return _bookReviewService.GetBookReviewsByBookIdAsync(id);
        }

        [HttpPut]
        public async Task<BookReview> Put([FromBody]BookReview bookReview)
        {
            return await _bookReviewService.AddBookReviewAsync(bookReview);
        }
    }
}
