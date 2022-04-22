using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadPrinting
{
    /// <summary>
    /// Так как все потоки приложения имеют равыный доступ ко всем его ресурасам, то 
    /// при доступе к одним и тем же ресуросам они могут получать некорректные данные.
    /// </summary>
    public class Printer
    {
        public void PrintNumbers()
        {
            //вывести инфу о потоке
            Console.WriteLine(" -> {0} is executing PrintNumbers()",Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                //Приостонавить поток на случайный период времени.
                Random rnd = new Random();
                Thread.Sleep(1000 * rnd.Next(5));
                Console.WriteLine($"{i}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ Synchronization Thread **********");
            Printer p = new Printer();
            // создать 10 потоков кот. указ. на один и тот же метод одно и тогоже экез.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {

                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format($"Worker thread #{i}");
            }
            // Запускаем все потоки       
            foreach (Thread t in threads)
                t.Start();
            Console.ReadLine();
        }
    }
}
