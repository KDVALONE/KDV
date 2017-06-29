using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{
    class Program
    {
        // Главный класс. 
        // Программа с разбором всех сортировок
        // вводим массив, выбираем сортировку, получаем ответ.

        static void Main()
        {
            int a = Int32.Parse(Console.ReadLine()); 
            GetMessage(a);

        }
    }
}
