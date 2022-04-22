using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
         
           MyClass.GenerateWay(Difficults.hard,QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            MyClass.GenerateWay(Difficults.hard, QuestTypes.Exploring);
            Console.ReadKey();
        }
    }
    static class MyClass
    {
       static Random rnd = new Random();
       static public void GenerateWay(Difficults difficult, QuestTypes questType)
        {
            int minBiomCount= 0;
            int maxBiomCount =0;
            int fullBiomCount = 0;

            switch (difficult)
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

            Console.WriteLine($"{fullBiomCount}");
       
        }
    }

    enum Difficults
    {
        hard,
            low,
            medium
    }
    enum QuestTypes
    {
        Hunt,
        Exploring,
        FreeRun
        

    }
}

