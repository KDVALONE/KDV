using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
namespace SetListOfDerClas
{
    /// <summary>
    /// Рефлексия. заполнить список наследниками абюрстрактного класса, причем у нектрых нет конструкторов по умолчанию.
    /// 
    /// </summary>
    abstract class Room { abstract public void Print(); }

    public enum SomeEnum { one = 1, two }
    class Kitchen : Room { override public void Print() { Console.WriteLine("Kitchen"); } }
    class Bedroom : Room { override public void Print() { Console.WriteLine("Bedroom"); } }
    class Hall : Room
    {
        SomeEnum CountIteration { get; set; }
        public Hall(SomeEnum countIteration)
        {
            CountIteration = countIteration;
        }
        override public void Print() { Console.WriteLine("Hall"); }
        public void SomeMet() { Console.WriteLine($"Что-то  делать {CountIteration} раза"); }

        class Program
        {
            static List<Room> rooms;
            public static Random rnd = new Random();
            static void Main()
            {

                rooms = new List<Room>();
                Type ourtype = typeof(Room);
                Type[] types = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype)).ToArray();
                for (int i = 0; i < rnd.Next(100); i++)
                {
                    SomeEnum e = SomeEnum.two;
                    int element = rnd.Next(types.Length);
                    Room room;
                    if (types[element] == typeof(Hall))
                    { room = (Room)Activator.CreateInstance(types[element], e); }
                    else { room = (Room)Activator.CreateInstance(types[element]); }
                    rooms.Add(room);
                }
                foreach (Room r in rooms)
                {
                    if (r is Hall)
                    { (r as Hall).SomeMet(); }
                    else { r.Print(); }

                }
                Console.ReadKey();
            }

        }
    }
}

