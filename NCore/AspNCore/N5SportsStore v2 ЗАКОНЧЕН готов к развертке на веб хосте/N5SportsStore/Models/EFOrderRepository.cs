using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace N5SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;
        public EFOrderRepository(ApplicationDbContext ctx) {
            context = ctx;
        }
        /// <summary>
        /// Методы Include() и ThenInclude() что когда обьект Order читается из базы то также
        /// должна загружаться коллекция ассоциированная со свойствами Lines вместе с Products
        /// это гарантирует получение всех данных не выполняя запросы и не собирая их напрямую.
        /// </summary>
        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            //тут исключается добавление лишних данных в БД подробнее стр 296.
            context.AttachRange(order.Lines.Select(l => l.Product));
            if(order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
