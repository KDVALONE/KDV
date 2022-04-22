using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace StatsInfo
    {
        public static class Stats
        {

            public  static async Task<string> Netstat(string parameters)
            {
                var startInfo = new ProcessStartInfo
            {
                FileName = "netstat.exe",
                Arguments = parameters,
                UseShellExecute = false,
                CreateNoWindow = true,//true to HIDE
                RedirectStandardOutput = true,

            };
                var value = await Task.Run(() => StatHandler.RunProcess(startInfo));
                return value;
            }

        public static async Task<string> Pathping(string parameters)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "pathping.exe",
                Arguments = parameters,
                UseShellExecute = false,
                CreateNoWindow = true,//true to HIDE
                RedirectStandardOutput = true,

            };
            var value = await Task.Run(() => StatHandler.RunProcess(startInfo));
            return value;
        }

        public static async Task<string> PcInfo(string parameters)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "pathping.exe",
                Arguments = parameters,
                UseShellExecute = false,
                CreateNoWindow = true,//true to HIDE
                RedirectStandardOutput = true,

            };
          
            var value = await Task.Run(() => StatHandler.RunProcess(startInfo));
            return value;
        }
       

        class ProcessClass
        {
            public ProcessClass()
            {
                this.ProcessToExec = new Process();
            }

            private Process ProcessToExec
            {
                get;
                set;
            }
            private bool EventHandled
            {
                get;
                set;
            }

            // Print a file with any known extension. 
            public void Execute(string fileName, string args)
            {
                this.EventHandled = false;

                try
                {
                    // Start a process to print a file and raise an event when done.
                    this.ProcessToExec.StartInfo.FileName = fileName;
                    this.ProcessToExec.StartInfo.Arguments = args;
                    this.ProcessToExec.StartInfo.RedirectStandardOutput = true;
                    this.ProcessToExec.StartInfo.RedirectStandardInput = true;
                    this.ProcessToExec.StartInfo.UseShellExecute = true;
                    this.ProcessToExec.EnableRaisingEvents = true;
                    this.ProcessToExec.Exited += new EventHandler(processToExec_Exited);
                    this.ProcessToExec.Start();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred trying to execute \"{0}\":" + Environment.NewLine + ex.Message, fileName);
                    return;
                }

                // Wait for Exited event
                while (!this.EventHandled)
                {
                    string _out = this.ProcessToExec.StandardOutput.ReadLine();
                    Console.WriteLine(_out);
                }
                this.ProcessToExec.StandardInput.WriteLine("info variables");
            }

            // Handle Exited event
            private void processToExec_Exited(object sender, System.EventArgs e)
            {

                this.EventHandled = true;
            }

            public static void Main(string[] args)
            {
                if (args.Length <= 0)
                {
                    Console.WriteLine("Enter a file name.");
                    return;
                }

                // Create the process
                ProcessClass myProcess = new ProcessClass();
                myProcess.Execute(args[0], (args.Length == 2 ? args[1] : string.Empty));
            }
        }



    }
    }
