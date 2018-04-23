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
    public class AvailableBooksController : ApiController
    {
        [HttpGet]
        public IEnumerable<Book> SearchAvailableBooks()
        {
            var db = new DataContext();
            var query = db.Books.Include(i => i.Author).Include(i => i.Genre);
            var results = query.Where(book => book.IsCheckedOut == false);
            return results.ToList();
        }
    }
}

