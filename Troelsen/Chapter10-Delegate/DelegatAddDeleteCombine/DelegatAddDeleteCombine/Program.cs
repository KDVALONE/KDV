using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatAddDeleteCombine
{/// <summary>
 /// 0- до 12:35 >>> Провалил, закончил в 14:20
 /// 1- сделать 3 делегата (с параметрами/ без параметров, обобщенный.)
 /// </summary>
 /// 
    public delegate void MyDelegate();
    public delegate void MyDelegate2(string v);
    public delegate void MyDelegate3<T>();

    class Program
    {
        static void Main(string[] args)
        {


            ClassA a = new ClassA();
            

            Console.WriteLine("\n *********РАБОТА С ДЕЛЕГАТАМИ *******\n\n");
            MyDelegate dell = new MyDelegate(a.MethodClassA);

            dell += a.MethodClassA;
            dell += ClassA.MethodStaticClassA;
            dell += a.MethodClassA;

            dell?.Invoke();
    
            Console.WriteLine("\n вычитем 2 метода \n***************\n\n");

            dell -= a.MethodClassA;
            dell -= ClassA.MethodStaticClassA;

            dell?.Invoke();

            Console.WriteLine("\n\n уберем все методы ***************\n\n");
            dell -= a.MethodClassA;
            dell -= a.MethodClassA;
            
            dell?.Invoke(); // не выведиться ничего, так как делегат без подписчиков, так же если бы не было ? проверки на null то был бы exception
            Console.WriteLine("\n\n обощеный делегат Action он используется при VOID ***************\n\n");
            Action act; //Делегат Action является обобщенным, принимает параметры и возвращает значение void:
            act = a.MethodClassA;
            act(); //act?.Invoke(); тоже самое

            Console.WriteLine("\n\n обощеный делегат Function он используется при возвращении значения ***************\n\n");
            Func<string,string> func; // первый параметр string тип передаваемого параметра, второй тип возврщ. значения
            func = ClassB.MethodClassB;
            func?.Invoke("PARAMETR");
            Console.ReadKey();



           
        }

        class ClassA
        {
            public void MethodClassA()
            {
                Console.WriteLine("Вызвали метод classA");
            }
            public static void MethodStaticClassA()
            {
                Console.WriteLine("Вызвали static метод classA");
            }
        } // содержит VOID методы
        class ClassB
        {
            public static string MethodClassB(string value)
            {
                Console.WriteLine($"Вызвали static метод classB, с параметром: {value}, который он вернет");
                return value;
            }

        } // содержит возвращаемые методы.


    }
}


