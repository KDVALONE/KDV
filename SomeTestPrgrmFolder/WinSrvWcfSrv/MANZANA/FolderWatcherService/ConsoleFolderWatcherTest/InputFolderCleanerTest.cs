using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using ConsoleFolderWatcherTest.Logger;

namespace ConsoleFolderWatcherTest
{
    class InputFolderCleanerTest
    {
        public static void FileToGarbage(string fileFullPath, string fileName)
        {
            MyLoggerTest.Log.Info($"Sending file {fileName} to Grabage folder");
            string garbageFolderPath;

            if (ConfigurationManager.AppSettings.Get("GarbageFolder") == "")
            {
                garbageFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"\FolderWatcherServiceTest\Garbage");
                MyLoggerTest.Log.Info($"Path to folder Garbage not set in App.config, path to Garbage folder {garbageFolderPath}");
            }
            else
            {
                garbageFolderPath = Path.Combine(ConfigurationManager.AppSettings.Get("GarbageFolder"), @"\FolderWatcherServiceTest\Garbage");
            }

            if (!Directory.Exists(garbageFolderPath))
            {

                try
                {
                    Directory.CreateDirectory(garbageFolderPath);
                    MyLoggerTest.Log.Info($"Directory {garbageFolderPath} created");
                }
                catch { MyLoggerTest.Log.Error($"Directory  {garbageFolderPath} was not created"); }
            }

            MoveFile(fileFullPath, Path.Combine(garbageFolderPath, fileName));

        }
        public static void FileToComplete(string fileFullPath, string fileName)
        {

            string completeFolderPath;

            if (ConfigurationManager.AppSettings.Get("CompleteFolder") == "")
            {

                completeFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"\FolderWatcherServiceTest\Complete");
                MyLoggerTest.Log.Info($"Path to folder Complete not set in App.config, path to Complete folder {completeFolderPath}");
            }
            else
            {
                completeFolderPath = Path.Combine(ConfigurationManager.AppSettings.Get("CompleteFolder"), @"\FolderWatcherServiceTest\Complete");
            }

            if (!Directory.Exists(completeFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(completeFolderPath);
                    MyLoggerTest.Log.Info($"Directory {completeFolderPath} created");
                }
                catch
                {
                    MyLoggerTest.Log.Error($"Directory { completeFolderPath} cant created");
                }

                MoveFile(fileFullPath, Path.Combine(completeFolderPath, fileName));

            }

        }
        private static void MoveFile(string currentPath, string destenationPath)
        {

            DirectoryInfo diSource = new DirectoryInfo(currentPath);
            DirectoryInfo diDestenation = new DirectoryInfo(destenationPath);

            if (File.Exists(currentPath))
            {

                try
                {
                    File.Copy(currentPath, destenationPath);
                    //  File.Move(currentPath, destenationPath); TODO:УБРАТЬ
                    MyLoggerTest.Log.Info($"File {currentPath} cop to {destenationPath}");
                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"File {currentPath} cant copy to {destenationPath} {ex}"); }
                try
                {
                    File.Delete(currentPath);
                    //  File.Move(currentPath, destenationPath);
                    MyLoggerTest.Log.Info($"File {currentPath} deleted ");
                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"File {currentPath} cant deleted {ex}"); }
            }else{
                try
                {
                    CopyDirectory(diSource, diDestenation);
                    MyLoggerTest.Log.Info($"Directory {currentPath} copy to {destenationPath}");
                    Directory.Delete(currentPath,true);
                    MyLoggerTest.Log.Info($"Directory {currentPath} deleted");

                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"Directory {currentPath} cant moved to {destenationPath} {ex}"); }
            }

           

        }
        private static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }
            
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            
            foreach (FileInfo fi in source.GetFiles())
            {
              fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }


            //рекурсия в случае воженных подпапок
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                              target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
    
}


