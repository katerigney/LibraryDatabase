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
        //[HttpGet]
        //public IEnumerable<Book> SearchBookTitle(string title)
        //{
        //    var db = new DataContext();
        //    var query = db.Books.Include(i => i.Author).Include(i => i.Genre);

        //    var result = query.Where(book => book.Title.Contains(title));
        //    return result;
        //}

        //[HttpGet]
        //public IEnumerable<Book> SearchBookGenre(string genre)
        //{
        //    var db = new DataContext();
        //    var query = db.Books.Include(i => i.Author).Include(i => i.Genre);

        //    var result = query.Where(book => book.Genre.Name == genre);
        //    return result;
        //}

        //[HttpGet]
        //public IEnumerable<Book> SearchBookAuthor(string author)
        //{
        //    var db = new DataContext();
        //    var query = db.Books.Include(i => i.Author).Include(i => i.Genre);

        //    var result = query.Where(book => book.Author.Name.Contains(author));
        //    return result;
        //}



        //using a ViewModel - could not get to work

        [HttpGet]
        public IEnumerable<Book> Search([FromUri]SearchBooksParams book)
        {
          var db = new DataContext();

        var query = db.Books.Include(i => i.Author).Include(i => i.Genre);

          if (!String.IsNullOrEmpty(book.Title))
        {
          query = query.Where(w => w.Title == book.Title);
          //maybe use contains here?
        }

        if (book.Author != null)
        {
          query = query.Where(w => w.Author.Name == book.Author);
        }
        if (book.Genre != null)
        {
          query = query.Where(w => w.Genre.Name == book.Genre);
        }

        return query;

        }
    }
}

