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
        //for Checkout, need to add if logic with the bool property 'IsCheckedOut' on book
        public IEnumerable<Book> GetAllBooks()
        {
            var db = new DataContext();
            return db.Books.ToList();
        }

        //Add a new Book
        public Book Post(PostBook bookData)
        {
            Author author = GetAuthor(bookData);
            //Genre genre = CheckGenre(bookData);

            var newBook = new Book
            {
                Title = bookData.Title,
                YearPublished = bookData.YearPublished,
                Condition = bookData.Condition,
                AuthorID = author.ID,
                //GenreID = genre.ID,
                ISBN = bookData.ISBN,
                IsCheckedOut = bookData.IsCheckedOut,
                DueByDate = bookData.DueByDate
            };

            var db = new DataContext();
            db.Books.Add(newBook);
            db.SaveChanges();
            newBook.Author = author;
            //newBook.Genre = genre;
            return newBook;
        }


        var db = new DataContext();
            newBook = db.Books
              .Include(i => i.Genre)
              .Include(i => i.Author)
              .First(book => book.GenreID == Genre.ID);
            db.Books.Include(b => b.Genre);
            newBook.Genre = 
            db.Books.Add(newBook);
            db.SaveChanges();
            return newBook;
        }


        //Add a new Author
    }
}
