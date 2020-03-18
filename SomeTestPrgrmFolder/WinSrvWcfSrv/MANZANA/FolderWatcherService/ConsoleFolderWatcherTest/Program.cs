using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFolderWatcherTest.Logger;
using log4net;

namespace ConsoleFolderWatcherTest
{
    /// <summary>
    /// Протестировать: 
    /// 0   - Логер в тесте работает. Возможно, относительные пути в app.Config не дают создать файлы логов в службе
    /// 0.1 - Поменять пути и создавать папку в App.Data, так не вариант, сделал в ProgrammData
    /// 1   - Наблюдение за папкой
    /// 2   - создание директорий в АppData
    /// 3   - перемещение файлов
    /// 4   - удаление файлов
    /// 5   - валидацию файлов
    /// 6   - чтение Json
    /// 7   - передачу прочтеного Json файла службе.
    /// 
    /// ----
    /// останавливается, потому что не может обратиться к WCF сервису, так как он не запущен.getLastChecks() посмотреть потом 
    /// </summary>
    /// 

        //шпора для записи файл
    //using (StreamWriter streamWriter = new StreamWriter(writePath, true, System.Text.Encoding.Default))
    //            {
    //                streamWriter.WriteLine($" ");
    //            }


class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("START CONSOLE TEST \n");
           
           
            MyLoggerTest.InitLogger();//инициализация - требуется один раз в начале
            MyLoggerTest.Log.Info("Ура заработало!");
            MyLoggerTest.Log.Error("Ошибочка вышла!");
            Console.ReadKey();
        }
    }
}
