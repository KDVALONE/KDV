using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Salesperson : Employee
    {
        public int SalesNumber { get; set; }
        // В качестве общего правила, все подклассы должны явно вызывать
        // соответствующий конструктор базового класса.
        public Salesperson() { }
        public Salesperson(string fullName, int age, int empID,
                           float currPay, string ssn, int numbOfSales)
                : base(fullName, age, empID, currPay, ssn)
        {
            // Это касается нас!
            SalesNumber = numbOfSales;
        }
    }
}
