using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramEventDeletAfter2
{

    /// <summary>
    /// 1- анонимные методы, обобщенный делегат, обобщенное событие, лямбда выражение
    /// <param name="e"></param>
    /// 

    public delegate void MyDelegateHandler(object sender, MyEventArgs e);
    
    class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            MyEventClass mec = new MyEventClass();
            ClassA ca = new ClassA();


            Console.WriteLine("выведем результат выполнения события1");
            mec.MyEvent += ca.Method;
            mec.MyEvent += ClassB.MethodStatic;
            mec.MyEvent += delegate { Console.WriteLine("Анонимный метод"); }; // анонимный метод.
            mec.MyEvent += (object sender, MyEventArgs e) => { Console.WriteLine("Лямбда вырожение"); };// лямбда вырожение, упрощающее написание анонимного метода

            mec.StartMyEvent(a);


            Console.WriteLine("выведем результат выполнения события2");
            mec.MyEvent2 += ClassB.MethodStatic;
            mec.StartMyEvent2(a);

            Console.ReadKey();


        }
    }

    public class MyEventClass
    {
        public event MyDelegateHandler MyEvent;
        public event EventHandler<MyEventArgs> MyEvent2; // тут используется обобщенный делегат EventHandler, используя его мы не 
                                                         // обязанны определять тип делегата в коде, мы сразу пишем строку события, а EventHandler имеет входные параметры object sender,  EventAgrs e
                                                         // по сути одной строчкой мы сделали тоже самое что и до этого при обьявлении MyEvent, только убрав созданный явно делегат MyDelegateHandler

        public void StartMyEvent(int val)
        {
            MyEvent?.Invoke(this,new  MyEventArgs(val));
        }
        public void StartMyEvent2(int val)
        {
            MyEvent2?.Invoke(this, new MyEventArgs(val));
        }

    }

    public class ClassA
    {
        public void Method(object sender, MyEventArgs e) { Console.WriteLine($"METHOD вернул {e.Value}"); }
    }
    public static class ClassB
    {
        public static void MethodStatic(object sender, MyEventArgs e)
        {
            Console.WriteLine("STATIC METHOD вернул {0}", e.Value);
        }
    }

    public class MyEventArgs : EventArgs
    {
        public int Value { get; set; }
        public MyEventArgs( int value)
        {
            this.Value = value;
        }
    }
}
