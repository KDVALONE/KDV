using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DelPrgm
{
    class Station
    {
        readonly int passagerMinCount = 0;
        readonly int passagerMaxCount = 5;

        readonly int passagerTakeOfMinCount = 1;
        readonly int passagerTakeOfMaxCount = 6;

        public int PassagerGetInCount { get; set; }
        public int PassagerTakeOfCount { get; set; }
        private Random rnd = new Random();       
        public Station()
        {
           PassagerGetInCount = rnd.Next(passagerMinCount,passagerMaxCount);
           PassagerTakeOfCount = rnd.Next(passagerMinCount, passagerMaxCount);
        }



    }
}
