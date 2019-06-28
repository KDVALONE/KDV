using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace _1MVCMetV2.Models
{
    /*
     * Первым делом определим модели данных нашего приложения. Поскольку речь идет о книжном магазине, то такими моделями могут быть модель книги и модель покупки книги.
     свойство идентификатора модели должна иметь имя либо Имя_моделиId, либо просто Id.
     cвойство PurchaseId- данное свойство является первичным ключом. 
     */

    public class Book
    {
        // ID книги
        public int Id { get; set; }
        // название книги
        public string Name { get; set; }
        // автор книги
        public string Author { get; set; }
        // цена
        public int Price { get; set; }
    }
}