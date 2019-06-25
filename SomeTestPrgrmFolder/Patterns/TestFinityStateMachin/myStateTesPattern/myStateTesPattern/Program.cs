using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myStateTesPattern
{/// <summary>
/// Хер знает как реализовать паттерн состояние.
/// создать класс для переключения состояния, 
/// и создать классы с состояниями
/// 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Context cn = new Context(new StateA());
            cn.Reqest();
            cn.Reqest();

        }
    }
    class Context
    {
       public State State ;
        public Context(State state)
        {
            this.State = state;
        }

        public void Reqest()
        {
            this.State.Handle(this);
        }
    }
    abstract class State
    {
        abstract public void Handle(Context context);
    }
    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }
    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }

}
