using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace personal_library_management_system.data
{
    public class BorrowedBook
    {
        public int BorrowID { get; set; }
        public int BookID { get; set; }
        public int FriendID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int DaysBorrowed { get; set; }

        public class Book
        {
            public int BookID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public string ISBN { get; set; }
            public int Quantity { get; set; }
        }

        public class Friend
        {
            public int FriendID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public DateTime RegistrationDate { get; set; }
        }
    }

}