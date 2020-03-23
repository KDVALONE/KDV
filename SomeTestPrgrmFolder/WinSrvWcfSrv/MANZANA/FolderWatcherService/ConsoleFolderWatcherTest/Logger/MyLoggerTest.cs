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
using System.Configuration;
using System.IO;

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
            GlobalContext.Properties["LogPath"] = GetLoggerPath();
            XmlConfigurator.Configure();
            //TODO:Удалить
            // TEST проверки пути к логу
            // обязательно Добавить type = log4net.Util.PatternStringв элемент File в app.config
            // <File type="log4net.Util.PatternString" value="App_Data/%property{LogName}" />
            //TEST проверки пути к логу
            //var fileAppender = LogManager.GetRepository()
            //.GetAppenders().First(appender => appender is RollingFileAppender);
            //var pathToLogger = ((log4net.Appender.FileAppender)fileAppender).File;
            //Console.WriteLine($"{pathToLogger}");
            //Debugger.Break();
        }
        private static string GetLoggerPath()
        {
            string loggerPath = "";

            if (ConfigurationManager.AppSettings.Get("LogFolder") == "")
            {
                loggerPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"\FolderWatcherServiceTest\Logs");
            }
            else
            {
                loggerPath = ConfigurationManager.AppSettings.Get("LogFolder");
            }

            return loggerPath;
        }
    }
}
