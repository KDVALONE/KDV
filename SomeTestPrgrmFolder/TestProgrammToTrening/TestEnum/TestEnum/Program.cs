using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomEnumValue();
          
        }
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }


            for (int i = 0; i< 10; i++)
            {
                var value = RandomEnumValue<System.DayOfWeek>();
        Console.WriteLine(value.ToString());
            }
}
}
