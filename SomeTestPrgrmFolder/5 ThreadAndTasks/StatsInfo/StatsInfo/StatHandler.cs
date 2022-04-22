using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsInfo
{
    class StatHandler
    {

        public static string RunProcess(ProcessStartInfo startInfo)
        {
            var netStart = Process.Start(startInfo);
            var val = netStart.StandardOutput.ReadToEnd();
            netStart.WaitForExit();
            return val;
        }
    }
}