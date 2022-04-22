using _1MVCMetV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1MVCMetV2.Controllers
{
    public class HomeController : Controller
    {
        /*
        Контроллер (controller) представляет класс, обеспечивающий связь между пользователем и системой, представлением и хранилищем данных.
        Он получает вводимые пользователем данные и обрабатывает их.
        И в зависимости от результатов обработки отправляет пользователю определенный вывод, например, в виде представления.
        По у молчанию создается класс HomeController, c методами Index, About, Contact. (Они нам не нужны)
        */

        // создаем контекст данных через который мы будем взаимодействовать с бд: BookContext db = new BookContext();.
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;

            // передаем все объекты в динамическое свойство Books в ViewBag
            /* ViewBag представляет такой объект, который позволяет определить любую переменную и передать ей некоторое значение, а затем в представлении извлечь это значение.*/
            ViewBag.Books = books;
            // возвращаем представление
            return View();

        }


        /*Хотя здесь два метода, но в целом они составляют одно действие Buy, 
         * только первый метод срабатывает при получении запроса GET, а второй - при получении запроса POST. 
         * С помощью атрибутов [HttpGet] и [HttpPost] мы можем указать, какой метод какой тип запроса обрабатывает.

        Так как предполагается, что в метод Buy будет передаваться id книги, которую пользователь хочет купить,
        то нам надо определить в методе соответствующий параметр: public ActionResult Buy(int id). 
        Затем этот параметр передается через объект ViewBag в представление, которое мы сейчас создадим.*/
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        /*
        Метод public string Buy(Purchase purchase) выглядит несколько сложнее. 
        Он принимает переданную ему в запросе POST модель purchase и добавляет ее в базу данных. 
        Результатом работы метода будет строка, которую увидит пользователь.

        А весь код по добавлению нового объекта в бд благодаря использованию EntityFramework фактически 
        сводится к двум строчкам purchase.Date = DateTime.Now; и db.SaveChanges();
            
        */
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }

    }
}