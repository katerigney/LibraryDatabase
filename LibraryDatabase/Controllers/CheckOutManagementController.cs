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
        public string PutCheckOutIn(int bookToLendID, [FromBody] UserEmail data) 
        {
            var db = new DataContext();
            var Message = "";

            Book bookToLend = db.Books.First(book => book.ID == bookToLendID);

            if (bookToLend.IsCheckedOut == false)
            {
                bookToLend.IsCheckedOut = true;
                bookToLend.DueByDate = DateTime.Now.AddDays(14);
                var newCheckout = new CheckOutLedger()
                {
                    Timestamp = DateTime.Now,
                    UserEmail = data.Email,
                    BookID = bookToLend.ID,
                    Book = bookToLend
                };
                db.CheckOutLedger.Add(newCheckout);
                db.SaveChanges();
                //FROM LECTURE: Use a view model for message (bc scaling)
                Message = $"You have checked out {bookToLend.Title}. It is due by {bookToLend.DueByDate}";
            }
            else
            {
                bookToLend.IsCheckedOut = false;
                bookToLend.DueByDate = null;
                Message = $"This book is unavailable for checkout.";
            }
            return Message;
        }
    }
}

