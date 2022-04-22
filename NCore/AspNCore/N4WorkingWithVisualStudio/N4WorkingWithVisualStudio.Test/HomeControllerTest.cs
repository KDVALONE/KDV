using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using N4WorkingWithVisualStudio.Controllers;
using N4WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace N4WorkingWithVisualStudio.Test
{
    /// <summary>
    /// класс для тестирования боле сложных классов содержащих зависимости
    /// </summary>
    public class HomeControllerTest
    {
      // тест проверяет что метод действия Index() передает представлению все обьекты хранилища, с применением прамаетрезации.
        [Theory]
        [ClassData(typeof(ProductTestData))] // данный атрибут конфигуриуется с типом тестовых данных (ProductTestData), во время выполнения создасться
        //экземпляр ProductTestData и будет применен для получения последовательных тестовых данных
        public void IndexActionModelIsComplete(Product [] products)
        {
            //организация

            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);

            var controller = new HomeController {Repository = mock.Object};

            //действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //утвреждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

   /// <summary>
        /// тест выполняет просто подсчет обращений к Products, фиктивного хранилища
        /// и проверяет точно ли обращались всего один раз
        /// </summary>
        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            //организация arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] {new Product {Name = "P1", Price = 100}});

            var controller = new HomeController {Repository = mock.Object};

            //действие act
            var result = controller.Index();

            //утверждение assert
            mock.VerifyGet(m=>m.Products,Times.Once);
        }
    }
}