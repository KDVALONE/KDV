using  Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using N2LanguageFeatures.Models;
namespace N2LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Dictionary<string, Product> products = new Dictionary<string, Product> // инициализация коллекции с помощью словаря
            {
                // старый синтаксис
                //{"Kayak",new Product{ Name = "Kayak", Price = 275M }  },
                //{"Lifejacket", new Product{ Name = "Lifejacket", Price = 48.95M} } 

                //более простой новый синтаксис инициализация коллекции с помощью словаря
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
                ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            };

            return View("Index", products.Keys);

            // return View("Index", new string[] {"Bob", "Joe", "Alice"}); //использование инициализации коллекции

            //List<string> result = new List<string>();
            //foreach (Product p in Product.GetProducts() )
            //{
            //    string name = p?.Name ?? "No Name";
            //    decimal? price = p?.Price ?? 0;
            //    string relatedName = p?.Related?.Name ?? "<None>";
            //    result.Add(string.Format($"Name:{name}, Price:{price},Related:{relatedName}"));
            //}

            //return View(result);
        }
    }
}