
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2DelPrgm
{
    class Display
    {
        public void ShowFieldArray(FieldObjectEnum[,] field)
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
        public void ShowFieldArray(int [,] field)
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
        private void ShowColoredSymbol( FieldObjectEnum  symbol )
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