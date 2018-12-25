using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramEventDeletAfter6
{
    class Program
    {
        static void Main(string[] args)
        {

            MyEvent.myEvent += delegate { Console.WriteLine("анонимный метод"); };
            MyEvent.myEvent += (object sender,EventArgs e) => { Console.WriteLine("лямбда"); };

            MyEvent.EventSart();
            Console.ReadKey();
        }
    }

    public static class MyEvent
    {
        public static event EventHandler<EventArgs> myEvent;

        public static void EventSart()
        {
            myEvent?.Invoke(null, EventArgs.Empty );
        }

    }


}
