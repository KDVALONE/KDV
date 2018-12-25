﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2
{/*
    Вычислить площадь и периметр прямоугольника,
    если задана длина одной стороны (a) и коэффициент n (%), 
    позволяющий вычислить длину второй стороны (b=n*a).
   
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону A прямоугольнка = ");
            double a = GetValue();
            Console.WriteLine("Введите коефициент для соотношения сороны B к A= ");
            double precent = GetValue() * 0.01;
            double b = GetB(a,precent);
            Console.WriteLine($"Ответ: Периметр прямоугольнка = {GetPerimetr(a,b)}");
            Console.WriteLine($"Ответ: Площадь прямоугольнка = {GetSqare(a, b)}");
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
        public static double GetB(double a,double precent)
        {
            return precent * a;
        }
        public static double GetPerimetr(double a,double b)
        {
            return (a + b) * 2;
        }
        public static double GetSqare(double a, double b)
        {
            return a * b;
        }
    }
}
