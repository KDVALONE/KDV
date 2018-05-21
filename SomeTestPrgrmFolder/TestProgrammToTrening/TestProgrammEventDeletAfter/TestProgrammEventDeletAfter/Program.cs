using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgrammEventDeletAfter
{/// <summary>
 /// побырому написать 2 события 
 /// </summary>
 /// 

    public delegate void MyDeleagteHandler(object sender, MyEventAgrs e);

    class Program
    {

        static void Main(string[] args)
        {
            string MyFuckingMessage = "EVENT BABY! YEAH!!!";
            MyClass1 mc1 = new MyClass1();
            EventStart evStrt = new EventStart();
            evStrt.MyEvent += mc1.Method;
            evStrt.EventSartMethod(MyFuckingMessage);

            Console.ReadKey();
        }


    }
    public class EventStart
    {
        public event MyDeleagteHandler MyEvent;
        
        public void EventSartMethod(string msg)
        {
            MyEvent?.Invoke(this, new MyEventAgrs(msg));

        }

    }





    public class MyClass1
    {

        public void Method(object sender, MyEventAgrs e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static class MyClass2
    {
        public static void MethodStatic(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class MyEventAgrs : EventArgs
    {
        public string Message;
        public MyEventAgrs(string message)
        {
            this.Message = message;
        }
    }

}

