using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public class NPC : Character, ISaler, IQuester
    {
        int IQuester.QuestCont
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        void IQuester.QuestCompleet()
        {
            throw new NotImplementedException();
        }

        void IQuester.QuestGive()
        {
            throw new NotImplementedException();
        }

        void ISaler.Thieve()
        {
            throw new NotImplementedException();
        }

        void ISaler.Trade()
        {
            throw new NotImplementedException();
        }
    }
}
