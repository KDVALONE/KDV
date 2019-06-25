using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteParse
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// Парсер сайта HABRAHABR
        /// По уроку https://www.youtube.com/watch?v=nz4ZCr6pnXA&t=201s
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
