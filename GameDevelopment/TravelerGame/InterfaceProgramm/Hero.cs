using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TravelerGame
{
    public class Hero : Character, IFighter, ISaler//Класс главного персонажа
    {
        #region Propierties and Constructor
        public bool AttackFirst { get; set; }
        public bool Shoked { get; set; }

        public Hero( string charackterFirstName)
                    :base(charackterFirstName)
        {
            AttackFirst = false;
            Shoked = false;
        }
        #endregion

       

        public void Attack(int endurence, Attack attackType, bool fastKill = false)
        {
            throw new NotImplementedException();
        }

        public void Block(int endurence, Attack attackType, bool fastKill = false)
        {
            throw new NotImplementedException();
        }

        public void Dodge(int endurence, Attack enemyAttackType, bool fastKill = false)
        {
            throw new NotImplementedException();
        }

        public void Escape(int indurence)
        {
            throw new NotImplementedException();
        }

        public bool FastKill(int endurence)
        {
            throw new NotImplementedException();
        }

        public void Ranaway(int endurence)
        {
            throw new NotImplementedException();
        }

        public void Stelth(int endurence, bool visbele)
        {
            throw new NotImplementedException();
        }

        public void Swear()
        {
            throw new NotImplementedException();
        }

        public void Thieve()
        {
            throw new NotImplementedException();
        }

        public void Trade()
        {
            throw new NotImplementedException();
        }

        void CampRest()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Helth += 5;
                Endurence += 10;
                Console.WriteLine($"{Name} отдыхает, и восполняет жизненные силы.\n" +
                $" Похоже что его бодрость восстановилась  на {Endurence} процентов, а здоровье и самочувствие на {Helth} процентов от нормы.");
            }
        } // отдых в лагере.

        private void Walk(int Endurence) // метод для передвижения по месности (глобальная карта.)
        {
            

        }
    }
}
