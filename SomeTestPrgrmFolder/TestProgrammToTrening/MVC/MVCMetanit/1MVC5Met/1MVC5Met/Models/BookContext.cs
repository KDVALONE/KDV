using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using _1MVC5Met.Models.BookStore.Models;

namespace _1MVC5Met.Models.BookStore
{
    //Контекст данных использует EntityFramework для доступа к БД на основе некоторой модели

    //Чтобы создать контекст, нам надо унаследовать новый класс от класса DbContext. 
    //Свойства наподобие public DbSet<Book> Books { get; set; }
    //помогают получать из БД набор данных определенного типа (например, набор объектов Book).
    public class BookContext : DbContext
        {
            public DbSet<Book> Books { get; set; }
            public DbSet<Purchase> Purchases { get; set; }
        }
   
}
