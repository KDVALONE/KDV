using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSimple1
{
    class Program
    {
        static void Main(string[] args)
        {

            Gun gun = new Gun("AK-47", 10, 10);
            gun.RegisterMethodForDelegate(new Gun.GunLoaderHandler(StartShooting));
            gun.RegisterMethodForDelegate(Chek);
            gun.Shooting();
        }
        public static void StartShooting(string msg)
        {
            Console.WriteLine("*******MSG from rifle**********");
            Console.WriteLine($"=> {msg}");
            Console.WriteLine("***********");
        }
        public static void Chek(string msg)
        {
            Console.WriteLine("*******Chek some!**********");
            
        }
    }
}
