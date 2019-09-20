using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ScyScrapers
{
    /// <summary>
    /// Ограничение времени, с  2
    ///Ограничение памяти, МБ  96
    ///Необходимо расставить небоскрёбы в городе размером 6х6 клеток, учитывая следующие ограничения:
    ///1. Высота любого небоскрёба: 1 - 6 этажей.
    ///2. Количество этажей у небоскрёба должно быть уникальным по строке и по столбцу.
    ///3. За более высокими небоскрёбами не видны более низкие
    ///4. Количество видимых небоскрёбов для строки или столбца (0 - любое количество).
    ///Входные данные
    ///Ограничения по количеству видимых небоскрёбов заданы строкой, состоящей из 24 чисел, разделенных запятыми.
    ///Ограничения расположены по часовой стрелке.
    /// Каждое число на рисунке обозначает порядковый номер числа-ограничения в строке.
    ///    0  1  2  3  4  5	
    /// 23 			     6
    /// 22			         7
    /// 21			         8
    /// 20			         9
    /// 19			         10
    /// 18	 	 	         11
    ///   17 16 15 14 13 12
    /// Выходные данные 
    /// ограничения, из 36 чисел, разделенные запятой.
    ///Первые 6 - высоты небоскребов в верхней строке карты, вторые 6 чисел - высоты небоскребов во второй строке карты и т.д.
    ///Задача имеет единственное решение.
    ///Напоминаем, что 0 в строке ограничений означает отсутствие ограничений.
    ///Пример:
    ///Входные данные: 0,0,0,2,2,0,0,0,0,6,3,0,0,4,0,0,0,0,4,4,0,3,0,0
    ///Выходные данные: 5,6,1,4,3,2,4,1,3,2,6,5,2,3,6,1,5,4,6,5,4,3,2,1,1,2,5,6,4,3,3,4,2,5,1,6
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            int fieldCount = 5;
            string limitsToFive = "2,1,3,2,3,3,4,2,1,2,2,1,3,4,3,3,4,2,1,2";
            string limitsToSix = "0,0,0,2,2,0,0,0,0,6,3,0,0,4,0,0,0,0,4,4,0,3,0,0";
            ScyScrapers sc = new ScyScrapers(limitsToFive,fieldCount);

            

            


            Console.ReadKey();
        }
    }

    /// <summary>
    /// Основной класс игры небоскребы
    /// </summary>
    public class ScyScrapers
    {
        public int[,] Field;
        public int[] UpLimits;
        public  int[] RightLimits;
        public  int[] DownLimits;
        public  int[] LeftLimits;
        public ScyScrapers(string limits,int fieldCount)
        {
            Field = ArrayWithLimitsInitialization(limits,fieldCount);
            UpLimits = GetUpLimits(Field);
            RightLimits = GetRightLimits(Field);
            DownLimits = GetDownLimits(Field);
            LeftLimits = GetLeftLimits(Field);
        }

        private int[,] ArrayWithLimitsInitialization(string limitations, int fieldCount)
        {
            //убираем запятые из строки
            var str = "";
            str = new string((from c in limitations
                              where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                              select c
                ).ToArray());

            int[,] field = new int[fieldCount+2, fieldCount+2];

            // инициализируем матрицу нулями
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = 0;
                }
            }

            int strCurIndex = 0;

            // 1 cтрока - заполняем ограничения
            field[0, 0] = -1;
            for (int j = 1; j < field.GetLength(1) - 1; j++, strCurIndex++)
            {
                field[0, j] = (int)char.GetNumericValue(str[strCurIndex]);
            }
            field[0, field.GetLength(0) - 1] = -1;

            // последний столбец - заполняем ограничения
            for (int i = 1, j = field.GetLength(1) - 1; i < field.GetLength(0) - 1; i++, strCurIndex++)
            {
                field[i, j] = (int)char.GetNumericValue(str[strCurIndex]);
            }

            // последняя строка - заполняем ограничения
            field[field.GetLength(1) - 1, field.GetLength(0) - 1] = -1;
            for (int j = field.GetLength(1) - 2; j > 0; j--, strCurIndex++)
            {
                field[field.GetLength(0) - 1, j] = (int)char.GetNumericValue(str[strCurIndex]);
            }
            field[field.GetLength(0) - 1, 0] = -1;

            // Первый столбец - заполняем ограничения
            for (int i = field.GetLength(0) - 2; i > 0; i--, strCurIndex++)
            {
                field[i, 0] = (int)char.GetNumericValue(str[strCurIndex]);
            }

            return field;
        }

        private int[] GetUpLimits(int[,] field)
        {
            int [] upLimits = new int [field.GetLength(0) - 2];

            for (int j = 1; j < field.GetLength(0) - 1; j++)
            {
                upLimits[j-1] = field[0, j];
            }

            return upLimits;
        }
        private int[] GetRightLimits(int[,] field)

        {
            int[] rightLimits = new int[field.GetLength(1) - 2];
            for (int i = 1, j = field.GetLength(1) - 1; i < field.GetLength(0) - 1; i++)
            {
                rightLimits[i - 1] = field[i, j];
            }
            return rightLimits;
        }
        private int[] GetDownLimits(int[,] field)
        {
            int limitsIndex = 0;
            int[] downLimits = new int[field.GetLength(0) - 2];
            for (int j = field.GetLength(1) - 2; j > 0; j--, limitsIndex++)
            {
                downLimits[limitsIndex] = field[field.GetLength(0) - 1, j];
            }

            Array.Reverse(downLimits);
            return downLimits;
        }
        private int[] GetLeftLimits(int[,] field)
        {
            int limitsIndex = 0;
            int[] leftLimits = new int[field.GetLength(1) - 2];
            for (int i = field.GetLength(0) - 2; i > 0; i--, limitsIndex++)
            {
                leftLimits[limitsIndex] = field[i, 0];
            }

            Array.Reverse(leftLimits);
            return leftLimits;
        }



        public void FindMaxBuild(ref int[,] filed)
        {
            

        }



    }

    /// <summary>
    /// Класс для отображения поля игры
    /// </summary>
    public static class FieldVisualisator
    {
       public static void ShowField(int [,] field)
        {
            Console.Clear();
            //отображаем массив
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write(" ");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i == 0){ Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                    if (i == field.GetLength(0)-1) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                    if (j == field.GetLength(1) - 1) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                    if (j == 0) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }

                    if (i != 0 &&
                        i != field.GetLength(0) - 1 &&
                        j != field.GetLength(1) - 1 &&
                        j != 0 &&
                        field[i, j] != 0)
                    {
                        switch (field[i,j])
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                        }
                        
                    }

                    Console.Write(field[i, j]);
                    Console.Write(" ");

                    Console.ResetColor();
                }

                Console.Write("\n");
                if (i != field.GetLength(0) - 2) Console.Write(" ");
            }
        }

      


    }

}
