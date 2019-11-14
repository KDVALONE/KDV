using System.Collections.Generic;
using System.Collections;
namespace N2LanguageFeatures.Models
{
    /// <summary>
    /// Класс служащий оболочкой для последовательности обькетов Product
    /// </summary>
    public class ShoppingCart : IEnumerable<Product>
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}