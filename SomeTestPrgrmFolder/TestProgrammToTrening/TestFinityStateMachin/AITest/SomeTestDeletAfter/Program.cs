using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeTestDeletAfter
{
    class Program
    {
        static void Main(string[] args)
        {



            Battle battle = new Battle();
            Hero hero = new Hero("Избранный");
            List<Enemy> enemyList = new List<Enemy>();//комент
            enemyList.Add(new Enemy("Рейдер1"));
            enemyList.Add(new Enemy("Рейдер2"));



            battle.StartBattle(hero, enemyList);

            Console.ReadKey();

        }
    }

    public class Battle
    {


        public void StartBattle(Hero hero, List<Enemy> enemyList)
        {
            List<Charackter> turn = new List<Charackter>();
            turn.Add(hero);
            foreach (Enemy e in enemyList)
                turn.Add(e);
            int turnPosition = 0; // кто ходит первый

            while (HeroIsLiving( turn[0] as Hero) && turn.Count > 1)
            {
                NextTurn(ref turn, ref turnPosition);
            }
            TheEnd(ref turn);
        }
        public bool HeroIsLiving(Hero hero)

        {
            bool value = false;
            return value = hero.Health >= 10 ? value = true : value = false;
        }

        public void NextTurn(ref List<Charackter> turn, ref int turnPosition)
        {
            if (turn[turnPosition] is Hero)
            { HeroTurn(ref turn); }
            else { EnemyTurn(ref turn, turnPosition); }

            turnPosition = (turnPosition == (turn.Count - 1))? (turnPosition = 0) : (turnPosition +=1 );
        }

        public void HeroTurn(ref List<Charackter> turn)
        {
            int targetIndex = (turn[0] as Hero).SelectEnemy(ref turn);
            (turn[0] as Hero).Atack(ref turn, targetIndex); // тип всегда передается по сылке, по этому если указать ref будет ошибка, при передаче всего List<> нужно передвать по ссылке, так как это коллекция, ну или ХЗ, нужно гуглить.
        }
        public void EnemyTurn(ref List<Charackter> turn, int myIndex)
        {
            (turn[myIndex] as Enemy).Atack(ref turn, myIndex);

        }

        public void TheEnd(ref List<Charackter> turn)
        {
            if (HeroIsLiving(turn[0] as Hero))
            { Console.WriteLine("\n Вы победили всех врагов, и спасли деревню от вымирания."); }
            else { Console.WriteLine("\n Ваша жизнь окончилась в пустошах... "); }
        }

    }
    public abstract class Charackter
    {
        public string Name;
        public int Health;
      
    }

    public class Hero : Charackter
    {

        public Hero(string name)
        {
            this.Name = name;
            this.Health = 100;
        }

        public void Atack(ref List<Charackter> enemy, int indexOfEnemy)
        {
            
            Console.WriteLine($" {enemy[0].Name} атакует {enemy[indexOfEnemy].Name} и наносит 20 урона");
            enemy[indexOfEnemy].Health -= 20;
            Console.WriteLine($" У {enemy[indexOfEnemy].Name} теперь {enemy[indexOfEnemy].Health} жизней \n");
            if (enemy[indexOfEnemy].Health <= 0)   {
                Thread.Sleep(500);
                Console.WriteLine($" Вы наносите {enemy[indexOfEnemy].Name} критический удар в глаз,\n {enemy[indexOfEnemy].Name} падает и умирает. \n");
                enemy.RemoveAt(indexOfEnemy);
            }
            
        }
        public int SelectEnemy(ref List<Charackter> enemy)
        {   
            Console.WriteLine($" Вы видите {enemy.Count - 1} врага(ов).\n");
            if (enemy.Count > 1)
            {
                Console.WriteLine($" Выбирите кого атаковать \n ");
                int indexOfenemy;
                foreach (Charackter e in enemy)
                {
                    if (e is Enemy)
                    { indexOfenemy = enemy.IndexOf(e); Console.WriteLine($" Для атаки на {e.Name} нажать {indexOfenemy} "); }
                }
                indexOfenemy = Convert.ToInt32(Console.ReadLine());
                return indexOfenemy;
            }
            else {
                Console.WriteLine(" Вы победили всех врагов!");
                return 0;
            }
        }

    }
    public class Enemy : Charackter
    {
        public Enemy(string name)
        {
            this.Name = name;
            this.Health = 100;
        }

        public void Atack(ref List<Charackter> hero, int myIndex) // переделать, чтоб враг мог атаковать и своих))Сделать индекс переменной
        {
            Thread.Sleep(500);
            Console.WriteLine($" {hero[myIndex].Name} атакует {hero[0].Name} и наносит 10 урона ");
            hero[0].Health -= 10;
            Console.WriteLine($" У {hero[0].Name} теперь {hero[0].Health} жизней ");
            if (hero[0].Health <= 0)
            {
                Thread.Sleep(500);
                Console.WriteLine($" {hero[myIndex].Name} наносит смертельный удар по {hero[0].Name}, Вы с глухим стоном падаете на землю.\n Вы пытаетесь кричать, но у Вас не хватает воздуха. Вы не можете  понять почему так вышло...");
            }
        }
    }
}

