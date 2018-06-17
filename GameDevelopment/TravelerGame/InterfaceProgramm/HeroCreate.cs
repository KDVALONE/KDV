using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerGame
{
    class HeroCreate
    {
        public string CreatePlayerName()
        {
            string HeroFirstName;
            string substring = "";// первые 2 буквы имени
            string substring2 = "";// последние 2 буквы имени
            string substring3 = ""; // первые 3 буквы имени
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("- Иди сюда! Да, ты! Чего уставился? \n " +
            "Ты тугой или как? Работа нужна? Имя свое черкани вот тут и не спрашивай за чем. ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("'[протягивает мятый листок]'");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Введите ваше имя: ");
            Console.ForegroundColor = ConsoleColor.Green;
            HeroFirstName = Console.ReadLine();
            while (HeroFirstName.Length < 3)
            {
                Console.WriteLine("- Ты че обрубок совсем? Нет таких имен, ну или у нормальных нет! \n" +
                "Пиши полностью, или отчество там укажи, если папка был. ");
                HeroFirstName = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            substring = HeroFirstName.Substring(0, 2);
            substring2 = HeroFirstName.Substring(HeroFirstName.Length - 2, 2);
            substring3 = HeroFirstName.Substring(0, 3);
            Console.Write($"- Ты писать умеешь вообще? Хрен разберешь чего написал \n" +
            $"Так... {substring}... гхем... {substring3} че та, {substring2}... не понятно ни хрена. ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("'[Прищуривается и сплевывает] '");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{substring3}... {HeroFirstName}, вроде... Да похрен, сойдет. Короче, {HeroFirstName}, ты нанят.");

            return HeroFirstName;
        }
    }
}
