using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1MVC5Met.Models
{/// <summary>
/// второй класс - модель Purchase, которая будет отвечать за отдельную совершаемую покупку книги
/// </summary>
    public class Purchase
    {
        // ID покупки
        public int PurchaseId { get; set; }
        // имя и фамилия покупателя
        public string Person { get; set; }
        // адрес покупателя
        public string Address { get; set; }
        // ID книги
        public int BookId { get; set; }
        // дата покупки
        public DateTime Date { get; set; }
    }
}