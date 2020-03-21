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
            string garbageFolderPath = "";

            if (ConfigurationManager.AppSettings.Get("GarbageFolder") == "")
            {
                garbageFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"\FolderWatcherServiceTest\Garbage");
                MyLoggerTest.Log.Info($"Path to folder Garbage not set in App.config, path to Garbage folder {garbageFolderPath}");
            }
            else
            {
                garbageFolderPath = ConfigurationManager.AppSettings.Get("GarbageFolder");
            }

            DirectoryCheckerTest.CreateDirectoryIfNotExist(garbageFolderPath);

            //TODO: УБРАТЬ
            //if (!Directory.Exists(garbageFolderPath))
            //{
            //    try
            //    {
            //        Directory.CreateDirectory(garbageFolderPath);
            //        MyLoggerTest.Log.Info($"Directory {garbageFolderPath} created");
            //    }
            //    catch { MyLoggerTest.Log.Error($"Directory  {garbageFolderPath} was not created"); }
            //}

            MoveFile(fileFullPath, garbageFolderPath,fileName);

        }
        public static void FileToComplete(string fileFullPath, string fileName)
        {
            MyLoggerTest.Log.Info($"Sending file {fileName} to Complete folder");

            string completeFolderPath ="";

            if (ConfigurationManager.AppSettings.Get("CompleteFolder") == "")
            {

                completeFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"\FolderWatcherServiceTest\Complete");
                MyLoggerTest.Log.Info($"Path to folder Complete not set in App.config, path to Complete folder {completeFolderPath}");
            }
            else
            {
                completeFolderPath = ConfigurationManager.AppSettings.Get("CompleteFolder");
            }

            DirectoryCheckerTest.CreateDirectoryIfNotExist(completeFolderPath);

            //TODO:УБРАТЬ
            //if (!Directory.Exists(completeFolderPath))
            //{
            //    try
            //    {
            //        Directory.CreateDirectory(completeFolderPath);
            //        MyLoggerTest.Log.Info($"Directory {completeFolderPath} created");
            //    }
            //    catch
            //    {
            //        MyLoggerTest.Log.Error($"Directory { completeFolderPath} cant created");
            //    }

            //}
            MoveFile(fileFullPath,completeFolderPath, fileName);

        }
        private static void MoveFile(string currentPath, string destenationFolder, string fileName)
        {
            DirectoryInfo diSource = new DirectoryInfo(currentPath);
            DirectoryInfo diDestenation = new DirectoryInfo((Path.Combine(destenationFolder, fileName)));

            if (CheckIsFile(diSource))
            {
                try
                {
                    CopyFile(currentPath,destenationFolder,fileName);
                    MyLoggerTest.Log.Info($"File {currentPath} copy to {destenationFolder}");
                    File.Delete(currentPath);
                    MyLoggerTest.Log.Info($"File {currentPath} deleted");
                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"File {currentPath} cant moved to {diDestenation.FullName} {ex}"); }
            }
            else {

                try
                {
                    CopyDirectory(diSource, diDestenation);
                    MyLoggerTest.Log.Info($"Directory {currentPath} copy to {destenationFolder}");
                    Directory.Delete(currentPath, true);
                    MyLoggerTest.Log.Info($"Directory {currentPath} deleted");
                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"Directory {diSource.FullName} cant moved to {diDestenation.FullName} {ex}"); }
            }

           



            #region возможно убрать полностью так как есть DirectoryCopy
            /*
            string fileNameNew = fileName;
            
            while (File.Exists(Path.Combine(destenationFolder, fileNameNew)))
            {
                fileNameNew = fileNameNew.Replace(".", "-copy.");
                MyLoggerTest.Log.Info($"File {Path.Combine(destenationFolder, fileNameNew) }  existed, added suffix to file {Path.Combine(destenationFolder, fileNameNew)}");
            }

            string fullDestenationPath = Path.Combine(destenationFolder, fileNameNew); // TODO: Внимание, путь до файла, пока не проверяется копия ли

            if (File.Exists(currentPath))
            {
                try
                {
                    File.Copy(currentPath, fullDestenationPath);
                    MyLoggerTest.Log.Info($"File {currentPath} cop to {fullDestenationPath}");
                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"File {currentPath} cant copy to {fullDestenationPath} {ex}"); }
               
                try
                {
                    File.Delete(currentPath);
                    MyLoggerTest.Log.Info($"File {currentPath} deleted ");
                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"File {currentPath} cant deleted {ex}"); }

            }
            else
            {
                diSource = new DirectoryInfo(currentPath);
                diDestenation = new DirectoryInfo(fullDestenationPath);
                try
                {
                    CopyDirectory(diSource, diDestenation);
                    MyLoggerTest.Log.Info($"Directory {currentPath} copy to {fullDestenationPath}");
                    Directory.Delete(currentPath,true);
                    MyLoggerTest.Log.Info($"Directory {currentPath} deleted");

                }
                catch (Exception ex) { MyLoggerTest.Log.Error($"Directory {currentPath} cant moved to {fullDestenationPath} {ex}"); }
            }
            */
            #endregion
        }
        private static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {

            MyLoggerTest.Log.Info($"Method CopyDirectory start copy file {source.FullName} to {target.FullName} ");
       
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            int copyCount = 1;
            string createdDirectory = "";
            
            if (Directory.Exists(target.FullName) == false)
            {
                createdDirectory = target.FullName;
                Directory.CreateDirectory(createdDirectory);
            }
            else 
            {
                while (Directory.Exists(Path.Combine(target.FullName + copyCount.ToString())) == true)
                {
                    copyCount++;
                }
                createdDirectory = (Path.Combine(target.FullName + copyCount.ToString()));
                Directory.CreateDirectory(createdDirectory);
            }

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(createdDirectory,fi.Name ),true);
            }


            //рекурсия в случае воженных подпапок
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                              target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }

        private static bool CheckIsFile(DirectoryInfo item)
        {
            return File.Exists(item.FullName) ? true : false;
            
        }
        private static void CopyFile(string currentPath, string destenationPath,string fileName) 
        {
            var temp1 = currentPath.ToLower();//TODO Удалить
            var temp2 = (Path.Combine(destenationPath, fileName)).ToLower(); //TODO Удалить

            //TODO: незакончено
            if (currentPath.ToLower() == (Path.Combine(destenationPath,fileName)).ToLower())
            {
                return;
            }

            int copyCount = 1;

            if (File.Exists(Path.Combine(destenationPath, fileName)) == false)
            {
                File.Copy(currentPath,(Path.Combine(destenationPath, fileName)));
            }
            else
            {
                while (File.Exists(Path.Combine(destenationPath, (fileName.Replace(".", $"{copyCount}.")))) == true)
                {
                    copyCount++;
                }
                File.Copy(currentPath, (Path.Combine(destenationPath, (fileName.Replace(".", $"{copyCount}.")))));
                //TODO: наверное убрать
               // MyLoggerTest.Log.Info($"File {Path.Combine(destenationPath, fileName) }  existed, added suffix to file {copyCount}");
            }
        }
    }
    
}


