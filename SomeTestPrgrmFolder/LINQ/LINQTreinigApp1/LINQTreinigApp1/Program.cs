using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQTreinigApp1
{   
    /// <summary>
    /// Тренировочное решение-шпора по Linq и лямбдам 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LambdaSyntaxis1:");
            LambdaLinq.LambdaSyntaxis1();
            Console.WriteLine("LambdaSyntaxis2:");
            LambdaLinq.LambdaSyntaxis2();
            Console.WriteLine("LambdaSyntaxis3:");
            LambdaLinq.LambdaSyntaxis3();
            Console.ReadKey();
        }
    }
}

public static class LambdaLinq
{
    class Car
    {
        public string Name;
        public string Color;
        public int MaxSpeed;
        public string Made;

    }


    public static void LambdaSyntaxis1()
    {
        List<int> list = new List<int>();
        list.AddRange(new int[] {20, 1, 4, 8, 9, 44});

        List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);
        foreach (var e in evenNumbers)
        {
            Console.Write($"{e} ");
        }

        Console.Write($"\n");

    }

    public static void LambdaSyntaxis2()
    {
        string[] videoGames = {"Unchareted", "Deus Ex", "X - Com", "Fallout-2", "Last of Us - 2"};

        IEnumerable<string> selectedGames = videoGames.Where(g => g.Contains("-")).OrderBy(g => g).Select(g => g);

        foreach (var e in selectedGames)
        {
            Console.WriteLine(e);
        }
    }

    public static void LambdaSyntaxis3()
    {
        List<Car> myCars = new List<Car>()
        {
            new Car() { Name = "BadAss", Color = "White", MaxSpeed = 200, Made = "BMW"},
            new Car() { Name = "Lastochka", Color = "Red", MaxSpeed = 180, Made = "LADA" },
            new Car() { Name = "Rocket", Color = "Red", MaxSpeed = 210, Made = "BMW" },
            new Car() { Name = "Lux", Color = "Black", MaxSpeed = 200, Made = "Mercedes" },
            new Car() { Name = "Wing", Color = "White", MaxSpeed = 220, Made = "BMW" }
        };
        

        var fastCarsBMW = from c in myCars where c.MaxSpeed > 200 && c.Made == "BMW" select c;

        foreach (var e in fastCarsBMW)
        {
            Console.WriteLine($"{e.Name} {e.Color} {e.MaxSpeed} {e.Made}");
        }
    }
}