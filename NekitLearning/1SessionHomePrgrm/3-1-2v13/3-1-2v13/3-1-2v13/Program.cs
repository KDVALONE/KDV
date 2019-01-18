using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1_2v13
{/// <summary>
///  По заданной формуле члена последовательности с номером К составить 2 программы.
///   1. вычесление суммы всех первых членов последоавтельности
///   2. программу вычесления суммы всех членов последоваетльности не меньших заданного E
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Expression exp = new Expression();
            exp.Start();
            Console.ReadKey();
        }
    }


    class Expression
   {
        public void Start()
        {
            Dispaly.ShowObjectives();
            double[] values = Dispaly.EnterElements();
            double e = values[0]; // сравниваемая величена
            double n = values[1]; // размер последовательности
            int h = 1; // шаг. (задан в в условии (K = 1,2,3...n) след. шаг 1)

            values = FindS(e, n, h);
            Dispaly.ShowAnswer(values, e);




        }

        public double FindK(double k) => Math.Sqrt(k + 1) / 2 * (Math.Sqrt(Math.Pow(k, 2) + 1)); // метод сжатый до выражения)))
        public double[] FindS(double e, double n, int h)
        {
            double s = 0; // сумма всех членов послед
            double se = 0; // сумма всех членов которые не меньше заданного е
            double element = 0;
            
            for (int k = 1; k <= n; k += h)
            {
                element += FindK(k); // тут неявное приведение int к double 
                s += element;
                if(element>= e){ se += element; }
            }
            double[] sElements = { s, se }; // e[0] = S, e[1] = SE
            return sElements;
        }

   }

    static public class Dispaly
    {
        public static void ShowObjectives()
        {
            string objectives = " По заданной формуле члена последовательности с номером К составить 2 программы.\n " +
                " 1. вычесление суммы всех первых членов последоавтельности \n" +
                " 2. программу вычесления суммы всех членов последоваетльности не меньших заданного E \n";
            Console.WriteLine(objectives);
        }
        public static double [] EnterElements()
        {
            double[] elements = new double[2];
            string[] elementsName = {"e","n - размер последовательноти: " };
            bool elementIsCorrect = false;
          
            double value = 0;
            for (int i = 0; i < elements.Length; i++)
            {
              do
              {
                elementIsCorrect = false;
                Console.WriteLine($" Введите значение елемента {elementsName[i]}");
                var enteredVal = Console.ReadLine();
                if (!double.TryParse(enteredVal, out value) || (i == 1 & (Convert.ToDouble(enteredVal) < 0)))
                {
                  Console.WriteLine($"Введено не верное значение или {elementsName} = 0");
                }
                else
                {
                  elements[i] = Convert.ToDouble(enteredVal);
                  elementIsCorrect = true;
                }
              }while(!elementIsCorrect);
            }
            return elements;
        }
        public static void ShowAnswer(double[] S, double e )
        {
            Console.WriteLine($"Ответ1 = суммы всех членов последовательности S= {S[0]:0.000}");
            Console.WriteLine($"Ответ1 = суммы всех членов последовательности  не меньше e = {e}  Se= {S[1]:0.000} ");

        }
    }
}
