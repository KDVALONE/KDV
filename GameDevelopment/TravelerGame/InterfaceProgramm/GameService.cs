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

    }
    
}

