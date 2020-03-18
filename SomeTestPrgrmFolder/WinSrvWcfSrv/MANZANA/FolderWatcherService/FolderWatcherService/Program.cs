using FolderWatcherService.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FolderWatcherService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            MyLogger.InitLogger();
            MyLogger.Log.Info("logger initialization");
            MyLogger.Log.Error($"ERROR TEST");//TODO: УБРАТЬ И ИЗМЕНИТЬ APP.Config
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new FolderWatcherService()
            };
            try
            {
                ServiceBase.Run(ServicesToRun);
                MyLogger.Log.Info("Start FolderWatcherService Service");
            }
            catch (Exception ex)
            {
                MyLogger.Log.Error($"Service not running {ex}");
            }
        }
    }
}
