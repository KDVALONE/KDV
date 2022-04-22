using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1
{
    //В дневнике получилось много записей вида <name>:<email> с даными друзей.
    //Чтобы искать записи было быстрее, нужно сделать словарь, в котором по двум первым буквам имени можно 
    //найти все записи в дневника.
    //Вася уже написал функцию GetContacts, которая считывает его каракули из блокнота. Помогите ему сделать все остальное!

    //       Ва: Ваня: v@mail.ru, Вася: vasiliy@gmail.com, Ваня: ivan@grozniy.ru, Ваня: vanechka@domain.com
    //2      Са: Саша: sasha1995@sasha.ru, Саша: alex@nd.ru, Саша: alexandr@yandex.ru, Саша: a@lex.ru
    //3      Па: Паша: po@p.ru, Паша: pavel.egorov @urfu.ru
    //4      Юр: Юрий: dolgo@rukiy.ru
    //5      Ге: Гена: genadiy.the.best@inbox.ru
    //6      Ы: Ы: nobody @nowhere.no

    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = new List<string>();
            contacts.Add("<Леша>:<lesha@mail.ru>");
            contacts.Add("<Саша>:<Sasha@mail.ru>");
            contacts.Add("<Маша>:<Masha@mail.ru>");
            contacts.Add("<Маня>:<Manya@mail.ru>");
            contacts.Add("<Мася>:<Masya@mail.ru>");


            Console.WriteLine(OptimizeContacts(contacts));
            Console.ReadKey();

        }
        private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            string key = "";
            var dictionary = new Dictionary<string, List<string>>();
            foreach (var contact in contacts)
            {
                string[] someText = contact.Split(':');
    
                foreach (string element in someText)
                {
                    string a = element.Trim('<', '>');
                   key = a.Remove(2, a.Length);
                    dictionary.Add( "Short List", new List<string> { "One", "Two" });
              
                }
            }
            Console.ReadKey();
            return dictionary;
        }
    }
}
