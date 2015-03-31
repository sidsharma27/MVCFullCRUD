using MVCFullCRUD.Model;
using MVCFullCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFullCRUD.Controllers
{
    public class HomeController : Controller
    {
        DB DB = DB.Instance;
        public ActionResult Index()
        {
            return View(DB.Books);
        }
        public ActionResult Details(int id)
        {
            Book book = DB.Books.FirstOrDefault(x => x.BookId == id);
            return View(book);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DeleteBook(int id)  //because of RedirectToAction no view needed
        {

            Book deleteBook = DB.Books.FirstOrDefault(x => x.BookId == id); //casts it into Book automatically, rather than iQuery that Where gives us
            DB.Books.Remove(deleteBook);
            return RedirectToAction("Index");
        }
        public ActionResult EditBook(int id)
        {
            Book editBook = DB.Books.FirstOrDefault(x => x.BookId == id);
            return View(editBook);
        }
        [HttpPost] //differentiates ^ EditBook from the one below
        public ActionResult EditBook(Book editedBook)
        {
            foreach (var b in DB.Books) //loop checks the id for editBook and Books 
            {
                if (b.BookId == editedBook.BookId)
                {
                    b.Title = editedBook.Title;
                    b.Author = editedBook.Author;
                    b.Genre = editedBook.Genre;
                    break;
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult AddBook()
        {
    
            return View(new Book());
            
        }
    [HttpPost]
        public ActionResult AddBook(Book model){
            model.BookId = DB.Books.OrderBy(x => x.BookId).LastOrDefault().BookId + 1;
            DB.Books.Add(model);
            return RedirectToAction("Index");  
        } 
    }
}