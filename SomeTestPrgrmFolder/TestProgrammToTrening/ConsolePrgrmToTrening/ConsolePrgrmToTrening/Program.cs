using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNameSpace
{

    class Program
    {

        static void Main(string[] args)
        {

            int[,] array = new int[10, 10];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[i, j] = -3;
                }
            }

            array[3, 3] = 22;


           int a = Array.IndexOf(array, 22);
            Console.WriteLine(a);
            Console.ReadKey();

        }
        
    }

    public struct FieldPoint
    {
        int a;
        string b;
      
        public FieldPoint(int a, string b)
        {
            this.a = a;
            this.b = b;
        }

    }
}