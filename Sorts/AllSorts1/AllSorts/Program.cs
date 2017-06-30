using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{
    class Program
    {
        static void Main()
        {
            Message gm = new Message();
            Sorts srt = new Sorts();

                gm.GetStartMessage();
                gm.GetSortNameMessage(gm.SetSortName());
                gm.GetSetArrayMessage();
                srt.BubleSort(gm.SetArray()); 
           

        
        }
    }
}
