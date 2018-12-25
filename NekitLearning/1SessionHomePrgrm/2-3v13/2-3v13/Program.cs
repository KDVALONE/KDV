using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3v13
{
   /* Определить будут ли прямые A1x+B1y+C1 и A2x+B2y+C2 перпендикулярны.
Если нет, то найти угол между ними.*/

    class Program
    {
        static void Main(string[] args)
        {
            double a1x, b1y, c1, a2x, b2y, c2;
            do
            {
                Console.WriteLine($" Введите значения коэффицента a1x : ");
                a1x = GetValue();
                Console.WriteLine($" Введите значения коэффицента b1y : ");
                b1y = GetValue();
                Console.WriteLine($" Введите значения коэффицента c1 : ");
                c1 = GetValue();
                Console.WriteLine($" Введите значения коэффицента a2x : ");
                a2x = GetValue();
                Console.WriteLine($" Введите значения коэффицента b2y : ");
                b2y = GetValue();
                Console.WriteLine($" Введите значения коэффицента c2 : ");
                c2 = GetValue();
                
    if (!IsLine(a2x, b2y))
                {
                    Console.WriteLine("Заданные линии не являютя прямыми, " +
                                       "так как a2x и b2y не должны ровняться 0 одновременно. Попробуйте заного");
                }
            } while (!IsLine(a2x, b2y));

            if (IsPerpendicular(a1x, a2x, b1y, b2y))
            {
                Console.WriteLine("Прямые перпендикулярны");
            }
            else
            {
                Console.WriteLine($"Прямые не перпендикулярны, угол равен {GetAngle(a1x,a2x,b1y,b2y)}");
            }
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
        protected static bool IsLine(double a2x, double b2y)
        {
            return a2x == 0 && b2y == 0 ? false : true; // это тренарный оператор, время учиться, прочитай про него.=)
            
        }
        protected static bool IsPerpendicular(double a1x, double a2x, double b1y, double b2y) {
            return (a1x * a2x + b1y * b2y) == 0 ? true : false;
        }
        protected static double GetAngle(double a1x, double a2x, double b1y, double b2y) {
            return Math.Abs((Math.Atan((a1x * b2y - a2x * b1y) / (a1x * a2x + b1y * b2y))) * 180 / Math.PI);
        }

    }
}
