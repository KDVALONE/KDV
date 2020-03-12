using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringFolderSevice
{
    class JsonReader
    {
        public static ServiceReference1.Cheque ReadJsonFile(string filePath)
        {
            String json;
            using (StreamReader reader = File.OpenText(filePath))
            {
                //TODO: залогировать этот момент, возможно добавить прекращение по токену, если за N-времени не прочтется файл
                //Console.WriteLine("Opened file.");
                //TODO: Сделать асинхронным ReadToEndФAsync
                json = reader.ReadToEnd();
                //Console.WriteLine("Contains: " + result);

            }


            //TODO: декомпозировать, вообще разделить метод на 2, чтение файла и десериалиазацию,+ TRY catch и лог 
            var deserializedFile = JsonConvert.DeserializeObject<ServiceReference1.Cheque>(json);
            return deserializedFile;
        }
    }
}
