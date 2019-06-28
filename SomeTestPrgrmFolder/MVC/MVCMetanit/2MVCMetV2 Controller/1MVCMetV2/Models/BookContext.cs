using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using _1MVCMetV2_Cntrllr.Models;

namespace _1MVCMetV2_Cntrllr.Models
{
    /*
    Контекст данных использует EntityFramework для доступа к БД на основе некоторой модели. Итак, добавим в папку Models новый класс BookContext: 
    */
    public class BookContext : DbContext
        {
        /*Свойства наподобие public DbSet<Book> Books { get; set; } помогают получать из БД набор данных определенного типа (например, набор объектов Book).*/
            public DbSet<Book> Books { get; set; }
            public DbSet<Purchase> Purchases { get; set; }
        }
    
}