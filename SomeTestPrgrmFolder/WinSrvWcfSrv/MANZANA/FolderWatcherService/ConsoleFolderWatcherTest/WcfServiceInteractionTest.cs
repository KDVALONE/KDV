using ConsoleFolderWatcherTest.Logger;
using ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFolderWatcherTest
{
    class WcfServiceInteractionTest
    {
        ChequeServiceContractClient _client;
        int _lastChequeCount;

        public WcfServiceInteractionTest()
        {
            _lastChequeCount = GetChequesPackCount();
            _client = new ChequeServiceContractClient();
        }

        public void RunInteraction(string fileName, string filePath)
        {
             SendChequeToWcfServie(fileName, filePath);
             AddLastChequesFromWcfServiceToFile(_lastChequeCount); 
        }
        private void SendChequeToWcfServie(string fileName, string filePath)
        {

            if (ValidateFile(fileName))
            {
                try
                {
                    var deserializedCheque = InputFolderFileReaderTest.ReadFile(filePath);
                    if (deserializedCheque != null)
                    {
                        _client.SaveCheque(deserializedCheque);
                        InputFolderCleanerTest.FileToComplete(filePath, fileName);
                        MyLoggerTest.Log.Info($"File {filePath} was sending to WcfService");
                    }
                    else { InputFolderCleanerTest.FileToGarbage(filePath, fileName); }
                }
                catch (Exception ex)
                {
                    InputFolderCleanerTest.FileToGarbage(filePath, fileName);
                    MyLoggerTest.Log.Error($"Cant sending file {fileName} to WcfService  {ex}");
                }
            }
            else
            {
                InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            }
        }
        private void AddLastChequesFromWcfServiceToFile(int packCount)
        {
            MyLoggerTest.Log.Info($"Start added {packCount} last cheques from WcfService to file ");

            try
            {
                Cheque[] cheques = _client.GetChequesPack(packCount);
                if (cheques?.Length > 0)
                {
                    WriteCheques(cheques);
                }
                else
                {
                    MyLoggerTest.Log.Info("WcfService not returned last cheques ");
                }

            }
            catch (Exception ex)
            {
                MyLoggerTest.Log.Error($"Cant getting last cheques from wcf service {ex}");
            }
        }

        private bool ValidateFile(string fileName)
        {
            MyLoggerTest.Log.Info($"Start validate {fileName}");

            bool isValid;
            isValid = (fileName.Contains(".txt") && (fileName.Substring(fileName.Length - 4, 4)).Contains(".txt")) == true ? true : false;
            MyLoggerTest.Log.Info($"File {fileName} valid state = {isValid}");
            return isValid;
        }
        /// <summary>
        /// записывает последние чеки в файл. Сделал для наглядности
        /// </summary>
        private void WriteCheques(Cheque[] cheques)
        {
            string writePath;

            if (ConfigurationManager.AppSettings.Get("SavedChequesFolder") == "")
            {

                writePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"\SavedCheqes\LastCheqes.txt");
                MyLoggerTest.Log.Info($"Path to folder SavedCheqes not set in App.config, path to SavedCheqes folder {writePath}");
            }
            else
            {
                writePath = Path.Combine(ConfigurationManager.AppSettings.Get("SavedChequesFolder"), @"LastCheques.txt");
            }

            foreach (var e in cheques)
            {
                try
                {
                    DirectoryCheckerTest.CreateDirectoryIfNotExist(ConfigurationManager.AppSettings.Get("SavedChequesFolder"));

                    using (StreamWriter streamWriter = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        StringBuilder articles = new StringBuilder();
                        foreach (var val in e.Articles) { articles.Append(val + ';'); }
                        streamWriter.WriteLine($"Id = {e.Id}, Number = {e.Number}, Simm = {e.Summ}, Descount = {e.Discount},  Articles = {articles}");
                        MyLoggerTest.Log.Info($"Cheque added to file {writePath}");
                    }
                }
                catch (IOException ex) {  MyLoggerTest.Log.Error($"Cant write cheques collecttion, {ex}"); }
                catch (Exception ex)   {  MyLoggerTest.Log.Error($"Cant write cheques collecttion, {ex}"); }

            }
            MyLoggerTest.Log.Info($"Cheques pack added to file {writePath}");
        }
        private int GetChequesPackCount()
        {
            int chequePackCount;
            if (ConfigurationManager.AppSettings.Get("ChequesPackCount") == "")
            {
                chequePackCount = 4;
                MyLoggerTest.Log.Info($"Cheques Pack count not set in App.config, LastChequesCount = {4}");
            }
            else
            {
                chequePackCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ChequesPackCount"));
            }

            return chequePackCount;
        }
    }
}
