using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool enemyInFront = true;
            string enemyName = "boss";
            int robotHealth = 51;
           
           Console.WriteLine( ShouldFire2(enemyInFront, enemyName, robotHealth));
            Console.ReadLine(); 
        }

            static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {
            //   return enemyInFront && ((enemyName == "boss") && (robotHealth > 100));
            bool shouldFire = true;
            if (enemyInFront == true)
            {
                if (enemyName == "boss")
                {
                    if (robotHealth < 50) shouldFire = false;
                    if (robotHealth > 100) shouldFire = true;
                }
            }
            else
            {
                return false;
            }
            return shouldFire;

        }
    }
}

