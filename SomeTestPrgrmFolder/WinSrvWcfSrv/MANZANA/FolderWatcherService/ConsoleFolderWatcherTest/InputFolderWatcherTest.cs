using ConsoleFolderWatcherTest.Logger;
using ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleFolderWatcherTest
{


    class InputFolderWatcherTest
    {
        WcfServiceInteractionTest _wcfInteraction;
        FileSystemWatcher _watcher;
        bool _enabled;

        public InputFolderWatcherTest()
        {
            _enabled = true;
            _wcfInteraction = new WcfServiceInteractionTest();
            _watcher = new FileSystemWatcher(GetInputFolderPath());

            //  _watcher.Filter = "*.txt"; -- Можно было сделать так, чтоб работать только с .txt

            MyLoggerTest.Log.Info("Signed to event");
            _watcher.Deleted += Watcher_Deleted;
            _watcher.Created += Watcher_Created;

        }

        public void Start()
        {

            _watcher.EnableRaisingEvents = true;

            while (_enabled)
            {
                Thread.Sleep(1000);
            }
            MyLoggerTest.Log.Info("Service Started ");
        }
        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _enabled = false;
            MyLoggerTest.Log.Info("Service Stoped");
        }


        
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "created";
            string filePath = e.FullPath;
            string fileName = e.Name;
            MyLoggerTest.Log.Info($" Object {filePath} was {fileEvent}");

            _wcfInteraction.RunInteraction(fileName, filePath);

        }
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "deleted";
            string filePath = e.FullPath;
            MyLoggerTest.Log.Info($" Object {filePath} was {fileEvent}");
        }
        private string GetInputFolderPath()
        {
            string inputFolderPath = "";

            if (ConfigurationManager.AppSettings.Get("InputFolder") == "")
            {
                inputFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"\FolderWatcherServiceTest\Input");
                MyLoggerTest.Log.Info($"Path to folder Input not set in App.config, path to Input folder {inputFolderPath}");
            }
            else
            {
                inputFolderPath = ConfigurationManager.AppSettings.Get("InputFolder");
                DirectoryCheckerTest.CreateDirectoryIfNotExist(inputFolderPath);
            }
            return inputFolderPath;
        }

    }
}
