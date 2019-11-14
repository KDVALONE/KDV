using  Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using N2LanguageFeatures.Models;
namespace N2LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            #region синтаксис с использованием методов расширения
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            decimal cartTotal = cart.TotalPrices(); // применение метода расширения TotalPrice класса MyExtensionMethods расширяющего ShoppingCart
            return View("Index", new string[] {$"Total: {cartTotal:C2}"});

            #endregion
            #region синтаксис с использованием IS и SWITCH - сопоставление с образцом


            object[] data = new object[] {275M, 29.95M, "apple", "orange",100, 10 };
            decimal total = 0;
            //синтаксис с использованием IS
            //for (int i = 0; i < data.Length; i++)
            //{
            //    if (data[i] is decimal d)
            //    {
            //        total += d;
            //    }
            //}

            //************
            //синтаксис с использованием SWITCH
            //for (int i = 0; i < data.Length; i++)
            //{
            //    switch (data[i])
            //    {
            //        case decimal decimalValue: // для сравнения нужного типа обратить необходимо использовать его переменную
            //            total += decimalValue; 
            //            break;
            //        case int intValue when intValue > 50:
            //            total += intValue;
            //            break;
            //    }
            //}

           // return View("Index", new string[] {$"Total: {total:C2}"});
            #endregion

            #region синтаксис с использованием инициализации коллекции Dictionary

            // инициализация коллекции с помощью словаря
            // Dictionary<string, Product> products = new Dictionary<string, Product> 
            // {
            // старый синтаксис инициализация коллекции с помощью словаря
            //{"Kayak",new Product{ Name = "Kayak", Price = 275M }  },
            //{"Lifejacket", new Product{ Name = "Lifejacket", Price = 48.95M} } 

            //**********************

            // более простой новый синтаксис инициализация коллекции с помощью словаря
            // ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
            // ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            // };
            // return View("Index", products.Keys);

            #endregion

            #region синтаксиси с использованием инициализации коллекции

            // return View("Index", new string[] {"Bob", "Joe", "Alice"}); //использование инициализации коллекции

            #endregion

            #region синтаксиси с использованием Null-услованой операции

            //List<string> result = new List<string>();
            //foreach (Product p in Product.GetProducts() )
            //{
            //    string name = p?.Name ?? "No Name";
            //    decimal? price = p?.Price ?? 0;
            //    string relatedName = p?.Related?.Name ?? "<None>";
            //    result.Add(string.Format($"Name:{name}, Price:{price},Related:{relatedName}"));
            //}

            //return View(result);

            #endregion
        }
    }
}