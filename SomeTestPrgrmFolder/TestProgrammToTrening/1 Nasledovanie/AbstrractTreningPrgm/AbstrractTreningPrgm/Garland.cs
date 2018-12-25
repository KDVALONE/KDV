using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrractTreningPrgm
{
    abstract class Garland
    {
       public  int Lamp {get; }


        public Garland()
        {
            Lamp = 12;     
        }
        abstract public void PrintStateOfLights();

    }
}
