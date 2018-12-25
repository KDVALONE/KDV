using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds
{
    // написать метод FindSightAngle() для поиска угла тела брошенного к горизонту по задавнному расстоянию и начальной скорости.

    class programm { 

            static void Main(string[] args)
            {
                double v = 100;
                double distance = 1000;
                Console.WriteLine($" {FindSightAngle(v, distance)}");
                Console.ReadKey();
            }


            public static double FindSightAngle(double v, double distance)
            {
                double g = 9.8;

                double a = Math.Asin((distance * g) / Math.Pow(v, 2)) / 2;
                return a;
            }

        }
}
