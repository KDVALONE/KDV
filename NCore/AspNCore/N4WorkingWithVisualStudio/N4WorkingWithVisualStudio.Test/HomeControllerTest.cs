using System.Collections.Generic;
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
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product {Name = "P1", Price = 275M},
                new Product {Name = "P2", Price = 48.95M},
                new Product {Name = "P3", Price = 19.50M},
                new Product {Name = "P3", Price = 34.95M}
            };

            public void AddProduct(Product p)
            {
                //ничего не делать - для теста не требуется
            }
        }
        // тест проверяет что метод действия Index() передает представлению все обьекты хранилища
        [Fact]
        public void IndexActionModelComplete()
        {
            //организация
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository();
            //действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //утвреждение
            Assert.Equal(controller.Repository.Products, model,
                        Comparer.Get<Product>((p1,p2)=>p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}