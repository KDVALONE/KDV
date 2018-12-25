using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegate
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Async Delegate ********");
            Console.WriteLine("Main() Invoked on thread {0}.",Thread.CurrentThread.ManagedThreadId);
            //вывести id текущего потока.

            BinaryOp b = new BinaryOp(Add);// add запуститься во вторичном потоке
            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);
            while (!iftAR.IsCompleted)
            {
                Console.WriteLine("Doing more in Main()"); // пока в другом потоке не завершиться метод Add бедет выводиться сообщение
                Thread.Sleep(1000);

            }
            Console.WriteLine("Doing many work in Main()!");
            int answer = b.EndInvoke(iftAR);// можно просто b.(10,10);
            Console.WriteLine($"10+10 is {answer}");
            Console.ReadLine();
        }

        static int Add(int x, int y) 
        {
            Console.WriteLine("Add() Invoked in thread {0}",Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);// ждем 5 секунд, имитируя длительность
            return x + y;
        }
    }
}
