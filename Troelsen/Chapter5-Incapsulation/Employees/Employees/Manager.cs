using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Manager : Employee
    {
        //Свойство
        public int StockOptions { get; set; }
        //Конструктор
        public Manager() { }
        public Manager(string fullName, int age, int empID,
            float currPay, string ssn, int numbOfOpts)
                : base(fullName, age, empID, currPay, ssn)
              {
                   // Это свойство определено в классе Manager.
                  StockOptions = numbOfOpts;
             }
    }

}
