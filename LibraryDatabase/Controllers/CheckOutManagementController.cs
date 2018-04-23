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
    public class CheckOutManagementController : ApiController
    {
        //CHECKOUT
        public string PutCheckOutBook(string ID)
        {
            var db = new DataContext();
            var bookToLendID = Convert.ToInt32(ID);
            var CheckOutReciept = "";

            Book bookToLend = db.Books.First(book => book.ID == bookToLendID);

            if (bookToLend.IsCheckedOut == false)
            {
                bookToLend.IsCheckedOut = true;
                bookToLend.DueByDate = DateTime.Now.AddDays(14);
                var newCheckout = new CheckOutLedger()
                {
                    Timestamp = DateTime.Now,
                    //UserEmail = ,
                    BookID = bookToLend.ID,
                    Book = bookToLend
                };
                db.CheckOutLedger.Add(newCheckout);
                db.SaveChanges();
                CheckOutReciept = $"You have checked out {bookToLend.Title}. It is due by {bookToLend.DueByDate}";
            }
            else
            {
                CheckOutReciept = $"This book is unavailable for checkout";
            }
            return CheckOutReciept;
        }
    }
}

