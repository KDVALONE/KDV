using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    //enum необходимо русифицировать.

    //Кажется, что эту задачу можно решить немного веселее, с помощью массивов.Возможно даже всего в одну строчку кода.


    class Program
    {
        enum Suits
        {
            Wands,
            Coins,
            Cups,
            Swords
        }
        public static void Main()
        {
            //Console.WriteLine((int)Suits.Coins);
           
            for (int i = 0; i < 4; i++)
            {
                
               Console.WriteLine(GetSuit((Suits)i));
            }
            Console.ReadKey();
        }
     
        private static string GetSuit(Suits suit)
        {

            return new string[] { "жезлов", "монет", "кубков", "мечей" }[(Int32)suit];

        }
    }
}

