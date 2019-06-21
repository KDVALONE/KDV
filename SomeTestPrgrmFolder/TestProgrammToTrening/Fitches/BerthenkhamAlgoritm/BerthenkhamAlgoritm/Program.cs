using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BerthenkhamAlgoritm
{/// <summary>
/// Алгорим Берзенкхема, оцифровки линии к точке
/// Бедет мофдифинован чтоьы закрасить висю видимую зону для обьекта, за перпятствиями в видно не будет
/// </summary>
    class Program
    {
        static Random rnd = new Random();
        static public int HorizontalTreeCount = 4;
        static public int VerticalTreeCount = 3;
        static public int[,] array = new int[20, 20];
        static public int ForestDeep = 4;
        static public int PlayerVisbleRadius = 5;
        // static MapPoint playerCurrentPoint;


        static void Main(string[] args)
        {
            array = InitializeArray(array);
            Display.ShowArray(array);
            PlayerMoving.PlayerMoved(array, PlayerVisbleRadius);



            Console.ReadKey();
        }

        static int[,] InitializeArray(int[,] array)
        {
            array = AddGround(array);
            array = AddTree(array);

            return array;
        }

        private static int[,] AddGround(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[i, j] = (int)ElementOnMap.Ground;
                }
            }
            return array;

        }
        private static int[,] AddTree(int[,] array)
        {
            array = AddTreeHorizntal(array, HorizontalTreeCount);
            array = AddTreeVertical(array, VerticalTreeCount);

            return array;
        }
        private static int[,] AddTreeHorizntal(int[,] array, int horizontalTreeCount)
        {
            int y;
            int x;
            int AddedTree = 0;
            while (AddedTree < horizontalTreeCount)
            {
                int forestDeep = 1;
                y = rnd.Next(ForestDeep, array.GetLength(0) - ForestDeep);
                x = rnd.Next(ForestDeep, array.GetLength(1) - ForestDeep);
                array[y, x] = (int)ElementOnMap.Tree;
                while (forestDeep != ForestDeep)
                {
                    array[y, x + forestDeep] = (int)ElementOnMap.Tree; // cдвиг влево по х
                    forestDeep++;
                }
                AddedTree++;
            }
            return array;

        }
        private static int[,] AddTreeVertical(int[,] array, int verticalTreeCount)
        {
            int y;
            int x;
            int AddedTree = 0;
            while (AddedTree < verticalTreeCount)
            {
                int forestDeep = 1;
                y = rnd.Next(ForestDeep, array.GetLength(0) - ForestDeep);
                x = rnd.Next(ForestDeep, array.GetLength(1) - ForestDeep);
                array[y, x] = (int)ElementOnMap.Tree;
                while (forestDeep != ForestDeep)
                {
                    array[y + forestDeep, x] = (int)ElementOnMap.Tree; // cдвиг вниз по y
                    forestDeep++;
                }

                AddedTree++;
            }
            return array;
        }

    }


    public enum ElementOnMap
    {
        Ground = 0,
        Player,
        Tree,
        VisibleZone

    }
    public enum PlayerMoveVariant
    {
        GoDown,
        GoRight
    }
    static class Display
    {
        public static void ShowArray(int[,] array)
        {
            Console.Clear();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    ColoredSymbol(array[i, j]);
                }
                Console.WriteLine();
            }
            Thread.Sleep(200);

        }

        private static void ColoredSymbol(int symbol)
        {
            switch (symbol)
            {
                case (int)ElementOnMap.Ground: { Console.ForegroundColor = ConsoleColor.DarkYellow; break; }
                case (int)ElementOnMap.Player: { Console.ForegroundColor = ConsoleColor.Blue; break; }
                case (int)ElementOnMap.Tree: { Console.ForegroundColor = ConsoleColor.Green; break; }
                case (int)ElementOnMap.VisibleZone: { Console.ForegroundColor = ConsoleColor.Red; break; }
            }
            Console.Write(symbol);
            Console.ResetColor();
        }
    }
    public struct MapPoint
    {
        public int Y;
        public int X;
        public MapPoint(int y, int x)
        {
            Y = y;
            X = x;
        }
    }
    public static class PlayerMoving
    {

        public static void PlayerMoved(int[,] array, int playerVisbleRadius)
        {

            PlayerGoRight(array,playerVisbleRadius);
            PlayerGoDown(array);
            //MapPoint playerUpStartPoint = PlayerStartPointInitialization(array, PlayerMoveVariant.GoDown);

        }

        private static void PlayerGoRight(int[,] array ,int playerVisbleRadius)
        {

            MapPoint playerCurrentPoint = PlayerStartPointInitialization(array, PlayerMoveVariant.GoRight);
            MapPoint playerBeforePoint = playerCurrentPoint;
            int playerBeforeCellElement = array[playerCurrentPoint.Y, playerCurrentPoint.X];

            while (playerCurrentPoint.X != array.GetLength(0))
            {
                array = PlayerStepRight(ref array, playerCurrentPoint, ref playerBeforeCellElement, ref playerBeforePoint);
                GetPlayerVisibleSpace(array,playerCurrentPoint, playerVisbleRadius);
                Display.ShowArray(array);
                playerCurrentPoint.X++;
            }

            Console.WriteLine("Проход в право завершен");
            Thread.Sleep(1000);
            array[playerBeforePoint.Y, playerBeforePoint.X] = playerBeforeCellElement;

        }
        private static int[,] PlayerStepRight(ref int[,] array, MapPoint playerCurrentPoint, ref int playerBeforeCellElement, ref MapPoint playerBeforePoint)
        {
            array[playerBeforePoint.Y, playerBeforePoint.X] = playerBeforeCellElement;
            playerBeforeCellElement = array[playerCurrentPoint.Y, playerCurrentPoint.X];

            if (array[playerCurrentPoint.Y, playerCurrentPoint.X] == (int)ElementOnMap.Ground)
            {
                array[playerCurrentPoint.Y, playerCurrentPoint.X] = (int)ElementOnMap.Player;
            }

            playerBeforePoint.Y = playerCurrentPoint.Y;
            playerBeforePoint.X = playerCurrentPoint.X;
            return array;
        }

        private static void PlayerGoDown(int[,] array)
        {
            MapPoint playerCurrentPoint = PlayerStartPointInitialization(array, PlayerMoveVariant.GoDown);
            MapPoint playerBeforePoint = playerCurrentPoint;
            int playerBeforeCellElement = array[playerCurrentPoint.Y, playerCurrentPoint.X];

            while (playerCurrentPoint.Y != array.GetLength(1))
            {
                array = PlayerStepDown(ref array, playerCurrentPoint, ref playerBeforeCellElement, ref playerBeforePoint);
                Display.ShowArray(array);
                playerCurrentPoint.Y++;
            }

            Console.WriteLine("Проход влево завершен");
            Thread.Sleep(1000);
            Display.ShowArray(array);
            array[playerBeforePoint.Y, playerBeforePoint.X] = playerBeforeCellElement;
        }
        private static int[,] PlayerStepDown(ref int[,] array, MapPoint playerCurrentPoint, ref int playerBeforeCellElement, ref MapPoint playerBeforePoint)
        {
            array[playerBeforePoint.Y, playerBeforePoint.X] = playerBeforeCellElement;
            playerBeforeCellElement = array[playerCurrentPoint.Y, playerCurrentPoint.X];

            if (array[playerCurrentPoint.Y, playerCurrentPoint.X] == (int)ElementOnMap.Ground)
            {
                array[playerCurrentPoint.Y, playerCurrentPoint.X] = (int)ElementOnMap.Player;
            }

            playerBeforePoint.Y = playerCurrentPoint.Y;
            playerBeforePoint.X = playerCurrentPoint.X;
            return array;
        }

        public static MapPoint PlayerStartPointInitialization(int[,] array, PlayerMoveVariant playerCurrentMove)
        {
            MapPoint startPlayerPoint;
            startPlayerPoint = playerCurrentMove == PlayerMoveVariant.GoRight ? FindLeftStartPoint(array) : FindUpStartPoint(array);

            return startPlayerPoint;

        }
        private static MapPoint FindUpStartPoint(int[,] array)
        {
            int y = 0;
            int x = (array.GetLength(1) % 2) == 0 ? array.GetLength(1) / 2 : (array.GetLength(1) + 1) / 2;
            return new MapPoint(y, x);
        }
        private static MapPoint FindLeftStartPoint(int[,] array)
        {
            int y = (array.GetLength(0) % 2) == 0 ? array.GetLength(0) / 2 : (array.GetLength(0) + 1) / 2;
            int x = 0;
            return new MapPoint(y, x);
        }

        private static void GetPlayerVisibleSpace(int[,] array,MapPoint playerPoint, int playerVisbleRadius ) // главный метод для получения простраства видимости
        {
            List<MapPoint> playerVisiblePoints = new List<MapPoint>();

            playerVisiblePoints = GetPlayerVisibleDistancePoint(playerPoint.X, playerPoint.Y, playerVisbleRadius);
            //TODO: сделать обрезку видимой части по границам массива, в отдельный метод

        } // реализация алогоритма Бр. для круга

        private static List<MapPoint> GetPlayerVisibleDistancePoint(int X1, int Y1, int r)// получаем список точек дистанции видимости персонажа
        {

            List<MapPoint> SeeRadiusPoints = new List<MapPoint>();
            int x = -r, y = 0, err = 2 - 2 * r; /* II. Quadrant */
            do
            {
                SeeRadiusPoints.Add(new MapPoint(Y1 + y, X1 - x)); /*   I. Quadrant */
                SeeRadiusPoints.Add(new MapPoint(Y1 - x, X1 - y));  /*  II. Quadrant */
                SeeRadiusPoints.Add(new MapPoint(Y1 - y, X1 + x)); /* III. Quadrant */
                SeeRadiusPoints.Add(new MapPoint(Y1 + x, X1 + y)); /*  IV. Quadrant */

                r = err;
                if (r <= y) err += ++y * 2 + 1;           /* e_xy+e_y < 0 */
                if (r > x || err > y) err += ++x * 2 + 1; /* e_xy+e_x > 0 or no 2nd y-step */
            } while (x < 0);

            return SeeRadiusPoints;
        }
        private static void GetMaxVisibleDistance(int[,] array, MapPoint playerPoint, int visibleRadius, int minVisibleWidth) // // нахождение макс возможных точек дистанции
        {

            int indexA = GetA(playerPoint.X, visibleRadius);// самая левая точка
            int indexB = GetB(playerPoint.X, visibleRadius, array.GetLength(0));// самая правая точка

            //for (int i = indexA ;i <= indexB ; i++)
            //{
            //    // тут проходим по всем элемнтам и устанавливаем с шагом 1 значение стремящ. к visibleRadius

            //}

            for (int i = playerPoint.X; i < indexA; i--)
            {
                for (int j = playerPoint.Y; (j < (playerPoint.Y - visibleRadius)) & (j >= 0); j--)
                {

                }

            }


        }
        public static int GetA(int playerX, int visibleRadius)
        {
            int indexA;
            if (visibleRadius - 1 > playerX)
            {
                indexA = 0;
            }
            else
            {
                indexA = playerX - visibleRadius;
            }

            return indexA;
        } // найти самую левую точку видимости 
        public static int GetB(int playerX, int visibleRadius, int mapLenght)
        {
            int indexB;

            if (visibleRadius > (mapLenght - 1) - playerX)
            {
                indexB = mapLenght - 1;
            }
            else
            {
                indexB = playerX + visibleRadius;
            }
            return indexB;
        }// найти самую правую точку видимости
    }
}





