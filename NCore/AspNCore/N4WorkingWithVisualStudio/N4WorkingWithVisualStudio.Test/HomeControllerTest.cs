using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using N4WorkingWithVisualStudio.Controllers;
using N4WorkingWithVisualStudio.Models;
using Xunit;

namespace N4WorkingWithVisualStudio.Test
{
    /// <summary>
    /// класс для тестирования боле сложных классов содержащих зависимости
    /// </summary>
    public class HomeControllerTest
    {
        // фиктивоное хранилище данных для теста
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                //ничего не делать - для теста не требуется
            }
        }

        // тест проверяет что метод действия Index() передает представлению все обьекты хранилища, с применением прамаетрезации.
        [Theory]
        [ClassData(typeof(ProductTestData))] // данный атрибут конфигуриуется с типом тестовых данных (ProductTestData), во время выполнения создасться
        //экземпляр ProductTestData и будет применен для получения последовательных тестовых данных
        public void IndexActionModelIsComplete(Product [] products)
        {
            //организация
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository
            { 
                Products = products
            };
            //действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //утвреждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}