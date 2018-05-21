using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fighter> fighters = new List<Fighter>(4);
         
            foreach (Fighter f in fighters)
            {
                Console.WriteLine($"{f.Name} {f.Age}");
            }

            Console.ReadKey();
        }
    }

    public class Fighter
    {
        public string Name;
        public int Age;
        static Random rnd = new Random();
        public Fighter()
        {
            
            string[] RndName = { "Smoke", "Scorpion", "Syrax", "Sub-Zero" };
            int[] RndAge = { 32, 29, 39, 33, 28, 31 };
            Name = RndName[rnd.Next(0, RndName.Length)];
            Age = RndAge[rnd.Next(0, RndAge.Length)];
        }
    }

}

