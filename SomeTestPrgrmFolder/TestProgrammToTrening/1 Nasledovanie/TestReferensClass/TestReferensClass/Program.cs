using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReferensClass
{   // Цель проверить не накасячил ли с областями видимости
    // И корректно ли передается Мой класс в биом а в нем вызывается уже метод файт
    class Program
    {
        static void Main(string[] args)
        {

            MyClass mc1 = new MyClass();
            Console.WriteLine($"В начале {mc1.A}");
            Biom biom = new Biom();
            biom.StatBattle(mc1);
            Console.WriteLine($"В конце {mc1.A}"); // Если в конце значение 2 то ок.
            Console.ReadKey();
        }
    }
    public class MyClass
    {
        public int A ;
        public MyClass()
        {
            A = 1;
        }
    }
   public  class Biom
    {
      public void StatBattle(MyClass mc1)
        {
            BFight bf = new BFight(mc1);
            bf.StartFight();
        }
    }
    public class BFight
    {
        MyClass mc;
        public BFight(MyClass mc1)
        {
            this.mc = mc1;
        }
        public void StartFight()
        {
            mc.A++;
            Console.WriteLine($"В нутри метода {mc.A}");
        }
    }
}
