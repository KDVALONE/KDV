using  Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using N2LanguageFeatures.Models;
using System;
using  System.Linq;

namespace N2LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //public async Task<ViewResult> Index()
        //{
        #region синтаксис с использованием асинхронных методов действия
        //    long? length = await MyAsyncMethods.GetPageLength();
        //    return View(new string[] {$"Length:{length}"});
        #endregion
        //}

        public ViewResult Index()
        {
            #region синтаксис с использованием выражения nameof
            //данный синтаксис облегчает отлов ошибок по сравнению с обычным LINQ
            //и исключает возникновение ошибок на этапе выполнения, свзанных с неверным строгим заданным именем полей.
            //IntelliSense при использовании nameof выдает больше подсказок, а ошибки возникают только на этапе компиляции,
            // что не дает им ускользнуть от внимания разраб-ка.

            var products = new []
            {
                new Product { Name = "Kayak", Price = 275M},
                new Product { Name = "Lifejacket", Price = 48.95M},
                new Product { Name = "Soccer ball", Price = 19.50M},
                new Product { Name = "Corner flag", Price = 34.95M}
            };
            return View(products.Select(p =>
                $"{nameof(p.Name)}:{p.Name},{nameof(p.Price)}:{p.Price}"));

            #endregion

            #region синтаксис с использованием методов расширения с лямбда выражением 
            //позволяет не писать кучу методов расширения для новых филтраций, а делать это быстро и лаконично с помощью лямбд
            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            //Product[] productsArray =
            //{
            //    new Product { Name = "Kayak", Price = 275M},
            //    new Product { Name = "Lifejacket", Price = 48.95M},
            //    new Product { Name = "Soccer ball", Price = 19.50M},
            //    new Product { Name = "Corner flag", Price = 34.95M}
            //};
            //decimal priceFilterTotal = productsArray
            //    .Filter(p => (p?.Price ?? 00) >= 20).TotalPrices();
            //decimal nameFilterTotal = productsArray
            //    .Filter(p => p?.Name?[0] == 'S').TotalPrices();
            //return View("Index", new string[]
            //{
            //    $"Price Total: {priceFilterTotal:С2}",
            //    $"Name Total: {nameFilterTotal:C2}"
            //});
            #endregion

            #region синтаксис с использованием методов расширения
            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            //decimal cartTotal = cart.TotalPrices(); // применение метода расширения TotalPrice класса MyExtensionMethods расширяющего ShoppingCart
            //return View("Index", new string[] {$"Total: {cartTotal:C2}"});

            #endregion

            #region синтаксис с использованием методов расширения применительно к интерфейсу
            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            //Product[] productsArray =
            //{
            //    new Product { Name = "Kayak", Price = 275M},
            //    new Product { Name = "Lifejacket", Price = 48.95M},
            //    new Product { Name = "Soccer ball", Price = 19.50M},
            //    new Product { Name = "Corner flag", Price = 34.95M}

            //};
            //синтаксис для использования мет.расширения к интерфейсам БЕЗ ФИЛЬТРАЦИИ.
            //decimal cartTotal = cart.TotalPrices();
            //decimal arrayTotal = productsArray.TotalPrices();

            //return View("Index", new string[]
            //{
            //    $"Cart Total: {cartTotal:C2}",
            //    $"Array Total: {arrayTotal:C2}"
            //});

            //*********************
            //синтаксис для использования мет.расширения к интерфейсам C ФИЛЬТРАЦИЕЙ.
            //decimal arrayTotal = productsArray.FilterByPrice(20).TotalPrices();
            //return View("Index", new string[] {$"Array Total: {arrayTotal:C2}"});

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