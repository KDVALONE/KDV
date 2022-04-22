using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerGame;

namespace TravelerGame
{
    class Battle 
    {///класс для описания битвы, .
        // TO DO: Расширить, добавив коструктор в который передавать NPC помощника, для боя 3 на 
        //переделать потом под событие
        Hero Hero { get; set; }
        List<Enemy> EnemyList;
        List<Character> TurnSequence; // порядок хода
        public Battle(Hero hero,List<Enemy> enemyList) 
        {
            this.Hero = hero;
            this.EnemyList = enemyList;
        }

        
        public void FigthWithEnemy() // начало битвы
        {
            if (Hero.AttackFirst)
            {
            }
        }

        public void TurnOfHero() { }
        public void TurnOfEnemy() { }

        public void HeroIsLiving()
        {
            if (Hero.Living == false)
                NexTurn           
        }
    }
}
