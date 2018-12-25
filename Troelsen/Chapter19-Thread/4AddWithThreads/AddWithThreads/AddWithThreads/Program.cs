using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddWithThreads
{
    /// <summary>
    /// вызвать метод с параметрами в другом потоке .
    /// Для передачи метода с параметрами использовать делегат ParametrizedThreadStatrt
    /// Для ожидания выполнения задачи  другом потоке использовать событие AutoResetEvent()
    /// </summary>
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false); // false показывает что уведомления пока не было
        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0}+{1} is {2}",ap.a, ap.b, ap.a + ap.b);
                // вызвать метод Set для сообщения что работа закончена, на том же экземпляре AutoResteEvent
                waitHandle.Set();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("******** Adding with Thread object ********");
            Console.WriteLine("ID of Thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
            //Создать обьект Params для передачи вторичному потоку.
            AddParams ap = new AddParams(10,10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);
            //ждем завершения другого потока, для этого в точке ожидания вызовем метод  WatitOne у экз. типа AutoResteEvent
            waitHandle.WaitOne();
            Console.WriteLine("Действие в Main : {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }
    }
    class AddParams
    {
        public int a, b;
        public AddParams(int numb1, int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }

    

}
