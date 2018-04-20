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
    //Add a new Author
}

