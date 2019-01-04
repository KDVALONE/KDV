using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TankGame
{
    public struct Point
    {
        public int Y { get; set; }
        public int X { get; set; }
        
        public Point( int y,int x)
        {
            
            Y = y;
            X = x;
        }
    }
}