using System.Collections.Generic;
using System.Linq;

namespace N5SportsStore.Models
{
    //Временный класс для хранения данных, пока не будет реализована полноценная БД.
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Football",Price = 25 },
            new Product {Name = "Surf board",Price = 25 },
            new Product {Name = "Running shoes",Price = 25 }

        }.AsQueryable<Product>();
    }
}