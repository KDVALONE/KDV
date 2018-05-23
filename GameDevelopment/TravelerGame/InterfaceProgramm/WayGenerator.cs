using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public static class WayGenerator
    {
        //TODO: переделать класс, наверное не на статику,Сделать класс генерирующий
        // случайное кол-во биом, которое будет считаться путем до квестовой цели. 

        public static int BiomCount { get; private set; }
        private static Random rnd = new Random();
        private static int[] arrayToIndexation;

    
        
        
        public static List<Biom> GenerateWay(Difficults difficult, QuestTypes questType)
        {
            BiomCount = arrayToIndexation[rnd.Next(0,)];
            List<Biom> BiomList = new List<Biom>();
            foreach (Biom biom in BiomList)
            {

            }
            return BiomList;
        } 

    }
   
}
