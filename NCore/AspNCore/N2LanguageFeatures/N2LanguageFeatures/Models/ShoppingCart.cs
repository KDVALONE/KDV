using System.Collections.Generic;

namespace N2LanguageFeatures.Models
{
    /// <summary>
    /// Класс служащий оболочкой для последовательности обькетов Product
    /// </summary>
    public class ShoppingCart
    {
        public IEnumerable<Product> Products { get; set; }
    }
}