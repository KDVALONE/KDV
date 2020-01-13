using System.Collections.Generic;
using System.Linq;
using N5SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using N5SportsStore.Models;
namespace N5SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;

        //принимает обьект реализующий IProductRepository, по сути это DInjection, класс Startup метод services.AddTransient<> отвечают за предоставление нужного обьекта
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Метод действия для визуализации представления, выводит весь список товаров из хранилища 
        /// </summary>
        /// <returns></returns>
        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p=> category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },
                CurrentCategory = category
            });
    }
}