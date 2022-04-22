using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_PoweredArr
{/*Помогите Васе написать метод, который принимает массив int[],
   возводит все его элементы в заданную степень и возвращает массив с результатом этой операции.
   Исходный массив при этом должен остаться неизменным.*/
    class Program
    {
        static void Main(string[] args)
        {

            var arrayToPower = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Метод PrintArray уже написан за вас
            PrintArray(GetPoweredArray(arrayToPower, 1));

            // если вы будете менять исходный массив, то следующие два теста сработают неверно:
            PrintArray(GetPoweredArray(arrayToPower, 2));
            PrintArray(GetPoweredArray(arrayToPower, 3));

            // не забывайте про частные случаи:
            PrintArray(GetPoweredArray(new int[0], 1));
            PrintArray(GetPoweredArray(new[] { 42 }, 0));
            Console.ReadKey();
        }
        public static int[] GetPoweredArray(int[] arr, int power)
        {
            List<int> poweredArray = new List<int>();
            foreach (int e in arr)
            {
                poweredArray.Add(Convert.ToInt32(Math.Pow(e, power)));
            }
            return poweredArray.ToArray();
        }
        public static void PrintArray(int[] array)
        {
            foreach (int e in array)
            {  
            Console.WriteLine(e);
            }
        }
    }
}
