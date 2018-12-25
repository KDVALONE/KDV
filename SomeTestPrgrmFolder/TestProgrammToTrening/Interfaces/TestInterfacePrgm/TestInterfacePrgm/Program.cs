using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterfacePrgm
{
    class Program
    {
        // тут используется механизм Раннего и Позднего связывания.
        // При Раннем связывании выполняется метод из базового класса (если в базовом классе методы не виртуальные) (В программе не испольуется)
        // При Позднем связывании выполняется метод из производного, это происходит благодаря таблице вирутальных методов, которая создается при 
        // переопределении методов.
        // При вызове метода через переменную интерфейса, если она ссылается на объект производного класса, 
        // будет использоваться реализация из производного класса.
        static void Main(string[] args)
        {

            BaseAction action1 = new HeroAction(); // позденее связывание, так как в базовом классе метод Move() виртуальный,
            //значит будет использоваться реализация из производного класса.
            action1.Move();            // Move in HeroAction 

            IAction action2 = new HeroAction();//вызове метода через переменную интерфейса, значит будет использоваться реализация из производного класса.
            action2.Move(); // Move in HeroAction
            Console.ReadKey();
        }
    }
    interface IAction
    {
        void Move();
    }
    class BaseAction : IAction
    {
        public virtual void Move()
        {
            Console.WriteLine("Move in BaseAction");
        }
    }
    class HeroAction : BaseAction
    {
        public override void Move()
        {
            Console.WriteLine("Move in HeroAction");
        }
    }
}
