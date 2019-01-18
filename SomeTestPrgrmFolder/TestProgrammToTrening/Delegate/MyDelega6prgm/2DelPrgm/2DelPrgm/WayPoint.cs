using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    public struct WayPoint
    {
        public int Y { get; set; }
        public int X { get; set; }
        
        public WayPoint( int y,int x)
        {
            
            Y = y;
            X = x;
        }
    }
}