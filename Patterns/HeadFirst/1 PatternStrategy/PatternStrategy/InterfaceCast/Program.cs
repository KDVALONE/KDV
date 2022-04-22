using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy
{
    /// <summary>
    /// Патерн Стратегия -
    /// определяет семейство алгоритмов, инкапсулирует каждый из них и обеспечивает
    /// их взаимозаменяемость. Он позволяет модифицировать алгоритмы независимо от 
    /// их использования на стороне клиента.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();
            mallard.PerformFly();
            mallard.PerformQuack();

            Duck model = new ModelDuck();
            model.PerformFly(); // в первый вызов, передается реализация из конструктора (тоесть FlyNoWay)
            model.setFlyBehavior(new FlyRocketPower());
            model.PerformFly();
            
            Console.ReadLine();
        }
    }

      public abstract  class Duck
    {

        public FlyBehavior flyBehavior;
        public QuackBehavior quackBehavior;

        public void setFlyBehavior(FlyBehavior fb) { flyBehavior = fb; }
        public void setQuackBehavior(QuackBehavior qb) { quackBehavior = qb; } // по сути это сеттер

        public void PerformFly() {
            flyBehavior.Fly();
        }
        public void PerformQuack()
        {
            quackBehavior.quack();
        }

        void swim() => Console.WriteLine("Все утки плавают.");
        public abstract void display();
    }
   public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();
        }
        public override void display()
        {
            Console.WriteLine("I am a MallarDuck");
        }
    }
    class ModelDuck : Duck
    {
        public ModelDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyNoWay();//утка приманка, летать не умеет
        }
        public override void  display() { Console.WriteLine("I am a ModulDuck"); }
    }
    #region реализация интерфейса FlyBehavior и классов его реализующих
    public interface FlyBehavior
    {
       void Fly();
    }
    class FlyWithWings : FlyBehavior
    {
        public void Fly() => Console.WriteLine("Летает");
    }
    class FlyNoWay : FlyBehavior
    {
        public void Fly() { Console.WriteLine("Эта утка не летает"); }
    }

    class FlyRocketPower : FlyBehavior // рекативный полет
    {
        public void Fly() { Console.WriteLine("Эта утка летает на ракете!"); }
    }
    #endregion

    #region реализация интерфейса QuackBehavior и классов его реализующих
    public interface QuackBehavior
    {
        void quack();
    }
    class Quack : QuackBehavior
    {
        public void quack() => Console.WriteLine("Крякает");
    }
    class Squeak : QuackBehavior
    {
        public void quack() { Console.WriteLine("Эта утка пищит"); }

    }
    class MuteQuack : QuackBehavior
    {
        public void quack() { Console.WriteLine("Эта утка не издает звуков"); }
    }
    #endregion

}
