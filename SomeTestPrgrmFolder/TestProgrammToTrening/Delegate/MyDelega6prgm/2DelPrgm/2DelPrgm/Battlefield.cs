using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DelPrgm
{
    class Battlefield
    {
        public FieldObjectEnum [,] Field { get; set; }
        public int MineLimit { get; set; } // лимит мин
        public int ForestLimit { get; set; } //лимит леса

        static Random rnd = new Random();


        public Battlefield()
        {
            Field = new FieldObjectEnum[20, 20];
            MineLimit = rnd.Next(4,8);
            ForestLimit = rnd.Next(13, 18);
        }

        public void InitializeField( )
        {
            Field = InitLand(Field);
            Field = InitForest(Field);
            Field = InitBase(Field);
            Field = InitMine(Field);
            ShowField();
            //**************
            Tank tank = new Tank(TeamTypeEnum.A,1,1,19,19);
            Pathfinder pf = new Pathfinder();
            pf.LeeAlgoritm(Field,ref tank);
            // TODO: для тестов убрать отсюда        
        }
        private FieldObjectEnum[,] InitBase(FieldObjectEnum[,] fieldArray)
        {
            FieldObjectEnum[,] array = fieldArray;
            array[0, 0] = FieldObjectEnum.A;
            array[array.GetLength(0) - 1, array.GetLength(1) - 1] = FieldObjectEnum.B;
            return array;
        }
        private FieldObjectEnum[,] InitLand(FieldObjectEnum[,] fieldArray)
        {
            FieldObjectEnum[,] array = fieldArray;
            for (int i = 0; i < fieldArray.GetLength(0); i++)
            {
                for (int j = 0; j < fieldArray.GetLength(1); j++)
                {
                    array[i, j] = FieldObjectEnum.o;
                }
            }
            return array;
        }
        private FieldObjectEnum[,] InitForest(FieldObjectEnum[,] fieldArray)
        {
            FieldObjectEnum[,] array = fieldArray;
            int i;
            int j;
            int forestCount = 0;
            while (forestCount < ForestLimit)
            {
                i = rnd.Next(0, Field.GetLength(0));
                j = rnd.Next(3, Field.GetLength(1)-3);
                array[i,j] = FieldObjectEnum.F;
                array = GetDeepestForest(array, i, j);
                forestCount++;
            }
            
            return array;
          
        }
        private FieldObjectEnum[,] InitMine(FieldObjectEnum[,] fieldArray)
        {

            FieldObjectEnum[,] array = fieldArray;
            int i;
            int j;
            int mineCount = 0;
            while (mineCount <= MineLimit)
            {
                i = rnd.Next(0, Field.GetLength(0));
                j = rnd.Next(3, Field.GetLength(1)-3);
                array[i, j] = FieldObjectEnum.E;
                
                mineCount++;
            }
            return array;
        }
        private bool GetMeadowInForest()
        {
            return (rnd.Next(0, 5)) > 3;
        }
        private int GetForestDeep()
        {
           return rnd.Next(5);
        }
    
        private FieldObjectEnum[,] GetDeepestForest(FieldObjectEnum[,] field, int iCurent,int jCurent)
        {

            FieldObjectEnum [,] array = field;
            int y1Deep = iCurent - GetForestDeep(); // сколько даст в вверх клеток леса
            int y2Deep = iCurent + GetForestDeep(); // сколько даст в низ клеток леса
            int x1Deep = jCurent + GetForestDeep();
            int x2Deep = jCurent - GetForestDeep();

            for (int i = iCurent; i >= y1Deep & i != array.GetLength(0) - 1 & i != 0; i--) //смещение вверх и вправо
            {
                for (int j = jCurent; j <= x1Deep & j != array.GetLength(1) - 1 & i != 0; j++  )
                {
                    array[i, j] = GetMeadowInForest() ? FieldObjectEnum.o : FieldObjectEnum.F;
                }
            }
            for (int i = iCurent; i <= y2Deep & i != array.GetLength(0) - 1 & i != 0; i++)// смещение вниз и влево
            {
                for (int j = jCurent; j >= x1Deep & j != array.GetLength(1) - 1 & i != 0; j--)
                {
                    array[i, j] = GetMeadowInForest() ? FieldObjectEnum.o : FieldObjectEnum.F;
                }
            }
            return array;
        }

        public void ShowField()
        {
            Display disp = new Display();
            disp.ShowFieldArray(Field);
        }
    }
}
