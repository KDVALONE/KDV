using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Variant13
{
    class Program
    {/*Создать консольное приложение, вычисляющее значения переменных 
       по заданным расчетным формулам. Исходные данные вводит пользователь.
       Осуществить проверку вводимых пользователем данных (разрешается вводить только числа).
       На экран вывести значения вводимых исходных данных и результаты вычислений,
       сопровождая ввод и вывод поясняющими комментариями.
       Расчет тестового примера осуществить по заданным в 
       таблице константам (значения исходных данных).*/

        static void Main(string[] args)
        {
            //double a = 0.5;
            //double b = 3.1;
            //double x = 1.4;
            double a ;
            double b ;
            double x ;
            Console.WriteLine("Ведите двоичные значения переменных а, b и x \n" +
                "дробная часть отделяется запятой (пример 3,14)");
            Console.WriteLine("Введите а = ");
            a = GetValue();
            Console.WriteLine("Введите b = ");
            b = GetValue();
            Console.WriteLine("Введите x = ");
            x = GetValue();
            Console.WriteLine("**********");
            Console.WriteLine("Ответ: ");
            Console.WriteLine("Z = "+ GetZ(a,b,x));

            if (a == 0 && b == 0)
            {
                Console.WriteLine("a и b == 0, решения для W не существует"); 
            }
            else
            {
                Console.WriteLine("W = " + GetW(a, b, x));
            }
           Console.ReadKey();

        }
        protected static double GetValue()
        {
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            double Value;
            do
            {
                enteredValue = Console.ReadLine();
                if (!double.TryParse(enteredValue, out Value) & Convert.ToDouble(enteredValue) < 0)
                {
                    Console.WriteLine("Вы ввели не двоичное число. Используйте зяпятую что бы отделить дробь. Попробуйте ще раз.");
                    flagOfEnterdCount = false;
                }
                else
                {
                    Value = Convert.ToDouble(enteredValue);
                    flagOfEnterdCount = true;
                }
            } while ((flagOfEnterdCount == false));

            return Value;
        }
        protected static double GetZ(double a, double b, double x)
        {
            double Z =0.0;
            Z = Math.Sqrt(a * x * Math.Sin(2 * x) + Math.Exp(-2*x) * (x + b));
            return Z;
        }
        protected static double GetW(double a, double b, double x)
        {
                      double W = 0.0;
                W = (Math.Pow(Math.Cos(Math.Pow(x, 3)), 2)) - (x / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)));
                return W;
        }
    }
}

