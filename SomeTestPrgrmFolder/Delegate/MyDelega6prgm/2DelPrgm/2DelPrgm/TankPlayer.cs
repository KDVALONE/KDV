
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    class TankPlayer : Tank
    {

        public TankPlayer(TeamTypeEnum teamType, int tankI, int tankJ,string tankName)
            : base(teamType, tankI, tankJ)
        {
            TankName = tankName;
        }
    }
}