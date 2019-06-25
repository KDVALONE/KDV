
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    class TankEnemy : Tank
    {
        

        public TankEnemy(TeamTypeEnum teamType, int tankI, int tankJ)
            : base(teamType,tankI,tankJ)
        {
            TankName = TankNameGenerator.GenerateTankName();
        }
        
     
    }
}