using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrathCircleNew
{
    class Program
    {


        static void Main(string[] args)
        {
            int[,] arr = new int[30, 30];
            int X1 = 10;
            int Y1 = 10;
            int R = 7;

            Method mtd = new Method();
           
           mtd.PlotCircle(arr, X1, Y1, R);
          //  mtd.PlotEllipseRect(X1, Y1, 20, 20);
            Console.ReadKey();
        }
    }

    class Method
    {
       

        public void PlotCircle(int [,] array,int X1, int Y1, int r)
        {
            int x = -r, y = 0, err = 2 - 2 * r; /* II. Quadrant */
            do
            {
                array[X1 - x, Y1 + y] = 2 ; /*   I. Quadrant */
                Display.ShowArray(array); // для вывода окружности на дисплей, разкоментить
                array[X1 - y, Y1 - x] = 2; /*  II. Quadrant */
                Display.ShowArray(array); // для вывода окружности на дисплей, разкоментить
                array[X1 + x, Y1 - y]= 2; /* III. Quadrant */
                Display.ShowArray(array); // для вывода окружности на дисплей, разкоментить
                array[X1 + y, Y1 + x] = 2; /*  IV. Quadrant */
                Display.ShowArray(array); // для вывода окружности на дисплей, разкоментить

                r = err;
                if (r <= y) err += ++y * 2 + 1;           /* e_xy+e_y < 0 */
                if (r > x || err > y) err += ++x * 2 + 1; /* e_xy+e_x > 0 or no 2nd y-step */
            } while (x < 0);
        } // реализация алогоритма Бр. для круга

        public void PlotEllipseRect(int x0, int y0, int x1, int y1)
        {
            int[,] array = new int[30,30];
            int a = Math.Abs(x1 - x0), b = Math.Abs(y1 - y0), b1 = b & 1; /* values of diameter */
            long dx = 4 * (1 - a) * b * b, dy = 4 * (b1 + 1) * a * a; /* error increment */
            long err = dx + dy + b1 * a * a, e2; /* error of 1.step */

            if (x0 > x1) { x0 = x1; x1 += a; } /* if called with swapped points */
            if (y0 > y1) y0 = y1; /* .. exchange them */
            y0 += (b + 1) / 2; y1 = y0 - b1;   /* starting pixel */
            a *= 8 * a; b1 = 8 * b * b;

            do
            {
                array[x1, y0] = 1; /*   I. Quadrant */
                Display.ShowArray(array);
                array[x0, y0] = 1; /*  II. Quadrant */
                Display.ShowArray(array);
                array[x0, y1] = 1; /* III. Quadrant */
                Display.ShowArray(array);
                array[x1, y1] = 1 ; /*  IV. Quadrant */
                Display.ShowArray(array);
                e2 = 2 * err;
                if (e2 <= dy) { y0++; y1--; err += dy += a; }  /* y step */
                if (e2 >= dx || 2 * err > dy) { x0++; x1--; err += dx += b1; } /* x step */
            } while (x0 <= x1);

            while (y0 - y1 < b)
            {  /* too early stop of flat ellipses a=1 */
                array[x0 - 1, y0] = 2 ; /* -> finish tip of ellipse */
                Display.ShowArray(array);
                array[x1 + 1, y0++] = 2;
                Display.ShowArray(array);
                array[x0 - 1, y1] = 2;
                Display.ShowArray(array);
                array[x1 + 1, y1--] =2;
                Display.ShowArray(array);
            }
        }  // реализация алогоритма Бр. для элипса.
    }

    public static class Display
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
                    if (array[i, j] == 2) { Console.ForegroundColor = ConsoleColor.Blue; }
                    if (array[i, j] == 3) { Console.ForegroundColor = ConsoleColor.Green; }
                    if (array[i, j] == 4) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                    Console.Write(array[i, j] + " " );
                    Console.ResetColor();
                }

            }
           
        }
    }

}
