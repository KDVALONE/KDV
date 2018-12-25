using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1v15
{/*Создать консольное приложение, вычисляющее значения переменных по
   заданным расчетным формулам. Исходные данные вводит пользователь. 
   Осуществить проверку вводимых пользователем данных 
   (разрешается вводить только числа). На экран вывести значения вводимых
   исходных данных и результаты вычислений, сопровождая ввод и 
   вывод поясняющими комментариями.

   Расчет тестового примера осуществить 
   по заданным в таблице константам (значения исходных данных)*/
    class Program
    {
        static double m = 0.7;
        static double c = 2.1;
        static double x = 1.7;
        static double a = 0.5;
        static double b = 1.8;
        static string mName = "n";
        static string cName = "c";
        static string xName = "x";
        static string aName = "a";
        static string bName = "b";

        static void Main(string[] args)
        {
            if (IsHandcraftedValue())
            {
                m = SetValue(mName);
                c = SetValue(cName);
                x = SetValue(xName);
                a = SetValue(aName);
                b = SetValue(bName);
            }
            Console.WriteLine($"Ответ z ={GetExpressionZ(m, c, x, a, b)} ");
            Console.WriteLine($"Ответ s ={GetExpressionS(m, c, x, a, b)} ");
            Console.ReadKey();
        }

        protected static bool IsHandcraftedValue()//ручной ли ввод?
        {
                Console.WriteLine("Вы хотите ввести переменные вручную, или использовать значения по умолчнию? \n" +
                    "Значения по умолчанию: m=0.7 c=2.1 x=1.7 a=0.5 b=1.8  \n");
                bool doing = true;
                string enteredString;
                do
                {
                    Console.WriteLine("Введите 'y' или нажмите Enter для ручного ввода \n" +
                    "Введите 'n' для автоматического заполнения  ");
                    enteredString = Console.ReadLine();

                    if (enteredString.Contains('y') || enteredString.Contains('Y') ||
                    enteredString.Contains('у') || enteredString.Contains('У') ||
                    enteredString == "" || enteredString.Contains('н') || enteredString.Contains('Н') ||
                    enteredString.Contains('N') || enteredString.Contains('n'))
                    { doing = false; }
                    else
                    {
                        doing = true;
                        Console.WriteLine("Вы ввели не корректные данные, попробуйте еще раз");
                    }
                } while (doing);

                if (enteredString.Contains('y') || enteredString.Contains('Y') ||
                    enteredString.Contains('у') || enteredString.Contains('У') ||
                    enteredString == "")
                {
                    return true;
                }
                else { return false; }
            }
       
        protected static double SetValue(string valueName)
        {
            Console.WriteLine($"Введите двоичное число для переменной {valueName}: "  );
            bool flagOfEnterdCount = true; //маркер введено ли корректное значение
            string enteredValue = ""; // переменная для вводимого значения в формате string
            double value; // возварщаемое значение метода в формате double
            do
            {
                enteredValue = Console.ReadLine();
                //if (!double.TryParse(enteredValue, out value)& Convert.ToDouble(enteredValue) < 0) // если нужно ограничить значения только положительными числами
                if (!double.TryParse(enteredValue, out value)) // можем ли привести введеное значение типа string к типу double 
                {
                    Console.WriteLine("Вы ввели не двоичное число. Используйте зяпятую что бы отделить дробь. Попробуйте ще раз.");
                    flagOfEnterdCount = false;
                }
                else
                {
                    value = Convert.ToDouble(enteredValue);
                    flagOfEnterdCount = true;
                }
            } while ((flagOfEnterdCount == false));

            return value;
        }

        protected static double GetExpressionZ(double m, double c, double x, double a, double b)
        {
            return (Math.Sin(x) / (Math.Sqrt(m * m + Math.Pow(Math.Sin(x),2)))) - c * m * Math.Log(m * x);
        }
        protected static double GetExpressionS(double m, double c, double x, double a, double b)
        {
            return Math.Exp((-a) * x) * Math.Sqrt(x + 1) + Math.Exp((-b) * x) * Math.Sqrt(x + 1.5);
        }
    }
}
