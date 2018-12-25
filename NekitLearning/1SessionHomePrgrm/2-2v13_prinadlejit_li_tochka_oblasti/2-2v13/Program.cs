﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_2v13
{/*
    Определить принадлежит ли некоторая точка М с произвольными координатами х,y 
    к закрашенной области между точками A(-1,0) B(1,2) С(-2,5)
*/
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrayX = { -1,1,-2 };
            double[] arrayY = { 0, 2, 5 };
            Console.WriteLine("Введите координаты точки M(x,y)");
            Console.WriteLine("Введите x = ");
            double mX = GetValue();
            Console.WriteLine("Введите y = ");
            double mY = GetValue();
            Console.WriteLine($"Ответ: Точка М({mX},{mY}) {DoteIsOnPerimetr(mX,mY, arrayX, arrayY)} к закрашенной области");
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
        
        protected static string DoteIsOnPerimetr(double mX, double mY, double [] arrayX, double [] arrayY)
        {
            int j = arrayX.Length - 1;
            for (int i = 0; i < arrayX.Length; i++)
            {
                if (((arrayY[i] <= mY) && (mY < arrayY[j]) || ((arrayY[j] <= mY) && (mY < arrayY[i]))) &&
                   (mX > (arrayX[j] - arrayX[i]) * (mY - arrayY[i]) / (arrayY[j] - arrayY[i]) + arrayX[i]))
                    {
                    return "не принадлежит";
                    }
                j = i;
            }
            return "принадлежит";    
        }
    }
}
