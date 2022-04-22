
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    class Tank
    {

        public bool TankIsDead { get; set; }
        public int Ekipage { get; set; } // Кол-во человек в экипаже, влияет на кол во очков действия
        // public int Venchils { get; set; } //TODO: тут подумать, над состоянимями танка, предметами и прочим 
        public WayPoint CurrentCellPoint { get; set; } // местоположение танка на карте
        public TeamTypeEnum Team { get; set; }
        public string TankName { get; set;}
        public List<WayPoint> WayToTarget { get; set; }
        

        public Tank(TeamTypeEnum teamType, int tankI, int tankJ /*, int finishJ , int finishI*/)
        {
            
            TankIsDead = false;
            Ekipage = 3;
            Team = teamType;
            CurrentCellPoint = new WayPoint(tankI, tankJ);
           
         
        } 

    }
}