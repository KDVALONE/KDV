using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic;
using System.Management;
using System.Runtime.InteropServices;

namespace TaskServerEndProgramm
{
    class Program
    {
        //скрываем консоль
        
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        //скрываем консоль конец


        public const string killProc = "SQL Server Windows NT - 64 Bit"; // название процесса для завершения.
        public static int procentRamMax = 80; // максимальный процен загрузки RAM.

        static void Main(string[] args)
        {
          
            var handle = GetConsoleWindow();//скрываем консоль
            ShowWindow(handle, SW_HIDE);

            
            RamState rm = new RamState();

            rm.GetRAMv2(procentRamMax); //вызываем метод получения значения памяти.
        }
            
        }


    }



 
