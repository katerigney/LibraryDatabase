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
    public class CheckInManagementController : ApiController
    {
        //CHECKOUT
        public string PutCheckOutIn(string ID)
        {
            var db = new DataContext();
            var bookToReturnID = Convert.ToInt32(ID);
            var Message = "";

            Book bookToReturn = db.Books.First(book => book.ID == bookToReturnID);

            if (bookToReturn.IsCheckedOut == true)
            {
                bookToReturn.IsCheckedOut = false;
                bookToReturn.DueByDate = null;
                db.SaveChanges();
                Message = $"Thanks for returning {bookToReturn.Title}";
            }
            else
            {
                Message = $"This book has already been returned.";
            }
            return Message;
        }
    }
}
