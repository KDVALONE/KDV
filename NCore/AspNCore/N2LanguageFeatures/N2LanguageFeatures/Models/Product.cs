using System.Security.Cryptography.X509Certificates;

namespace N2LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            InStock = stock;
        }
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; }
        public static Product[] GetProducts()
        {
            Product kayak = new Product {Name = "Kayak", Category = "Water Craft",Price = 275M};
            Product lifejacet = new Product(false) {Name = "Lifejacket", Price = 48.95M};

            kayak.Related = lifejacet;

            return new Product[] { kayak, lifejacet, null };
        }
    }
}