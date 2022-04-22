
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    public static class Display
    {
        //TODO: отрефакторить отображение массивов
        public static void ShowFieldArray(FieldObjectEnum[,] field)
        {
            Console.WriteLine("\n ");
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    ShowColoredSymbol(field[i, j]);
                }
            }
            Console.WriteLine("\n ");
        }
        public static void  ShowFieldArray(int [,] field)
        {
            Console.WriteLine("\n ");
           
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    Console.Write("|" + field[i, j] + "|");
                }
            }
            Console.WriteLine("\n ");
        }
        public static void ShowFieldArray(int[,] field,List<WayPoint> wayToTarget)
        {
            
            Console.WriteLine("\n ");

            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < field.GetLength(0); j++)
                {
                    foreach (var e in wayToTarget)
                    {
                        if (e.Y == i & e.X == j)
                        { Console.ForegroundColor = ConsoleColor.Red;
                          break;
                        }
                        
                    }
                    Console.Write("|" + field[i, j] + "|");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine("\n ");
        }

        private static void ShowColoredSymbol( FieldObjectEnum  symbol )
        {
            switch (symbol)
            {
                case FieldObjectEnum.F :
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|" + symbol + "|");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                case FieldObjectEnum.o:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("|" + symbol + "|");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                case FieldObjectEnum.A:
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("|" + symbol + "|");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                case FieldObjectEnum.B:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|" + symbol + "|");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                case FieldObjectEnum.E:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("|" + symbol + "|");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|"+symbol +"|");
                        break;
                    }

            }

        }
    }
}