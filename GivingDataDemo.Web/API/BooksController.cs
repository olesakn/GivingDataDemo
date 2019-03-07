using GivingDataDemo.Core.Models;
using GivingDataDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GivingDataDemo.Web.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService; 

        /// <summary>
        /// Constructor
        /// </summary>
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public async Task<IEnumerable<Book>> Get(string keywords, int maxRecords)
        {
            return await _bookService.GetBooksByKeywordsAsync(keywords, maxRecords);
        }


        [HttpGet]
        public async Task<Book> Get(string id)
        {
            return await _bookService.GetByIdAsync(id);
        }
        
    }
}
