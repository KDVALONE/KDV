using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace EventPrgrm2
{/// <summary>
 /// 0- с 10:13 до 11:00 
 /// 1- В очередной раз оттестить события, по памяти.
 /// 2- Есть машина, когда бензин есть у нее включается двигатель и она едет,
 ///    когда его нет она выключает двигатель и останавливается.
 /// 3- Порядок обьявления события: делегат(сендер, событие), событие. регистрация события,
 ///    изменения методов для событий, запуск   
 /// 
 /// </summary>
 /// 
 //TODO: Прелопатить код для работы с EVENT,  не охуевать и не здаваться


    //  public delegate void ActionHandler(object sender, ActionEventAgrs e);

    class Program
    {
        static void Main(string[] args)
        {
            Barrel brl = new Barrel();
            Car car = new Car();
            Engine eng = new Engine();


            Action.Drivered(eng, car, brl);

            Console.WriteLine("\n Все приехали!");
            Console.ReadKey();
        }
    }



    public class Car
    {
        public int Fuel { get; set; }
        public int Speed { get; set; }

        public Car()
        {
            Fuel = 0;
            Speed = 0;
        }
    }
    public class Engine
    {
        public bool EngineIsStarted { get; set; }
        public Engine()
        {
            EngineIsStarted = false;

        }
    }
    public static class Action // действие с машиной
    {


        public static void Drivered(Engine engine, Car car, Barrel barrel)
        {
            while (barrel.FuelCount > 0)
            {
                if (car.Fuel <= 0)
                {
                    car.Speed = 0;
                    FuelingGas(car, barrel);
                }
            while (UseEngine(engine, car))
            {
                CarAcselerated(car, engine);
            }
            }
            Console.WriteLine("На заправках закончилось горючее, заправляться больше нечем.");
        } // главный метод запуска поездки

        public static bool UseEngine(Engine engine, Car car)
        {
              if (car.Fuel > 0)
                 engine.EngineIsStarted = true;
            else { engine.EngineIsStarted = false; }
            return engine.EngineIsStarted;
        } // включить двигатель.
        public static void FuelingGas(Car car, Barrel barrel)
        {
            if (barrel.FuelCount>0)
          {
                while (car.Fuel < 120 && barrel.FuelCount > 0)
                { 
            Thread.Sleep(1000);
            car.Fuel+=10;
            barrel.FuelCount-=10;
            Console.WriteLine($"Маина заправлена, в ней {car.Fuel} литр(ов), в бочке теперь {barrel.FuelCount} литров(ов)");
                }
            }
            else Console.WriteLine($"Машину нечем заправлять");
        } // заправить машину
        public static void CarAcselerated(Car car, Engine engine) // ускорение
        {
            if (engine.EngineIsStarted && car.Fuel > 0 && car.Speed < 50)
            {
                Thread.Sleep(1000);
                car.Speed += 10;
                car.Fuel -= 10;
                Console.WriteLine($"Скорость машины {car.Speed} км/ч, в баке {car.Fuel} литров ");
            }
            else if (engine.EngineIsStarted && car.Fuel > 0 && car.Speed == 50)
            {
                Thread.Sleep(1000);
                car.Fuel -= 10;
                Console.WriteLine($"Скорость машины {car.Speed} км/ч, в баке {car.Fuel} литров ");
            } 

            }
        }
    }
   

    public class Barrel
    {
        private int fuelCount;
        public int FuelCount
        {
            get
            {
                if (fuelCount > 0) { return fuelCount; }
                else { Console.WriteLine("Кончилось тополиво в бочке"); return 0; }
            }
            set { fuelCount = value; }
        }

        public Barrel()
        {
            FuelCount = 300;
        }
    }

    public class ActionEventAgrs : EventArgs // класс для делегата
    {
        public int Fuel;
        public ActionEventAgrs(int fuel)
        {
            this.Fuel = fuel;
        }

    }


