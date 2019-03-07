using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GivingDataDemo.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GivingDataDemo.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksByKeywordsAsync(string keywords, int maxNumberOfRecords);
        Task<Book> GetByIdAsync(string id);
    }


    public class BookService : IBookService
    {
        private string GoogleApiKey => ConfigurationManager.AppSettings["GoogleApiKey"] as string;
        private string GoogleBooksApiBaseUrl = "https://www.googleapis.com/books/v1";

        /// <summary>
        /// Constructor
        /// </summary>
        public BookService()
        {
            
        }

        public async Task<IEnumerable<Book>> GetBooksByKeywordsAsync(string keywords, int maxNumberOfRecords)
        {
            List<Book> books = new List<Book>();
            try
            {
                // Query Google's API to get list of books that meet the search criteria
                using (var httpClient = new HttpClient())
                {
                    maxNumberOfRecords = Math.Min(maxNumberOfRecords, 40); // google has an upper limit of 40 records per query

                    var response = await httpClient.GetAsync($"{GoogleBooksApiBaseUrl}/volumes?q={keywords}&key={GoogleApiKey}&maxResults={maxNumberOfRecords}");
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonBooks = JObject.Parse(responseData)["items"];
                    
                    foreach (var jsonBook in jsonBooks)
                    {
                        try
                        {
                            books.Add(new Book()
                            {
                                Id = jsonBook?.Value<string>("id"),
                                Title = jsonBook["volumeInfo"]?.Value<string>("title"),
                                Description = jsonBook["volumeInfo"]?.Value<string>("description"),
                                PublishedYear = ParsePublishedYearFromString(jsonBook["volumeInfo"]?.Value<string>("publishedDate"))
                            });
                        }
                        catch
                        {
                            // Failed to parse result into our Book class
                            // TODO - log error
                        }
                    }
                }
            }
            catch
            {
                // Failed...
                // TODO - log error
            }
            return books;
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            // Query Google's API to get list of books that meet the search criteria
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{GoogleBooksApiBaseUrl}/volumes/{id}?key={GoogleApiKey}");
                var responseData = await response.Content.ReadAsStringAsync();

                JObject jsonBook = JObject.Parse(responseData);
                return new Book()
                {
                    Id = jsonBook?.Value<string>("id"),
                    Title = jsonBook["volumeInfo"]?.Value<string>("title"),
                    Description = jsonBook["volumeInfo"]?.Value<string>("description"),
                    PublishedYear = ParsePublishedYearFromString(jsonBook["volumeInfo"]?.Value<string>("publishedDate")),
                    Publisher = jsonBook["volumeInfo"]?.Value<string>("publisher"),
                    PageCount = jsonBook["volumeInfo"]?.Value<int>("pageCount"),
                    Authors = jsonBook["volumeInfo"]["authors"]?.ToObject<IEnumerable<string>>(),
                    Categories = jsonBook["volumeInfo"]["categories"]?.ToObject<IEnumerable<string>>(),
                    ThumbnailImageUrl = jsonBook["volumeInfo"]["imageLinks"]?.Value<string>("small"),
                    GoogleProductUrl = jsonBook["volumeInfo"]?.Value<string>("infoLink"),
                };
            }
        }

        private int? ParsePublishedYearFromString(string dateStr)
        {
            // Can we parse this as a date? 
            if (DateTime.TryParse(dateStr, out DateTime date))      // NOTE: this is a C#7 feature (inline out param declarations)
            {
                return date.Year;
            }

            // Can we parse the first 4 chars a year?
            if (int.TryParse(dateStr?.Substring(0, 4), out int year))
            {
                return year;
            }

            return null;    // Failed to parse

        }
    }
}
