using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DelPrgm
{
    class Autobus
    {
        public int WorkHours { get; set; }
        public readonly int passagerMaxCount;
        public readonly int passagerMinCount;
        private int passagerInBus;
        public int PassagerInBus 
        {
            get { return passagerInBus; }
            set {

                if ((value + passagerInBus)> passagerMaxCount)
                {
                    //throw new Exception("Автобус переполнен!");
                    passagerInBus = passagerMaxCount;
                }
                else if ((passagerInBus - value) < passagerMinCount)
                {
                    // throw new Exception("Автобус управляется призраками.!. о_О");
                    passagerInBus = passagerMinCount;
                } else {
                    passagerInBus = value;
                }
                }
        }
        public bool BusIsWork { get; set; }
        Random rnd = new Random();
        public List<Station> road = new List<Station>();
        public Autobus()
        {
            passagerMaxCount = 16;
            passagerMinCount = 0;
            WorkHours = 8;
            PassagerInBus = passagerMinCount;
            BusIsWork = true;
            int stationCount = rnd.Next(20, 30);
            for (int i = 0; i <= stationCount; i++)
            {
                road.Add(new Station());
            }
        }

        public delegate void AutobusHandler(ref int PassagerInBus, Station station, int time);

        private AutobusHandler listOfEvents;

        public void RegisterOnEventList(AutobusHandler method)
        {
            listOfEvents += method; 
        }

        public void TakePassagires(ref int passagerInBus,Station station, int time)
        {
            int currentInBus = passagerInBus;
            passagerInBus += station.PassagerGetInCount;
            Console.WriteLine($"В {time} в отвтобусе было {currentInBus}на станции было { station.PassagerGetInCount } в автобусе стало {PassagerInBus} ");
        }
        public void TakeOFPassgires(ref int passagerInBus, Station station, int time)
        {
            int currentInBus = passagerInBus;
            passagerInBus -= station.PassagerTakeOfCount;
            Console.WriteLine($"В {time} в отвтобусе было {currentInBus} на на стацнию хотели сойти { station.PassagerTakeOfCount } в автобусе стало {PassagerInBus} ");
        }

        public void BusRide()
        {
            int stationNumber = 1;
            double currentHours = 0.0;
            RegisterOnEventList(TakePassagires);
            RegisterOnEventList(TakeOFPassgires);
            
            while (BusIsWork & (stationNumber <= road.Count))
            {
                listOfEvents.Invoke(ref passagerInBus,road[stationNumber],(int)(currentHours));
                WorkHours++;
                stationNumber++;
                currentHours += 0.5;
                BusIsWork = currentHours == 8 ? false:true;
            }
            Console.WriteLine("Рабочий день закончен");
        }
    }
}
