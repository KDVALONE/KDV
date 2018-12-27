
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2DelPrgm
{
    class Tank
    {

        public bool TankIsDead { get; set; }
        public int Ekipage { get; set; }
        public int Venchils { get; set; }
        public int TankI { get; set; }
        public int TankJ { get; set; }
        TeamTypeEnum Team { get; set; }
        public int FinishJ { get; set; }
        public int FinishI { get; set; }
        public List<Point> WayToTarget { get; set; }


        public Tank(TeamTypeEnum teamType, int tankJ, int tankI, int finishJ , int finishI)
        {
            TankIsDead = false;
            Ekipage = 3;
            Venchils = 3;
            Team = teamType;
            TankI = tankI;
            TankJ = tankJ;
            FinishJ = finishJ;
            FinishI = FinishJ;


        } 

    }
}