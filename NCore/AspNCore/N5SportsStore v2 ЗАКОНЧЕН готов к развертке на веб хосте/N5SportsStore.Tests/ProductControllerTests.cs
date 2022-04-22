using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using N5SportsStore.Controllers;
using N5SportsStore.Models;
using N5SportsStore.Models.ViewModels;
using Xunit;

namespace N5SportsStore.Tests
{
    public class ProductControllerTests
    {
        /// <summary>
        /// Модульный тест создания ссылкок на страницы
        /// </summary>
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
            // IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;
            ProductsListViewModel result =
                controller.List(null, 2).ViewData.Model as ProductsListViewModel;

            //Утверждение
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }

        /// <summary>
        /// Модульный тест данные для разбиения страницы для модели представления
        /// </summary>
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //Организация
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
            new Product { ProductID = 1, Name = "P1" },
            new Product { ProductID= 2, Name = "P2" },
            new Product { ProductID = 3, Name = "P3" },
            new Product { ProductID= 4, Name = "P4" },
            new Product { ProductID= 5, Name = "P5" }
            }).AsQueryable<Product>());

            //Организация
            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };
            //Действие
            ProductsListViewModel result = controller.List(null, 2).ViewData.Model as ProductsListViewModel;
            //Утверждение
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);

        }

        ///модульный тест проверки функциональности фильтрации по категориям
        [Fact]
        public void Can_Filter_Products()
        {

            //Организация- создание имитированного хранилища
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product { ProductID = 1,  Name = "P1",  Category = "Cat1" },
                new Product { ProductID = 2,  Name = "P2" , Category = "Cat2" },
                new Product { ProductID = 3,  Name = "P3",  Category = "Cat1" },
                new Product { ProductID = 4,  Name = "P4" , Category = "Cat2" },
                new Product { ProductID = 5,  Name = "P5" , Category = "Cat3" }
            }).AsQueryable<Product>());

            //Организация - сощдание контроллера и установка размера страницы в три элемента
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Действие
            Product[] result =
                (controller.List("Cat2", 1).ViewData.Model as ProductsListViewModel)
                .Products.ToArray();
            //Утверждение
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
        }

        ///модульный тест для проверки счетчика товаров определенной категории
        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            //Организация
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { ProductID = 1,  Name = "P1",  Category = "Cat1" },
                new Product { ProductID = 2,  Name = "P2" , Category = "Cat2" },
                new Product { ProductID = 3,  Name = "P3",  Category = "Cat1" },
                new Product { ProductID = 4,  Name = "P4" , Category = "Cat2" },
                new Product { ProductID = 5,  Name = "P5" , Category = "Cat3" }

            }).AsQueryable<Product>());

            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;

            Func<ViewResult, ProductsListViewModel> GetModel = result =>
            result?.ViewData?.Model as ProductsListViewModel;

            //Действие
            int? res1 = GetModel(target.List("Cat1"))?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.List("Cat2"))?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.List("Cat3"))?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.List(null))?.PagingInfo.TotalItems;

            //Утверждение
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
        }
    }
}