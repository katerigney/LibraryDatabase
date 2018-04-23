using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryDatabase.Models;
using LibraryDatabase.Data;
using LibraryDatabase.ViewModels;

namespace LibraryDatabase.Controllers
{
    public class SearchBooksController : ApiController
    {
        [HttpGet]
        public IEnumerable<Book> Search([FromUri]SearchBooksParams book)
        {
            var db = new DataContext();
            var query = db.Books.Include(i => i.Author).Include(i => i.Genre);

            if (!String.IsNullOrEmpty(book.Title))
            {
                query = query.Where(w => w.Title == book.Title);
                //maybe use contains here?
                // query.Where(book => book.Title.Contains(title));
            }

            if (book.Author != null)
            {
                query = query.Where(w => w.Author.Name == book.Author);
                //maybe use contains here?
            }
            if (book.Genre != null)
            {
                query = query.Where(w => w.Genre.Name == book.Genre);
                //maybe use contains here?
            }
            return query;
        }
    }
}

