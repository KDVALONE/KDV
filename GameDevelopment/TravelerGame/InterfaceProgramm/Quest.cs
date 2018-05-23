using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    class Quest
    {
        public QuestTypes QuestType { get; private set; } //тип квеста убить монстра(Hunt), найти предмет(Exploring).
        public Difficults QuestDifficult { get; private set; }
        public string QuestName { get; private set; }
        public string QuestDescription { get; private set; }
        public Dictionary<string,string> QestDescriptionDict { get; private set; }
        public List<Biom> QuestWay { get; private set; }
        public Quest()
        {
            this.QuestDifficult = GameService.GetDifficult();
            this.QuestType = GameService.GetQuestType();
            this.QestDescriptionDict = QuestDescriptionGenerator.GetQuestDescription(QuestType);
            QuestName =  QestDescriptionDict.ElementAt(0).Key;
            QuestDescription = QestDescriptionDict.ElementAt(0).Key;
            QuestWay = 
        }
        
       
    }
    
  
}
