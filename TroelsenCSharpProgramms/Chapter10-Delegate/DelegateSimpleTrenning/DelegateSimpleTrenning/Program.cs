using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DelegateSimpleTrenning
{/// <summary>
/// Затварил чето сумасбродное с делегатом, делегат вызывает метод который вызывет метод другоего делегатного типа, или что то типо того
/// тут даже не все параметры задействованны, что то лишнее, переделывать в лом. Чисто тренился.
/// </summary>
/// <param name="x"></param>


    public delegate void MyDel(int x);
    public delegate void MyDel1();
    class Program
    {
        static void Main(string[] args)
        {

            Bird brd = new Bird();
            brd.GetSomeFly();
            Console.ReadKey();

        }
    }

    class Bird
    {
        MyDel del = new MyDel(new Flyer().Flying);
        public void GetSomeFly()
        {
            for (int i = 0; i < 20; i++ )
                
            del.Invoke(i);
            Thread.Sleep(1000);
        }

    }

    public class Flyer
    {
        public MyDel1 del;
        public int Speed;
        public Flyer()
        {
            Random rnd = new Random();

            this.Speed = rnd.Next(0, 100);
        }
        public void Flying (int Speed)
        {
            FlyingRegister(Speed, FlyFast, FlySlow, FlyNormal);
            del.Invoke();
        }
        public void FlyingRegister(int currentSpeed, MyDel1 delMethodFast, MyDel1 delMethodSlow, MyDel1 delMethodNormal)
        {
            if (currentSpeed > 10) { del = delMethodFast; }
            else if (currentSpeed <= 10 && currentSpeed > 3) { del = delMethodNormal; }
            else { del = delMethodSlow; }

        }

        public void FlyNormal() { Console.WriteLine("Полет нормальный"); }

        public void FlyFast() { Console.WriteLine("Полет быстрый"); }

        public void FlySlow() { Console.WriteLine("Полет медленный"); }
    }


}
