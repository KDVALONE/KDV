using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSorts
{
    class Program
    {

        void BubleSort(int[] array)
        {
            bool f = false;
            do
            {
                f = false;
                int j = array.Length - 1;
                for (int i = 0; i < j; i++)
                    if (array[i] > array[i + 1])
                    {
                        int buf = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = buf;
                        f = true;
                    }
            } while (f);         
        }

        static void Main(string[] args)
        {

            int[] array = { 7,3,4,6,1,5,2};
            foreach (int e in array)
                Console.WriteLine(e);
            Program p = new Program();
            p.BubleSort(array);
            Console.WriteLine("____________");
            foreach (int e in array)
                Console.WriteLine(e);
            Console.ReadKey();
        }

        
    }
}
