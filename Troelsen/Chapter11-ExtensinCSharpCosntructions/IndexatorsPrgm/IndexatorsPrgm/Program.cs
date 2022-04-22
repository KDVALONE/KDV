using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexatorsPrgm
{/// <summary>
/// Индексаторы, синтаксис похож на обьявление свойств.
/// Служат для обращению к полю вроучную созданной коллекции
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            BookList library  = new BookList();

            Console.WriteLine(library[0].Name);

            library[0] = new Book("Чук и Гек");

            Console.WriteLine(library[0].Name);

            foreach (Book e in library)
            {
                Console.WriteLine($"{e.Name}");
            }


            Console.ReadLine();
        }
    }

    class Book
    {
        public string Name;
        public Book(string name)
        {
            this.Name = name;
        }
    }
    class BookList : IEnumerable
    {
        Book[] books;
        public BookList()
        {
            books = new Book[] {new Book("Отцы и дети"),new Book("Война и Мир"), new Book("Перступление и наказание") };
        }
        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }

        public IEnumerator GetEnumerator() //для перебора коллекции через foreach в принципе 
        //достаточно в классе определить публичный метод GetEnumerator, который бы возвращал объект IEnumerator

        {
            return books.GetEnumerator();
        }
    }



}
