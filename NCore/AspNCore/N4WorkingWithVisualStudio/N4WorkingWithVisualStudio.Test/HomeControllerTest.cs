using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using N4WorkingWithVisualStudio.Controllers;
using N4WorkingWithVisualStudio.Models;
using Xunit;

namespace N4WorkingWithVisualStudio.Test
{
    /// <summary>
    /// класс для тестирования боле сложных классов содержащих зависимости
    /// </summary>
    public class HomeControllerTest
    {
        // тест проверяет что метод действия Index() передает представлению все обьекты хранилища
        [Fact]
        public void IndexActionModelComplete()
        {
            //организация
            var controller = new HomeController();
            //действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //утвреждение
            Assert.Equal(SimpleRepository.SharedRepository.Products, model,
                        Comparer.Get<Product>((p1,p2)=>p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}