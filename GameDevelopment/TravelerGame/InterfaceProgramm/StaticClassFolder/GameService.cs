using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
   static class GameService
    {
        /// <summary>
        /// вспомогательный класс, сюда вспомогательные статические методы.
        /// </summary>
            static Random rnd = new Random();
            static public bool GetProcent(int n)
            {
            bool hit = rnd.Next(1, 101) <= n;
            return hit;
            } // класс проверки выполненния какого то действия. ринимает n - шанс выполнения, и возвращаяет, тру или фолс

            static public Difficults GetDifficult() => (Difficults)rnd.Next(Enum.GetValues(typeof(Difficults)).Length); // возвращает случайное занчиение сложности
            static public QuestTypes GetQuestType() => (QuestTypes)rnd.Next(Enum.GetValues(typeof(QuestTypes)).Length); // возвращает случайное типа квеста
            static public CityTypes GetCityType() => (CityTypes)rnd.Next(Enum.GetNames(typeof(CityTypes)).Length);// возвращает случайное типа города

            static public Difficults SetGameDifficult()
        {
            int difficult;
            
            Console.WriteLine("Выбирите уровень сложности\n 1-легкий 2-средний 3-тяжелый");
            difficult = Console.Read();
            while (difficult == 1 || difficult == 2 || difficult == 3)
            {
                difficult = Console.Read();
            }

            return (Difficults)difficult;


        }  //  выбор сложности игры
            static public int GetCityCount(Difficults gameDif)
            {
            int cityCount= 2 + ((int)gameDif * 2);
            return cityCount;
            } // задает количество городов в игре
    }
    
}

