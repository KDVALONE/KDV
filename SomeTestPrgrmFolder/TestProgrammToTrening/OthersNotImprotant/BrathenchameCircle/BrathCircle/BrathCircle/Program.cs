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
            int arrayY = 80;
            int arrayX = 80;
            int playerY = 40;
            int playerX = 40;
            int R = 30;
            Methods mtd = new Methods();

            //circlePoints = mtd.Circle();
            //circlePoints = mtd.SortCirclePoints(arrayY, arrayX, circlePoints);

            //int[,] arr = new int[15,15];
            //List<Point> test = new List<Point>();
            //test = mtd.BrathLineMethod(1,1,2,6);
            //foreach (var e in test)
            //{
            //    arr[e.X, e.Y] = 4; 

            //}

            //Display.ShowArray(arr);
            // mtd.PaintCircle(arrayY, arrayX, circlePoints);

            mtd.PaintSeeFeild(playerY, playerX, arrayY, arrayX, R);

            Console.ReadKey();
        }
    }
    
    class Methods
    {
        //public int [,] array = new int[20, 20];

        ////int X1 = 10;
        ////int Y1 = 10;
        ////int R = 4; //  радиус

        ////public List<Point> Circle()
        ////{
        ////    List<Point> CirclePoints = new List<Point>();
        ////    // R - радиус, X1, Y1 - координаты центра
        ////    int x = 0;
        ////    int y = R;
        ////    int delta = 1 - 2 * R;
        ////    int error = 0;

        ////    while (y >= 0)
        ////    {
        ////        #region отметка точек  вытянутых по Y 
        ////        // так как, почему - то, чертится скорее елипс, нежели окружность. То ниже реализация втянутая по Y, а в продакшене по X
        ////        //array[X1 + x, Y1 + y] = 1;
        ////        //Display.ShowArray(array); // для вывода окружности на дисплей, разкоментить
        ////        //CirclePoints.Add(new Point(X1 + x, Y1 + y));

        ////        //array[X1 + x, Y1 - y] = 1;
        ////        //Display.ShowArray(array);
        ////        //CirclePoints.Add(new Point(X1 + x, Y1 - y));

        ////        //array[X1 - x, Y1 - y] = 1;
        ////        //Display.ShowArray(array);
        ////        //CirclePoints.Add(new Point(X1 - x, Y1 - y));

        ////        //array[X1 - x, Y1 + y] = 1;
        ////        //Display.ShowArray(array);
        ////        //CirclePoints.Add(new Point(X1 - x, Y1 + y));
        ////        #endregion

        ////        //**
        ////        array[ Y1 + y, X1 + x] = 1;
        ////        Display.ShowArray(array); // для вывода окружности на дисплей, разкоментить
        ////        CirclePoints.Add(new Point( Y1 + y, X1 + x));

        ////        array[ Y1 - y, X1 + x] = 1;
        ////        Display.ShowArray(array);
        ////        CirclePoints.Add(new Point( Y1 - y, X1 + x));

        ////        array[ Y1 - y, X1 - x] = 1;
        ////        Display.ShowArray(array);
        ////        CirclePoints.Add(new Point( Y1 - y,X1 - x));

        ////        array[ Y1 + y,X1 - x] = 1;
        ////        Display.ShowArray(array);
        ////        CirclePoints.Add(new Point( Y1 + y, X1 - x));
        ////        //**

        ////        ////закоментить эту строчку. В основном алгоритме не участвует
        ////        //BrathLineMethod(array, BrCirclePoints[BrCirclePoints.Count - 2].X, BrCirclePoints[BrCirclePoints.Count - 2].Y, BrCirclePoints[BrCirclePoints.Count - 1].X, BrCirclePoints[BrCirclePoints.Count - 1].Y);


        ////        error = 2 * (delta + y) - 1;
        ////        if ((delta < 0) && (error <= 0))
        ////            { delta += 2 * ++x + 1; }
        ////        if ((delta > 0) && (error > 0))
        ////            { delta -= 2 * --y + 1; }
        ////        delta += 2 * (++x - y--);
        ////     }

        ////    return CirclePoints;
        //// }  // реализация алогоритма Бр. для круга
        ////public List<Point> BrathLineMethod( int Ax, int Ay, int Bx, int By)
        ////{
        ////    List<Point> circlePointFull = new List<Point>();

        ////    int deltax = Math.Abs(Bx - Ax);
        ////    int deltay = Math.Abs(By - Ay);
        ////    int error = 0;
        ////    int deltaerr = deltay;
        ////    int y = Ay;
        ////    int diry = By - Ay;

        ////    if (diry > 0)
        ////    {
        ////        diry = 1;
        ////    }
        ////    if (diry < 0)
        ////    {
        ////        diry = -1;
        ////    }
        ////    if (Ax == Bx & Ay == By)
        ////    {
        ////        circlePointFull.Add(new Point(Ay, Ax));
        ////    }
        ////    for (int x = Ax; x < Bx; x++) // for x from Ax to Bx
        ////    {
        ////        //array[x, y] = 4;//
        ////        //Display.ShowArray(array);//

        ////        circlePointFull.Add(new Point(y, x));
        ////        error = error + deltaerr;
        ////        if (2 * error >= deltax)
        ////        {
        ////            y = y + diry;
        ////            error = error - deltax;
        ////        }
        ////    }
        ////    return circlePointFull;

        ////} // реализация алгоритма Бр. для двух линий.
        ////public List<Point> SortCirclePoints( int arrayYLenght, int arrayXLenght, List<Point> circlePoints) // отсортировывает точки круга, для соединения их через метод line.
        ////{
        ////    List<Point> sortedPointsUpDown = new List<Point>();
        ////    List<Point> sortedPointsDownUp = new List<Point>();
        ////    List<Point> sortedPoints = new List<Point>();

        ////    int[,] array = new int[arrayYLenght, arrayXLenght];

        ////    foreach (var e in circlePoints) { array[e.Y, e.X] = 1; }

        ////    sortedPointsUpDown = SortClockWiseCounterUpDown(array);
        ////    sortedPointsDownUp = SortClockWiseCounterDownUp(array);
        ////    sortedPoints = sortedPointsUpDown;

        ////    foreach (var e in sortedPointsDownUp) { sortedPoints.Add(new Point(e.Y, e.X)); }

        ////    return sortedPoints;
        ////}
        public void PaintSeeFeild(int YPlayer,int XPlayer,int arrayYLenght, int arrayXLenght,int R) // начертить полный круг
        {
            List<Point> CircleSeePoints = new List<Point>();
            int[,] array = new int[arrayYLenght, arrayXLenght];

            CircleSeePoints = GetCirclePoints(YPlayer, XPlayer, R);
           
            PlotLine(arrayYLenght, arrayXLenght, YPlayer, XPlayer,  CircleSeePoints);
           
            

            //********
            //Point previosElement = circlePoints[0]; ;
            //foreach (var e in circlePoints)
            //{
            //    array[e.Y, e.X] = 3;
            //    Display.ShowArray(array);
            //}


            //for (int i = 0; i < circlePoints.Count; i++)
            //{
            //    circlePointsLine = BrathLineMethod(circlePoints[i].X, circlePoints[i].Y, previosElement.X, previosElement.Y);
            //    foreach (var e in circlePointsLine) { circlePointsFull.Add(new Point(e.Y, e.X)); }
            //    previosElement = circlePoints[i]; 
            //}

            //foreach (var e in circlePointsFull)
            //{
            //    array[e.Y, e.X] = 3;
            //    Display.ShowArray(array);
            //}

        }
        public void PlotLine(int arrayY, int arrayX, int playerY, int playerX, List<Point> pointList )
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

            //private List<Point> SortClockWiseCounterUpDown(int [,] array) // сортировка против часовой сверху вниз
            //{
            //    List<Point> sortedPoints = new List<Point>();

            //    for (int i = 0; i < array.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < array.GetLength(1); j++)
            //        {
            //            if (array[i, j] == 1)
            //            { 
            //                sortedPoints.Add(new Point(i, j));
            //                break;
            //            }
            //        }

            //    }
            //    return sortedPoints;
            //}
            //private List<Point> SortClockWiseCounterDownUp(int [,] array) // сортировка против часовой снизу вверх
            //{
            //    List<Point> sortedPoints = new List<Point>();

            //    for (int i = array.GetLength(0) -1 ; i >= 0; i--)
            //    {
            //        for (int j = array.GetLength(1)-1; j >= 0 ; j--)
            //        {
            //            if (array[i,j] == 1)
            //            {
            //                sortedPoints.Add(new Point(i, j));
            //                break;
            //            }
            //        }

            //    }
            //    return sortedPoints;
            //}
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
