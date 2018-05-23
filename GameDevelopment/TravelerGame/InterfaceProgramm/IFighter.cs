using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{// возможно стоит передавать и ссылку на вызывающий обьект
    interface IFighter // интерфейс поведения боя
    {
        bool AttackFirst { get; set; } // персонаж атаковал первым? Вообще нужно подумать о системе типа SPECISAL,
        //и на основе ее реализовывать иницативу в бою.
        bool Shoked { get; set; } // перонаж шокирован?

        void Attack(int endurence, Attack attackType, bool fastKill = false);
        void Block(int endurence, Attack attackType, bool fastKill = false);
        void Dodge(int endurence, Attack enemyAttackType, bool fastKill = false); //уклонение
        void Stelth(int endurence, bool visbele); // возможность подкрсться
        bool FastKill(int endurence); //убийство с первого удара.
        void Ranaway(int endurence); // прокрасться мимом и скрыться
        void Escape(int indurence);// убежать
        void Swear(); // материться =)) восполняет выносливость.

    }
}
