using ConsoleFolderWatcherTest.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFolderWatcherTest
{
    /// <summary>
    /// Класс проверяет задана ли дериктория в файле app.config и если нет то создает ее
    /// </summary>
    public static class DirectoryCheckerTest
    {
        public static void CreateDirectoryIfNotExist(string folderPath) {

            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                    MyLoggerTest.Log.Info($"Directory {folderPath} created");
                }
                catch
                {
                    MyLoggerTest.Log.Error($"Directory {folderPath} cant created");
                }
            }

        }
    }
}
