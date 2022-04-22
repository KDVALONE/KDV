using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DelPrgm
{
    /// <summary>
    /// Автобус на 15 мест
    /// Едет по астановкам. подбирает пассажиров. от 0 до 5 за раз.
    /// Высаживает на остановках по 1 - 6 за раз.
    /// Едет пока не закончиться смена. Смена 8 часов. Через 4 часа обед. Через 8 конец.
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            Autobus auto = new Autobus();
            auto.BusRide();
            Console.ReadKey();

        }
    }
}
