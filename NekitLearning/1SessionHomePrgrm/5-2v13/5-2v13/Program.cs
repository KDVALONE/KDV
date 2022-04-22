﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2v13
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace _5_2v13
    {
        /*
         Задачи решать в общем виде. Все константные значения, указанные в таблице,
         использовать для решения тестовых примеров. 
         Все вводимые пользователем значения переменных проверять на непротиворечивость данных.
         Три пункта задания организовать в виде функций (методов). 
         Реализовать возможность заполнения массива, как случайными числами, 
         так и с помощью клавиатуры по желанию пользователя. 
         Логически повторяющиеся части программы убрать в функции (методы).

         Дан двумерный массив размером n*m, заполненный случайным образом. 
         5.      Заменить нечетный элемент каждой строки нулем (сам элемент или номер у него не четный?)
         6.      Вставить после всех строк, содержащих минимальное значение строку 1,2,3,…. 
         7.      Удалить все столбцы, в которых первый элемент четный 
                    (Столбец (колонка) всегда ничинается со своего первого елемента находящегося в первой строке 
                    , следовательно удалить все столбцы которые в первой строке своей ячейки четные)
         8.      Поменять местами первый и последний столбцы. 

         */
        class Program
        {
            static Random rnd = new Random();// экзепляр класса Random, нужен для присвоения случайных значений
            public static int ArrayDiapasoneX1 = -100;
            public static int ArrayDiapasoneX2 = 100;
            public static int ArrayLengthDiapasoneA = 2;
            public static int ArrayLengthDiapasoneB = 12;
            public static int[,] Array;
            public static int[,] ArrayWithZero;
            public static int[,] ArrayWithNewString;
            public static int[,] ArrayWithoutEvenColumn;
            public static int[,] ArrayWithReaplaseColumn;
            static void Main(string[] args)
            {

                ShowObjective();
                Array = IsHandeArrayFill() ? SetArrayHandcrafted() : SetDoubleArrayAuto();

                // Не бага а фича!!! (хотя я бы так не сказал=)))
                // все что происходит в программе происходит с одним массивом тоесть,
                // сначала заменяются на нули цифры (1)
                // потом в него же вставляется строка (2) и тд.
                // потом удаляются столбцы начинающейся с четного числа(3). и тд..
                // это происходит из за того что массив Array помечен ключевым словом static
                // что бы продеманстрировать отдельные задания из программы чтоб они друг на друга не влияли то,
                // просто закоментируй строчки вызова методов не нужных. и оставь только 1 с номерм задания

                 ArrayWithZero = ReplaceElementToZero(Array); //1.  
                 ArrayWithNewString = InsertNewStringsToArray(Array); //2.
                 ArrayWithoutEvenColumn = DeleteEvenColumns(Array); //3.
                 ArrayWithReaplaseColumn = ReplaceFirstAndLastColumn(Array); //4.
                
            Console.ReadKey();
            }
           

            protected static int[,] GetDoubleArray()
            {
                int[] arraySize = GetDoubleArraySize();
                int arrayStringCount = arraySize[0];
                int arrayTableCount = arraySize[1];
                int[,] enteredArray = GetDoubleArrayValue(arrayStringCount, arrayTableCount);

                return enteredArray;
            }
            protected static void ShowObjective()
            {
                string objective = "Дан двумерный массив размером n*m, заполненный случайным образом, \n" +
                    $"числами из промежутка[{ArrayDiapasoneX1},{ArrayDiapasoneX2}]. \n" +
                    "1. Заменить нечетный элемент каждой строки нулем \n" +
                    "\n" +
                    "2. Вставить после всех строк, содержащих минимальное значение строку 1,2,3,… \n" +
                    "\n" +
                    "3. Удалить все столбцы, в которых первый элемент четный \n" +
                    "\n" +
                    "4. Поменять местами первый и последний столбцы. \n";
                Console.WriteLine($"{objective}");
            }
            protected static string ShowDoubleArray(int[,] array)
            {
                string text = "";
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        text += array[i, j] + " ";
                    }
                    text += "\n";
                }
                return text;

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
            protected static int[,] SetArrayHandcrafted()
            {
                Console.WriteLine("Введите двумерный массив чисел:");
                int[,] array = GetDoubleArray();
                Console.WriteLine($"Введеный в ручную массив \n{ShowDoubleArray(array)}");
                return array;
            }
            protected static int[,] SetDoubleArrayAuto()
            {
                Console.WriteLine($"Двумерный массив[n,m] где m и и случайное число от {ArrayLengthDiapasoneA} до {ArrayLengthDiapasoneB}, \n" +
                                  $"автоматически заполняется случайными значениями в диапазоне от {ArrayDiapasoneX1} до {ArrayDiapasoneX2}\n");

                int[,] doubleArrayAuto = new int[rnd.Next(ArrayLengthDiapasoneA, ArrayLengthDiapasoneB), rnd.Next(ArrayLengthDiapasoneA, ArrayLengthDiapasoneB)];
                for (int i = 0; i < doubleArrayAuto.GetLength(0); i++)// цикл добавления новой строки
                {
                    for (int j = 0; j < doubleArrayAuto.GetLength(1); j++) // цикл заполнения полей стрки
                    {
                        doubleArrayAuto[i, j] = rnd.Next(ArrayDiapasoneX1, ArrayDiapasoneX2); // присваеваем случайное значение от -10 до 10.
                    }
                }
                Console.WriteLine($"Автоматически заполненный двойной массив  array[{doubleArrayAuto.GetLength(0)},{doubleArrayAuto.GetLength(1)}] = \n" +
                                  $"{ShowDoubleArray(doubleArrayAuto)}");

                return doubleArrayAuto;
            }
         
            protected static int[] GetDoubleArraySize()
            {
                bool flagOfEnterdCount = true;
                string enteredValue = "";
                string[] splitedTextArray;
                int[] arraySize = new int[2];
                int value;
                do
                {
                    int i = 0;
                    Console.WriteLine("введите размерность двумерного массива через запятую \n" +
                        "Пример  4,3 - создаст массив из 4 строк по 3 столбца");
                    enteredValue = Console.ReadLine();
                    splitedTextArray = enteredValue.Split(',');

                    foreach (string e in splitedTextArray)
                        if (!int.TryParse(e, out value) || Convert.ToInt32(e) < 0)
                        {
                            Console.WriteLine($"Введеный вами символ '{e}' массива не является целым числом или меньше 0. Попробуйте еще раз.");
                            flagOfEnterdCount = false;
                            break;
                        }
                        else
                        {
                            value = Convert.ToInt32(e);
                            arraySize[i] = value;
                            i++;
                            if (i == arraySize.Length) { flagOfEnterdCount = true; }
                        }
                } while (!flagOfEnterdCount);
                return arraySize;
            }
            protected static int[,] GetDoubleArrayValue(int doubleArrayStringCount, int doubleArrayTableCount)
            {
                Console.WriteLine($"Введите значения для Массива[{doubleArrayStringCount},{doubleArrayTableCount}]");
                bool flagOfArraySetValue = false;
                string enteredValue = "";
                string[] splitedTextArray;
                int value;

                int currentString = 0;
                int[,] doubleArray = new int[doubleArrayStringCount, doubleArrayTableCount];
                do
                {
                    Console.WriteLine($"Введите значения для строки {currentString + 1} в в колличестве {doubleArrayTableCount} разделяя смиволы пробелами");
                    int i = 0;
                    enteredValue = Console.ReadLine();
                    splitedTextArray = enteredValue.Split(' '); // т.к. значения вводяться в одну строку, их нужно разбить по числам с помощью пробела


                    foreach (string e in splitedTextArray)
                    {
                        if (!int.TryParse(e, out value) || splitedTextArray.Length > doubleArrayTableCount)
                        {
                            Console.WriteLine($"Введеный вами символ '{e}' массива не является целым числом, \n" +
                                $"или колличество элементов превышает максимальное значение {doubleArrayTableCount}. Попробуйте еще раз.\n");
                            break;
                        }
                        else
                        {
                            value = Convert.ToInt32(e);
                            doubleArray[currentString, i] = value;
                            i++;
                            if (i == splitedTextArray.Length && currentString + 1 == doubleArrayStringCount) { flagOfArraySetValue = true; }
                            else if (i == splitedTextArray.Length) { currentString++; }
                        }
                    }
                } while ((flagOfArraySetValue == false));

                return doubleArray;
            }

            protected static int GetDoubleArrayMinElement(int [,] doubleArray)
            {
                int elementMin = doubleArray[0, 0];
              

                for (int i = 0; i < doubleArray.GetLength(0); i++)
                {
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                    {
                        if (elementMin > doubleArray[i, j])
                        {
                            elementMin = doubleArray[i, j];
                        }
                    }
                }

                Console.WriteLine($"Минимальный элемент в массиве это число {elementMin}");
                return elementMin;
            }

            protected static int[] StringToIntArray(string text)
            {
                string[] bufArray = text.Split(' ');
                int[] arrayInt = new int[bufArray.Length - 1];
                for (int i = 0; i < arrayInt.GetLength(0); i++)
                {
                    arrayInt[i] = Int32.Parse(bufArray[i]);
                }
                return arrayInt;
            }

            protected static int[,] ReplaceElementToZero(int[,] doubleArray) //заменить нечетный элемент каждой строки нулем,
                                                                             //я выбрал по значению не четный, если имеется по порядку элемент то  переделаешь
            {
                int[,] arrayReplaced = doubleArray;
                for (int i = 0; i < arrayReplaced.GetLength(0); i++)
                {
                    for (int j = 0; j < arrayReplaced.GetLength(1); j++)
                    {
                        if (arrayReplaced[i, j] % 2 != 0 && arrayReplaced[i, j] != 0) { arrayReplaced[i, j] = 0; }
                        // if (j % 2 != 0 && j != 0)  { arrayReplaced[i, j] = 0; } //заменить на эту строку,в случае если нужны нечетные по номеру

                    }
                }
                Console.WriteLine($"Ответ: Массив где каждый нечетный элемент массива заменен на 0 \n{ShowDoubleArray(arrayReplaced)}");
                return arrayReplaced;
            }

            protected static int GetArrayWithoutEvenColumnLenght(int[,] doubleArray)
            {
                int deletedColumnCount = 0;

                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                    {
                        if (doubleArray[i, j] % 2 == 0) { deletedColumnCount++; }
                    }
                }
                return deletedColumnCount;
            }

            protected static int GetArrayWithNewStringHeight(int [,] doubleArray,int minElement)
            {
                int addedHeight = doubleArray.GetLength(0);
                

                for (int i = 0; i < doubleArray.GetLength(0); i++)
                {
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                    {
                        if(doubleArray[i,j] == minElement)
                        {
                            addedHeight++;
                            break;
                        }    
                    }
                }
                return addedHeight;
            }

            protected static int[,] InsertNewStringsToArray(int[,] doubleArray)
            {
                int minElement = GetDoubleArrayMinElement(doubleArray);
                int arrayWithStringY = GetArrayWithNewStringHeight(doubleArray,minElement);
                int[,] arrayWithNewStrings = new int[arrayWithStringY, doubleArray.GetLength(1)];

                int y = 0;
                
                bool addString = false;

                for (int i = 0; i < doubleArray.GetLength(0); i++,y++)
                {
                    if (addString)
                    {
                        for (int j = 0; j < doubleArray.GetLength(1); j++)
                        {
                            arrayWithNewStrings[y, j] = j + 1;
                            if (j + 1 == arrayWithNewStrings.GetLength(1)) { y++; addString = false; }
                        }
                    }
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                    {
                       if (doubleArray[i, j] == minElement) { addString = true; }
                        arrayWithNewStrings[y, j] = doubleArray[i, j];
                    }
                }
                if (addString)
                {
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                    {
                        arrayWithNewStrings[y, j] = j + 1;
                        if (j + 1 == arrayWithNewStrings.GetLength(1)) { y++; addString = false; }
                    }
                }

                Console.WriteLine("2. Ответ: Двойной массив в котором добавлена строка 1,2,3... \n" +
                $"после каждой строки содержащий минимальный элемент:\n{ShowDoubleArray(arrayWithNewStrings)}");

                return arrayWithNewStrings;

            }

            private static int[,] ReplaceFirstAndLastColumn(int[,] doubleArray)
            {
                int bufferElement;
                for (int i = 0; i < doubleArray.GetLength(0); i++)
                {
                    bufferElement = doubleArray[i, 0];
                    doubleArray[i, 0] = doubleArray[i, doubleArray.GetLength(1) - 1];
                    doubleArray[i, doubleArray.GetLength(1) - 1] = bufferElement;
                }

                Console.WriteLine("4. Ответ: Двойной массив в заменены первый и последний столбец \n" +
                                  $"\n{ShowDoubleArray(doubleArray)}");
                return doubleArray;
            }

            private static int[,] DeleteEvenColumns(int[,] doubleArray)
            {
                int deletedColumnCount = GetArrayWithoutEvenColumnLenght(doubleArray); // не забыть, что если останется 0 то вывести что нет начинающихся с четных элементов столбцов
                int[,] arrayWithoutEvenColumn = new int[doubleArray.GetLength(0),doubleArray.GetLength(1)-deletedColumnCount];
                
                int x = 0;
                int i;
                int j;

                if (deletedColumnCount > 0)
                {
                    
                    for (j = 0; j < doubleArray.GetLength(1); j++)
                    {
                        for (i = 0; i < doubleArray.GetLength(0); i++)
                        {
                            if (!(doubleArray[0, j] % 2 == 0))
                            {
                                arrayWithoutEvenColumn[i, x] = doubleArray[i, j];
                                if (i == doubleArray.GetLength(0)-1) { x++; }
                            }
                        }
                    }

                    Console.WriteLine("3. Ответ: Двойной массив в котором удалены столбцы с первым четным элементом: \n" +
                                         $"\n{ShowDoubleArray(arrayWithoutEvenColumn)}");
                }
                else
                {
                    Console.WriteLine("3. Ответ: Столбцов в которых первый элемент четный в массиве - нет! \n"); 
                }

                return arrayWithoutEvenColumn;
            }


        }

    }
}
