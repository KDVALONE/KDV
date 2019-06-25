using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1MVC5Met.Models.BookStore;
using _1MVC5Met.Models.BookStore.Models;

namespace _1MVC5Met.Controllers
{
    public class HomeController : Controller
    {
        
            // создаем контекст данных
            BookContext db = new BookContext();

            public ActionResult Index()
            {
                // получаем из бд все объекты Book
                IEnumerable<Book> books = db.Books;
                // передаем все объекты в динамическое свойство Books в ViewBag
                ViewBag.Books = books;
                // возвращаем представление
                return View();
            }
        
    }
}