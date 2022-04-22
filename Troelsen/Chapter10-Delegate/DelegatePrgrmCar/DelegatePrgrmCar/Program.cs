using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePrgrmCar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********* FunWithDelegate*********");

            Car c1 = new Car("SlugBug", 100, 10); //создаем обьект Car

            //Сообщаем какой обьект вызвать когда пожелает отправить сообщение
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            //Увеличить скорость, это иницализирует события
            Console.WriteLine("********* SpeedingUp *********");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n********* Message From  Car Object *********");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("******************\n");
        }

     }
    
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }


        private bool carIsDead;
        public Car() { }
       
        public Car(string name,int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        //Добавляем код работы с делегатлом.
        
        public delegate void CarEngineHandler(String msgForCaller); // Определяем тип делегата.

        private CarEngineHandler listOfHandlers; // определить переменную-член этого типа.

        public void RegisterWithCarEngine(CarEngineHandler methodToCall) //добавляем регистрационнй метод для вызывающего кода,
                                                                        //можно было бы и без него, но так лучше инкапсуляция.
        {
            listOfHandlers = methodToCall;
        }

        // Реализуем метод Accelerate() для обращения к списку деллегатов в подходящий момент.

        public void Accelerate(int delta)
        {
            // сообщение о полной поломке.
            if (carIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // сообщение повреждениях вызванных превышением скорости. машины
                if (10 == (MaxSpeed - CurrentSpeed)
                    && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrenntSpeed= {0}", CurrentSpeed);
            }
        }
    }
}


