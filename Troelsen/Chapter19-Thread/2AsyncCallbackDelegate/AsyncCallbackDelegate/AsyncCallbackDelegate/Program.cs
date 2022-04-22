using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCallbackDelegate
{
        public delegate int BinaryOp(int x, int y);
        class Program
        {
            private static bool isDone = false;
            static void Main(string[] args)
            {
                Console.WriteLine("*********Async Callback Delegate ********");
                Console.WriteLine("Main() Invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
                //вывести id текущего потока.

                BinaryOp b = new BinaryOp(Add);// add запуститься во вторичном потоке
                IAsyncResult iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null); //AsyncCallback - параметр принимающий делегат, который вызывает передаваемый в него метод, при завершении запущенного асинхронного метода
                while (!isDone)
                {
                Thread.Sleep(1000);
                Console.WriteLine($"Working... {Thread.CurrentThread.ManagedThreadId}"); // пока в другом потоке не завершиться метод Add бедет выводиться сообщение
                }
                Console.ReadLine();

       
            }
        static int Add(int x, int y)
        {
            Console.WriteLine("Add() Invoked in thread {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);// ждем 5 секунд, имитируя длительность
            return x + y;
        }
        static void AddComplete(IAsyncResult itfAr) // метод для делегата AsyncCallback , в данном примере параметр IAsyncResult itfAr не используется
        {
            Console.WriteLine("AddComplete() Invoked in thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            isDone = true;
           
        }

    }
}

