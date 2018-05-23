using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    static class EnemyNameGenerator
    {// Класс для генерирования имен врагов.
        public static string[] EnemyFirstName{ get; set;}
        public static string[] EnemyNickName { get; set;}
        private static Random random = new Random();

        static EnemyNameGenerator()
        {
            EnemyFirstName = new string[] { "Серега", "Димон", "Костян", "Некит", "Саня", "Лёня", "Дёc", "Макс", "Андрюха", "Колян" };
            EnemyNickName = new string[] { "Коловрат", "Череп", "Черный", "Рокот", "Монах", "Докер", "Фараон", "Свинец", "Печенег", "Сектор", "Шиба" };
        }
    
        public static string GetEnemyName()
        {
             return EnemyFirstName[random.Next(0, EnemyFirstName.Length)];
            
        }
        public static string GetEnemyNickName()
        {
            return EnemyNickName[random.Next(0, EnemyNickName.Length)];
        }
    }
}
