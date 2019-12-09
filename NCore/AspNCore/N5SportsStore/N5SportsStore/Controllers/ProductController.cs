using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using N5SportsStore.Models;
namespace N5SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        //принимает обьект реализующий IProductRepository, по сути это DInjection, класс Startup метод services.AddTransient<> отвечают за предоставление нужного обьекта
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Метод действия для визуализации представления, выводит весь список товаров из хранилища 
        /// </summary>
        /// <returns></returns>
        public ViewResult List() => View(repository.Products);
    }
}