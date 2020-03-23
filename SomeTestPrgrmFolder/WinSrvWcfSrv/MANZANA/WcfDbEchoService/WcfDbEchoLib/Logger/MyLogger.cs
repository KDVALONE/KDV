using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;

namespace WcfDbEchoLib.Logger
{
    class MyLogger
    {
        private static ILog log = LogManager.GetLogger("MyLogger");

        
        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
           
            GlobalContext.Properties["LogPath"] = GetLoggerPath(); 
            XmlConfigurator.Configure();
            MyLogger.Log.Info($"LoggerIninting");

            //TODO: Убрать. Разобраться! Такое ощущение что код не вызывается!!!
            //TEST проверки пути к логу
            IAppender fileAppender = LogManager.GetRepository()
            .GetAppenders().First(appender => appender is RollingFileAppender);
            var pathToLogger = ((log4net.Appender.FileAppender)fileAppender).File;
            var writePath = @"F:\LoggerWCF.txt";

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(pathToLogger);
            }
            //Debugger.Break();
        }
        private static string  GetLoggerPath()
        {
            string loggerPath = "";

            if (ConfigurationManager.AppSettings.Get("WcfLogFolder") == "")
            {

                loggerPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"\WcfEchoService\Logs");
            }
            else
            {
                //TODO: не получает путь от ЛОГГЕРА!
                loggerPath = ConfigurationManager.AppSettings.Get("WcfLogFolder");
            }

            //TODO:удалить
            var tempKeys = ConfigurationManager.AppSettings.AllKeys;
            var tempConnString = ConfigurationManager.ConnectionStrings;
            var temp = 1;//чтоб точку останова поставить

            return loggerPath;
        }

    }
}
