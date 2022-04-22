using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateUlearnTest
{
    public delegate void MyDelegate(string x);
    class Program
    {/// <summary>
     /// просто написать один делегат
     /// </summary>
     /// <param name="args"></param>

       public  void SomeMethod(string x)
        {
            Console.WriteLine(x);
        }

        public MyDelegate myDellegateVarriable;

        public void RegisterMethod(MyDelegate methodToCall)
        {
            myDellegateVarriable = methodToCall;

        }

        public void RunDelegateMethod()
        {
            myDellegateVarriable("Hello i am DELEGATE");
        }

        public void Main(string[] args)
        {
           SomeMethod("*********fun with delgate**********");
            RunDelegateMethod();
           Console.ReadKey();
        }
     


    }
}
