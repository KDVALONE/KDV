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

            static public Difficults GetDifficult() // возвращает случайное занчиение сложности
            {
              return  (Difficults)rnd.Next(Enum.GetValues(typeof(Difficults)).Length);
            }
            static public QuestTypes GetQuestType() // возвращает случайное типа квеста
            {
            return (QuestTypes)rnd.Next(Enum.GetValues(typeof(QuestTypes)).Length);
            }
    }
    
}

