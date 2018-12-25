using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RndDerivedClassGnrtr
{
    /// <summary>
    /// Заполнить списо случайными наслледниками класса
    /// </summary>
    /// 
    
        abstract class Room { abstract public void Print(); }

        class Kitchen : Room { override public void Print() { Console.WriteLine("Kitchen"); } }
        class Bedroom : Room { override public void Print() { Console.WriteLine("Bedroom"); } }
        class Hall : Room { override public void Print() { Console.WriteLine("Hall"); } }
        class Restroom : Room { override public void Print() { Console.WriteLine("Restroom"); } }
        class Storeroom : Room { override public void Print() { Console.WriteLine("Storeroom"); } }
        class FunRoom : Room
            {
              override public void Print() { Console.WriteLine("FunRoom"); }
              public void GetFun()
        {
            Console.WriteLine("SOME FUNN BABY!!!");
        }
            }
       
    class Program
        {
            static List<Room> rooms;

            static void Main()
            {
                Random rnd = new Random();
                rooms = new List<Room>();
                Type ourtype = typeof(Room);
                Type[] types = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype)).ToArray();
                for (int i = 0; i < rnd.Next(100); i++)
                {
                    Room room = (Room)Activator.CreateInstance(types[rnd.Next(types.Length)]);
                    rooms.Add(room);
                }
            foreach (Room room in rooms)
            {
                room.Print();
               
                if (room.GetType() == typeof(FunRoom)) // если данный тип FunRoom, то используй его метод
                {
                    (room as FunRoom ).GetFun();
                }
            }



            Console.ReadKey();
            }
        }
}


#region Моя попытка реализации
//class Program
//{
//    static void Main(string[] args)
//    {
//       var assembley = Assembly.GetExecutingAssembly();

//        Method(assembley);

//        Console.ReadKey();

//    }
//    public static void Method(Assembly assembley)
//    {

//        Type[] type = assembley.GetTypes();
//        foreach (Type e in type)
//        {
//            if (e.IsSubclassOf(typeof(Room)))
//            {
//                  Console.WriteLine($"{e}");
//                (Type)e.Name A = new e.Name();
//            }
//        }


//    }




//   public class Room
//    {
//        public string NameOfRoom { get; set; }
//    }
//    class Kitchen : Room
//    {
//        public Kitchen()
//        {
//            this.NameOfRoom = "Kitchen";
//        }
//    }
//    class RestRoom : Room
//    {
//        public RestRoom()
//        {
//            this.NameOfRoom = "RestRoom";
//        }
//    }
//    class Hall : Room
//    {
//        public Hall()
//        {
//            this.NameOfRoom = "Hall";
//        }
//    }
//    class StoreRoom : Room
//    {
//        public StoreRoom()
//        {
//            this.NameOfRoom = "StoreRoom";
//        }
//    }

//}

#endregion

