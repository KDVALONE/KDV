﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2v13
{/* Задачи решать в общем виде.
    Все константные значения, указанные в таблице, использовать для решения тестовых примеров.
    Все вводимые пользователем значения переменных проверять на непротиворечивость данных.
    Три пункта задания организовать в виде функций (методов).
    Реализовать возможность заполнения массива, как случайными числами,
    так и с помощью клавиатуры по желанию пользователя.
    Логически повторяющиеся части программы убрать в функции (методы). 
    
    1. Заменить последний отрицательный элемент массива предпоследним элементом массива. 
    2. Умножить все элементы массива, кратные 3, на его номер. (на свои номера наверно?)
    3. Из элементов массива P сформировать массив M той же размерности по правилу:
       каждый третий элемент по формуле Mi=i*Pi , а все остальные по формуле Mi=-Pi*(i+1). */
    class Program
    {
        static Random rnd = new Random();// экзепляр класса Random, нужен для присвоения случайных значений
        public static int ArrayDiapasoneX1 = -30;
        public static int ArrayDiapasoneX2 = 30;
        public static int ArrayLengthDiapasoneA = 3;
        public static int ArrayLengthDiapasoneB = 20;
        public static double[] Array;
        static void Main(string[] args)
        {
            Array = IsHandeArrayFill() ? SetArrayHandcrafted() : SetArrayAuto(); // тренарный оператор
            ReversLastNegativeNumber(Array);
            MultiplicationElement(Array);
            CreatedNewArrayM(Array);
           
            // спросят почему переменные DOUBLE, скажи сначала думал что в 3 задании придеться умножать на 
            // 3,14 а потом, дойдя до него понял что наверное имеллось ввиду P[i], но ты не стал переделывать
            // так как int вкходит в double и так же, задание по факту усложняется

            Console.ReadKey();
        }
        protected static double[] SetArray()
        {
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            string[] splitedTextArray;
            double value;
            double[] enteredArray;

            do
            {
                int i = 0;
                enteredValue = Console.ReadLine();
                splitedTextArray = enteredValue.Split(' '); // т.к. значения вводяться в одну строку, их нужно разбить по числам с помощью пробела

                enteredArray = new double[splitedTextArray.Length];
                foreach (string e in splitedTextArray)
                    if (!double.TryParse(e, out value))
                    {
                        Console.WriteLine($"Введеный вами символ '{e}' массива не является целым числом. Попробуйте еще раз.");
                        flagOfEnterdCount = false;
                        break;
                    }
                    else
                    {
                        value = Convert.ToDouble(e);
                        enteredArray[i] = value;
                        i++;
                        if (i == splitedTextArray.Length) { flagOfEnterdCount = true; }
                    }
            } while ((flagOfEnterdCount == false));

            return enteredArray;
        }
        protected static bool IsHandeArrayFill()
        {
            Console.WriteLine("Вы хотите заполнить массив элементами в ручную ? \n");
            bool doing = true;
            string enteredString;
            do
            {
                Console.WriteLine("Введите 'y' или нажмите Enter для ручного ввода \n" +
                "Введите 'n' для автоматического заполнения массива ");
                enteredString = Console.ReadLine();

                if (enteredString.Contains('y') || enteredString.Contains('Y') ||
                enteredString.Contains('у') || enteredString.Contains('У') ||
                enteredString == "" || enteredString.Contains('н') || enteredString.Contains('Н') ||
                enteredString.Contains('N') || enteredString.Contains('n'))
                { doing = false; }
                else
                {
                    doing = true;
                    Console.WriteLine("Вы ввели не корректные данные, попробуйте еще раз");
                }
            } while (doing);

            if (enteredString.Contains('y') || enteredString.Contains('Y') ||
                enteredString.Contains('у') || enteredString.Contains('У') ||
                enteredString == "")
            {
                return true;
            }
            else { return false; }
        }
        protected static double[] SetArrayHandcrafted()
        {
            Console.WriteLine("Введите массив чисел:");
            double[] array = SetArray();
            return array;
        }
        protected static double[] SetArrayAuto()
        {
            Console.WriteLine($"Массив с случайным размером от {ArrayLengthDiapasoneA} до {ArrayLengthDiapasoneB} автоматически заполняется \n" +
                              $"случайными значениями в диапазоне от {ArrayDiapasoneX1} до {ArrayDiapasoneX2}");

            double[] arrayAuto = new double[rnd.Next(ArrayLengthDiapasoneA, ArrayLengthDiapasoneB)];
            for (int i = 0; i < arrayAuto.Length - 1; i++)
            {
                arrayAuto[i] = rnd.Next(ArrayDiapasoneX1, ArrayDiapasoneX2); // присваеваем случайное значение от -10 до 10.
            }
            string arrayString = "";
            foreach (double e in arrayAuto)
            {
                arrayString += e + " ";
            }
            Console.WriteLine($"Автоматически заполненный массив {arrayString}");
            return arrayAuto;
        }

        protected static void ReversLastNegativeNumber(double[] array)
        {
            bool arrayHaveNegativeNumber = false;
            int IndexLastNegativeNumber = 0;
            string reversedArray = "";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0 && i >= IndexLastNegativeNumber)
                {
                    IndexLastNegativeNumber = i;
                    arrayHaveNegativeNumber = true;
                }
            }
            if (!arrayHaveNegativeNumber)
            { Console.WriteLine("\n 1. В массиве нет отрицательных чисел"); }
            else
            {
                double buffer = array[IndexLastNegativeNumber];
                array[IndexLastNegativeNumber] = array[array.Length - 2];
                array[array.Length - 2] = buffer;
                // array[IndexLastNegativeNumber] ^= arr[array.Length- 2]; если бы был массив int то можно было вообще одной стракой поменять. 
                foreach (double e in array)
                {
                    reversedArray += e + " ";
                }
                Console.WriteLine($"\n 1. Поменяли местами последний отрицательный \n" +
                                    $"элемент с предпоследним элементом {reversedArray}");
            }
            

        }
        protected static void MultiplicationElement(double[] array) //Умножить все элементы массива, кратные 3, на его номер.
        {
            bool wasMultipled = false;
            string multipledArray= "";
            for (int i = 0;i < array.Length ; i++)
            {
                if (array[i] % 3 == 0)
                {
                    wasMultipled = true;
                    multipledArray += array[i] * i + " ";
                }
                else
                {
                    multipledArray += array[i] + " ";
                }
            }
            if (!wasMultipled)
            { Console.WriteLine("\n 2. В массиве нет элементов кратных трем"); }
            else
            { Console.WriteLine($"\n 2. Массив с умноженными на свой номер значениями кратными трем: {multipledArray} "); }
           
        }
        protected static void CreatedNewArrayM(double[] arrayP)  // ВОТ ТУТ ВОРОС, Mi=i*Pi, Mi=-Pi*(i+1)!! Pi это число Пи? просто или P[i]
        {
            double [] arrayM = new double[arrayP.Length];  // чтоб не было вопросов что я для удобства ответ вывел в string arrayTextM
            string arrayTextM = "";
            int j = 1;
            for (int i = 0; i < arrayP.Length; i++)
            {
                if (j == 3)
                {
                    //arrayM[i] = i * Math.PI;
                    arrayM[i] = i * arrayP[i];  // точно P[i] , если PI=3,14 то там полная труба
                    j = 0;
                }
                else
                {
                    //arrayM[i] = -(Math.PI) * (i + 1);
                    arrayM[i] = -arrayP[i] * (i + 1);  // точно P[i] , если PI=3,14 то там полная труба
                }
                j++;
            }
            foreach (double e in arrayM)
            {
                arrayTextM += e + " ";
            }
            Console.WriteLine($"\n 3. Новый сформированный массив М {arrayTextM}");
        }


    //     protected static int SetA()
    //    {
    //        Console.WriteLine("Введите число A , для решения задания №2 и №3 ");
    //        bool flagOfEnterdCount = true;
    //        string enteredValue = "";
    //        int value;
    //        do
    //        {
    //            enteredValue = Console.ReadLine();
    //            if (!Int32.TryParse(enteredValue, out value))
    //            {
    //                Console.WriteLine("Вы ввели не целое число.  Попробуйте еще раз.");
    //                flagOfEnterdCount = false;
    //            }
    //            else
    //            {
    //                value = Convert.ToInt32(enteredValue);
    //                flagOfEnterdCount = true;
    //            }
    //        } while (!flagOfEnterdCount);

    //        return value;
    //    }

    //    protected static int GetSumOfArrayElement(int[] array)  //Найти сумму элементов, значения которых кратны 3 и 5. (тоесть по заданию они должны быть одновременно кратны 3 и 5.
    //                                                            // Такие цифры это 30 15 45 60), тоесть с диапазоном по умолчанию от -10 до 10 задача всегда будет выдавать 0
    //    {
    //        int sum = 0;
    //        foreach (int e in array)
    //        {
    //            if (e % 3 == 0 & e % 5 == 0)
    //                sum += e;
    //        }
    //        return sum;
    //    }
    //    protected static int GetCountAbsOfElements(int[] array, int a)
    //    {
    //        int countElemtnts = 0;
    //        foreach (int e in array)
    //        {
    //            if (e > 0 && Math.Abs(e) > Math.Abs(a))
    //            {
    //                countElemtnts++;
    //            }
    //        }
    //        return countElemtnts;
    //    }
    //    protected static string GetFirstPairOfElement(int[] array, int a)
    //    {
    //        int pairNumber = 1;
    //        int firsExistPair = 0; // найденная пара
    //        for (int i = 0; i <= array.Length - 1; i++)
    //        {
    //            if (i + 1 <= array.Length - 1 && (array[i] + array[i + 1]) < a && (firsExistPair == 0))
    //            {
    //                firsExistPair = pairNumber;
    //            }
    //            pairNumber++;
    //        }
    //        return firsExistPair > 0 ? "является " + firsExistPair.ToString() : "отсутствует, так как такой пары не существует.";
    //    }
    }
}

