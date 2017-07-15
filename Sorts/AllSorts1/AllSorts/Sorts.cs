using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AllSorts
{/// <summary>
/// класс для сортировок
/// </summary>
    class Sorts
    {
        public void BubleSort(int[] array) // Сортировка пузырьком
        {
            Message.GetArrayCountMessage(array);
            bool sortIsUsed;

            int index;
            int arrayLength = array.Length;
            do
            {
                sortIsUsed = false;
                for (index = 0; index < arrayLength - 1; index++)
                {
                    if (array[index] > array[index + 1])
                    {
                        Methods.Swap(array, index, index + 1);
                        sortIsUsed = true;
                    }
                }

            } while (sortIsUsed);
            Message.GetFinalArrayCountMessage(array);

            //или можно так. Сортировка пузырьком v2
            /*
            int i, j;
            int n = array.Length;
            for (i = 0; i < n - 1; i++)
            {
                for (j = 0; j < n - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    Methods.Swap(array, j, j + 1);
                }
            }
            */


        }
        public void InsertSort(int[] array) // Сортировка вставкой
        {
            int index;
            int indexSort;

            for (index = 1; index < array.Length; index++)
            {
                indexSort = index - 1;
                int curentElement = array[index];

                while (indexSort >= 0 && array[indexSort] > curentElement)
                {
                    array[indexSort + 1] = array[indexSort];
                    array[indexSort] = curentElement;
                    indexSort--;
                }
            }
            Message.GetFinalArrayCountMessage(array);
        }
        public void SelectSort(int[] array) // Сортировка выбором
        {
            int index;
            int j;
            int minIndex;
            for (index = 0; index < array.Length; index++)
            {
                minIndex = index;
                for (j = index + 1; j < array.Length; j++)
                {
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }
                Methods.Swap(array, minIndex, index);
            }
            Message.GetFinalArrayCountMessage(array);
        }
        public void QuickSort(int[] array) // Сортировка быстрая
        {
            
            Message.GetFinalArrayCountMessage(array);
        }
        public void MergetSort(int[] array) // Сортировка слиянием
        {
            

            Message.GetFinalArrayCountMessage(array);
        }
    }
}

