using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadTest
{/// <summary>
/// Оттестить потоки.
///    1. Создать несколько потоков
///    2. Отработать, Асинхронные делегаты  (Ну такое, BeginEnvoke и EndInvoke, лучше применять assync await)
/// ок 3. Отрабтать асинхронные потоки c ThreadStart,ParametrizedThreadStart
///    4. Отрабоать паралельные потоки.
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            ClassOne cone = new ClassOne();
            ClassTwo ctwo = new ClassTwo();
            ClassTwo ctwo2 = new ClassTwo(20);
            Thread thread1 =  Thread.CurrentThread;
            thread1.Name = "Поток1";
            Thread thread2 = new Thread (new ThreadStart(ctwo.Print));
            thread2.Name = "Поток2";
            void Add(object data)
            {
                if (data is ClassTwo)
                {
                    ClassTwo ct = (ClassTwo)data;
                    ct.PrintWithParametes(ct.A);
                }
            } 
            Thread thread3 = new Thread(new ParameterizedThreadStart(Add)); // парам ParameterizedThreadStart делегат, принимающий метод который должен принимать тип object
            thread3.Name = "Поток3";
            Thread thread4 = new Thread(new ThreadStart(ctwo.Print));
            thread4.Name = "Поток4";
            Thread thread5 = new Thread(new ThreadStart(ctwo.PrintLock));
            thread5.Name = "Поток5";
            Thread thread6 = new Thread(new ThreadStart(ctwo.PrintLock));
            thread6.Name = "Поток6";

            #region Assync Threads
            #region ThreadStart
            // запускаем в разных потоках метод одного и того же экзепляра класса, ошибка в том что иногда так как код не безопасный
            // будут получаться одинаковые занчения например 5 и 5 

            // thread2.Start();
            // thread4.Start();
            #endregion
            #region ParametizedThreadStart
            // thread3.Start(ctwo2);
            #endregion
            #region ThreadStartLock 
            // данный код, потоко безопасный, тоесть при выполнении в потоке этого метода одного и тиого же экземпляра
            // класса, другие потоки будут ждать его завершения.

            //thread5.Start();
            //thread6.Start();
            #endregion
            #endregion


            Console.ReadKey();
        }
    }
}
class ClassOne
{
   string Name => "Класс1";
   public void Print()
    {
        
       for(int i =0; i < 15; i++)
        { 
            Console.WriteLine(" Поток = {0}, a = {1} ", Thread.CurrentThread.ManagedThreadId, i);
            Thread.Sleep(500);
        }
        Console.WriteLine("Ура поток {0} закончил",Thread.CurrentThread.ManagedThreadId);
    }
   public void PrintWithParametes( int a)
    {

        Console.WriteLine(" Метод запустился в потоке  {0} c именем {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name);
        for (int i = 0; i < a; i++)
        {
            Console.WriteLine(" Поток = {0}, a = {1}", Thread.CurrentThread.ManagedThreadId, i);
            
        }
        Console.WriteLine("Ура поток {0} закончил", Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(500);
    }
}

public class ClassTwo
{
    string Name => "Класс2";
    public int A { get; set; }
    public int B { get; set; }
    public ClassTwo()
    {
        A = 18; 
    }
    public ClassTwo(int a)
    {
        A = a;
        B = 0; 
    }
    public void Print()
    {
        
        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine(" Поток = {0}, a = {1} B = {2}", Thread.CurrentThread.ManagedThreadId, i,B);
            Thread.Sleep(500);
        }
        Console.WriteLine("Ура поток {0} закончил", Thread.CurrentThread.ManagedThreadId);
       
    }
    public void PrintWithParametes( int a) {
        
            for (int i = 0; i < a; i++)
        {
            Console.WriteLine(" Метод запустился в потоке  {0} c именем {1} а + 1 = {2}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name, i);
            Thread.Sleep(1000);
        }
        
    }
    public void PrintLock()
    {
        lock (this) {     // данный код, потоко безопасный, тоесть при выполнении в потоке этого метода одного и тиого же экземпляра
            // класса, другие потоки будут ждать его завершения.
        for (int i = 0; i < 15; i++)
        {
            Console.WriteLine(" Поток = {0}, a = {1} B = {2}", Thread.CurrentThread.ManagedThreadId, i, B);
        Thread.Sleep(500);
        B++;
        }
        }
        Console.WriteLine("Ура поток {0} закончил", Thread.CurrentThread.ManagedThreadId);
    }
    
  
}