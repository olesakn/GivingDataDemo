using GivingDataDemo.Core.Interfaces;
using GivingDataDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace GivingDataDemo.Infrastructure.Repositories
{
    public class BookReviewRepository : BaseRepository, IBookReviewRepository
    {
        public async Task<BookReview> GetBookReviewAsync(int bookReviewId)
        {
            using (var conn = GivingDataDemoDbConnection)
            {
                return await conn.GetAsync<BookReview>(bookReviewId);
            }
        }

        public async Task<IEnumerable<BookReview>> GetBookReviewsAsync(string googleBookId)
        {
            using (var conn = GivingDataDemoDbConnection)
            {
                return await conn.GetListAsync<BookReview>(new { GoogleBookId = googleBookId });
            }
        }

        public async Task<BookReview> AddBookReviewAsync(BookReview bookReview)
        {
            using (var conn = GivingDataDemoDbConnection)
            {
                var id = await conn.InsertAsync<BookReview>(bookReview);
                return await conn.GetAsync<BookReview>(id);
            }
        }

    }
}
