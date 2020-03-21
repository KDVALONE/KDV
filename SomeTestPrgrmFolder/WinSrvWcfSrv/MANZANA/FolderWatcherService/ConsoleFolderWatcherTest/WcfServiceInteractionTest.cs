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
            _lastChequeCount = GetLastChequesCount();
            _client = new ChequeServiceContractClient();
        }
        
        public void RunInteraction(string fileName, string filePath)
        {
            SendChequeToWcfServie(fileName, filePath);
           // AddLastChequesFromWcfServiceToFile(_lastChequeCount); //TODO: ВКЛЮЧИТЬ
        }
        private void SendChequeToWcfServie(string fileName, string filePath)
        {
            if (ValidateFile(fileName))
            {

                try
                {
                    var deserializedCheque = InputFolderFileReaderTest.ReadFile(filePath);
                    _client.SaveCheque(deserializedCheque);
                    InputFolderCleanerTest.FileToComplete(filePath, fileName);
                    MyLoggerTest.Log.Info($" file {filePath} was sending to WcfService");
                }
                catch (Exception ex)
                {

                    InputFolderCleanerTest.FileToGarbage(filePath, fileName);
                    MyLoggerTest.Log.Error($"Cant read file {fileName} {ex}");
                }

            }
            else
            {
                InputFolderCleanerTest.FileToGarbage(filePath, fileName);
            }
        }
        private void AddLastChequesFromWcfServiceToFile(int lastChequesCount) 
        {
            try
            {
                Cheque[] lastCheques = _client.GetLastCheques(lastChequesCount);
                if (lastCheques?.Length > 0)
                {
                    WriteLastCheques(lastCheques);
                }
                else
                {

                    MyLoggerTest.Log.Info("WcfService not returned last cheques ");
                }

            }
            catch (Exception ex)
            {
                MyLoggerTest.Log.Error($"Cant geting last cheques from wcf service {ex}");
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
        private void WriteLastCheques(Cheque[] cheques)
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
                    using (StreamWriter streamWriter = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        StringBuilder articles = new StringBuilder();
                        foreach (var val in e.Articles) { articles.Append(val + ';'); }
                        streamWriter.WriteLine($"Id = {e.Id}, Number = {e.Number}, Simm = {e.Summ}, Descount = {e.Discount}, Articles = {e.Articles[0]}, Articles = {articles}");
                        MyLoggerTest.Log.Info($"Cheque added to file {writePath}");
                    }
                }
                catch (IOException ex)
                {
                    MyLoggerTest.Log.Error($"Cant write cheques collecttion, {ex}");
                }
                catch (Exception ex)
                {
                    MyLoggerTest.Log.Error($"Cant write cheques collecttion, {ex}");
                }

            }
            MyLoggerTest.Log.Info($"LastCheques added to file {writePath}");
        }
        private int GetLastChequesCount()
        {
            int lastChequeCount;
            if (ConfigurationManager.AppSettings.Get("LastChequesCount") == "")
            {
                lastChequeCount = 4;
                MyLoggerTest.Log.Info($"LastChequesCount not set in App.config, LastChequesCount = {4}");
            }
            else
            {
                lastChequeCount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("LastChequesCount"));
            }

            return lastChequeCount;
        }
    }
}
