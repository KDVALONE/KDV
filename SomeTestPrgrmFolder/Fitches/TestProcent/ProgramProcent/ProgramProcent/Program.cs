using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramProcent
{/// <summary>
/// создать метод для проверки выполнилось что то с заданным процентом.
/// К примеру, 5 процентов на падание, 95 процентов на промах.
/// Предаем 5, и с 95 процентной вероятностью выпадет False.
/// </summary>
    class Program
    {
   
        static void Main(string[] args)
        {
           int n = 95;
            Console.WriteLine(ProcentGenerator.GetProcent3(n));
            Console.ReadKey();
        }
        public class ProcentGenerator
        {
            static Random rnd = new Random();
            static public bool GetProcent(int n)
            {

                bool procentIsCorrect = false;
                int[] array1 = new int[100];
                int[] array2 = new int[n];
                int value;
                for (int i = 0; i < 100; i++)
                {
                    array1[i] = i + 1;
                }
                for (int i = 0; i <= n - 1; i++)
                {
                    array2[i] = i + 1;
                }
                value = array1[rnd.Next(0, array1.Length)];
                foreach (int e in array2)
                {
                    if (e == value)
                        procentIsCorrect = true;
                }
                return procentIsCorrect;
            }
            static public bool GetProcent2(int n)
            {
                bool result;
                int[] array1 = new int[100];
                for (int i = 0; i < 100; i++)
                {
                    array1[i] = i + 1;
                }
                int value = array1[rnd.Next(0, array1.Length)];
                return result = Enumerable.Range(1, n).Contains(value);
            }
            static public bool GetProcent3(int n)
            {
                bool hit = rnd.Next(1, 101) <= n;
                return hit;
            } // Рефакторинг!! в 2 строчки!!!
        }
    }
}

