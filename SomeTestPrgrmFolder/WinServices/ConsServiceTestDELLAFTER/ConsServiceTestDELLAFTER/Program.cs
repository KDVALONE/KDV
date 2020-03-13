using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsServiceTestDELLAFTER.Models;
using Newtonsoft.Json;
using System.Configuration;
using ConsServiceTestDELLAFTER.Logger;
using ConsServiceTestDELLAFTER.ServiceReference1;

namespace ConsServiceTestDELLAFTER
{

    /// <summary>
    /// РАБОТАЕТ.
    /// Консольное приложение, так как писать тесты было влом, 
    /// нужно для тестов службы для задания в  MANZANA GROUP 
    /// делает считвание JSON 
    /// подключил сторонюю библиотеку LOG4NET для логироования. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            


            MyLogger.InitLogger();//инициализация - требуется один раз в начале
            MyLogger.Log.Info("Ура заработало!");// - пример для логирования простых действий
            MyLogger.Log.Error("Ошибочка вышла!");// - пример для логирования при ошибке

            WatcherFolder watcherFolder = new WatcherFolder();
            Console.WriteLine("Начало работы приложения мониторинга папки. \n" +
                $"Переместите в папку {ConfigurationManager.AppSettings.Get("InputFolder")} файл формата json соттветсующий модели Cheqe" +
                $" для его десериализации, \nили любой другой для для отражения логирования");// Удалить, это просто чтоб консолька не была пустой в начале
            watcherFolder.Start();

        }


    }
    public class WatcherFolder
    {
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

            //watcher.Filter = "*.txt";

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


        // создание файлов 
        //Использую как основную логику для отладки.
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
             // При создании файла
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);


            //попытка считать json
            var val = ReadJsonFile(filePath);

            //если файл не был json (вернул null) вывести в лог , и на экран, для тестовой налглядности

            if (val != null)
            {
                client.SaveCheque(val);
            }
            else {
                MyLogger.Log.Info($"Файл {filePath} не формата json");
                Console.WriteLine($"Файл {filePath} не формата json");
            }
            Debugger.Break();

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


       private static ServiceReference1.Cheque ReadJsonFile(string filePath)
        {
            String json;
            ServiceReference1.Cheque deserializedFile;
            using (StreamReader reader = File.OpenText(filePath))
            {
                //TODO: залогировать этот момент, возможно добавить прекращение по токену, если за N-времени не прочтется файл
                //Console.WriteLine("Opened file.");
                //TODO: Сделать асинхронным ReadToEndФAsync
                json =  reader.ReadToEnd();
                //Console.WriteLine("Contains: " + result);

            }


            //TODO: декомпозировать, вообще разделить метод на 2, чтение файла и десериалиазацию,+ TRY catch и лог 
            try
            {
                deserializedFile = JsonConvert.DeserializeObject<ServiceReference1.Cheque>(json);
                return deserializedFile; ;
            }
            catch (Exception ex)
            {
                MyLogger.Log.Error($"Ошибка {ex}!");
                return null;
            }
          
        }
    }
}
