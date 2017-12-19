using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic;
using System.Management;

namespace TaskServerEndProgramm
{
    class Program
    {

        public static string killProc = "steam"; // название процесса для завершения.
        const int procentRamMax = 43 ; // максимальный процен загрузки RAM.

        static void Main(string[] args)
        {
              GetRAMv2();
            // KillProcess();
           
        }
        
        //public static  void GetRAMv1() {
        //    PerformanceCounter perfMemCounter = new PerformanceCounter("Memory", "Available MBytes");

        //    while (true)
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Memory Load: {0}%", perfMemCounter.NextValue());
        //    }
        //} // вариант 1, выдает кол-во исп. памяти в мегабайтах.
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
            Process.Start(@"F:\\Soft\\Steam\\Steam.exe");
        }
        }


    }



 
