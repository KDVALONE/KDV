using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMProgrammTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new ConcerteSatateA());
            context.Reqest();
            context.Reqest();
            Console.ReadKey();
        }
    }
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    class ConcerteSatateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcerteSatateB();
        }

    }
    class ConcerteSatateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcerteSatateA();
        }
    }
    class Context
    {
        public State State { get; set; }
        public Context(State state)
        {
            this.State = state;
        }
        public void Reqest()
        {
            this.State.Handle(this);
        }

    }
}
