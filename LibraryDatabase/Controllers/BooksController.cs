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
    public class BooksController : ApiController
    {
        public IEnumerable<Book> GetAllBooks()
        {
            var db = new DataContext();
            var query = db.Books.Include(i => i.Author).Include(i => i.Genre);
            return query.ToList();
        }

        //Add a new Book
        //Need to add null checking (Author and Genre)
        public Book Post(PostBook bookData)
        {
            var db = new DataContext();

            Author author = db.Authors.First(x => x.Name == bookData.AuthorName);
            Genre genre = db.Genres.First(x => x.Name == bookData.GenreName);

            var newBook = new Book
            {
                Title = bookData.Title,
                YearPublished = bookData.YearPublished,
                Condition = bookData.Condition,
                AuthorID = author.ID,
                GenreID = genre.ID,
                ISBN = bookData.ISBN,
                IsCheckedOut = bookData.IsCheckedOut,
            };

            db.Books.Add(newBook);
            db.SaveChanges();
            newBook.Author = author;
            newBook.Genre = genre;
            return newBook;
        }

    }
}

