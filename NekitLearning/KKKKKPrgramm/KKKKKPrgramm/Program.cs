using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKKKKPrgramm
{
    class Program
    {
        static void Main(string[] args)
        {
         
            FindK fk = new FindK();
            fk.FindValue();
            Console.ReadKey();
        }
    }

    public class FindK
    {

        public string K = "К";
        public string L = "Л";
        public string M = "М";
        public int MBuf = 1;
        public string[] array = { "К", "К", "К", "К", "К" };
        public int I = 1;



        public void FindValue( )
        {
            Console.WriteLine($"{I} {string.Join("", array)}");

            for ( int i =1; i < 100; i++) 
            {
                I++;
                MBuf = 1;
                for (int j = array.Length -1; j >= 0 && MBuf == 1; j--)
                {
                    switch (array[j])
                    {
                        case "К":
                            array[j] = "Л";
                            MBuf = 0;
                            break;
                        case "Л":
                            array[j] = "М";
                            MBuf = 0;
                            break;
                        case "М":
                            array[j] = "К";
                            MBuf = 1;
                            break;
                    }
                    
                }
                Console.WriteLine($"{I} {string.Join("", array)}");
            }

        }

    }

}
