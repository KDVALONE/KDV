using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    partial class Employee
    {
        

        //Свойства
        public string Name
        {
            get { return empName; }
            set
            {
                // Здесь value имеет тип string.
                if (value.Length > 15)
                    Console.WriteLine("Error! Name must be less than 16 characters!");
                else
                    empName = value;
            }
        }
        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        public string SocialSecurityNumber
        {
            get { return empSSN; }
        }

        // Содержит объект BenefitPackage.
        protected BenefitPackage empBenefits = new BenefitPackage();

        //Методы 
        public void GiveBonus(float amount)
        { Pay += amount; }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
        }


    }
}
