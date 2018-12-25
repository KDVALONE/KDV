using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasledovanie
{
    class Child : Parent
    {
        public override void ParentMethod()
        {
            base.ParentMethod();
            Console.WriteLine("Хеллоу");
        }
    }
}
