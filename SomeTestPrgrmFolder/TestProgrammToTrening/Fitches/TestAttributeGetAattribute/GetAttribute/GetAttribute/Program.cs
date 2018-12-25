using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SomeNamespace
{
    /// <summary>
    /// Создаем список из наследника класса, и выводим на печать только тех кто помечен атрибутом.
    /// Сам атрибут, помечаем спецальным атрибутом, чтоб он не наследовался наследникам класса, 
    /// </summary>
    public abstract class Book
    {
        public virtual void Print() { }
        public string Name
        {
            get; private set;
        }
    }

    [Author("Book style")]
    public class Roman : Book
    {
        public override void Print() { Console.WriteLine("Roman"); }
        public string Name
        {
            get; set;
        }

        public Roman()
        {
            Name = "Tolstouy";
        }
    }

    public class Comix : Book
    {
        public override void Print() { Console.WriteLine("Comix"); }
        public string Name
        {
            get; private set;
        }
        public Comix()
        {
            Name = "Lee";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> BookList = new List<Book>();
            Type ourtype = typeof(Book);
            Type[] types = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype)).ToArray();
            for (int i = 0; i < types.Length; i++)
            {
                AuthorAttribute IsMyAtrribute = (AuthorAttribute)Attribute.GetCustomAttribute(types[i], typeof(AuthorAttribute));
                if (IsMyAtrribute != null)
                {
                    BookList.Add((Book)Activator.CreateInstance(types[i]));
                    Console.WriteLine(IsMyAtrribute.V);
                }
            }

            foreach (Book b in BookList)
            {
                b.Print();
                Console.WriteLine(b.Name);
            }
            Console.ReadKey();
        }
    }



}