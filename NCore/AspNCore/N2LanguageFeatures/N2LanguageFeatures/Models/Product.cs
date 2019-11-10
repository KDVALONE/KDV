namespace N2LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public static Product[] GetProducts()
        {
            Product kayak = new Product {Name = "Kayak", Price = 275M};
            Product lifejacet = new Product {Name = "Lifejacket", Price = 48.95M};
            return new Product[] {kayak, lifejacet, null};
        }
    }
}