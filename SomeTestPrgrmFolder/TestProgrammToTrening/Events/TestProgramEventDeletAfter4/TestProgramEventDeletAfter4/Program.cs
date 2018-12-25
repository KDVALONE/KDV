using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramEventDeletAfter4
{
    class Program
    {
        static void Main(string[] args)
        {
            string message1 = "Сообщение 1";
            string message2 = "Сообщение 2";
         
            string message3 = message1 + message2;
            
            Console.WriteLine($"{message1}хэш: {message1.GetHashCode()} {message2} хэш:{message2.GetHashCode()} = {message3}хэш:{message3.GetHashCode()} ");
            message1 += message2;
            Console.WriteLine($"и теперь выводим 1 переменную в которую добавли вторую{message1}  {message1.GetHashCode()}" );
            message3 += message2;
            Console.WriteLine($"обьединенный {message3}хэш:{message3.GetHashCode()} ");

            Console.ReadKey();
        }
    }




}
