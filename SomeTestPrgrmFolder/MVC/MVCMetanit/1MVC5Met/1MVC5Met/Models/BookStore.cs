using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1MVC5Met.Models
{
    namespace BookStore.Models
    {/// <summary>
     /// первый новый класс Book и добавим в него код, описывающий модель книги
     /// </summary>
        public class Book
        {
            // ID книги
            //свойство идентификатора модели должна иметь имя либо Имя_моделиId, либо просто Id. 
            //Так, у нас в модели Book определено свойство Id, то есть данное свойство является первичным ключом.
            public int Id { get; set; }
            // название книги
            public string Name { get; set; }
            // автор книги
            public string Author { get; set; }
            // цена
            public int Price { get; set; }
        }
    }
}