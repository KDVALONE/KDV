using System.Collections;
using System.Collections.Generic;
using  N4WorkingWithVisualStudio.Models;

namespace N4WorkingWithVisualStudio.Test
{
    /// <summary>
    /// Класс возвращающий полседовательность массивов обьектов последоватлености, каждый из которых
    /// содержит один набор аргументов передаваемых тестовому методу. Это позволит сделать так чтоб тестовый метод
    /// не работал если кол-во аргументов переданных в т.метод не соответствует его сигнатуре.
    ///
    /// В классе закрытые методы и свойства определяли наборы т.данных которые с помощью  GetEnumerator() обьединялись
    /// в последовательность массивов обьектов.
    /// </summary>
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return  new object[] { GetPricesUnder50() };
            yield return new object[] { GetPricesOver50 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<Product> GetPricesUnder50()
        {
            decimal[] prices = new decimal[] { 275, 49.95M, 19.50M, 24.95M };
            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product {Name = $"P{i + 1}", Price = prices[i]};
            }
        }

        private Product[] GetPricesOver50 => new Product[]
        {
            new Product {Name = "P1", Price = 5},
            new Product {Name = "P2", Price = 48.95M},
            new Product {Name = "P3", Price = 19.50M},
            new Product {Name = "P4", Price = 24.95M}
        };
    }
}