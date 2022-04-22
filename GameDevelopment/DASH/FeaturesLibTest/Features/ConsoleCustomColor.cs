using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FeaturesLibTest
{

    #region Памятка по фону и тексту
    /*
     Вам нужно установить флаг ENABLE_VIRTUAL_TERMINAL_PROCESSING (0x4) с помощью SetConsoleMode
     Используйте последовательности:

    "\x1b[48;5;" + s + "m" - установить цвет фона по индексу в таблице (0-255)
    "\x1b[38;5;" + s + "m" - установить цвет переднего плана по индексу в таблице (0-255)
    "\x1b[48;2;" + r + ";" + g + ";" + b + "m" - установить фон значениями r, g, b
    "\x1b[38;2;" + r + ";" + g + ";" + b + "m" - установить передний план значениями r, g, b

     */
    #endregion
    /// <summary>
    /// класс для вывода разных цветов на консоль
    /// </summary>
    public class ConsoleCustomColor
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        public void ShowTextCustomColor(int colorNumber = 0, string text ="color=")
        {
            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
            SetConsoleMode(handle, mode | 0x4);
            string sufix="";
            for (colorNumber = 0; colorNumber < 255; colorNumber++)
            {
                if (text == "color=") { sufix = colorNumber.ToString(); }

                Console.Write("\x1b[38;5;" + colorNumber + $"m{text}{sufix} ");
            }

            Console.ReadLine();
        }
    }
}
