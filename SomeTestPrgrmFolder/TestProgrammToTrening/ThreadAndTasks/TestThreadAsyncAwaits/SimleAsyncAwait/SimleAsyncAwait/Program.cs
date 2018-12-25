using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimleAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Запускаем метод в потоке №{Thread.CurrentThread.ManagedThreadId}");
            Method();
            Console.WriteLine($"Управление вернулось к вызвавшему коду в потоке №{Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }
        static private async void Method() // более простой код, вызова задач в потоках
        {
            await Task.Run(() => { Console.WriteLine($" start1 in source №{Thread.CurrentThread.ManagedThreadId}"); Thread.Sleep(10000); Console.WriteLine($" ок1 in source №{Thread.CurrentThread.ManagedThreadId}"); });

            await Task.Run(() => { Console.WriteLine($" start2 in source №{Thread.CurrentThread.ManagedThreadId}"); Thread.Sleep(5000); Console.WriteLine($" ок2 in source №{Thread.CurrentThread.ManagedThreadId}"); });

            await Task.Run(() => { Console.WriteLine($" start3 in source №{Thread.CurrentThread.ManagedThreadId}"); Thread.Sleep(4000); Console.WriteLine($" ок3 in source №{Thread.CurrentThread.ManagedThreadId}"); });

        }
    }
}
