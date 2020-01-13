using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Moq;
using N5SportsStore.Models;
using N5SportsStore.Componetnts;
using Xunit;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace N5SportsStore.Tests
{
    /// <summary>
    /// Класс для тестирования генерации списка категорий
    /// </summary>
    public class NavigationMenuViewComponentTests
    {

        /// <summary>
        /// Модульный тест для проверки возможности генерации списка категорий
        /// </summary>
        [Fact]
        public void Can_Select_Categories() {
            //Организация
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"  },
                new Product {ProductID = 2, Name = "P2", Category = "Apples"  },
                new Product {ProductID = 3, Name = "P3", Category = "Plums"   },
                new Product {ProductID = 4, Name = "P4", Category = "Oranges" },
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);
            //Действие - получение набора критерий
            string[] results = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();

            //Утверждение
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plums" }, results));
        }

        /// <summary>
        /// Тест для проверки сообщения о том что компонент корректно добавил детали о выбранной категории товара
        /// </summary>
        [Fact]
        public void Indicates_Selected_Category() {
            //Организация
            string categoryToSelect = "Apples";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"  },
                new Product {ProductID = 4, Name = "P2", Category = "Oranges"  },
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
               ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext {
               RouteData = new Microsoft.AspNetCore.Routing.RouteData()
               }
            };
            target.RouteData.Values["category"] = categoryToSelect;

            //Действие
            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            //Утверждение
            Assert.Equal(categoryToSelect, result);
        }
    }
}
