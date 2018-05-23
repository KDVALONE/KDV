using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    interface IQuester
    {
        int QuestCont { get; set; }

        void QuestGeve();
        void QuestCompleet();
    }
}