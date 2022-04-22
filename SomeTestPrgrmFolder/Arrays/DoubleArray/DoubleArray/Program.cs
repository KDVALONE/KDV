using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleArray
{

        class Program
        {
            static void Main(string[] args)
            {
                Method();
                Console.ReadKey();
            }


            public static void Method()
            {
                int[,] arr = new int[2, 6];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        arr[i, j] = i + j;
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.Write(arr[i, j] + "\t");
                    }
                }
                // arr[2] ^= arr[6]; только с ИНТ СОХРАНИ!!!! Менят местами елементы!!! Магия!
                // Нужна проверка
            }
        }
    }
