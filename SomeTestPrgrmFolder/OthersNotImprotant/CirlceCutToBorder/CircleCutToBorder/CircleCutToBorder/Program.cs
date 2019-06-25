using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CircleCutToBorder
{/// <summary>
 /// Есть некая область видимости.С радиусом.
 /// сделать так чтоб она не вылезала за граници (массива, или искуственного отделения.)
 /// В примере за искуственное отделение будет выступасть искуственная стена.
 /// </summary>
 /// 
    class Program
    {
        static void Main(string[] args)
        {
            Start strt = new Start();
            int arrayCount = 45; //размерность матрицы
            int playerX = 15;
            int playerY = 15;// стартовый Y для цетральной точки 
            for (int i = playerY; playerY < arrayCount; i++)
            {
                strt.Sart(i,playerX,arrayCount);
            }
            
        }

    }

   public class Start
    {
        public void Sart(int playerY, int playerX, int arrayCount)
        {
                List<Point> circlePoints = new List<Point>();
                //int arrayCount = 40;
                int[,] arr = new int[arrayCount, arrayCount];
              
                int X1 = playerX;
                int Y1 = playerY;
               //int X1 = 15;
               // int Y1 = 15;

                int R = 11;
                int WallMargin = R + 2;

                Method mtd = new Method();
                arr = mtd.AddWalls(arr, WallMargin);
                mtd.AddStones(arr);

                Y1 += 1;

                circlePoints = mtd.PlotCircle(arr, X1, Y1, R);

                foreach (var e in circlePoints)
                {
                    mtd.PlotLine(arr, Y1, X1, e);
                }
                arr[Y1, X1] = 2;
                Display.ShowArray(arr);

                

            Console.ReadKey();
            

        }

    }
    
    class Method
    {

        public void PlotLine(int [,] array,int playerY, int playerX, Point point)
        {
            int Ay = playerY;
            int Ax = playerX;
            int By = point.Y;
            int Bx = point.X;
            int Wall = 3;

            int Xmax = array.GetLength(1)-1;
            int Ymax = array.GetLength(0)-1;

            int dx = Math.Abs(Bx - Ax), sx = Ax < Bx ? 1 : -1;
            int dy = -Math.Abs(By - Ay), sy = Ay < By ? 1 : -1;
            int err = dx + dy, e2; /* error value e_xy */

            for (; ; ) // петля
            {  
                if (Ax > Xmax || Ay > Ymax || Ay < 0 || Ax < 0) break;
                if (array[Ay,Ax] == Wall ) break;
                array[Ay, Ax] = 4;
                
                if (Ax == Bx && Ay == By ) break;
                e2 = 2 * err;
                if (e2 >= dy) { err += dy; Ax += sx; } /* e_xy+e_x > 0 */
                if (e2 <= dx) { err += dx; Ay += sy; } /* e_xy+e_y < 0 */
            }
        } // реализация алогоритма Бр. для линии (Вот тут модификация для стены)

        public List<Point> PlotCircle(int[,] array, int X1, int Y1, int r)
        {
            List<Point> circlePoints = new List<Point>();

            int x = -r, y = 0, err = 2 - 2 * r; /* II. Quadrant */
            do
            {
                circlePoints.Add(new Point(Y1 + y, X1 - x)); /*   I. Quadrant */
                circlePoints.Add(new Point(Y1 - x, X1 - y)); /*  II. Quadrant */
                circlePoints.Add(new Point(Y1 - y, X1 + x)); /* III. Quadrant */
                circlePoints.Add(new Point(Y1 + x, X1 + y)); /*  IV. Quadrant */

                //array[X1 - x, Y1 + y] = 2; /*   I. Quadrant */ // из за статики изменения напрямую происходят
                //array[X1 - y, Y1 - x] = 2; /*  II. Quadrant */
                //array[X1 + x, Y1 - y] = 2; /* III. Quadrant */
                //array[X1 + y, Y1 + x] = 2; /*  IV. Quadrant */


                r = err;
                if (r <= y) err += ++y * 2 + 1;           /* e_xy+e_y < 0 */
                if (r > x || err > y) err += ++x * 2 + 1; /* e_xy+e_x > 0 or no 2nd y-step */
            } while (x < 0);

            return circlePoints;
        } // реализация алогоритма Бр. для круга 
        public int [,] AddWalls(int[,] array, int wallMargin) // создаем массив со стеной
        {
            for (int x = wallMargin; x <= array.GetLength(1)+1 - (wallMargin + 2); x++) { array[wallMargin, x] = 3; } // верхняя стена
            for (int x = wallMargin; x <= array.GetLength(1)+1 - (wallMargin + 2); x++) { array[array.GetLength(1) - wallMargin, x] = 3; } // нижняя стена

            for (int y = wallMargin; y <= array.GetLength(0)+2 - (wallMargin + 2); y++) { array[y, array.GetLength(0) - wallMargin] = 3; } // правая стена
            for (int y = wallMargin; y <= array.GetLength(0)+1 - (wallMargin + 2); y++) { array[y, wallMargin] = 3; } // правая стена

            return array;
        }
        public void AddStones(int[,] array)
        {
            Point stone1 = new Point(27,19);
            Point stone2 = new Point(27,18);
            Point stone3 = new Point(27,17);
            Point stone4 = new Point(26,11);
            Point stone5 = new Point(26,11);
            Point stone6 = new Point(23,15);
            Point stone7 = new Point(23,16);
            Point stone8 = new Point(23,17);
            Point stone9 = new Point(21, 11);
            Point stone10 = new Point(10, 15);
            Point stone11 = new Point(10, 16);
            Point stone12 = new Point(18, 17);

            array[stone1.Y, stone1.X] = 3;
            array[stone2.Y, stone2.X] = 3;
            array[stone3.Y, stone3.X] = 3;
            array[stone4.Y, stone4.X] = 3;
            array[stone5.Y, stone5.X] = 3;
            array[stone6.Y, stone6.X] = 3;
            array[stone7.Y, stone7.X] = 3;
            array[stone8.Y, stone8.X] = 3;
            array[stone9.Y, stone9.X] = 3;
            array[stone10.Y, stone10.X] = 3;
            array[stone11.Y, stone11.X] = 3;
            array[stone12.Y, stone12.X] = 3;
        }
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
                    if (array[i, j] == 1) { Console.ForegroundColor = ConsoleColor.DarkGray; }
                    if (array[i, j] == 2) { Console.ForegroundColor = ConsoleColor.Red; } 
                    if (array[i, j] == 3) { Console.ForegroundColor = ConsoleColor.Blue; } // окруж.
                    if (array[i, j] == 4) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }// стена.
                    Console.Write(array[i, j] + " ");
                    Console.ResetColor();
                }

            }

        }
    }
    public struct Point
    {
       public int Y, X;
        public Point(int y, int x)
        {
            X = x;
            Y = y;
        }
    }



}
