using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskServerEndProgramm
{
    class ServiceRestart
    {

        public void KillProcess() //выключает ненужный процесс 
        {
            //   создаем список процессов, ищем нужный и завершаем. 

            Process[] listprosecc = Process.GetProcesses();
            try
            {
                foreach (Process proc in Process.GetProcessesByName(Program.killProc))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartProcess() // запускает выбранный процесс
        {
            Thread.Sleep(5000);
            try
            {
                Process.Start(@"C:\\Program Files\\Microsoft SQL Server\\MSSQL11.SQLEXPRESS\\MSSQL\\Binn\\sqlservr.exe");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    }

