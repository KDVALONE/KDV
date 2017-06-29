using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestProgrammToTrening
{
    class Hud //  интерфейс, вывод всего через интерфейс
    {
        private String wether = "";
        private int hungry = 0;
        private int time = TimeHours.CurentHours;
        private string message = "";
        private string foodName = "";

        public string Wether { get { return wether; } set { wether = value; } }
        public int Hungry { get { return hungry; } set { hungry = value; } }
        public int Time { get { return time; } set { time = value; } }
        public string Message { get { return message; } set { message = value; } }
        public string FoodName { get { return foodName; } set { foodName = value; } }

    internal void HudScreen()
        {
            Time = TimeHours.CurentHours;
            Console.WriteLine(" \n  Wether: {0}            Hangry: {1}                   Time: {2} : 00 hours " +
                    "\n \n \n \n \n \n \n                 {3}             \n  \n \n \n \n \n \n " +
                     "\n       ______  M " + "\n  -__-(_////_)<00>  " + "\n      ll  ll   Y " + "\n      LL  lL   " +
                      "\n----------------({4})------------------------------------------------------------", wether, hungry, time, message, foodName);
                Thread.Sleep(1000);
                Console.Clear();
                
         }

   /*     internal void HudScreen( )
             {
            Console.WriteLine(" \n  Wether: {0}            Hangry: {1}                   Time: {2} : 00 hours " +
               "\n \n \n \n \n \n \n                 {3}             \n  \n \n \n \n \n \n " +
                "\n       ______  M " + "\n  -__-(_////_)<00>  " + "\n      ll  ll   Y " + "\n      LL  lL   " +
                 "\n----------------({4})------------------------------------------------------------", wether, hungry, time, message, foodName);
            Thread.Sleep(1000);
            Console.Clear();
        } */
        public Hud()// Конструктор по умолчанию ьез параметров
        {

        }
        public Hud(string HWether, int HHungry, string HMessage, string HFoodName) // конструктор
        {
            Wether = HWether;
            Hungry = HHungry;
            Message = HMessage;
            FoodName = HFoodName;

        }
      

    }
}
