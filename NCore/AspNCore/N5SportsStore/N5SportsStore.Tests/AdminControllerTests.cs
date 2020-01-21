using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;
using N5SportsStore.Controllers;
using N5SportsStore.Models;
namespace N5SportsStore.Tests
{
   public class AdminControllerTests
    {

        /// <summary>
        /// Проверка корректного возвращения обьектов PRODUCT контроллером AdminController
        /// </summary>
        [Fact]
        public void Index_Contains_All_Products()
        {
            //Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
                {
                    new Product{ ProductID = 1, Name= "P1"},
                    new Product{ ProductID = 2, Name= "P2"},
                    new Product{ ProductID = 3, Name= "P3"},
                }).AsQueryable<Product>());
            //Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);
            //Действие
            Product[] result
                = GetViewModel<IEnumerable<Product>>(target.Index())?.ToArray();

        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
