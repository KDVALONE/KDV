using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace AsyncAwaitEx
{
    /// <summary>
    /// Программа как шпора по Async Await
    /// Метод помеченный как Async МОЖЕТ но НЕ ДОЛЖЕН содержать конструкцию Await которая позволяет запускать методы в другом потоке, через TASK, и передает управление в вызывающий метод
    /// Так же мотод можно просто запустить асинхронно добавя в конструкцию TASK
    /// Пока выполняется асинхронная задача  Task.Run(() => a.Go(20)); (а она может выполняться довольно продожительное время),
    /// выполнение кода возвращается в вызывающий метод - то есть в метод Main. 
    /// Если асинхронный метод ПОМЕЧЕН await то пока не выполниться он,
    /// то другие методы следующие за ним запускаться не будут и он будет асинхронно работать с методом main один 
    /// </summary>
    class Program
    {

        public static void Main()
        {
            A a = new A();
            a.GoAsync();
            for (int i = 0; i < 200; i++) Console.WriteLine($"Main in Thread №{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"**End Main in Thread №{Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();

            /*
            Ход выполнения.
             - Выполнятеся FOO - синхронно, пока не закончится ничего другого работать не будет

             - Выполняется await GO - асинхронно, управление передается в Мain и он асинхронно выполняется с GO, 
               т.к. GO - ПОМЕЧЕН await то пока не выполниться он, GO2 и BAR не запускаются   

             - Запускается GO2 - асинхронно, управление НЕ передается в Мain а продолжает идти в методе GoAsync, метод GO2 начинает асинхронно выполняться в новом потоке,
               так как он НЕ ПОМЕЧЕН await то запукается метод BAR
            
            - Запускается BAR - асинхронно, управление НЕ передается в Мain а продолжает идти в методе GoAsync, метод BAR начинает асинхронно выполняться в новом потоке
              так как он НЕ ПОМЕЧЕН await то  он асинхронно выполняется с GO2 и BAR и MAIN

            - Если метод Main отработал быстрее то программа завершиться, не дождавшись завершения GO1, GO2 и BAR
              но так как в неме есть Console.ReadKey();, то главынй метод ждет ввода кнопки, пока завершаются оставшиеся асинхронные методы
           */

        }

    }


    public class A
    {

        // асинхронные методы принято именовать с суфиксом Async, так же  метод который МОЖЕТ содержать конструкцию await нужно помечать кл.словом async
        public async void GoAsync()
        {
            A a = new A();

            // FOO выполняется синхронно, тоесть последовательно
            Foo(200);

            // GO запускается в отельном асинхронном потоке, операция может завершиться после завершения метода Main если операция длительная
            // выполнение кода ВОЗВРАЩАЕТСЯ в вызывающий метод(Main), и начинается асинхоронное выполнение GO и выполняется метод Main, 
            // так как метод помечен Await то пока он ен выполниться методы GO2 и BAR выполняться не будут
            await Task.Run(() => a.Go(200));

            // GO2 запускается в отельном асинхронном потоке, (операция может завершиться после завершения метода Main если операция длительная)
            // выполнение кода НЕ ВОЗВРАЩАЕТСЯ в вызывающий метод(Main), и начинается асинхоронное GO2,  метод Main(если он еще не завершился) продолжет выполняться
            // так как метод не помечен Await то запаускается следующий метод BAR 
            Task.Run(() => a.Go2(200));
            // BAR запускается в отельном асинхронном потоке, (операция может завершиться после завершения метода Main если операция длительная),
            // выполнение кода НЕ ВОЗВРАЩАЕТСЯ в вызывающий метод(Main), и начинается асинхоронное BAR в новом потоке, методы Main(если он еще не завершился), GO2(если он еще не завершился) продолжают выполняться
            // так как метод не помечен Await то он работает асинхронно с другими запущенными методами
            Task.Run(() => a.Bar(200));
           
          
        }

        public void Foo(int n = 5)
        {

            for (int a = 0; a < n; a++)
            {
                Console.WriteLine($"FOO in Thread №{Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine($"**End FOO in Thread №{Thread.CurrentThread.ManagedThreadId}");
        }
        public void Go(int n = 5)
        {
            for (int a = 0; a < n; a++)
            {
                Console.WriteLine($"GO in Thread №{Thread.CurrentThread.ManagedThreadId}");
             
            }
            Console.WriteLine($"**End GO in Thread №{Thread.CurrentThread.ManagedThreadId}");
        }
        public void Go2(int n = 5)
        {
            for (int a = 0; a < n; a++)
            {
                Console.WriteLine($"GO2 in Thread №{Thread.CurrentThread.ManagedThreadId}");
                //  Thread.Sleep(500);
            }
            Console.WriteLine($"**End GO2 in Thread №{Thread.CurrentThread.ManagedThreadId}");
        }
        public void Bar(int n = 5)
        {

            for (int a = 0; a < n; a++)
            {
                Console.WriteLine($"BAR in Thread №{Thread.CurrentThread.ManagedThreadId}");
            }
            Console.WriteLine($"**End BAR in Thread №{Thread.CurrentThread.ManagedThreadId}");
        }
    }


}
