using System.Collections.Generic;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace N2LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        /// <summary>
        /// Метод расширения для класса ShoppingCart : Product, делающий подсчет суммы значений свойств Product.Price
        /// </summary>
        /// <param name="cartParam"></param>
        /// <returns></returns>
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (Product prod in products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }

        #region Добавление фильтрующего метода расширения

        //FilterByPrice содержит доп параметр decimal minimumPrice, исп. для фильтрации товаров
        //public static IEnumerable<Product> FilterByPrice( this IEnumerable<Product> productEnum, decimal minimumPrice)
        //{
        //   foreach (var prod in productEnum)
        //   {
        //     if ((prod?.Price ?? 0) >= minimumPrice)
        //     {
        //        yield return prod;
        //     }
        //   }
        // }
        #endregion

        #region Добавление универсального метода расширения  для фильтрации обьектов с помощью лябда-выражения

        //аргументом Func<Product, bool> selector, является функция принимающая обькт Product и возвращающая true,
        //метод Filter вызвает ее для каждого обьекта Product и включает в результат, если функция возвращает true.
        public static IEnumerable<Product> Filter(
            this IEnumerable<Product> productEnum,
            Func<Product, bool> selector)
        {
            foreach (var product in productEnum)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }

        #endregion
    }
}