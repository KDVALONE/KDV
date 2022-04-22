using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Collections;

namespace ConsoleApplication
{
    public enum SomeEnum { one, two }

    public class AnimalAttribute : Attribute { }
    public interface IFlore { }
    public class Tree : IFlore { public string R { get; set; } public SomeEnum a = SomeEnum.one; }
    public class Flower : IFlore { public string X { get; set; } public SomeEnum a = SomeEnum.one; }
    public class Animal { public string X { get; set; } public SomeEnum a = SomeEnum.two; }
    public class Elephant : Animal { public string X { get; set; } public SomeEnum a = SomeEnum.two; }
    public class Wolf : Animal { public string X { get; set; } public SomeEnum a = SomeEnum.two; }
    public class Program
    {


        public static void Main()
        {
            void Met3()
            {
                List<Animal> savanna = new List<Animal>();
                savanna.Add(new Wolf { X = "Wolf" });
                savanna.Add(new Wolf { X = "Wolf2" });
                savanna.Add(new Wolf { X = "Wolf12" });
                savanna.Add(new Elephant { X = "Elephant" });
                savanna.Add(new Animal { X = "dethclaw" });


                var some = from f in savanna.OfType<Wolf>() where f.X.Contains("2") select f;

                foreach (var s in some)
                    Console.WriteLine(s.X);
            }
            void Met2()
            {
                ArrayList savanna = new ArrayList();
                savanna.Add(new Animal { X = "wolf" });
                savanna.Add(new Animal { X = "rabbit" });
                savanna.Add(new Animal { X = "dethclaw" });
                savanna.Add(new Flower { X = "rose" });
                savanna.Add(new Flower { X = "narcise" });

                var some = from f in savanna.OfType<Flower>() where f.X.Contains("ro") select f;

                foreach (var s in some)
                    Console.WriteLine(s.X);
            }
            Met3();
            //  Met2();
            //List<Tree> savana = new List<Tree>();
            // savana.Add(new Tree {R = "mmm" });
            // savana.Add(new Tree { R = "mxx" });
            // savana.Add(new Tree { R = "mxm" });

            void Meth(List<Tree> savana1)
            {
                var selectedTeams = from c in savana1 where c.a == SomeEnum.one && c.R.Contains("xx") select c;
                foreach (var s in selectedTeams)
                    Console.WriteLine(s.R);
            }

            //string[] array = {"one1","two2","three3","four4" };

            //var s = from t in array
            //        where t.Contains("one1")
            //        select t;

            //Console.WriteLine($"{s.}");
            Console.ReadKey();
        }
        // IFlore[] FloreArray;

    }
}