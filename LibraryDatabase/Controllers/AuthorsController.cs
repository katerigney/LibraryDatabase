using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryDatabase.Models;
using LibraryDatabase.Data;

namespace LibraryDatabase.Controllers
{
    public class AuthorsController : ApiController
    {
        public IEnumerable<Author> GetAllAuthors()
        {
            var db = new DataContext();
            return db.Authors.ToList();
        }

        public Author Post(Author newAuthor)
        {
            //Add a new Author
            var db = new DataContext();
            db.Authors.Add(newAuthor);
            db.SaveChanges();
            return newAuthor;
        }
    }
}
