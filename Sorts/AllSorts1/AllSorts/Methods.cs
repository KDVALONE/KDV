using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{  
     class Methods
    {
        /// <summary>
        /// Класс для для используемых методов.
        /// </summary>

        static public void ChoseSort(int sortName, int[] array)// выбор нужной сортировки
        {
            Sorts srt = new Sorts();
            switch (sortName)
            {
                case 1:
                    srt.BubleSort(array);
                    break;
                case 2:
                    srt.InsertSort(array);
                    break;
                case 3:
                    srt.SelectSort(array);
                    break;
            }
        }
        static public void Swap(int[]array,int leftVariable,int rightVariable)
        {
            if (array[leftVariable] != array[rightVariable])
            {
                int temp = array[leftVariable];
                array[leftVariable] = array[rightVariable];
                array[rightVariable] = temp;
            }
        }//перемена мест значений
       /* static public void Insert(int[] array)
        {
            
        }// пустая.
        */
    
    }
}
