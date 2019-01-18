using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1v13
{/*Протабулировать (это значит найти все решения.) заданную функцию на интервале, задаваемом пользователем,
    и с шагом, задаваемым пользователем. Пользовательский ввод проверять на корректность 
    ввода чисел с плавающей точкой. При невозможности расчета функции в конккретной точке
    выводить значение этой точки и надпись, означающую отсутствие решения. Константные 
    значения границы отрезка табулирования и шага, заданные в таблице, 
    использовать для решения тестовых примеров

    функция y = 3 * x - 14 + Math.Exp(x) - Math.Exp(-x); отрезок [1;3] шаг step =  0,2
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты отрезка");
            Console.WriteLine("Введите точку А ");
            double a = GetValue();
            Console.WriteLine("Введите точку B ");
            double b = GetValue();
            Console.WriteLine("Введите шаг для табуляции  ");
            double step = GetValue();
            GetAllStepsCount(a,b,step);
            Console.ReadKey();
        }
        protected static double GetValue()
        {
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            double value;
            do
            {
                enteredValue = Console.ReadLine();
                if (!double.TryParse(enteredValue, out value))
                {
                    Console.WriteLine("Вы ввели не двоичное число. Используйте зяпятую что бы отделить дробь. Попробуйте еще раз.");
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

        protected static double GetFunc( double x)
        {
            return 3 * x - 14 + Math.Exp(x) - Math.Exp(-x);
        }
        protected static void GetAllStepsCount(double a, double b, double step)
        {
            if (((a <= b) && (step >= 0)) || ((a >= b) && (step <= 0)))
            {
                while (a <= b && step >=0 || ((a >= b) && (step <= 0)))
                {
                    Console.WriteLine($"Ответ:  в точке F({a}) = {GetFunc(step)}");
                    a += step;
                }
            }
            else {
                Console.WriteLine("Табулировние функции по отрезку не возможно, так как шаг вне границы отрезка");
            }

        }
    }
}

