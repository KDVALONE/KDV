using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public static class IdGenerator
    {
        private static int Id { get; set; }
        static IdGenerator()
        {
            Id = 0;
        }

        public static int GetId() => Id++; 
        

    }
}
