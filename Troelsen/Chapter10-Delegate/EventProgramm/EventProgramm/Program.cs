using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProgramm
{/// <summary>
 /// 0- начал 14:35 сделать до 15:35
 /// 1- сделать 3 события (с параметрами/ без параметров, обобщенные.)
 /// </summary>


        //TODO: Сделать шпору для ANKI на основе примера, очень удобен

    public delegate void MyDelegate(); // делегат для события
    public delegate void MyDelegateEvent(object sender, ClassEventArgs e); // делегат для события с аргументами
    class Program
    {
        static void Main(string[] args)
        {
            ClassA ca = new ClassA();

            Console.WriteLine("********* События*********\n");
            MyEventStartClass mEvnt = new MyEventStartClass(); 
            mEvnt.UserEvent += ca.MethodClassA; // обработчик событий

            Console.WriteLine("Просто вызов события, без oject sender");

            mEvnt.StartEvent();

            Console.WriteLine("********* События с аргументами *********\n");
            ClassB cb = new ClassB();
            MyEventArgStartClass mEvntArg = new MyEventArgStartClass();
            mEvntArg.UserEventAgrs += cb.MethodArgClassB;
           

            mEvntArg.StartMyDelegatAgrs("!!!!передаваеме стринговое занчение в событие!!!!");

            Console.ReadKey();
        }
    }
    class MyEventStartClass
    {
        public event MyDelegate UserEvent;

        public void StartEvent() // метод запуска события
        {
          UserEvent?.Invoke();
        }
    }
    class MyEventArgStartClass
    {
        public event MyDelegateEvent UserEventAgrs;
        public void StartMyDelegatAgrs(string some)
        {
            UserEventAgrs?.Invoke(this, new ClassEventArgs (some));
        }
    }

    class ClassA // содержит методы VOID    
    {
        public void MethodClassA()
        {
            Console.WriteLine("Запускаем void метод класса А");
        }

        public static void MethodStaticClassA()
        {
            Console.WriteLine("Запускаем void STATIC метод класса А");
        }
    }
    class ClassB // содердит методы с возвращаемыми значениями и параметрами
    {
        public string MethodClassB()
        {
            Console.WriteLine("Запускаем string метод класса B, он просто возвращает - ок");
            return "ок";
        }

        public  void MethodArgClassB(object sender, ClassEventArgs e)
        {
            Console.WriteLine($"Запускаем static string метод класса B, который получает занчение {e.value}");
         
        }
    }
   public class ClassEventArgs : EventArgs // клас для события с аргументами, должен наследоваться от event agrs
    {
        public readonly string value;
        public ClassEventArgs(string inValue)
        {
            value = inValue;
        }

    }

}
