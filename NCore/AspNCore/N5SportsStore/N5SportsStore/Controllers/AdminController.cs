using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N5SportsStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace N5SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Products);

        /// <summary>
        /// Метод  ищет товар с ID соответсвующим productId и передает его как обьект меоде представления в метод View()
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ViewResult Edit(int productId) =>
            View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));

        /// <summary>
        /// Метод действия для перегруженного метода Edit, который будет обрабатывать POST запросы 
        /// при нажатии кнопки SAVE администратором.
        /// Описание метода смотри на стр317, там есть нюансы.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }else{
                //что то не так со занчением данных
                return View(product);
            }
        } 
    }
}
