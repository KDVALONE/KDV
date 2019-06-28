using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace TestNameSpace
{

    class Program
    {

        public static void Main()
        {
            A a = new A();
            a.Start();
            for (int i = 0; i < 100; i++) Console.WriteLine($"Hello from MAiN in Thread №{Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();

        }

        

    }


   public class A
    {

        public void Start()
        {
            Console.WriteLine("Start ");
            FOO();
            BAR();
            for (int i = 0; i < 100; i++) Console.WriteLine($"Hello from STRAT in Thread №{Thread.CurrentThread.ManagedThreadId}");
        }
        public async  void FOO()
        {
            string b = "FOO";
            Console.WriteLine($"Hello from FOO in Thread №{Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => Go(200,b ));

        }

        public async void BAR()
        {
            string b = "BAR";
            Console.WriteLine($"Hello from BAR in Thread №{Thread.CurrentThread.ManagedThreadId}");
            Task.Run(() => Go(200,b));
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC1 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC2 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Hello from BAR NO ASYNC3 №{Thread.CurrentThread.ManagedThreadId}");

        }

        public void Go(int n,string b)
        {
            for (int a = 0; a < n; a++)
            { 
            Console.WriteLine($"GO in {b} in Thread №{Thread.CurrentThread.ManagedThreadId}");
         
            }
            Console.WriteLine($"** End in Thread №{Thread.CurrentThread.ManagedThreadId}");
        }

    }

}