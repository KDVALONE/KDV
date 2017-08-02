using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAndAsTest
{
    abstract class Human
    {
        private string Name { get; set; }
        private int Age { get; set; }
        private string Sex { get; set; }
        private DateTime BDate { get; set; }
        

        public Human(string[] sex = { "Men","Woomen"}; )
        {

        int[] a = { 1, 2, 3, 4, 5 };
        Console.WriteLine (a[new Random().Next(0, a.Length)]);

          
        } 
      
    }
}
