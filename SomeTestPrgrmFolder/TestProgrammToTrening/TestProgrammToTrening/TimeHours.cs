using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProgrammToTrening
{
    class TimeHours
    {
       internal static int CurentHours { get; set; }
        public void SeeTimer() // метод для подсчета часов
        {


            int i = 0;
            while (true)

                if (i <= 23)
                {
                    do
                    {
                    //    Console.Clear();
                    //    Console.WriteLine("Time is {0}", i);
                         Thread.Sleep(2000);
                         CurentHours = i++;
                    }
                    while (i <= 23);

                }
                else { SeeTimer(); }
        }
    }
}
