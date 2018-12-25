using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutTreningTest
{
    class Program
    {

        
        static void Main(string[] args)
        {
            int  i ;
            int j = 1;
            SomeMethod(out i);
            SomeMethod2(ref i);
        }


        static public void SomeMethod(out int  x)
        {
            x = 1;
            Console.WriteLine(x);
        }
        static public void SomeMethod2(ref int x1)
        {
            x1 = 1;
            Console.WriteLine(x1);
        }
    }
}
