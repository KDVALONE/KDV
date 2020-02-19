using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using N5SportsStore.Models;
using Moq;

namespace N5SportsStore.Tests
{
    /// <summary>
    /// Класс для модульных тестов корзины пользователя
    /// </summary>
    public class CartTest
    {
        /// <summary>
        /// модульный тест по созданию корзины пользоватля
        /// </summary>
        [Fact]
        public void Can_Add_New_Lines()
        {
            //Организация - создание нескольких тестовых товаров
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            
            // Орагинизация - создание новой корзины
            Cart target = new Cart();
            
            //Действие
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            //Утвеждение
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }

        /// <summary>
        /// модульный тест по добалению элемента в корзину
        /// </summary>
        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //Организация - создание нескольких тестовых товаров
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Орагинизация - создание новой корзины
            Cart target = new Cart();

            //Действие
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = target.Lines
                .OrderBy(c => c.Product.ProductID).ToArray();

            //Утверждение
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }


        /// <summary>
        /// модульный тест по удалению элемента из корзины
        /// </summary>
        [Fact]
         public void Can_Remove_Line()
        {

            //Организация - создание нескольких тестовых товаров
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };    

             // Орагинизация - создание новой корзины
             Cart target = new Cart();

            // Орагинизация - добавление нескольких товаров в корзину
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            //Действие
            target.RemoveLine(p2);

            //Утверждение
            Assert.Equal(0, target.Lines.Where(c => c.Product == p2).Count());
            Assert.Equal(2, target.Lines.Count());
        }

        /// <summary>
        /// Модульный тест проверки вычисления общей стоимости элементов корзины
        /// </summary>
        [Fact]
        public void Calculate_Cart_Total()
        {
            //Организация - создание нескольких тестовых товаров
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };
            // Орагинизация - создание новой корзины
            Cart target = new Cart();

            //Действие
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();

            //Утверждение
            Assert.Equal(450M, result);
        }

        /// <summary>
        /// Модульный тест проверки удаления содержимого корзины
        /// </summary>
        [Fact]
        public void Can_Clear_Contents()
        {
            //Организация - создание нескольких тестовых товаров
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };
            
            // Орагинизация - создание новой корзины
            Cart target = new Cart();

            //Организация - добавление нескольких элементов в корзину
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            //Действие - очистка корзины
            target.Clear();

            //Утверждение
            // Assert.Equal(0,target.Lines.Count()); //вот так в книге, но так делать не рекомендуют, правильный способ ниже
            Assert.Empty(target.Lines);

        }
    }
}
