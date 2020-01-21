using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using N5SportsStore.Controllers;
using N5SportsStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace N5SportsStore.Tests
{  
    public class OrderControllerTests
    {
        /// <summary>
        /// Тест проверяет способность перехода к оплате при пустой корзине. 
        /// </summary>
        [Fact]
        public void Cannot_Checkout_EmptyCart()
        {
            //Организация - создание имитированного хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            //Организация - создание пустой корзины
            Cart cart = new Cart();
            //Организация - создание заказа
            Order order = new Order();
            //Организация - создание экз.контроллера.
            OrderController target = new OrderController(mock.Object, cart);

            //Действие
            ViewResult result = target.Checkout(order) as ViewResult;

            //Утверждение - проверка, что заказ не был сохранен
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            //Утверждение - проверка, что метод возвращает стандартное представление
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            //Утверждение - проверка, что передана недопустимая модель.
            Assert.False(result.ViewData.ModelState.IsValid);

        }

        /// <summary>
        /// Тест проверяет способность перехода к оплате при пустой корзине при внедренной ошибке 
        /// о которой сообщает средство привязки модели при вводе некорректных данных пользователем. 
        /// </summary>
        [Fact]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            //Организация - создание имитированного хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            //Организация - создание корзины c одним элементом
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            //Организация - создание экз.контроллера.
            OrderController target = new OrderController(mock.Object, cart);
            //Организация - добавление ошибки в модель
            target.ModelState.AddModelError("error", "error");
            //Действие - попытка перехода к оплате
            ViewResult result = target.Checkout(new Order()) as ViewResult;

            //Утверждение - проверка, что заказ не был сохранен
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never);
            //Утверждение - проверка, что метод возвращает стандартное представление
            Assert.True(string.IsNullOrEmpty(result.ViewName));
            //Утверждение - проверка, что передана недопустимая модель.
            Assert.False(result.ViewData.ModelState.IsValid);
        }

        /// <summary>
        /// Тест проверяет что некорректные данные о заказе или пустая корзина предотвращают сохраение заказа
        /// </summary>
        [Fact]
        public void Can_Checkout_And_Submit_Order()
        {
            //Организация - создание имитированного хранилища заказов
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            //Организация - создание корзины c одним элементом
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            //Организация - создание экз.контроллера.
            OrderController target = new OrderController(mock.Object, cart);

            //Действие - попытка перехода к оплате
            RedirectToActionResult result =
                target.Checkout(new Order()) as RedirectToActionResult;

            //Утверждение - проверка что заказ был сохранен
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
            //Утверждение - проверка что метод перенаправляется на действие Completed
            Assert.Equal("Completed", result.ActionName);
        }
    }
}
