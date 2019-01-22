using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeeSpaceFainder
{/// <summary>
/// На системе координат находим зону видимости обьекта.
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int arrayY = 80;
            int arrayX = 80;
            int playerY = 40;
            int playerX = 40;
            int R = 30;
            Methods mtd = new Methods();

            mtd.PaintSeeFeild(playerY, playerX, arrayY, arrayX, R);

            Console.ReadKey();
        }
    }
    
    class Methods
    {
        public void PaintSeeFeild(int YPlayer,int XPlayer,int arrayYLenght, int arrayXLenght,int R) // начертить полный круг
        {
            List<Point> CircleSeePoints = new List<Point>();
            int[,] array = new int[arrayYLenght, arrayXLenght];

            CircleSeePoints = GetCirclePoints(YPlayer, XPlayer, R);
            PlotLine(arrayYLenght, arrayXLenght, YPlayer, XPlayer,  CircleSeePoints);
           
        }
        public void PlotLine(int arrayY, int arrayX, int playerY, int playerX, List<Point> pointList ) // Провести линию до каждой точки окружности
        {
            int[,] array = new int[arrayY, arrayX];

            foreach (var e in pointList)
            {

            int destPointY = e.Y;
            int destPointX = e.X;

            
            int Ax = playerX;
            int Ay = playerY;
            int Bx = destPointY;
            int By = destPointX;

                int dx = Math.Abs(Bx - Ax), sx = Ax < Bx ? 1 : -1;
                int dy = -Math.Abs(By - Ay), sy = Ay < By ? 1 : -1;
                int err = dx + dy, e2; 

                for (; ; )
                {  
                    array[Ay, Ax] = 3;
                    
                    if (Ax == Bx && Ay == By) break;
                    e2 = 2 * err;
                    if (e2 >= dy) { err += dy; Ax += sx; } /* e_xy+e_x > 0 */
                    if (e2 <= dx) { err += dx; Ay += sy; } /* e_xy+e_y < 0 */

                }
            }
            Display.ShowArray(array);

        }
        public List<Point> GetCirclePoints(int X1, int Y1, int r)
        {
            List<Point> SeeRadiusPoints = new List<Point>();
            int x = -r, y = 0, err = 2 - 2 * r; /* II. Quadrant */
            do
            {
                SeeRadiusPoints.Add(new Point(Y1 + y, X1 - x)); /*   I. Quadrant */
                SeeRadiusPoints.Add(new Point(Y1 - x, X1 - y));  /*  II. Quadrant */
                SeeRadiusPoints.Add(new Point(Y1 - y, X1 + x)); /* III. Quadrant */
                SeeRadiusPoints.Add(new Point(Y1 + x, X1 + y)); /*  IV. Quadrant */


                r = err;
                if (r <= y) err += ++y * 2 + 1;           /* e_xy+e_y < 0 */
                if (r > x || err > y) err += ++x * 2 + 1; /* e_xy+e_x > 0 or no 2nd y-step */
            } while (x < 0);
            
            return SeeRadiusPoints;

        } // реализация алогоритма Бр. для круга
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point( int y, int x)
        {
            X = x;
            Y = y;
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
                    if (array[i, j] == 1) { Console.ForegroundColor = ConsoleColor.Red; }
                    if (array[i, j] == 2) { Console.ForegroundColor = ConsoleColor.Green; }
                    if (array[i, j] == 3) { Console.ForegroundColor = ConsoleColor.Blue; }
                    if (array[i, j] == 4) { Console.ForegroundColor = ConsoleColor.Yellow; }
                    Console.Write(array[i,j] +" ");
                    Console.ResetColor();
                }
            }
          //  Thread.Sleep(200);
           
        }

    }
}
