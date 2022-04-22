using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    class Enemy : Character, IFighter  //Класс врага
    {
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
    }
}
