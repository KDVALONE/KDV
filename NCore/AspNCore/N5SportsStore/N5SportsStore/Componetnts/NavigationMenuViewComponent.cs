using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using N5SportsStore.Models;

namespace N5SportsStore.Componetnts
{
    /// <summary>
    /// класс наваигационного компонента представления
    /// когда MVC необходимо создать экземпляр класса компонента представления, она отметит отметит потребность в этом аргументе и в классе startup 
    /// обратиться к конфигурации, чтоб посмотреть какой обьект должен исполнятся.
    /// </summary>
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo) {
            repository = repo;
        }

        /// <summary>
        /// в методе с помощью Linq выбирается и упорядочиваетя набор категорий в хранилище, после чего передается аргументом в метод View()
        /// который визуализирует стандартное частичное представление.
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke() {
            return  View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
            
        }
       
    }
}
