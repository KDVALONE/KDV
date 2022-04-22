using System.Collections.Generic;

namespace N4WorkingWithVisualStudio.Models
{
    /// <summary>
    /// Интерфейс для изоляции обьектов
    /// </summary>
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product p);
    }
}