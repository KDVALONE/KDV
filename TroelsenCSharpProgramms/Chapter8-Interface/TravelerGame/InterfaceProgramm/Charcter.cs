using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TravelerGame
{
    abstract class Character //Класс персонажа с характеристиками TODO: отрефакотрить по SOLID
    {
        Random rnd = new Random();

        private int helth; // жизни персонажа
        private int endurence;
        public List<Item> backpack = new List<Item>();

        public string Name { get; set; }
        public string NickName { get; set; }
        public int Helth // возможно стоит передавать ссылку на вызыванный класс в Die
            {
            get {  return this.helth;  }
            set {
                if ((value + helth) > 100)
                    this.helth = 100;
                if ((value + helth) <= 0)
                    Die();
                else
                    this.helth = value;
                }
            } 
        public int Endurence
            {
            get { return this.endurence; }
            set
            {
                if ((value + this.endurence) > 100)
                    this.endurence = 100;
                else
                    this.endurence = value;
            }
            }

        public bool Living { get; set; }  
        public bool Visible { get; set; }

        public Character() { }
        public Character(string charackterFirstName)
                       : this(charackterFirstName,"")
        {
        }
        public Character(string charackterFirstName, string charackterNickName) // главный конструктор, оттестить момент.
        {

            if (charackterNickName == "") {
                this.Name = charackterFirstName;
                this.NickName = charackterNickName; }           
            else { charackterFirstName = EnemyNameGenerator.GetEnemyName();
                charackterNickName = EnemyNameGenerator.GetEnemyNickName(); }

            Helth = 100;
            Endurence = 100;
            Visible = true;
            Living = true;

        }




        void Rest(Item tonic) // отдых для восполнения выносливости
        {
            Thread.Sleep(1000);
            Helth += (int)tonic.ItemProperties();
            Console.WriteLine($"{this.Name} воспользовался {tonic.Name}, его бодрость восстановилась на {Endurence} процентов от нормы.");
        }
        void Healing(Item medicine) // восстановление жизни
        {
            Thread.Sleep(1000);
            Helth += (int)medicine.ItemProperties();
            Console.WriteLine($"{this.Name} воспользовался {medicine.Name}, уровень его здоровья составляет {Helth}процентов от нормы.");
        }
        void Die()
        {
            this.Living = false;
        }



    }
}
