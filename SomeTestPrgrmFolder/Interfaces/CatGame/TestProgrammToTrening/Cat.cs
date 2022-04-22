using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgrammToTrening;

namespace TestProgrammToTrening
{
    
    class Cat
    {
 
        private int starvingStat = 0;
        public int StarvingStat { get { return starvingStat; } set { starvingStat = value; } } 
           
        protected internal void EatSome()
        {
            
            while (starvingStat < 100)
            {
                int x = StarvingStat;
                Console.WriteLine("Cat is starving! His starving status is {0} % \n\nPlease enter the food name to  (Mause, Meal, Fish, Milk):", starvingStat);
                string foodSample = Console.ReadLine();

                switch (foodSample)
                {
                    case ("Milk"):
                        x = (Int32)Food.Milk;
                        StarvingStat += x;
                        Console.WriteLine("\nCat have eat some food! Food have {0} % calories ", x );
                        break;
                    case ("Meal"):
                        x = (Int32)Food.Meal;
                        StarvingStat += x;
                        Console.WriteLine("\nCat have eat some food! Food have {0} % calories ", x);
                        break;
                    case ("Fish"):
                        x = (Int32)Food.Fish;
                        StarvingStat += x;
                        Console.WriteLine("\nCat have eat some food! Food have {0} % calories ", x);
                        break;
                    case ("Mause"):
                        x = (Int32)Food.Mause;
                        StarvingStat += x;
                        Console.WriteLine("\nCat have eat some food! Food have {0} % calories ", x);
                        break;
                    default:
                        Console.WriteLine("error! Not enter correct food name! Try again!");
                        break;
                }
                

            }

        }


    }
}
