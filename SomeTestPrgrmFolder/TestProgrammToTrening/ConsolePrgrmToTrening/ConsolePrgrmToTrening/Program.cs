using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNameSpace
{
  
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {

            int[,] array = new int[10, 10];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[i, j] = -3;
                }
            }
            ShowArray(array);
            LeeAlgoritm(array);

            Console.ReadKey();

        }
        public static void ShowArray(int[,] array)
        {
            Console.WriteLine("********************");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
           

        }

        public static void LeeAlgoritm(int[,] array)
        {
            Console.WriteLine("Lee Algoritm On");
            int symbol = 0;
            List<Point> pointCurrent = new List<Point>();
            pointCurrent.Add(new Point(2, 2));
            List<Point> pointToNextTurn = new List<Point>();

            while (pointCurrent.Count != 0) // заменить на find way to target как то так, или пока существуют ячейки с -2
            {
                foreach (var e in pointCurrent)
                {
                    array[e.I, e.J] = symbol;
                    GetUpElement(e,array,ref pointToNextTurn);
                    GetDownElement(e, array, ref pointToNextTurn);
                    GetLeftElement(e, array, ref pointToNextTurn);
                    GetRightElement(e, array, ref pointToNextTurn);
                }

                ShowArray(array);
                pointCurrent.Clear();
                pointToNextTurn.ForEach((item) =>
                {
                    pointCurrent.Add(new Point(item.I, item.J));
                });
                pointToNextTurn.Clear();
                symbol++;

            }
            Console.WriteLine("Lee Algoritm OFF");
        }
        public static void GetUpElement(Point pointCurent, int [,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.I - 1 >= 0 )
            {
                if (!pointToNextTurn.Exists(x => x.I == pointCurent.I - 1 & x.J == pointCurent.J) & array[pointCurent.I-1,pointCurent.J] == -3)
                {
                    pointToNextTurn.Add(new Point (pointCurent.I - 1, pointCurent.J));
                }
            }

        }
        public static void GetDownElement(Point pointCurent, int[,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.I + 1 < array.GetLength(0))
            {
                if (!pointToNextTurn.Exists(x => x.I == pointCurent.I + 1 & x.J == pointCurent.J) & array[pointCurent.I + 1, pointCurent.J] == -3)
                {
                    pointToNextTurn.Add(new Point(pointCurent.I + 1, pointCurent.J));
                }
            }

        }

        public static void GetLeftElement(Point pointCurent, int[,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.J - 1 >= 0)
            {
                if (!pointToNextTurn.Exists(x => x.I == pointCurent.I  & x.J == pointCurent.J-1) & array[pointCurent.I, pointCurent.J-1] == -3)
                {
                    pointToNextTurn.Add(new Point(pointCurent.I , pointCurent.J-1));
                }
            }

        }
        public static void GetRightElement(Point pointCurent, int[,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.J + 1  < array.GetLength(1))
            {
                if (!pointToNextTurn.Exists(x => x.I == pointCurent.I & x.J == pointCurent.J+1) & array[pointCurent.I, pointCurent.J+1] == -3)
                {
                    pointToNextTurn.Add(new Point(pointCurent.I, pointCurent.J+1));
                }
            }

        }
        
    }
   
    public struct Point
        {
            public int I;
            public int J;
            public Point(int i, int j)
            {
                I = i;
                J = j;
            }
        }

  }
