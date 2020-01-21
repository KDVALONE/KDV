using System.Linq;

namespace N5SportsStore.Models
{
    /// <summary>
    /// Класс зависящий от IProductRepository способен получать обьекты Product без необходимости знания детелей того,
    /// как они хранятся. К тому же при запросах LINQ использование данного и. даст возможность получать только те данные,
    /// которые удовлетворяют запросу, а не все, с дальнейшей выборкой, что снизит нагрузку на БД.
    /// </summary>
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
    }
}