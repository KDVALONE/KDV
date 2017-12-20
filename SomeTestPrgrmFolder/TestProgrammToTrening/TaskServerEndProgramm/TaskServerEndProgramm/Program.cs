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


        public static string killProc = "SQL Server Windows NT - 64 Bit"; // название процесса для завершения.
        const int procentRamMax = 80 ; // максимальный процен загрузки RAM.

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();//скрываем консоль
            ShowWindow(handle, SW_HIDE);

            GetRAMv2();//вызываем метод получения значения памяти.


        }
        



        
        public static void GetRAMv2() // вариант 2, выдает исп. кол-во памяти в процентах, поток
        {

            ManagementObjectSearcher ramMonitor =   new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");
           while (true)
           {
                Thread.Sleep(1000);
                foreach (ManagementObject objram in ramMonitor.Get())
            {
                ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);    //общая память ОЗУ
                ulong busyRam = totalRam - Convert.ToUInt64(objram["FreePhysicalMemory"]);         //занятная память = (total-free)
                ulong procentRamCurrent = (busyRam * 100) / totalRam; //вычисляем проценты занятой памяти
                    if (procentRamCurrent >= procentRamMax)
                    {
                        KillProcess();
                    }
             //   Console.ReadKey();
            }
           }
        }  
        public static void KillProcess() //выключает ненужный процесс 
        {
            //   создаем список процессов, ищем нужный и завершаем. 
            
            Process[] listprosecc = Process.GetProcesses();
            try
            {
                foreach (Process proc in Process.GetProcessesByName(killProc))
                    {
                        proc.Kill();
                        StartProcess();
                    }
             }
                    catch (Exception ex)
                     {
                      Console.WriteLine(ex.Message);
                     }
            }
        public static void StartProcess() // запускает выбранный процесс
        {
            Thread.Sleep(5000);
            Process.Start(@"C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\Binn\sqlservr.exe");
        }
        }


    }



 
