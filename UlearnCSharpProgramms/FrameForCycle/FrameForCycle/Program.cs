using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameForCycle
{
    class Program
    {
        static void Main(string[] args)
        {

            WriteTextWithBorder("Menu:");
            WriteTextWithBorder("");
            WriteTextWithBorder(" ");
            WriteTextWithBorder("Game Over!");
            WriteTextWithBorder("Select level:");
            Console.ReadKey();
        }

        private static void WriteTextWithBorder(string text)
        {
            string subtraction = "-";
            string stringFirstAndLast = "";
            string stringSecond = "| " + text + " |";
            for (int i = 0; i <= text.Length - 1; i++)
            {
                subtraction += "-";
            }
            stringFirstAndLast = "+-" + subtraction + "-+";
            Console.WriteLine("{0}\r\n{1}\r\n{0}", stringFirstAndLast, stringSecond);

        }
    }
}

