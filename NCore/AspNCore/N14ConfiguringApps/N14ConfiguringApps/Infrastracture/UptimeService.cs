using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace N14ConfiguringApps.Infrastracture
{
    /// <summary>
    /// Сервис для отслеживания времени выполнения приложения
    /// </summary>
    public class UptimeService
    {
        private Stopwatch timer;
        
        public UptimeService() 
        {
            timer = Stopwatch.StartNew();
        }
        public long Uptime => timer.ElapsedMilliseconds;
    }
}
