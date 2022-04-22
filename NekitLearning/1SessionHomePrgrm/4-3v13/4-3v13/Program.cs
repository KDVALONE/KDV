﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_3v13
{
    /*
     Задачи решать в общем виде. Все константные значения, указанные в таблице,
     использовать для решения тестовых примеров. 
     Все вводимые пользователем значения переменных проверять на непротиворечивость данных.
     Три пункта задания организовать в виде функций (методов). 
     Реализовать возможность заполнения массива, как случайными числами, 
     так и с помощью клавиатуры по желанию пользователя. 
     Логически повторяющиеся части программы убрать в функции (методы).

     1. Дан массив целых чисел из n элементов, 
     заполненный случайным образом числами из промежутка [-200,500].
     Удалить из него все элементы, в записи которых есть цифра 0. 
     2. Вставить число К после всех четных элементов. 
     3. Поменять местами три первых положительный элемента с тремя 
     первыми отрицательными элементами, сохраняя порядок их следования.
    
     */
    class Program
    {
        static Random rnd = new Random();// экзепляр класса Random, нужен для присвоения случайных значений
        public static int ArrayDiapasoneX1 = -200;
        public static int ArrayDiapasoneX2 = 500;
        public static int ArrayLengthDiapasoneA = 3;
        public static int ArrayLengthDiapasoneB = 20;
        public static int K;
        public static int[] Array = new int[] { 4, 3, 2, -2, 9, 11 };
        static void Main(string[] args)
        {
            ShowObjective();
            //Array = IsHandeArrayFill() ? SetArrayHandcrafted() : SetArrayAuto();
            K = SetK();
            DeleteZeroByArray(Array);
            InsertKInArray(Array);

            Console.ReadKey();
        }
        protected static int[] SetArray()
        {
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            string[] splitedTextArray;
            int value;
            int[] enteredArray;

            do
            {
                int i = 0;
                enteredValue = Console.ReadLine();
                splitedTextArray = enteredValue.Split(' '); // т.к. значения вводяться в одну строку, их нужно разбить по числам с помощью пробела

                enteredArray = new int[splitedTextArray.Length];
                foreach (string e in splitedTextArray)
                    if (!int.TryParse(e, out value))
                    {
                        Console.WriteLine($"Введеный вами символ '{e}' массива не является целым числом. Попробуйте еще раз.");
                        flagOfEnterdCount = false;
                        break;
                    }
                    else
                    {
                        value = Convert.ToInt32(e);
                        enteredArray[i] = value;
                        i++;
                        if (i == splitedTextArray.Length) { flagOfEnterdCount = true; }
                    }
            } while ((flagOfEnterdCount == false));

            return enteredArray;
        }
        protected static void ShowObjective()
        {
            string objective = "1. Дан массив целых чисел из n элементов, \n" +
                "заполненный случайным образом числами из промежутка[-200, 500]. \n" +
                "Удалить из него все элементы, в записи которых есть цифра 0. \n" +
                "\n " +
                "2. Вставить число К после всех четных элементов. \n" +
                "\n " +
                "3. Поменять местами три первых положительный элемента с тремя " +
                "\n первыми отрицательными элементами, сохраняя порядок их следования. \n";
            Console.WriteLine($"{objective}");
        }
        protected static void ShowArray(int[] array)
        {
            string text = "";
            foreach (int e in array)
            {
                text += e + " ";
            }
            Console.WriteLine($"{text}");

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
        protected static int[] SetArrayHandcrafted()
        {
            Console.WriteLine("Введите массив чисел:");
            int[] array = SetArray();
            return array;
        }
        protected static int[] SetArrayAuto()
        {
            Console.WriteLine($"Массив с случайным размером от {ArrayLengthDiapasoneA} до {ArrayLengthDiapasoneB} автоматически заполняется \n" +
                              $"случайными значениями в диапазоне от {ArrayDiapasoneX1} до {ArrayDiapasoneX2}");

            int[] arrayAuto = new int[rnd.Next(ArrayLengthDiapasoneA, ArrayLengthDiapasoneB)];
            for (int i = 0; i < arrayAuto.Length - 1; i++)
            {
                arrayAuto[i] = rnd.Next(ArrayDiapasoneX1, ArrayDiapasoneX2); // присваеваем случайное значение от -10 до 10.
            }
            string arrayString = "";
            foreach (int e in arrayAuto)
            {
                arrayString += e + " ";
            }
            Console.WriteLine($"Автоматически заполненный массив {arrayString}");
            return arrayAuto;
        }
        protected static int SetK()
        {
            Console.WriteLine("Введите число K, для решения задания №2 ");
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            int value;
            do
            {
                enteredValue = Console.ReadLine();
                if (!Int32.TryParse(enteredValue, out value))
                {
                    Console.WriteLine("Вы ввели не целое число.  Попробуйте еще раз.");
                    flagOfEnterdCount = false;
                }
                else
                {
                    value = Convert.ToInt32(enteredValue);
                    flagOfEnterdCount = true;
                }
            } while (!flagOfEnterdCount);

            return value;
        }

        //protected static void ReversLastNegativeNumber(double[] array)
        //{
        //    bool arrayHaveNegativeNumber = false;
        //    int IndexLastNegativeNumber = 0;
        //    string reversedArray = "";

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] < 0 && i >= IndexLastNegativeNumber)
        //        {
        //            IndexLastNegativeNumber = i;
        //            arrayHaveNegativeNumber = true;
        //        }
        //    }
        //    if (!arrayHaveNegativeNumber)
        //    { Console.WriteLine("\n 1. В массиве нет отрицательных чисел"); }
        //    else
        //    {
        //        double buffer = array[IndexLastNegativeNumber];
        //        array[IndexLastNegativeNumber] = array[array.Length - 2];
        //        array[array.Length - 2] = buffer;
        //        // array[IndexLastNegativeNumber] ^= arr[array.Length- 2]; если бы был массив int то можно было вообще одной стракой поменять. 
        //        foreach (double e in array)
        //        {
        //            reversedArray += e + " ";
        //        }
        //        Console.WriteLine($"\n 1. Поменяли местами последний отрицательный \n" +
        //                            $"элемент с предпоследним элементом {reversedArray}");
        //    }


        //}
        //protected static void MultiplicationElement(double[] array) //Умножить все элементы массива, кратные 3, на его номер.
        //{
        //    bool wasMultipled = false;
        //    string multipledArray = "";
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] % 3 == 0)
        //        {
        //            wasMultipled = true;
        //            multipledArray += array[i] * i + " ";
        //        }
        //        else
        //        {
        //            multipledArray += array[i] + " ";
        //        }
        //    }
        //    if (!wasMultipled)
        //    { Console.WriteLine("\n 2. В массиве нет элементов кратных трем"); }
        //    else
        //    { Console.WriteLine($"\n 2. Массив с умноженными на свой номер значениями кратными трем: {multipledArray} "); }

        //}
        //protected static void CreatedNewArrayM(double[] arrayP)  // ВОТ ТУТ ВОРОС, Mi=i*Pi, Mi=-Pi*(i+1)!! Pi это число Пи? просто или P[i]
        //{
        //    double[] arrayM = new double[arrayP.Length];  // чтоб не было вопросов что я для удобства ответ вывел в string arrayTextM
        //    string arrayTextM = "";
        //    int j = 1;
        //    for (int i = 0; i < arrayP.Length; i++)
        //    {
        //        if (j == 3)
        //        {
        //            //arrayM[i] = i * Math.PI;
        //            arrayM[i] = i * arrayP[i];  // точно P[i] , если PI=3,14 то там полная труба
        //            j = 0;
        //        }
        //        else
        //        {
        //            //arrayM[i] = -(Math.PI) * (i + 1);
        //            arrayM[i] = -arrayP[i] * (i + 1);  // точно P[i] , если PI=3,14 то там полная труба
        //        }
        //        j++;
        //    }
        //    foreach (double e in arrayM)
        //    {
        //        arrayTextM += e + " ";
        //    }
        //    Console.WriteLine($"\n 3. Новый сформированный массив М {arrayTextM}");
        //}

        protected static void DeleteZeroByArray(int[] array)
        {
            int i = 0;

            foreach (int e in array)
            {
                if (!e.ToString().Contains('0'))
                {
                    i++;
                }
            }

            int[] arrayWithoutZero = new int[i];
            i = 0;
            foreach (int e in array)
            {
                if (!e.ToString().Contains('0'))
                {
                    arrayWithoutZero[i] = e;
                    i++;
                }
            }
            ShowArray(arrayWithoutZero);
        }
        protected static void InsertKInArray(int[] array)
        {
            int i = 0;
            foreach (int e in array)
            {
                if (e % 2 == 0)
                {
                    i++;
                }
            }
            int[] arrayWithK = new int[array.Length + i];
            int index = 0;

            foreach (int e in array)
            {
                if (e % 2 == 0)
                {
                    arrayWithK[index] = e;
                    arrayWithK[index + 1] = K;
                    index += 2;
                }
                else
                {
                    arrayWithK[index] = e;
                    index++;
                }
            }
            ShowArray(arrayWithK);
        }
        protected static void ReversElements(int[] array)
        {
            int PstvElmtIndx1;
            int PstvElmtIndx2;
            int PstvElmtIndx3;

            int NgtvElmtIndx1;
            int NgtvElmtIndx2;
            int NgtvElmtIndx3;

            foreach (int e in array)
            {

            }
        }
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

