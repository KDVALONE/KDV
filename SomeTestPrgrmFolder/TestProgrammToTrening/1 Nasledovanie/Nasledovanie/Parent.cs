using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasledovanie
{
    class Parent
    {
        string SomeParametr { get; set; }

        public Parent()
        {
            SomeParametr = "Привет";
        }

        public virtual void ParentMethod()
        {
            Console.WriteLine(SomeParametr);
        }


    }
}
