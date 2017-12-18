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
        public static string pathOfProcess = "F:\\Soft\\Steam\\Steam.exe"; // путь для старта процесса.
        public static string killProc = "steam"; // название процесса для зваершения.

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
                ulong procentRam = (busyRam * 100) / totalRam; //вычисляем проценты занятой памяти
                    if (procentRam >= 80)
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
                        Thread.Sleep(10000);
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
            Process.Start(@"{0}",pathOfProcess);
        }
        }


    }



 
