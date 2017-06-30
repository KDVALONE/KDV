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
        //int Index { get; set; }
        //int ArrayLength { get; set; }

        public void BubleSort(int [] array) // Сортировка пузырьком
        {
            Message.GetArrayCountMessage(array);
            int index=0;
            int arrayLength = array.Length;
            while (index < arrayLength)
            {
                for (index = 0; index < arrayLength-1; index++)
                {
                    Swap1.Swap(array, index, index + 1);
                }
                arrayLength -= 1;
            }
            
            Message.GetArrayCountMessage(array);





        }

    }
}
