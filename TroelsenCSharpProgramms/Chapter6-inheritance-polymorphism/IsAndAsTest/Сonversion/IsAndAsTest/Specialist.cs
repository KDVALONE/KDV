using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAndAsTest
{
    class Specialist : Human
    {
       public override int Age
        {
            get;
            set;
        }
        public override string Sex
        {
            get;
            set;
        }
        public override string Name
        {
            get;
            set;
        }
        public override DateTime BDate
        {
            get
            {
                return BDate;
                throw new NotImplementedException();
            }

            set
            {
               
                BDate = DateTime.Today;
                throw new NotImplementedException();
            }
        }
        public override void SetSex()
        {
            Sex = Console.ReadLine();
            Console.ReadKey();
            throw new NotImplementedException();
            
        }
    }
}
