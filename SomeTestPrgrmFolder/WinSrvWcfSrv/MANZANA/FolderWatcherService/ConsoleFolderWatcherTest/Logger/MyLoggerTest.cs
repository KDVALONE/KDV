using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFolderWatcherTest.Logger;
using log4net;
using log4net.Appender;
using log4net.Config;
using System.Diagnostics;

namespace ConsoleFolderWatcherTest.Logger
{
    class MyLoggerTest
    {
    
        private static ILog log = LogManager.GetLogger("MyLoggerTest");


        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
            //// TEST проверки пути к логу
            //var fileAppender = LogManager.GetRepository()
            //.GetAppenders().First(appender => appender is RollingFileAppender);
            //Debugger.Break();
        }

    }
}
