using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryDatabase.Models
{
    public class CheckOutLedger
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public DateTime Timestamp { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}