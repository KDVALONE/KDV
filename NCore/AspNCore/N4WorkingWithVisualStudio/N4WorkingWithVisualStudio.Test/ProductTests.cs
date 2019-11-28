using Xunit;
using N4WorkingWithVisualStudio.Models;

namespace N4WorkingWithVisualStudio.Test
{
    /// <summary>
    /// Класс тестирующий класс Product
    /// Составлен по шаблону А/А/А  arrange/act/assert
    /// Имя класса говорит что он тестирует
    /// Имена методов говорят какое поведение или состояние они проверяют
    /// </summary>
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // организация arrange, в него входят условия теста
            var p = new Product { Name = "Test", Price = 100M};
            // действие act, выполнение теста
            p.Name = "New Name";
            // утверждение assert, ожидаемый результат
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            //Орагнизация
            var p = new Product {Name = "Test", Price = 100M};
            //Действие
            p.Price = 200M;
            //Утверждение
            Assert.Equal(200M, p.Price);
        }

    }
}