using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;

namespace TestNameSpace
{/// <summary>
/// Приложение созданно для понимания расположения обьектов в памяти STACK(СтекПотока) и HEAP(управляемая куча)
/// </summary>

    class Program
    {
        
        public static void Main()
        {
            //вернет 2 - так как ARef ссылочный тип, и передается в метод по ссылке
            ARef a = new ARef();
            ARef a1 = new ARef();
            a.a = 1;
            a1.a = 2;
            ChangerVoid(a, a1);
            Console.WriteLine($"КЛАСС = {a1.a}");
            Console.ReadKey();

            //вернет 1 так как BVal тип значения и передается в метод по значению
            BVal b = new BVal();
            BVal b1 = new BVal();
            b.b = 1;
            b1.b = 2;
            ChangerVoid(b, b1);
            Console.WriteLine($"СТРУКТУРА = {b.b}");
            Console.ReadKey();

            //Вернет 1 так как хоть STRING и передается по ссылке являясь ссылочным типом, но он UNMUTABLE тоесть не изменяемы, и поведение такое же как при передачи по значению
            string str = "1";
            string str1 = "2";
            ChangerVoid(str, str1);
            Console.WriteLine($"STRING = " + str);
            Console.ReadKey();

            //Вернет 2 так как массив STRING ссылочный тип
            string[] arr = { "1" };
            string[] arr1 = { "2" };
            ChangerVoid(arr, arr1);
            Console.WriteLine($"МАССИВ STRING = " + arr[0]);
            Console.ReadKey();

            //Вернет 2 так как массив ARef ссылочный тип
            ARef[] aref = new ARef[2];
            ARef[] aref1 = new ARef[1];
            ARef ac = new ARef();
            ARef ac1 = new ARef();
            aref[0] = ac;
            aref1[0] = ac1;
            aref1[0].a = 2;
            ChangerVoid(aref, aref1);
            Console.WriteLine($"МАССИВ AREF = " + aref[0].a);
            Console.ReadKey();


            //Вернет 1 так как массив AVal содержит тип значений, и он не изменится так как передасться по ссылке
            BVal[] aVal = new BVal[2];
            BVal[] aVal1 = new BVal[1];
            BVal astr = new BVal();
            BVal astr1 = new BVal();
            astr.b = 1;
            astr1.b = 2;
            aVal[0] = astr;
            aVal1[0] = astr1;
            ChangerVoid(aVal, aVal1);
            Console.WriteLine($"МАССИВ AVAL = " + aVal[0].b);
            Console.ReadKey();



            //Вернет 1 так как BValRef тип значений
            BValRef bvr = new BValRef();
            BValRef bvr1 = new BValRef();
            bvr.a = new ARef();
            bvr1.a = new ARef();
            bvr1.a.a = 2;
            ChangerVoid(bvr, bvr1);
            Console.WriteLine($"STRUCT WITH REFTYPE = " + bvr.a.a);
            Console.ReadKey();

            //Возвращает 1. Почему? ведь это ссылочный тип, и даже если он содержит тип значений то он приводится в CIL в ссылочный тип тоже (Boxing)
            ARefVal arv = new ARefVal();
            ARefVal arv1 = new ARefVal();
            arv.b = new BVal();
            arv.b.b = 1;
            arv1.b = new BVal();
            arv1.b.b = 2;
            ChangerVoid(arv, arv1);
            Console.WriteLine($"REFTYPE WITH STRUCT = " + arv.b.b);
            Console.ReadKey();

            Console.WriteLine("\n Конец");
            Console.ReadKey();
        }

        public static void ChangerVoid(Object a, Object b)
        {
            //  a = 2;
            a = b;

        }
        public static void ChangerVoid(String[] a, String[] b)
        {
            //  a = 2;
            a[0] = b[0];
        }
        public static void ChangerVoid(ARef[] a, ARef[] b)
        {
            //  a = 2;
            a[0] = b[0];
        }
        public static void ChangerVoid(BValRef a, BValRef b)
        {
            //  a = 2;
            a = b;
        }
        public static void ChangerVoid(ARefVal a, ARefVal b)
        {
            //  a = 2;
            a = b;
        }

    }


    public class ARef
    {
        public int a;
        public ARef()
        {
            a = 1;
        }

    }

    public struct BVal
    {
        public int b;

    }
    public struct BValRef
    {
        public ARef a;

    }
    public class ARefVal
    {
        public BVal b;

    }


}