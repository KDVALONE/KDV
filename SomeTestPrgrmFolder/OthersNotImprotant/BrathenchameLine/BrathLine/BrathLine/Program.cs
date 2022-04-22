using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrathLine
{/// <summary>
/// Алгоритм Брезенхейма, для начертания прямой линии между двумя точкми в матрице.
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Method mtd = new Method();
           
            mtd.PlotLine();
           
            Console.ReadKey();
        }
    }

    class Method
    {
        int[,] array = new int[20, 20];
        int Ax = 10;
        int Ay = 1;
        int Bx = 2;
        int By = 16;

        
        public void PlotLine()
        {
            int dx = Math.Abs(Bx - Ax), sx = Ax < Bx ? 1 : -1;
            int dy = -Math.Abs(By - Ay), sy = Ay < By ? 1 : -1;
            int err = dx + dy, e2; /* error value e_xy */

            for (; ; )
            {  /* loop */
                array[Ay, Ax] = 4;
                Display.ShowArray(array);
                if (Ax == Bx && Ay == By) break;
                e2 = 2 * err;
                if (e2 >= dy) { err += dy; Ax += sx; } /* e_xy+e_x > 0 */
                if (e2 <= dx) { err += dx; Ay += sy; } /* e_xy+e_y < 0 */

            }
          
        }


    }


    static class Display
    {
        public static void ShowArray(int[,] array)
        {
            Console.Clear();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == 1) { Console.ForegroundColor = ConsoleColor.Red; }
                    if (array[i, j] == 2) { Console.ForegroundColor = ConsoleColor.Green; }
                    if (array[i, j] == 3) { Console.ForegroundColor = ConsoleColor.Cyan; }
                    if (array[i, j] == 4) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                    Console.Write(array[i, j]);
                    Console.ResetColor();
                }
            }
            Thread.Sleep(200);
        }
    }
}


