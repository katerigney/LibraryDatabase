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
        public string PutCheckOutIn(int bookToReturnID)
        {
            var db = new DataContext();
            var Message = "";

            Book bookToReturn = db.Books.First(book => book.ID == bookToReturnID);

            if (bookToReturn.IsCheckedOut == true)
            {
                bookToReturn.IsCheckedOut = false;
                bookToReturn.DueByDate = null;
                db.SaveChanges();
                //FROM LECTURE: Use a view model for message (bc scaling)
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
