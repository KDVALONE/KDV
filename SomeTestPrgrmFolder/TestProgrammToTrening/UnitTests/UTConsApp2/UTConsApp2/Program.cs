using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTConsApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Factorial factorial = new Factorial();
            factorial.GetFactorial(5);
        }
    }

    public class Factorial
    {
        public void GetFactorial( int x )
        {
            int answer = 1;
            
            for (int i = 1; i < x; i++)
            {
                answer += answer * i;
            }
            Console.WriteLine($"Ответ факториал: {answer}");
            Console.ReadKey();
        }

    }
}
