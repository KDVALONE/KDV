using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    public class WayGenerator
    {
        private static Random rnd = new Random();

        public static List<Biom> GenerateWay(Quest currentQuest)
        {
            
            int minBiomCount = 0;
            int maxBiomCount = 0;
            int fullBiomCount = 0;
            List<Biom> biomList;

            switch (currentQuest.QuestDifficult)
                {
                    case Difficults.low:
                        minBiomCount = 7;
                        maxBiomCount = 15;
                        break;
                    case Difficults.medium:
                        minBiomCount = 11;
                        maxBiomCount = 19;
                        break;
                    case Difficults.hard:
                        minBiomCount = 15;
                        maxBiomCount = 23;
                        break;
                }

            fullBiomCount = rnd.Next(minBiomCount, maxBiomCount);

            biomList = new List<Biom>(fullBiomCount);
            biomList.Add(new Biom());// TODO: cделать так, что бы последний биом был квестовый, в вбиом сделать поле квестовый или нет.Добавить к коснстркуктору biom коструктор с параметрами QestType и Difficult (будет влиять на сложность босса и врагов).

            return biomList; 
        }
        public static List<Biom> GenerateWay()
        {

            int minBiomCount = 0;
            int maxBiomCount = 0;
            int fullBiomCount = 0;
            List<Biom> biomList;

            minBiomCount = 7;
            maxBiomCount = 15;

            fullBiomCount = rnd.Next(minBiomCount, maxBiomCount);

            biomList = new List<Biom>(fullBiomCount);
            biomList.Add(new Biom());// TODO: cделать так, что бы последний биом был квестовый, в вбиом сделать поле квестовый или нет.Добавить к коснстркуктору biom коструктор с параметрами QestType и Difficult (будет влиять на сложность босса и врагов).

            return biomList;
        }
    }
}

