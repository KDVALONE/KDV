using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrgrmDictonary
{
    class Program
    {
        /// <summary>
        /// Цель, получить ключ или занчение из словаря отдельно, не оп паре.
        /// Dictonary  реализует IEnumerable то можно обратиться к первому элементу или последнему.
        /// Или по индексу.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string v = "";
            string k = "";
            Dictionary <string, string> QestDescriptionDict = new Dictionary<string, string>();
            QestDescriptionDict.Add("Ключ1", "значение1");
            QestDescriptionDict.Add("Ключ2", "значение2");
            QestDescriptionDict.Add("Ключ3", "значение3");
            QestDescriptionDict.Add("Ключ4", "значение4");
            v = QestDescriptionDict.FirstOrDefault().Value ;  
            k = QestDescriptionDict.FirstOrDefault().Key;
            Console.WriteLine($"{k}{v}");
            Console.WriteLine("Обращение по индексу");
            k = QestDescriptionDict.ElementAt(2).Key;
            v = QestDescriptionDict.ElementAt(2).Value;
            Console.WriteLine($"{k}{v}");
            Console.ReadKey();

        }
    }
}
