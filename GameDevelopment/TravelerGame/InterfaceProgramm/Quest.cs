using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    class Quest
    {
        public QuestType QestType { get; private set; } //тип квеста убить монстра(Hunt), найти предмет(Exploring).
        public Difficult QuestDifficult { get; private set; }
        public string QuestName { get; private set; }
        public Dictionary<string,string> QestDescription { get; private set; }
      
        public Quest()
        {
            this.QuestDifficult = GameService.GetDifficult();
            this.
             
        }
        
       
    }
    
  
}
