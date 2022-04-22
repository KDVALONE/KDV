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
            
            int sortName;

                gm.GetStartMessage();
                sortName = gm.SetSortName();
                gm.GetSortNameMessage(sortName);
                gm.GetSetArrayMessage();
                Methods.ChoseSort(sortName, gm.SetArray());

        
        }
    }
}
