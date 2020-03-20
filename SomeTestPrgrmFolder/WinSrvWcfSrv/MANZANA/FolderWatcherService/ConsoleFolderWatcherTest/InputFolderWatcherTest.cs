using ConsoleFolderWatcherTest.Logger;
using ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            _watcher.Changed += Watcher_Changed;
            _watcher.Renamed += Watcher_Renamed;

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


        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            string fileName = e.Name;
            MyLoggerTest.Log.Info($" файл {filePath} был {fileEvent}");

            _wcfInteraction.RunInteraction(fileName, filePath);

            #region вывел в отдельыне методы

            //if (ValidateFile(fileName))
            //{

            //    try
            //    {
            //        WcfEchoServiceReferenceTest.Cheque deserializedCheque = InputFolderFileReaderTest.ReadFile(filePath);
            //        if (deserializedCheque != null)
            //        {
            //            MyLoggerTest.Log.Info($"Deserialization success");
            //            //_client.SaveCheque(deserializedCheque);
            //            InputFolderCleanerTest.FileToComplete(filePath, fileName);
            //        }
            //        else {
            //            MyLoggerTest.Log.Info($"Deserialization failure");
            //            InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            //        }

            //    }
            //    catch
            //    {
            //        MyLoggerTest.Log.Error($"Cant read file {fileName}");
            //        InputFolderCleanerTest.FileToGarbage(filePath, fileName);

            //    }

            //    //  var lastCheque = _client.GetLastCheques(lastChequeCount);
            //    //  WriteLastCheques(lastCheque);
            //}
            //else
            //{
            //    InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            //}
            #endregion
        }
        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            string fileName = e.Name;
            MyLoggerTest.Log.Info($" файл {filePath} был {fileEvent}");

            _wcfInteraction.RunInteraction(fileName, filePath);
            #region вывел в отдельыне методы

            //if (ValidateFile(fileName))
            //{

            //    try
            //    {
            //        var deserializedCheque = InputFolderFileReaderTest.ReadFile(filePath);
            //        //  _client.SaveCheque(deserializedCheque);
            //        InputFolderCleanerTest.FileToComplete(filePath, fileName);
            //    }
            //    catch
            //    {
            //        InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            //        MyLoggerTest.Log.Error($"Cant read file {fileName}");
            //    }

            //    //var lastCheque = _client.GetLastCheques(lastChequeCount);
            //    //WriteLastCheques(lastCheque);
            //}
            //else
            //{
            //    InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            //}
            #endregion 
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            string fileName = e.Name;
            MyLoggerTest.Log.Info($" файл {filePath} был {fileEvent}");

            _wcfInteraction.RunInteraction(fileName, filePath);
            #region В метод убрать
            //if (ValidateFile(fileName))
            //{

            //    try
            //    {
            //        var deserializedCheque = InputFolderFileReaderTest.ReadFile(filePath);
            //        // _client.SaveCheque(deserializedCheque);
            //        InputFolderCleanerTest.FileToComplete(filePath, fileName);
            //    }
            //    catch
            //    {

            //        InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            //        MyLoggerTest.Log.Error($"Cant read file {fileName}");
            //    }

            //    // var lastCheque = _client.GetLastCheques(lastChequeCount);
            //    // WriteLastCheques(lastCheque);
            //}
            //else
            //{
            //    InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            //}
            #endregion
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален";
            string filePath = e.FullPath;
            MyLoggerTest.Log.Info($" файл {filePath} был {fileEvent}");

        }

        private string GetInputFolderPath()
        {
            string inputFolderPath;
            if (ConfigurationManager.AppSettings.Get("InputFolder") == "")
            {
                inputFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"\FolderWatcherServiceTest\Input");
                MyLoggerTest.Log.Info($"Path to folder Input not set in App.config, path to Input folder {inputFolderPath}");
            }
            else
            {
                inputFolderPath = Path.Combine(ConfigurationManager.AppSettings.Get("InputFolder"), @"\FolderWatcherServiceTest\Input");
            }
            return inputFolderPath;
        }

    }
}
