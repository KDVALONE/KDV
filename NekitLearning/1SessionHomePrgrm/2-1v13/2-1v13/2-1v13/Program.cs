using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1v13
{/*Заданы длина, ширина и высота параллелепипеда. Определить его объем и площадь поверхности.*/
    class Program
    {
        static void Main(string[] args)
        {
            double length, width, hight;
            Console.WriteLine("Введите длинну, ширину, и высоту паралеппипеда");
            Console.WriteLine("Введите длинну");
            length = GetValue();
            Console.WriteLine("Введите ширину");
            width = GetValue();
            Console.WriteLine("Введите высоту");
            hight = GetValue();
            Console.WriteLine($"Ответ: площадь параллепипеда: {GetSqare(length, width, hight)}");
            Console.WriteLine($"Ответ: обьем параллепипеда {GetVolume(length, width, hight)}");
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

        public static double GetSqare(double l, double w, double h)
        {
            return 2 * ((l * h) + (h * w) + (w * l));
        }
        public static double GetVolume(double l, double w, double h)
        {
            return l*w*h;
        }
    }
}

