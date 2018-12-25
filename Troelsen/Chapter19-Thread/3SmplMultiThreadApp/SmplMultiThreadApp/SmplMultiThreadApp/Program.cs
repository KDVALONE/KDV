using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SmplMultiThreadApp
{/// <summary>
/// подключить библиотеку Windows.Forms.dll через nuget (пкм-- в обозревателе на имени прокета -- управление nuget ) 
/// если программа выполняется в 1 потоке, то сначала вывести все цифры а потом message box
/// если прогрмма выполняется в 2 потоках, то паралельно вывести мессадж бокс и цифры
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Thread App *******");
            Console.WriteLine("Do you whant [1] or [2] thread ?");
            string threadCount = Console.ReadLine(); //Запрос количества потоков
            // дать имя потоку
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            //вывести информацию о потоке
            Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);
            //создать рабочий класс
            Printer p = new Printer();
            switch (threadCount)
            {
                case "2":
                    //создать поток
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));// deltgate ThreadStart() может указывать только на void методы без аргументов
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I dont know you want... you get 1 thread.");
                    goto case "1";// переход к варианту с 1 потоком
            }
            // выполнить дополнитьельную работу.
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
            
        }
    }
    class Printer
        {
        public void PrintNumbers()
        {
            //вывести информацию о потоке.
            Console.WriteLine($"{Thread.CurrentThread.Name} is executing PrintNumbers()");
            //вывести числа.
            Console.WriteLine("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}, ",i );
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
        }
}
