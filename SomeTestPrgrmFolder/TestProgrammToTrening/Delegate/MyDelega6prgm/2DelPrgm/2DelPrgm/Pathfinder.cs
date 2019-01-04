
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    class Pathfinder
    {
        int noAccess = -5; // нельзя пройти
        int Access = -3; // можно пройти


        public void LeeAlgoritm(FieldObjectEnum [,] field ,ref Tank tank )
        {

            Console.WriteLine("Lee Algoritm On");
            Point target = new Point(tank.FinishI,tank.FinishJ);
            int[,] fieldIntArray = InitWayArray(field);
            bool wayIsFind = false;
            int stepCount = 0;
            List<Point> pointCurrent = new List<Point>();
            pointCurrent.Add(new Point(tank.TankI,tank.TankJ));
            List<Point> pointToNextTurn = new List<Point>();

            while (pointCurrent.Count > 0 || !wayIsFind )
            { 
            foreach (var e in pointCurrent)
            {
                fieldIntArray[e.Y, e.X] = stepCount;
                    if (!(e.Y == target.Y & e.X == target.X))
                    {
                        GetUpElement(e, fieldIntArray, ref pointToNextTurn);
                        GetDownElement(e, fieldIntArray, ref pointToNextTurn);
                        GetLeftElement(e, fieldIntArray, ref pointToNextTurn);
                        GetRightElement(e, fieldIntArray, ref pointToNextTurn);
                    }
                    else
                    {
                        Display dsp = new Display();
                        dsp.ShowFieldArray(fieldIntArray);
                    //    // а теперь от финалдьной точки к меньшему числу в обратку по кругу
                       wayIsFind = true;
                       tank.WayToTarget = GetWayToTarget(fieldIntArray, target.X, target.Y, tank);//TODO: передалать параметры , вообще target не нужен если я танк как класс передаю, в нем есть
                    }
                }

              pointCurrent.Clear();
              pointToNextTurn.ForEach((item) =>
              {
                    pointCurrent.Add(new Point(item.Y, item.X));
              });
                pointToNextTurn.Clear();
                stepCount++;
            }
            
            Display dp = new Display();
            //dp.ShowFieldArray(fieldIntArray); //выводит размеченный массив
            dp.ShowFieldArray(fieldIntArray, tank.WayToTarget); // выводит размеченный массив и путь
           
        }
        public int[,] InitWayArray(FieldObjectEnum[,]field) //TODO: Все же нужно распарсить массив enum, -3 свободно для прохода -5 проезд закрыт 
        {
            int[,] wayArray = new int[field.GetLength(0), field.GetLength(1)];
            for (int i = 0; i < wayArray.GetLength(0); i++)
            {
                for (int j = 0; j < wayArray.GetLength(0); j++)
                {
                    wayArray[i, j] = ParsFieldToInt(field[i, j]);
                }
            }
            return wayArray;

        }
        public int  ParsFieldToInt(FieldObjectEnum fieldObj)
        {
            
            switch (fieldObj)
            {
                case (FieldObjectEnum.T): { return noAccess; }
                case (FieldObjectEnum.Y): { return noAccess; }
                case (FieldObjectEnum.F): { return noAccess;} 
                case (FieldObjectEnum.X): { return noAccess;}
            }

            return Access;
        }

        public List<Point> GetWayToTarget(int[,] fieldIntArray, int targetI, int targetJ, Tank tank)
        {
            List<Point> wayToTargetList = new List<Point>();
            wayToTargetList.Add(new Point (targetI, targetJ));

            int currentElement = fieldIntArray[targetI, targetJ];
            Point currentPoint = new Point(targetI, targetJ);
            bool elementFound = false;
            bool wayFound = false;
            // TODO: тут разделить все на методы
            while (!wayFound)
            {
                if (!wayFound ) { elementFound = false; };

                if (currentPoint.Y - 1 >= 0 & fieldIntArray[currentPoint.Y - 1, currentPoint.X] == currentElement - 1 & !elementFound) { // проверяем верхний элемент

                    wayToTargetList.Add(new Point(currentPoint.Y - 1, currentPoint.X));

                    currentElement = fieldIntArray[currentPoint.Y - 1, currentPoint.X];
                    currentPoint.Y = currentPoint.Y - 1;
                    currentPoint.X = currentPoint.X;
                    
                    elementFound = true;
                }
                //*****************
                if (currentPoint.Y + 1 < fieldIntArray.GetLength(0) & fieldIntArray[currentPoint.Y + 1, currentPoint.X] == currentElement-1 & !elementFound)// проверяем нижний элемент
                {
                    wayToTargetList.Add(new Point(currentPoint.Y + 1, currentPoint.X));

                    currentElement = fieldIntArray[currentPoint.Y + 1, currentPoint.X];
                    currentPoint.Y = currentPoint.Y + 1;
                    currentPoint.X = currentPoint.X;
                    
                    elementFound = true;
                }
                //*****************
                if (currentPoint.X - 1 >= 0  & fieldIntArray[currentPoint.Y , currentPoint.X -1 ] == currentElement - 1 & !elementFound)// проверяем левыйы элемент
                {
                    wayToTargetList.Add(new Point(currentPoint.Y , currentPoint.X-1));

                    currentElement = fieldIntArray[currentPoint.Y, currentPoint.X - 1];
                    currentPoint.Y = currentPoint.Y ;
                    currentPoint.X = currentPoint.X - 1;
                    
                    elementFound = true;
                }
                //*****************
                if (currentPoint.X + 1 < fieldIntArray.GetLength(1) && fieldIntArray[currentPoint.Y , currentPoint.X + 1] == currentElement - 1 && !elementFound)// проверяем правый элемент
                {
                    wayToTargetList.Add(new Point(currentPoint.Y, currentPoint.X + 1));

                    currentElement = fieldIntArray[currentPoint.Y, currentPoint.X + 1];
                    currentPoint.Y = currentPoint.Y;
                    currentPoint.X = currentPoint.X + 1;
                    
                    elementFound = true;
                }
                //*****************
                if (fieldIntArray[currentPoint.Y,currentPoint.X] == 0) { wayFound = true; }

            }
            //wayToTargetList.Add(new Point(tank.TankI, tank.TankJ)); // хз за чемаписал, удалить

            wayToTargetList.Reverse();

            return wayToTargetList;
           


        }

       

        public  void GetUpElement(Point pointCurent, int[,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.Y - 1 >= 0)
            {
                if (!pointToNextTurn.Exists(x => x.Y == pointCurent.Y - 1 & x.X == pointCurent.X) & array[pointCurent.Y - 1, pointCurent.X] == Access )
                {
                    pointToNextTurn.Add(new Point(pointCurent.Y - 1, pointCurent.X));
                }
            }

        }
        public  void GetDownElement(Point pointCurent, int[,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.Y + 1 < array.GetLength(0))
            {
                if (!pointToNextTurn.Exists(x => x.Y == pointCurent.Y + 1 & x.X == pointCurent.X) & array[pointCurent.Y + 1, pointCurent.X] == Access)
                {
                    pointToNextTurn.Add(new Point(pointCurent.Y + 1, pointCurent.X));
                }
            }

        }
        public  void GetLeftElement(Point pointCurent, int[,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.X - 1 >= 0)
            {
                if (!pointToNextTurn.Exists(x => x.Y == pointCurent.Y & x.X == pointCurent.X - 1) & array[pointCurent.Y, pointCurent.X - 1] == Access)
                {
                    pointToNextTurn.Add(new Point(pointCurent.Y, pointCurent.X - 1));
                }
            }

        }
        public  void GetRightElement(Point pointCurent, int[,] array, ref List<Point> pointToNextTurn)
        {
            if (pointCurent.X + 1 < array.GetLength(1))
            {
                if (!pointToNextTurn.Exists(x => x.Y == pointCurent.Y & x.X == pointCurent.X + 1) & array[pointCurent.Y, pointCurent.X + 1] == Access)
                {
                    pointToNextTurn.Add(new Point(pointCurent.Y, pointCurent.X + 1));
                }
            }

        }




    }
}