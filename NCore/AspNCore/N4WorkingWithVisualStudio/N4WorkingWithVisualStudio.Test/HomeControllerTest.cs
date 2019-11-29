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
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]
        public void IndexActionModelIsComplete(decimal price1, decimal price2, decimal price3, decimal price4)
        {
            //организация
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository
            { 
                Products = new Product[]
                {
                    new Product {Name = "P1", Price = price1},
                    new Product {Name = "P2", Price = price2},
                    new Product {Name = "P3", Price = price3},
                    new Product {Name = "P4", Price = price4}
                }
            };
            //действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //утвреждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}