using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N5SportsStore.Models;

namespace N5SportsStore.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get;}
        void SaveOrder(Order order);
    }
}
