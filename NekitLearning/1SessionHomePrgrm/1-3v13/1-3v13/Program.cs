﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3v13
{/*Текущее время часы минуты секунды, заданно тремя переменными h, m, s 
    Округлить его до целых значений минут и часов.
    например  14ч 21мин 45сек округлить до 14 22 или 14 ч, а 9ч 59мин 23сек
    перобразуются в 9 59 или 10 ч*/
    class Program
    {
        public static int maxHourValue = 23;
        public static int maxMinutValue = 59;
        public static int maxSecondValue = 59;
        public static string hoursText = "часы";
        public static string minutsText = "минуты";
        public static string secondsText = "секунды";
        static void Main(string[] args)
        {
            Console.WriteLine("Введите время для округления");
            int h = GetValue(hoursText,maxHourValue);
            int m = GetValue(minutsText,maxMinutValue);
            int s = GetValue(secondsText,maxSecondValue);
            Console.WriteLine($"Заданное время = {h}часов {m}минут {s}секунд");
            Console.WriteLine("Ответ:");
            RoundUp(h, m, s);

            Console.ReadKey();
        }

        protected static int GetValue(string timeName,int maxTimeValue)
        {
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            int value;
            do
            {
                Console.WriteLine($"Введите {timeName}:");
                enteredValue = Console.ReadLine();
                if (!int.TryParse(enteredValue, out value) || Convert.ToInt32(enteredValue) < 0 || Convert.ToInt32(enteredValue) > maxTimeValue)
                {
                    Console.WriteLine($"Вы ввели не целое или отрицательное число. \nИли число больше максимально возможного значения {maxTimeValue} \nПопробуйте еще раз.");
                    flagOfEnterdCount = false;
                }
                else
                {
                    value = Convert.ToInt32(enteredValue);
                    flagOfEnterdCount = true;
                }
            } while ((flagOfEnterdCount == false));

            return value;
        }

        protected static void RoundUp(int h, int m, int s)
        {
            if (s > (maxSecondValue / 2)) { m++; }
            if(m == maxMinutValue+1){ m = 0; }
            Console.WriteLine($"Округленное время до минут = {h}часов {m} минут");
            if (m > maxMinutValue / 2) { h++; }
            if (m == maxHourValue + 1) { h = 0; }
            Console.WriteLine($"Округленное время до часов = {h}часов");
        }
    }
}
