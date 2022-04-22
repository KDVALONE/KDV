using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _1MVCMetV2_Cntrllr.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        //мы будем использовать подход Code First, то нам не надо вручную создавать базу данных и наполнять ее данными.
        /*Класс DropCreateDatabaseAlways позволяет при каждом новом запуске заполнять базу данных заново некоторыми начальными данными.
         * В качестве таких начальных значений здесь создаются три объекта Book. 
         * Используя метод db.Books.Add мы добавляем каждый такой объект в базу данных*/

        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });

            base.Seed(db);
        }
    }
}