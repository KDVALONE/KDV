using System;
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
         5.      Заменить нечетный элемент каждой строки нулем (сам элемент или норме у него не четный?)
         6.      Вставить после всех строк, содержащих минимальное значение строку 1,2,3,…. 
         7.      Удалить все столбцы, в которых первый элемент четный 
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
            static void Main(string[] args)
            {
                ShowObjective();
                // Array = IsHandeArrayFill() ? SetArrayHandcrafted() : SetDoubleArrayAuto();
                // ArrayWithZero = ReplaceElementToZero(Array); 
                //Array = new int[,] { { 13, 72, 26 }, { 42, -98, -95 }, { 24, -98, 15 }, { -45, 5, 78 } };
                //Array = new int[,] { { 61, 88, 79 }, { 77, -87, -80 }, { -62, -97, -64 }, { 72,-15, -73 },{-40, 86,-61},{-69,-27,73},{-76,92,-33},{89,25,16} };
                Array = new int[,] { { 13, -72, 26 }, { 42, -72, 95 }, { 24, -72, 15 }};
                ArrayWithNewString = InsertNewStringsToArray(Array);


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
            //protected static int SetK()
            //{
            //    Console.WriteLine("Введите число K, для решения задания №2 ");
            //    bool flagOfEnterdCount = true;
            //    string enteredValue = "";
            //    int value;
            //    do
            //    {
            //        enteredValue = Console.ReadLine();
            //        if (!Int32.TryParse(enteredValue, out value))
            //        {
            //            Console.WriteLine("Вы ввели не целое число.  Попробуйте еще раз.");
            //            flagOfEnterdCount = false;
            //        }
            //        else
            //        {
            //            value = Convert.ToInt32(enteredValue);
            //            flagOfEnterdCount = true;
            //        }
            //    } while (!flagOfEnterdCount);

            //    return value;
            //}
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
            protected static int[] GetStringIndexToInsert(int[,] doubleArray)
            {
                int elementMin = doubleArray[0, 0];
                int[] arrayOfMinElmtIndx;// массив с номерами строк, после которых нужно вставить новую строку.

                string strWithMinElem = "";

                for (int i = 0; i < doubleArray.GetLength(0); i++)
                {
                    for (int j = 0; j < doubleArray.GetLength(1); j++)
                    {
                        if (elementMin > doubleArray[i, j])
                        {
                            elementMin = doubleArray[i, j];

                            strWithMinElem = i.ToString() + ' ';
                        }
                        if (elementMin == doubleArray[i, j] && !strWithMinElem.Contains(i.ToString()))
                        {
                            strWithMinElem += i.ToString() + ' ';
                        }
                    }
                }

                arrayOfMinElmtIndx = StringToIntArray(strWithMinElem);

                Console.WriteLine($"Минимальный элемент в массиве это число {elementMin}");
                return arrayOfMinElmtIndx;
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

            protected static int[,] InsertNewStringsToArray(int[,] doubleArray)
            {
                int[] arrayString = new int[doubleArray.GetLength(1)];
                for (int i = 0; i < arrayString.Length; i++)
                {
                    arrayString[i] = i + 1;
                }

                int[] strsIndx = GetStringIndexToInsert(Array); // массив с индексами строк после которых нужно вставить свою строку
                int[,] arrayLongest = new int[doubleArray.GetLength(0) + strsIndx.Length, doubleArray.GetLength(1)];
                //int crntIndex = 0;
                //int sPlus = 1; // значение на которое сдвигается индекс строк изначального массива вперед 
                //int sMin=0 ; // значение на которое сдвигается индекс строк изначального массива вперед 
                int indexArrayString = 0;
                int indx = 0;
                int i2 = 0;
                int j2 = 0;
                bool flag = false;
                bool flag2 = false;
                for (int i = 0; i < arrayLongest.GetLength(0); i++)
                {
                    for (int j = 0; j < arrayLongest.GetLength(1); j++)
                    {
                                       
                        if (!flag2)
                        {
                            if (i2 == arrayString[indx] && flag == false)
                            {
                                flag = true; // включается когда следующей стракой нужно вставить свою строку
                            }
                            arrayLongest[i, j] = doubleArray[i2, j2];
                            if (j2 < doubleArray.GetLength(1))
                            {
                                j2++;
                            }
                            if (j2 == doubleArray.GetLength(1))
                            {
                                j2 = 0;
                            }
                        }
                        else
                        {
                            arrayLongest[i, j] = arrayString[indexArrayString];
                            if (indexArrayString < arrayString.Length)
                            {
                                indexArrayString++;
                            }
                            if (indexArrayString == arrayString.Length)
                            {
                                indexArrayString = 0;
                                flag2 = false;
                            }
                        }
                    }
                    if (i2 < doubleArray.GetLength(0)&& !flag)
                    {
                        i2++;
                    }
                    if (i2 == doubleArray.GetLength(0))
                    {
                        i2 = 0;
                    }
                    if (flag) {
                        flag = false;
                        if (indx != strsIndx.GetLength(0) && strsIndx.GetLength(0) > 1)
                        { 
                        indx++;
                        }
                        flag2 = true; }
                }
                Console.WriteLine("2. Ответ: Двойной массив в котором добавлена строка 1,2,3... \n" +
                       $"после каждой строки содержащий минимальный элемент:\n{ShowDoubleArray(arrayLongest)}");
                return arrayLongest;
#region
                //protected static void DeleteZeroByArray(int[] array)
                //{
                //    int i = 0;

                //    foreach (int e in array)
                //    {
                //        if (!e.ToString().Contains('0'))
                //        {
                //            i++;
                //        }
                //    }

                //    int[] arrayWithoutZero = new int[i];
                //    i = 0;
                //    foreach (int e in array)
                //    {
                //        if (!e.ToString().Contains('0'))
                //        {
                //            arrayWithoutZero[i] = e;
                //            i++;
                //        }
                //    }
                //    Console.WriteLine($"1. Ответ: массив в котором цифры содержащие 0 удалены \n" +
                //                        $"{ShowArray(arrayWithoutZero)}");
                //}
                //protected static void InsertKInArray(int[] array)
                //{
                //    int i = 0;
                //    foreach (int e in array)
                //    {
                //        if (e % 2 == 0)
                //        {
                //            i++;
                //        }
                //    }
                //    int[] arrayWithK = new int[array.Length + i];
                //    int index = 0;

                //    foreach (int e in array)
                //    {
                //        if (e % 2 == 0)
                //        {
                //            arrayWithK[index] = e;
                //            arrayWithK[index + 1] = K;
                //            index += 2;
                //        }
                //        else
                //        {
                //            arrayWithK[index] = e;
                //            index++;
                //        }
                //    }
                //    Console.WriteLine($"2. Вставили число {K} после всех четных сичел, \n" +
                //    $"получившийся массив {ShowArray(arrayWithK)}");

                //}
                //protected static void ReversElements(int[] array)
                //{
                //    int[] PstvElmtIndx = { -1, -1, -1 };
                //    int[] NgtvElmtIndx = { -1, -1, -1 };
                //    int countOfRevers = 0;
                //    int buff;

                //    int i = 0;
                //    int j = 0;
                //    for (int indx = 0; indx < array.Length; indx++)
                //    {
                //        if (array[indx] > 0 && i < 3)
                //        {
                //            PstvElmtIndx[i] = indx;
                //            i++;
                //        }
                //        else if (array[indx] < 0 && j < 3)
                //        {
                //            NgtvElmtIndx[j] = indx;
                //            j++;
                //        }
                //    }


                //    for (int ind = 0; ind < 3; ind++)
                //    {
                //        if (PstvElmtIndx[ind] >= 0 && NgtvElmtIndx[ind] >= 0)
                //        {
                //            buff = array[PstvElmtIndx[ind]];
                //            array[PstvElmtIndx[ind]] = array[NgtvElmtIndx[ind]];
                //            array[NgtvElmtIndx[ind]] = buff;
                //            countOfRevers++;
                //        }
                //    }
                //    string text = countOfRevers < 3 ? $"Так как положительных и отрицательных элементов не равное колличество, то \n" : "Успешно";

                //    Console.WriteLine($"3. Ответ: {text}было поменяно местами  {countOfRevers} елемента, \n получившийся массив {ShowArray(array)}");

                //}
#endregion
            }
        }

    }
}
