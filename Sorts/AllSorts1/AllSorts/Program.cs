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
            gm.GetMessage();
            int a = int.Parse(Console.ReadLine());
            gm.GetMessage(a);
        }
    }
}
