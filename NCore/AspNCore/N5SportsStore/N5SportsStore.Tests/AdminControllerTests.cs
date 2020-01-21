using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;
using N5SportsStore.Controllers;
using N5SportsStore.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

        /// <summary>
        /// Модульный тест для проверки редактирования ожидаемого товара.
        /// </summary>
        [Fact]
        public void Can_Edit_Product()
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
            Product p1 = GetViewModel<Product>(target.Edit(1));
            Product p2 = GetViewModel<Product>(target.Edit(2));
            Product p3 = GetViewModel<Product>(target.Edit(3));
            //Утверждение
            Assert.Equal(1, p1.ProductID);
            Assert.Equal(2, p2.ProductID);
            Assert.Equal(3, p3.ProductID);
        }

        /// <summary>
        ///  Модульный тест для проверки - не получения id товара отсутствующего в хранилище.
        /// </summary>
        [Fact]
        public void Cannot_Edit_Nonexisten_Product()
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
            Product result = GetViewModel<Product>(target.Edit(4));
            //Утверждение
            Assert.Null(result);
        }

        /// <summary>
        /// Модульный тест проверки что корректные данные модели в харнилище  предаются
        /// </summary>
        [Fact]
        public void Can_Save_Valid_Changes()
        {
            //Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //Организация - создание имитированного хранилища
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            //Организация - создание контроллера
            AdminController target = new AdminController(mock.Object) {
                TempData = tempData.Object
            };
            //Организация - создание товара
            Product product = new Product { Name = "Test" };
            //Действие - попытка сохранить товар
            IActionResult result = target.Edit(product);
            //Утверждение - проверка того, что к хранилищу было произведено обращение
            mock.Verify(m => m.SaveProduct(product));
            //Утверждение - проверка что типом результата является перенаправление
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
        }

        /// <summary>
        /// Модульный тест проверки что содержащие ошибки проверки достоверности модели данные в харнилище не предаются
        /// </summary>
        [Fact]
        public void Cannot_Save_Invalid_Changes() {
            //Организация - создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //Организация - создание контроллера
            AdminController target = new AdminController(mock.Object);
            //Организация - создание товара
            Product product = new Product { Name = "Test" };
            //Организация - добавление ошибки в состояние модели
            target.ModelState.AddModelError("error", "error");
            //Действие - попытка сохранить товар
            IActionResult result = target.Edit(product);

            //Утверждение - проверка что к хранилищу было произведено обращение
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            //Утверждение - проверка что типа результата метода
            Assert.IsType<ViewResult>(result);

        }

    }
}
