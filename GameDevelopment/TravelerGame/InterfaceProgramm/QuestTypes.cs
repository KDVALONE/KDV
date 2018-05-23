using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{

    enum QuestTypes
    {
        Hunt,
        Exploring,
        FreeRun  //HACK: Enum.QuestTypes.FreeRun свободное путешестивие, генерит дорогу впереди Героя,значение нужено для WayGenerator. Переделать как то свободное путешествие.
    }
   
}
