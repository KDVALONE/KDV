using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VstavkaSortV2
{
    class Program
    {
        

        internal int[] VstavkaSort(int[] array)
        {
            int i, location,curentA;
            int j = array.Length - 1;

            for (i = 1; i < j; i++)
            {
                location = i - 1;
                curentA = array[location + 1];
                while (location >= 0 && curentA < array[location])
                {
            array[location] = array[location];
                location = location - 1;
                }
        array[location + 1] = curentA;

             }
            return array;     


            return array;
        }
       
       void SeeArray(int [] array)
        {
            foreach(int e in array)
                 Console.WriteLine(e);
            Console.ReadKey();
        }

        static void Main()
        {

            Program p = new Program();
            int[] array = { 9,1,4,3,7,4 };
            p.SeeArray(array);
            int[] array2 = p.VstavkaSort(array);
            p.SeeArray(array2);


        }
    }
}
