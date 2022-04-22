using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MetanintWinService
{
    /// <summary>
    /// Win Service мониторинга папки, по Metanint 
    /// Мониторит папку и логирует в самопальный лог
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MetanitService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
