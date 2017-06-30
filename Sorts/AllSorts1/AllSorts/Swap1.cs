using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{  
     class Swap1
    {
            /// <summary>
            /// Класс для перемены мест значений.
            /// </summary>
            
    static public void Swap(int [] array, int leftVariable,int rightVariable)
        {
            if (leftVariable != rightVariable)
            {
                int temp = array[leftVariable];
                array[leftVariable] = array[rightVariable];
                array[rightVariable] = temp;
            }
        
        }
    }
}
