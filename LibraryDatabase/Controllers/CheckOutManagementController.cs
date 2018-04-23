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
    //    public CheckOutLedger PutCheckOutBook(string ID)
    //    {
    //        var db = new DataContext();
    //        var bookToLendID = Convert.ToInt32(ID);

    //        Book bookToLend = db.Books.First(book => book.ID == bookToLendID);
    //        if (bookToLend.IsCheckedOut == false)
    //        {
    //            bookToLend.IsCheckedOut = true;
    //            var newCheckout = new CheckOutLedger()
    //            {
    //                Name
    //            //BookID = bookID,
    //            TimeStamp = DateTime.Now,
    //            Email = userCheckout.Email,
    //            BookStatus = "Checking out"

    //            public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string UserEmail { get; set; }
    //    public DateTime Timestamp { get; set; }
    //    public int BookID { get; set; }
    //    public Book Book { get; set; }
    //};
    //        }
    //        }

    //        return CheckOuReciept;
    //    }

        //need bool property 'IsCheckedOut' on book = false
        //need Book ID
        //need user email
        //timestamp


    }
}
