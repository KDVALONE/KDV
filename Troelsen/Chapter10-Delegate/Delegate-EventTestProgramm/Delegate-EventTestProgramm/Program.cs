using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_EventTestProgramm
{/// <summary>
 /// Написать прогу используя делегаты и события.
 /// оттестить данные вещи.
 /// есть классы гангстер, ограбление, посетитель, и банк
 /// банк - хранит деньги, кладет и возвращает 
 /// Гангстре грабит банк забирая деньги себе
 /// Оргабление реализует налет на банк
 /// посетитель кладет случайное количество денего и уходит, или забирает случайное количество денего и уходит. 
 /// .
 /// </summary>


    //TODO: оргнизовать вызов связных методов через делегат и события, в них запихнуть,
    //ограбление банка грабителем и внесение/снятие денег посетителями. 

    //Организовать случайную последовательность вызова методов в классе посетителя, чтоб он мог или снять деньги или положиьт но случайно
    public delegate void BankVisitedDelegate(Bank bank);
    class Program
    {
        static void Main(string[] args)
        {
            
            Bank randomBank = new Bank();
            Gugnster randomGungster = new Gugnster(randomBank);
            List<Visitor> randomVisitors = new List<Visitor>();
                for (int i = 0; i <= 5; i++)
                     randomVisitors.Add(new Visitor(randomBank));
             
            foreach (Visitor vstr in randomVisitors)
            {
                VisitBank.RegisterEvent(vstr);
                VisitBank.StartEvent();
                //TODO реализовать вызов делегата - события.посещения банка
            }
            randomGungster.ViewGugngsterCash();
            randomGungster.VisitBank();
            randomGungster.HeistedBank();
            Console.ReadKey();
        }
    }

    public class Bank // банк
    {
        #region class properties and constructor
        public string BankName { get; set; }
        int money;
        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        public Bank(int Money = 1000)
        {
            Random rnd = new Random();
            money = Money;
            string[] bankNameArray =  new string[] { "Готем сити банк", "Нержавей-банк", "Черный банк", "Банкирский банкнотный банк" };
            BankName = bankNameArray[rnd.Next(0, bankNameArray.Length)];
        }
        #endregion 

        public void AddMoneyToBank(int money)
        {
            Money += money;
            Console.WriteLine($"Положили {money} рублей в банк, теперь в банке {Money} рублей ");
        }
        public int GetMoneyFromBank(int money)
        {
            if (money <= Money)
            {

                Money -= money;
                Console.WriteLine($"Забрали {money} рублей из банка, теперь в банке {Money} рублей ");
            }
            else {
                Console.WriteLine($"В банке всего {Money}, нельзя получить {money}");
                Money -= (money = Money);
                Console.WriteLine($"Забрали {money} рублей из банка, теперь в банке {Money} рублей ");
                 }
            return money;
        }

    }

    public static class VisitBank
    {
        public static event EventHandler BankVisit;

        public static void  RegisterEvent(Visitor vc)
            {
            BankVisit += vc.VisitorVisitBank;
            BankVisit += vc.VisitorTakeMoney;
            BankVisit += vc.VisitorGiveMoney;
            }
        public static void StartEvent(){ BankVisit?.Invoke(null,new EventArgs());  }
    }



    public static class Heist // реализует метод налет
        {

        public static  int GetAllBankMoney(Bank someBank)
        {
            int allMoney = someBank.GetMoneyFromBank(someBank.Money);
            Console.WriteLine($"{someBank.BankName} подвергся ограблению!");
            return allMoney;
        }
        }

    public class Visitor // посетитель, оставляет деньги  в банке, имеет рандомное кол во денег.
        {
        public event BankVisitedDelegate BankVisited;
        #region class properties and constructor
        string Name { get; set; } 
        public Bank VisitorsBank{ get; set; }
        int[] cash = { 500, 120, 300, 400, 200, 100, 300, 0 };
        string[] randomName = {"Джонни","Алекс","Морган","Стенфорд"};
        int Wallet { get; set; }
        static Random rnd = new Random();
        public Visitor(Bank bankToVisit)
        {
           
            VisitorsBank = bankToVisit; 
                     
            Wallet = rnd.Next(0, cash.Length);
            
            Name = randomName[rnd.Next(0, randomName.Length)];
        }
        #endregion

        public void VisitorVisitBank(object sender, EventArgs e)
        {
            Console.WriteLine($"{Name} пришел в  \"{VisitorsBank.BankName}\" , что бы положить {Wallet} рублей ");
        }
        public void VisitorGiveMoney(object sender, EventArgs e)
        {
            VisitorsBank.AddMoneyToBank(Wallet);
        }
        public void VisitorTakeMoney(object sender,EventArgs e)
        {
            Random rnd = new Random();
            Wallet += VisitorsBank.GetMoneyFromBank(cash[rnd.Next(0, cash.Length)]);
        }
        
    }

   

    class Gugnster // грабитель
        {
        
        #region  class properties and constructor
        public int Cash { get; set; }
        public Bank TargetBank { get; set; }

        public Gugnster(Bank bank)
        {
             this.TargetBank = bank;
        }
        #endregion

        public void VisitBank()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Грабитель пришел в \"{TargetBank.BankName}\", что бы ограбить его!");
        }
        public void HeistedBank()
        {
            Cash = Heist.GetAllBankMoney(TargetBank);
        }
        public void ViewGugngsterCash()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"У у грабителя на руках {Cash} рублей!");
        }
        }
    }

