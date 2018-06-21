using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public class Quest
    {/// <summary>
    /// Quest служит для хранения данных о квесте
    /// </summary>
        public QuestTypes QuestType { get; private set; } //тип квеста убить монстра(Hunt), найти предмет(Exploring).
        public Difficults QuestDifficult { get; private set; }
        public List<Biom> QuestWay { get; private set; }
        public string QuestName { get; private set; }
        public string QuestDescription { get; private set; }
        public Dictionary<string,string> QuestDescriptionDict { get; private set; }
        

        public Quest()
        {
            this.QuestDifficult = GameService.GetDifficult();
            this.QuestType = GameService.GetQuestType();
            this.QuestDescriptionDict = QuestDescriptionGenerator.GetQuestDescription(QuestType);
            QuestName =  QuestDescriptionDict.ElementAt(0).Key;
            QuestDescription = QuestDescriptionDict.ElementAt(0).Value;
            QuestWay = WayGenerator.GenerateWay(this);   
        }
        
       
    }
    
  
}
