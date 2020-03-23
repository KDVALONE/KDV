using ConsoleFolderWatcherTest.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFolderWatcherTest
{
    static class InputFolderFileReaderTest
    {
        public static WcfEchoServiceReferenceTest.Cheque ReadFile(string filePath)
        {
            MyLoggerTest.Log.Info($"Start read file:{filePath}");

            string value;
            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    value = reader.ReadToEnd();
                }

                if (value == "") { MyLoggerTest.Log.Info($"File {filePath} is empty"); return null; }

                var deserializedFile = JsonConvert.DeserializeObject<WcfEchoServiceReferenceTest.Cheque>(value);
                return deserializedFile;
            }
            catch (Exception ex)
            {
                MyLoggerTest.Log.Error($"File cant read: {ex} ");
                return null;
            }
        }
    }

}
