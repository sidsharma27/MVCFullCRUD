using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFullCRUD.Model
{
    public class Book
    {
        public int BookId
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public Genre Genre
        {
            get;
            set;
        }

    }
    public enum Genre
    {
        Sci_Fi,
        Educational,
        Children,
        Historical
    }

}
