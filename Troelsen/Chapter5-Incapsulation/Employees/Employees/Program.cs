using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");
            Salesperson fred = new Salesperson();
            fred.Age = 31;
            fred.Name = "Fred";
            fred.SalesNumber = 50;
            Console.ReadLine();
        }
    }
}
