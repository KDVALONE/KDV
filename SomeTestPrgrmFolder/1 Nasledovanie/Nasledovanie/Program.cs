using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasledovanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Child Ch = new Child();

            Ch.ParentMethod();

            Console.ReadKey();

        }
    }
}
