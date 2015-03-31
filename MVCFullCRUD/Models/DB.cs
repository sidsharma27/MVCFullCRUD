using MVCFullCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFullCRUD.Models
{
    public class DB
    {
        public List<Book> Books { get; set; }
        private static DB _instance;

        public static DB Instance
        {
            get
            {
                return _instance ?? (_instance = new DB()
                {
                    Books = new List<Book>() { 
                        new Book() {BookId = 1, Author = "Dave Pinkey", Genre = Genre.Children, Title = "Captin Underpants" },
                        new Book() {BookId = 2, Author = "Jeremy", Genre = Genre.Educational, Title = "Intro to MVC"},
                        new Book() {BookId = 3, Author = "Eddie", Genre = Genre.Sci_Fi, Title = "Intersteller: The Book"} 
                    }
                });
            }
        }
        private DB()
        {

        }
    }

}



