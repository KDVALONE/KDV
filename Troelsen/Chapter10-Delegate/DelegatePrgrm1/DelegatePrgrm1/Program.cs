using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePrgrm1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********Delegate as event enablers***********\n");

            // создаем обьект Car
            Car c1 = new Car("SlugBug", 100, 10);
            // сообщаем какой методы вызвать когда он захочет отправить сообщение
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            
            // увеличить скорость( это инициализирует события)
            Console.WriteLine("**********Delegate as event enablers***********\n");
            Console.WriteLine("*****************Speed Up*************");
            for (int i = 0; i < 6; i++) ;
            c1.Accelerate(20);
            Console.ReadLine();
        }
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n****************Message From Car Object **********");
            Console.WriteLine("=> {0}",msg);
            Console.WriteLine("***********************\n");


        }
    }

    class Car
    {
        //данные состояния
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // исправен ли автомобибиль?
        private bool carIsDead;

        //конструктор класса
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        //определяем тип делегата
        public delegate void CarEngineHandler(string msgForCaller);
        //определить переменную член этого делегата.
        private CarEngineHandler listOfHandlers;
        //добавить регистрационную функцию для вызывающего кода.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers = methodToCall;
        }
        // реализовать метод Accelerate() для обращения к списку
        // вызовов делегата в подходящих обстоятельствах
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry car is broken...");

            }
            else
            {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("Current speed = {0}", CurrentSpeed);
            }
        }


    }
}
