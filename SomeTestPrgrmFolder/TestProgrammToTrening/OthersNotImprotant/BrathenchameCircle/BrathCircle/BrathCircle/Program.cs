using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrathCircle
{/// <summary>
/// Попытаюсь написать алгорим Брезентхема для рисования окружности
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Method mtd = new Method();
            mtd.Circle();
            Console.ReadKey();
        }
    }

    class Method
    {
        public int [,] array = new int[20, 20];

        int X1 = 9;
        int Y1 = 9;
        int R = 6; //  радиус

        public void Circle()
        {
            // R - радиус, X1, Y1 - координаты центра
            int x = 0;
            int y = R;
            int delta = 1 - 2 * R;
            int error = 0;

            while (y >= 0)
            {
                //Display.ShowArray(array, X1 + x, Y1 + y);
                //Display.ShowArray(array, X1 + x, Y1 - y);
                //Display.ShowArray(array, X1 - x, Y1 + y);
                //Display.ShowArray(array, X1 - x, Y1 - y);
                array[X1 + x, Y1 + y] = 1;
                Display.ShowArray(array);
                array[X1 + x, Y1 - y] = 1;
                Display.ShowArray(array);
                array[X1 - x, Y1 + y] = 1;
                Display.ShowArray(array);
                array[X1 - x, Y1 - y] = 1;
                Display.ShowArray(array);


                error = 2 * (delta + y) - 1;
                if ((delta < 0) && (error <= 0))
                    { delta += 2 * ++x + 1; }
                if ((delta > 0) && (error > 0))
                    { delta -= 2 * --y + 1; }
                delta += 2 * (++x - y--);
             }
         }
    }

    public static class Display
    {
        public static void ShowArray(int [,] array)
        {
            Console.Clear();
            for(int i = 0; i < array.GetLength(0);i++)
            {
                Console.WriteLine();
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i,j]);
                }
            }
            Thread.Sleep(200);
            
        }

    }
}
