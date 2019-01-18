using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
   public static class TankNameGenerator
    {
        static private Random rnd = new Random();
        static private string[] TankNameArray = new string[] { "Toster", "Grill", "Stove", "Oven", "Pot", "Can" }; //TODO:переделать в файл или бд
        public static string GenerateTankName() => TankNameArray[rnd.Next(0, TankNameArray.Length)];

    }
}
