using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{/// <summary>
/// написать прогу для тренировки делегатов.
/// Есть танк. Едет по минному полю.
/// попадая на неверный квадрат он может:
/// выбить гусеницу. Может починить (до 3 раз)
/// Потерять одного из членов екипажа (до 3 раз)
/// 
/// доехать из точки А в точку Б
/// Выводить предвижение на экран.
/// 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();

            Console.ReadLine();
        }
    }
}
