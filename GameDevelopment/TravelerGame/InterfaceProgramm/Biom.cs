using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerGame;

namespace TravelerGame
{
    public class Biom
    {
     
        /// биом, содержащий в себе описание встреченной области, 
        /// с возможными врагами или непроходимыми местами и лутом 

        Random rnd = new Random();
        public int[] arrayToIndexation = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };// TODO: отрефакторить, убрав массив, сделав проще черех rnd.Next
        BiomTypes BiomType { get; private set; } // тип биома, лес, луг, поле,  и тд
        BiomLayers BiomLayer { get; private set; }
    
        public bool HardWay { get; private set; } // затруднение в пути, не может быть в месте с врагами
        public int EnemyCount
        {
            get { return this.EnemyCount; }
            private set
            {
                if (HardWay == true)
                    this.EnemyCount = 0;
                else
                    this.EnemyCount = value;
            }
        } // кол - во врагов, сделать от 0 до 3
        List<Enemy> enemyCountInBiom = new List<Enemy>();
       
             
        public bool BiomHaveTreasure { get; private set; } // ТОDO переделать, сделать отдельное происшествие - найден обьект для лута.
        public bool BiomHaveTrader { get; private set; }
        public Biom()
        {
            this.HardWay = (arrayToIndexation[rnd.Next(0, arrayToIndexation.Length)] < 3);
            this.BiomHaveTreasure = (arrayToIndexation[rnd.Next(0, arrayToIndexation.Length)] > 7);
            this.EnemyCount = arrayToIndexation[rnd.Next(0, 4)];
            for (int i = 0; i != this.EnemyCount; i++){ this.enemyCountInBiom.Add(new Enemy()); }
            
        }
        // возможно вывести методы в другой класс, что то типо BiomMethod

        public void StartBattle(Hero hero)// TODO: тут не закончил, разобрать и переделать
        {
            Battle battle = new Battle( hero, enemyCountInBiom);
            battle.FigthWithEnemy();
        }
        public void GoAcrossHardWay(Hero hero) { }
        public void FindTreasure(Hero hero) { }



    }
}
