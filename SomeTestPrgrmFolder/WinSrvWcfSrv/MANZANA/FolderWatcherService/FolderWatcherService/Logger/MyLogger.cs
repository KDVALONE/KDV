using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;


namespace FolderWatcherService.Logger
{
   
    public static class MyLogger
    { 
        // Фаил логов службы находиться в ProgramData\FolderWatcherSerivece\Log\Executing.log
      
        private static ILog log = LogManager.GetLogger("MyLogger");


        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
