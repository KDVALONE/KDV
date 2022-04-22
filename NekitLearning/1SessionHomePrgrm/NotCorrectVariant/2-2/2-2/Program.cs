﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_2
{/*Даны две точки А(х1, у1) и В(х2, у2). Составить алгоритм, 
   определяющий, которая из точек находится ближе к началу координат*/
    class Program
    {
        static void Main(string[] args)
        {
            double x1, y1, x2, y2, sA,sB;
           
            Console.WriteLine("Введите координаты точек  A(x1,y1) и B(x2,y2) \n" +
                              "(Координаты вводятся в формате double разделяя дробь запятой (x1 = 3,14)) ");

            Console.WriteLine("Введите координаты точки A:");
            Console.WriteLine("А х1 = ");
            x1 = GetValue();
            Console.WriteLine("А y1 = ");
            y1 = GetValue();

            Console.WriteLine("Введите координаты точки B:");
            Console.WriteLine("B x2 = ");
            x2 = GetValue();
            Console.WriteLine("B y2 = ");
            y2 = GetValue();

            sA = Math.Abs(GetS(x1, y1, 0, 0));
            sB = Math.Abs(GetS(x2, y2, 0, 0));
            Console.WriteLine($"Ответ: Ближе к началу координат точка {GetCloselyDote(sA,sB)}");
            Console.ReadKey();
        }

        protected static double GetValue()
        {
            bool flagOfEnterdCount = true; //маркер введено ли корректное значение
            string enteredValue = ""; // переменная для вводимого значения в формате string
            double value; // возварщаемое значение метода в формате double
            do
            {
                enteredValue = Console.ReadLine();
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
        protected static double GetS(double x1, double y1, double x2, double y2) // находим расстояние между двумя точками
        {
            double s;
            s = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return s;
        }
        protected static string GetCloselyDote(double sA, double sB) // находим кто ближе к началу координат
        {
            string a = "A";
            string b = "B";
            if (sA > sB)
            {
                return b;
            }
            else
            {
                return a;
            }

        } 

    }
}
