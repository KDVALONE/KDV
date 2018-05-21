using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMetaintSimple
{
    class Program
    {
        delegate void GetMessage(); // обьявляем тип делегата (ничего не возврачает и ничего не принимает)

        static void Main(string[] args)
        {
            if (DateTime.Now.Hour < 12)
            {
                Show_Message(GoodMorning);  // отправляем в  метод регистратор делегата, подходящий метод.
            }
            else
            {
                Show_Message(GoodEvening);
            }
            Console.ReadLine();
        }
        private static void Show_Message(GetMessage _del) // в метод передаем переменную делегатного типа.(которая которая будет отвечать требованиям для вызываемого метода.)
        {
            _del.Invoke(); // вызываем переданные в делегат метод коммандой .Invoke()
        }
        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }
    }
}
