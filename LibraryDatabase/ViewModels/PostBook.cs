using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryDatabase.ViewModels
{
    public class PostBook
    {
        public string Title { get; set; }
        public string YearPublished { get; set; }
        public string Condition { get; set; }
        public string ISBN { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime DueByDate { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
    }
}