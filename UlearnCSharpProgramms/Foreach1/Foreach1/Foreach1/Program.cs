using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreach1
{
    class Program
    {
        //Напишите метод, который создает массив из count первых четных чисел больших нуля, в порядке возрастания.
        //!!! Убодогейшее задание! Блин , только подсмотрев решение понял что хотят, 
        // нужно блин создать массив с размерностью [count], из четных чисел от нуля не считая его в порядке возрастания.
        static void Main(string[] args)
        {
            var c = "";
            int[] array1 = { };
            int[] array2 = { };
            int[] array3 = { };
            int[] array4 = { };
            int count1, count2, count3, count4;

            array1 = GetFirstEvenNumbers(count1 = 5);
            foreach (var e in array1)
                {
                Console.WriteLine(e);
                }
            array2 = GetFirstEvenNumbers(count2 = 11);
            foreach (var e in array2)
            {
                Console.WriteLine(e);
            }
            array3 = GetFirstEvenNumbers(count3 = 0);
            foreach (var e in array3)
            {
                Console.WriteLine(e);
            }
            array4 = GetFirstEvenNumbers(count4 = 2);
            foreach (var e in array4)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();


        }
        public static int[] GetFirstEvenNumbers(int count)
        {
            int i = 0;
            var array = new int[count];
            foreach (var e in array)
            {
                array[i] = (i + 1) * 2;
                i++; 
            }
            return array;
            //for (var i = 0; i < count; i++)
            //array[i] = (i + 1) * 2;
            //return array;
        }
    }
}
