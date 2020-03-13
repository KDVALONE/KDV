using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using MonitoringFolderSevice.Models;
using Newtonsoft.Json;
using System.Configuration;
using MonitoringFolderSevice.MyLogger;

namespace MonitoringFolderSevice
{
   public class WatcherFolder
    {
        //TODO: Добавить ссылку на службу WCF, но сначала нужно запустить ее в нутри собственной службы виндовс 
        ChequeServiceClient client = new ChequeServiceClient();
        FileSystemWatcher watcher;
        object obj = new object(); // для LOCK
        bool enabled = true;
        public WatcherFolder()
        {

            //TODO: Указать пути к GARBAGE и комплит, проверять если не созданы то сосздавать. логировать
            var inputFolderPath = ConfigurationManager.AppSettings.Get("InputFolder");
            // ConfigurationManager.AppSettings.Set("DestFolder", @"C:\Моя_Папка2"); // это для метод для задания собственного пути
            watcher = new FileSystemWatcher(inputFolderPath);

            watcher.Filter = "*.txt";

            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            //TODO: Возможно либо удалить либо переписать на событийную модель, к примеру сделать 
            // enable  observable collection <bool> ну или тип того
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            RecordEntry(fileEvent, filePath);
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);

            //TODO: Вот тут подумать над реализацией, и выносе в другой класс
            var val = JsonReader.ReadJsonFile(filePath);
            client.SaveCheque(val);
            Debugger.Break();

        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            // TODO: Разобрать lock.  Чтобы не было гонки ресурсов за файл templog.txt, 
            // в который вносятся записи об изменениях, процедура записи блокируется заглушкой lock(obj).

            Console.WriteLine("{0} файл {1} был {2}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent);

            //lock (obj)
            //{
            //    using (StreamWriter writer = new StreamWriter("F:\\templog.txt", true))
            //    {



            //        //writer.WriteLine(String.Format("{0} файл {1} был {2}",
            //        //       DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
            //        //writer.Flush();
            //    }
            //}
        }


        
    }
}
