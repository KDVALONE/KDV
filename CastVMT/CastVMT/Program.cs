using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePrgrmToTrening
{
    /// <summary>
    /// Код для демонстрации таблицы витруальных методов (VMT)
    /// Методы помеченные как виртуальные, при переопределении (override) попадают в таблицу VTM 
    /// и при вызове метода родительского типа вызывается последний вошеший в таблицу витруальный метод
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {

            ClassF f = new ClassF();

            ClassA ad = new ClassD();
            ClassA af = new ClassF();
            ClassD df = new ClassF();


            f.Go();  // Вывод: Go G  , так как прямой вызов
            ad.Go(); // Вывод: Go C  , так как вызов из VTM
            af.Go(); // Вывод: Go C  , так как вызов из VTM
            df.Go(); // Вывод: Go D  , так как D скрывает GO, от предыдущих переопределний, запроса к VTM нет 

            Console.ReadKey();

        }
    }
    class ClassA
    {
        public virtual void Go() => Console.WriteLine("Go A ");
    }
    class ClassB : ClassA
    {
        public override void Go() => Console.WriteLine("Go B ");
    }
    class ClassC : ClassB
    {
        public override void Go() => Console.WriteLine("Go C ");  // в ответе будет это значение,так как последний зашел в VTM

    }
    class ClassD : ClassC
    {
        public void Go() => Console.WriteLine("Go D ");// здесь идет перекрытие (вызывается неявно new) далее, все кто наследуются от D не требуют перегрузки
    }
    class ClassF : ClassD
    {
        public new void Go() => Console.WriteLine("Go F ");

    }

}
