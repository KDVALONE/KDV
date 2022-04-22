using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace _1MVCMetV2_Cntrllr.Models
{
    /*
     purchase - покупка
     модель Purchase, которая будет отвечать за отдельную совершаемую покупку книги
     свойство идентификатора модели должна иметь имя либо Имя_моделиId, либо просто Id.
     cвойство PurchaseId- данное свойство является первичным ключом. 
    */
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