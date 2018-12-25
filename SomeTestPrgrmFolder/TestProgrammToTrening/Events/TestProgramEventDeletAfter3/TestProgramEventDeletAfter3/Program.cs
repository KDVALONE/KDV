using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProgramEventDeletAfter3
{/// <summary>
 /// Затестить делегаты эвенты.
 /// простой делегат, обьединить делегаты, удалить делегаты, обобщенные делегаты Func  Action - ок.
 /// эвенты, эвенты с параметрами, обощеные евенты EventHadnler -ок
 /// анонимные методы, лямбда выражения -ок
 /// </summary>

   // public delegate void Action<T>(T obj);
    public delegate void MyDelegate(string v);
    public delegate void MyDelegateHadler(object sender, MyEventArgs e); // делегат для события
    class Program
    {
        const string message1 = "СООБЩЕНИЕ №1";
        const string message2 = "СООБЩЕНИЕ №2";
        const string message3 = "СООБЩЕНИЕ №3";
        const int value = 10;

        static void Main(string[] args)
        {
            ClassA ca = new ClassA();
            ClassB cb = new ClassB();
            ClassC cc = new ClassC();
            ClassG cg = new ClassG();

            MyDelegateRegster mdr = new MyDelegateRegster();
            MyDelegateRegister2 mdr2 = new MyDelegateRegister2();
            Console.WriteLine("**************** делгаты **************");
            mdr.MyDellRegisterMeth(ca.MethodClassA);
            mdr.MyDellRegisterMeth(cb.MethodClassB);

            mdr2.MyDellRegisterMeth2(cc.MethodClassC);
            mdr2.MyDellRegisterMeth2(cc.MethodClassC);
            mdr2.CombineDelegate();


            mdr2.StartDel2(message3);
            Console.WriteLine("**************** обощенные делгаты **************");
            mdr.StartActionDel(ClassD.MethodClassD, 2, 3);
            Console.WriteLine("Обобщеный делегат Func вывел {0} ", mdr.StartFuncDel(ClassF.MethodClassF, value));
            Console.WriteLine("**************** события **************");
            MyEventClass mec = new MyEventClass();
            mec.EventRegister(cg.MethodClassG);
            mec.EventSart(message1);
            Console.WriteLine("**************** обобщенные события **************");
            mec.EventGenericRegistr();
            mec.MyEventGeneric += delegate { Console.WriteLine("Анонимный метод"); };
            mec.MyEventGeneric += (sender, e) => { Console.WriteLine("Лямбда выражение"); };
            mec.EventGenericSart(message2);

            Console.ReadKey();


        }
    }

    class MyEventClass
    {
        public event MyDelegateHadler MyEvent;
        public event EventHandler<MyEventArgs> MyEventGeneric;

        public void EventGenericRegistr()
        {
            MyEventGeneric += ClassQ.MethodClassQ;
            
        }
        public void EventGenericSart(string msg)
        {
            MyEventGeneric?.Invoke(this, new MyEventArgs(msg));
        }

        public void EventRegister(MyDelegateHadler mydel)
        { MyEvent += mydel;        }
        public void EventSart(string msg)
        {
            MyEvent?.Invoke(this, new MyEventArgs(msg));
        }

    }

    class MyDelegateRegster
    {
        public MyDelegate myDell1;
        public Action<int, int> _act;
        public Func<int, int> _func;
        public void StartActionDel(Action<int, int> act, int a, int b)
        {
            _act += act;
            _act?.Invoke(a, b);
        }

        public int StartFuncDel(Func<int, int> func, int val)
        {
            _func += func;
           int result =(Int32)_func?.Invoke(val);
            return result;
        }
        public void MyDellRegisterMeth(MyDelegate del)
        {
            myDell1 += del;
        }
    }
    class MyDelegateRegister2
    {
        public delegate void MyDelegate2(string v);
        public MyDelegate2 myDell2;

        public void MyDellRegisterMeth2(MyDelegate2 delV)
        {
            myDell2 += delV;
        }

        public void StartDel2(string v)
        {
            myDell2?.Invoke(v);
        }

        public void CombineDelegate()
        {
            Delegate myCombDell = Delegate.Combine(myDell2, myDell2);
            myDell2 = myCombDell as MyDelegate2;
        }


    }

    public class ClassA { public void MethodClassA(string message) { Console.WriteLine($"Метод класса А вывел: {message}"); } }
    public class ClassB { public void MethodClassB(string message) { Console.WriteLine($"Метод класса B вывел: {message}"); } }
    public class ClassC { public void MethodClassC(string message) { Console.WriteLine($"Метод класса C вывел: {message}"); } }
    public static class ClassD { public static void MethodClassD(int val, int val2) { Console.WriteLine($"Метод класса C вывел: {val} и {val2} используя делегат обобщоный Action"); } }
    public static class ClassF { public static int MethodClassF(int val) { return val = val + 1; } }
    public class ClassG { public void MethodClassG(object sender, MyEventArgs e) { Console.WriteLine($"Метод класса G вывел: {e.Message}"); } }
    public static class ClassQ { public static void MethodClassQ(object sender, MyEventArgs e) { Console.WriteLine($"Метод класса Q вывел: {e.Message}"); } }

    public class MyEventArgs : EventArgs  // класс для события
    {
        public string Message;
        public MyEventArgs(string msg)
        {
            this.Message = msg;
        }
    }

}



