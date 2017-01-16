﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        

            public static void Main()
        {
            WriteParabolaMinX(1, 2, 3);
            WriteParabolaMinX(0, 3, 2);
            WriteParabolaMinX(5, 2, 1);
            WriteParabolaMinX(4, 3, 2);
            WriteParabolaMinX(0, 4, 5);
        }
        private static void WriteParabolaMinX(int a, int b, int c)
        {

            double x =0;
            if (a <= 0 || b <= 0 || c <= 0)
                Console.WriteLine("Impossible");
            else
                try
                {
                    x = (double)-b / (2 * a);
                    if (x == 0)
                    {
                        Console.WriteLine("Impossible");
                        return;
                    }
                    else
                    {
                        Console.WriteLine(x);
                    }
                   
                }
                catch
                {
                    Console.WriteLine("Impossible");
                return;
                }
           
        }




    }
    }
