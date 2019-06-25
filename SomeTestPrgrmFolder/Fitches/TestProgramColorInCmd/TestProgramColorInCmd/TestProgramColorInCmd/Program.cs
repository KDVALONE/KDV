using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramColorInCmd
{
    //Вывыести последовательно два слова, одно красным цветом, другое белым
    class Program
    {
        static void Main(string[] args)
        {
            string Text="";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Test  "); // после Write следующая надпись на той же строке
            Console.ResetColor();
            Console.WriteLine(" Test  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("FALLOUT");
            Console.WriteLine("New Vegas");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Ведите текст: ");
            Text = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Вы ввели: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{Text}");
            Console.ReadKey();
        }
    }
}
