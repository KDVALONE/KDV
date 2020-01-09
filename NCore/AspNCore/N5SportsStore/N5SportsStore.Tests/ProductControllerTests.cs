using System.Collections.Generic;
using System.Linq;
using Moq;
using N5SportsStore.Controllers;
using N5SportsStore.Models;
using Xunit;

namespace N5SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //Организация
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            
            //Действие
            IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;
            
            //Утверждение
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length ==2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}