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
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Product prod in cartParam.Products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }

      
    }
}