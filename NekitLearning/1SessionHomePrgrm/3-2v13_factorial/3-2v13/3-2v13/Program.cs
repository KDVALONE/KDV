using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2v13
{/// <summary>
/// вычислить сумму ряда
/// дана формула
/// составить две программы:
///  - вычисление первых n членов последовательности.
///  - программу вычисления всех членов последовательности не меньших заданного числа е
///  - при вычислении факториала числа, использовать рекурсивнюу подпрограмму.
///  
/// </summary>
/// 
    class Program
    {
       // ДУРАЦКАЯ ЗАДАЧА, в том смысле, что формулу сгенерировали для задания абсолютно феерично кривую!!!!.

        static void Main(string[] args)
        {
            Exercise excrs = new Exercise();
            excrs.Start();
            Console.ReadLine();
        }
    }
    /// <summary>
    /// Показаывает условие задачи, отвечает за ввод значений с клавиатуры
    /// </summary>
    static class Display
    {
        /// <summary>
        /// Показать условие задачи
        /// </summary>
        public static void ShowObjectives()
        {
            string objectives = "Вычислить сумму ряда по заданной формуле составив две подпрограммы: \n " +
                "- вычисление первых 'n' членов последовательности.\n " +
                "- программу вычисления всех членов последовательности \n  не меньших заданного числа 'e' \n" +
                "( при вычислении факториала числа, использовать рекурсивнюу подпрограмму. )";

            Console.WriteLine(objectives);
        }

        /// <summary>
        /// ввести значение целочисленного элемента вручную
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static int InsertElement(string elementName)
        {
           
            int element;
            bool elementInserted = false;
            do
            {
                Console.WriteLine($"\n Введите целочисленное число '{elementName}':\n ");
                var insertElement = Console.ReadLine();
                
                    if (Int32.TryParse(insertElement, out element))
                    {
                        elementInserted = true;
                    }
                    else
                    {
                        Console.WriteLine("\n Вы ввели не целочисленное число \n Попробуйте еще раз:");
                    }
                
            } while (!elementInserted);

            Console.WriteLine($"\n Введеное число '{elementName}' = {element} \n");
            return element;

        }

        public static void Answer(double answer, int numberOfTask ,double []summation, int n = 0, int e = 0)
        {
            string answer1 =  $"Ответ 1. Вычисление cуммы первых {n} членов последовательности = {answer}\n";
            string answer2 =  $"Ответ 2.  Вычисление всех членов последовательности не меньших заданного числа {e} = {answer}\n";

            Console.Write($"Последовательность : \n");
            foreach (var element in summation) { Console.WriteLine(" "+element+" "); }
            Console.WriteLine("\n");

            switch (numberOfTask)
            {
                case 1:
                    {
                        Console.WriteLine(answer1);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(answer2);
                        break;
                    }

            }

        }

    }
    /// <summary>
    /// Главный класс с задачами
    /// </summary>
    class Exercise
    {
        int N;
        int E;
        double [] SummationArray;
        public void Start()
        {
               Display.ShowObjectives();
            N = Display.InsertElement("n");
            E = Display.InsertElement("e"); 
              SummationArray = GetSummationArray(N);
              SummationNElement(SummationArray,N);
            SummationNontMinE(SummationArray, N, E);
            

           Console.WriteLine();
        }

        /// <summary>
        /// Получает последовательность для сумирования формулы
        /// </summary>
        private double [] GetSummationArray(int n)///TODO:!!! жуть с формулой. разобраться
        {
            double[] summationArray = new double[n];
            

            for (int k = 0; k < n ; k++)
            {
                summationArray[k] = (Math.Pow(-1, k) * (1 / (double)((Factorial.GetFactorial(k) * (Factorial.GetFactorial(k + 1))))));
            }
            return summationArray;
        }
        /// <summary>
        /// считает сумму первыйх n символов последовательности
        /// </summary>
        private void SummationNElement(double [] summationArray, int n)
        {
            double summation = 0;

            for (int i = 0; i < n; i++)
            {
                summation += summationArray[i];
            }

            Display.Answer(summation,1,summationArray,n);
        }
        private void SummationNontMinE(double[] summationArray, int n, int e)
        {
            double summation = 0;

            for (int i = 0; i < n; i++)
            {
                if (summationArray[i] >= e)
                {
                    summation += summationArray[i];
                }
              
            }

            Display.Answer(summation, 2, summationArray, n);
        }

    }
    static class Factorial
    {
        /// <summary>
        /// Считае факториал.
        /// Факториалом числа -произведение всех натуральных чисел до него включительно. 0 не нат.число.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetFactorial(int number)
        {
            if (number < 0)
            {
               throw new Exception($"Нельзя посчитать факториал отрицательного числа {number}");
               
            }
            int nNumberCount = 1;
            int factorial = 1;

            do
            {
                factorial = nNumberCount * factorial;
                nNumberCount++;
            } while (nNumberCount <= number);
            
            return factorial;
        }

    }

    

}
