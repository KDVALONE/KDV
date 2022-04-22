using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAndAsTest
{
    abstract class Human
    {
        abstract public string Name { get; set; }
        abstract public int Age { get; set; }
        abstract public string Sex { get; set; }
        abstract public DateTime BDate { get; set; }

        public abstract void SetSex(); 
        

      
    }
}
