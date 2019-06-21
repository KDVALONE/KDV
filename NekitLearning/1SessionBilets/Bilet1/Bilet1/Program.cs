using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilet1
{/// <summary>
 /// 2. Решить задачу (написать алгоритм и программу на языке C#). Все вводимые пользователем
 /// значения переменных проверять на непротиворечивость данных. Вычислить сумму первых n
 ///    членов ряда  k=0,n  ∑= 1/k!
 /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n ;
            double e = 0.001; // элемент е. Нужен если нужно суммировать все суммы больше е
            List<double> summElements; 
            string enteredCount;

            double answer;
            Method mtd = new Method();
            
            do
            {
                Console.WriteLine($"Введите число  n , число е = {e}");
                enteredCount = Console.ReadLine();
            } while (! int.TryParse(enteredCount, out n));

            n = Convert.ToInt32(enteredCount);

            summElements =  mtd.GetSummationElements(n);
            
            answer = mtd.GetSumElementsLargE(summElements, e);
            Console.WriteLine($"Ответ: сумма элементов которые не меньше {e} = "+ answer);

            Console.ReadKey();
        }
    }

    class Method
    {
        public  int GetFactorial(int number)
        {
            int factorial = 1;
            for (; number > 0; number--)
            {
                factorial = number * factorial;
            }
            return factorial;
        }

        public List<double> GetSummationElements(int n) // получаем перечень элементов для суммы
        {
            int k = 0; //для тех типов задач где к == 0
            
            List<double> summList = new List<double>();
           
            for (; k < n; k++)
            {
                summList.Add(1.00 /( (GetFactorial(k + 3)) * (GetFactorial(k + 3))));
            }
            return summList;     
        }
        public double GetSummNElemtnts(List<double> summElements, double n) //ищем сумму  первых n членов ряда                                                                     
        {
            double summ = 0;
            for (int i = 0; i < n; i++)
            {
                summ += summElements[i];
            }
            return summ;
        }
        public double GetSumElementsLargE(List<double> summElements, double e) //ищем сумму членов ряда больших e
        {
            double summ = 0;
            foreach (var elm in summElements)
            {
                if (elm > e) summ += e;
            }
            return summ;
        }

    }
}
