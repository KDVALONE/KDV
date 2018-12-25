using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1
{/*Вычислить периметр и площадь прямоугольного треугольника по заданным длинам двух катетов a и b.
    (только S)*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Катет A прямоугольного треугольника = ");
            double a = GetValue();
            Console.WriteLine("Введите Катет B прямоугольного треугольника = ");
            double b = GetValue();
            Console.WriteLine($"Ответ: Площадь прямоугольного треугольника = {GetSqare(a, b)}");
            Console.ReadLine();
        }

        protected static double GetValue()
        {
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            double value;
            do
            {
                enteredValue = Console.ReadLine();
                if (!double.TryParse(enteredValue, out value) & Convert.ToDouble(enteredValue) < 0)
                {
                    Console.WriteLine("Вы ввели не двоичное число или число меньше 0. Используйте зяпятую что бы отделить дробь. Попробуйте ще раз.");
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
      
        public static double GetSqare(double a, double b)
        {
            return 0.5*(a * b);
        }
    }
}
