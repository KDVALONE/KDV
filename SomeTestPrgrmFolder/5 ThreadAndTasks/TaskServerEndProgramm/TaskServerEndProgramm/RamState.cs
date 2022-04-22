using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskServerEndProgramm
{
    class RamState
    {
        
        public void GetRAMv2(int procentRamMax) // вариант 2, выдает исп. кол-во памяти в процентах, поток
        {
            int procentRamMax1 = procentRamMax;
            ManagementObjectSearcher ramMonitor = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");
            while (true)
            {
                Thread.Sleep(1000);
                foreach (ManagementObject objram in ramMonitor.Get())
                {
                    ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);    //общая память ОЗУ
                    ulong busyRam = totalRam - Convert.ToUInt64(objram["FreePhysicalMemory"]);         //занятная память = (total-free)
                    ulong procentRamCurrent = (busyRam * 100) / totalRam; //вычисляем проценты занятой памяти
                    if ((int)procentRamCurrent >= procentRamMax1)
                    {
                        ServiceRestart sr = new ServiceRestart();
                        sr.KillProcess();
                        sr.StartProcess();
                   
                    }
                    //   Console.ReadKey();
                }
            }
        }
    }
}
