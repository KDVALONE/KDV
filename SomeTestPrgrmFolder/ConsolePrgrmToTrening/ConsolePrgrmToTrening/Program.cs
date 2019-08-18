using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;


namespace TestNameSpace
{

    class Program
    {
        public static void Main()
        {

            Console.WriteLine("MAIN Process count: " + Process.GetCurrentProcess().Threads.Count.ToString());
           /// Foo();
           PCinfo();
            Console.ReadKey();
        }

        public async static void Foo()
        {

            Task.Run(() => StartProc.StartPrc());


        }

        public static void PCinfo()
        {

            Console.WriteLine(Environment.UserDomainName);
            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.SystemDirectory);
            Console.WriteLine(Environment.);

            Console.WriteLine("Displaying operating system info....\n");
            //Create an object of ManagementObjectSearcher class and pass query as parameter.
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    Console.WriteLine("Operating System Name  :  " + managementObject["Caption"].ToString());   //Display operating system caption
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    Console.WriteLine("Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                }
                if (managementObject["CSDVersion"] != null)
                {
                    Console.WriteLine("Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString());     //Display operating system version.
                }
            }
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    Console.WriteLine(processor_name.GetValue("ProcessorNameString"));   //Display processor ingo.
                }
            }

        }


    }



    public class StartProc
    {
        delegate string GettedString();
        public static void StartPrc()
        {

            Process prc = new Process();
            prc.StartInfo.FileName = "cmd.exe";
            prc.StartInfo.UseShellExecute = false;
            prc.StartInfo.RedirectStandardOutput = true;
            prc.StartInfo.Arguments = @"/c ping ya.ru ";
            prc.Start();

            var output = prc.StandardOutput.ReadToEnd();

            prc.WaitForExit();

        }


    }
}