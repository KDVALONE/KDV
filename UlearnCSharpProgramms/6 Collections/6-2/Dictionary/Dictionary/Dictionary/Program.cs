using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
В отпуске Вася не тратил время зря, а заводил новые знакомства. Он знакомился с другими крутыми программистами,
отдыхающими с ним в одном отеле, и записывал их email-ы.
В его дневнике получилось много записей вида <name>:<email>.
Чтобы искать записи было быстрее, он решил сделать словарь, в котором по двум первым буквам 
имени можно найти все записи его дневника.
Вася уже написал функцию GetContacts, которая считывает его каракули из блокнота. Помогите ему сделать все остальное!

Разбить запись на имя и email вам поможет уже знакомый метод Split у строки
Проверяйте наличие ключа в словаре перед добавлением

Aaron:А@A.A
 
     
*/
namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfFriends = new List<string>{ "Aaron:А@A.A", "б:xrlsr@nsl.jm", "бв:vidvv@utqvn.tv", "aaron:FssА@yandex.ru","Marx:Capital@ussr.com","Lexa:lex@l.ru", "Margareth:Marge@Marg.A","Aalex:Alex@z.com","D:Devil@hell.net", };
            Dictionary<string, List<string>> phoneBook;
            phoneBook =  OptimizeContacts(listOfFriends);
            foreach (var e in phoneBook)
            {
                Console.WriteLine( $"{e.Key}" );
                foreach (var f in e.Value)
                {
                    Console.WriteLine($"{f}");
                }
                
            }
            Console.ReadKey();
        }


        private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            var dictionary = new Dictionary<string, List<string>>();
            foreach (string e in contacts)
            {
                string[] splitedText;
                string firstSymbolsOfName;
                string currentKey;
                splitedText = e.Split(':');

                firstSymbolsOfName = splitedText[0].Length >= 2 ?
                  splitedText[0].Substring(0, 2) :
                  splitedText[0].Substring(0, 1);
                currentKey = firstSymbolsOfName.Count() < 2? firstSymbolsOfName + ":" : firstSymbolsOfName;
                
                IEnumerable<string> friends = from c in contacts
                                              where (c.StartsWith($"{currentKey}"))
                                              select c ;
                if (!dictionary.ContainsKey($"{firstSymbolsOfName}")) {
                   
                    List<string> friendMail = new List<string>();
                    foreach (string friend in friends) {
                       friendMail.Add(friend);
                    }
                    dictionary.Add(firstSymbolsOfName, friendMail);
                    }
            }
            return dictionary;
        }
    }



}