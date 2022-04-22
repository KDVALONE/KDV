using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
   public class Attack
    {
        //Сделать абстрактным классом?
        string AttackName { get; set; }
        
        int AttackHitPoints { get; set; }

        List<string> AttackDescriptionKill = new List<string>(); // список для описания событий при уибйстве
        List<string> AttackDescriptionHit = new List<string>(); // список для описания событий при попадании

        List<string> AttackDescriptionMiss = new List<string>();// список для описания событий при промахе

        Attack(string attackDescriptionHit)
        {
            this.AttackDescriptionHit.Add($"{attackDescriptionHit}");
        }
    }

}
