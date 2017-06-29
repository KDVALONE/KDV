using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{
    class Swap
    {   // Swap1 - Поменять значения переменных местами.
        void Swap1 (int [] array, int leftVariable, int rightVariable)
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
