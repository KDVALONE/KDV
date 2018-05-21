using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProgramm
{
    public class Way
    {
        //TODO: переделать класс, наверное не на статику,Сделать класс генерирующий
        // случайное кол-во биом, которое будет считаться путем до квестовой цели. 
        static int BiomCountIndex { get; private set; }
        private static Random rnd = new Random();
        private static int[] arrayToIndexation;
   
        public static List<Biom> WayGenerator()
        {
            BiomCountIndex = arrayToIndexation[rnd.Next(0,)];
            List<Biom> BiomList = new List<Biom>();
            for (int i = 0; I )
            BiomList
            l
            return BiomList;
        } 

    }
}
