using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectInfo1
{
    class Program
    {/// <summary>
     /// 
     /// </summary>

        static void Main(string[] args)
        {
            Console.WriteLine("*****Работа с файлом директ инфо.*******\n");
            Console.WriteLine("*****Показать директорию *******\n");
            ShowWindowsDirectInfo(@"C:\Windows");
            Console.WriteLine("*****Показать файлы *******\n");
            ShowFiles();
            Console.WriteLine("*****Создать директорию *******\n");
            MakeDir();
            Console.ReadKey();
        }
        static void ShowWindowsDirectInfo(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            Console.WriteLine($"FullName: {dir.FullName}");
            Console.WriteLine($"Name: {dir.Name}");
            Console.WriteLine($"Parent: {dir.Parent}");
            Console.WriteLine($"Creation: {dir.CreationTime}");
            Console.WriteLine($"Attributes: {dir.Attributes}");
            Console.WriteLine($"Root: {dir.Root}");
            Console.WriteLine($"*********************\n");
        }
        static void ShowFiles() // найти все файлы jpg в каталоге и подкаталогах
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            FileInfo [] imageFiles = dir.GetFiles("*.jpg",SearchOption.AllDirectories);
            Console.WriteLine($"Найдено файлов : {imageFiles.Length}");
            foreach (FileInfo f in imageFiles)
            { 
            Console.WriteLine($"Name: {f.Name}");
            Console.WriteLine($"File size{f.Length} *.jpg файлов");
            Console.WriteLine($"Creation: {f.CreationTime}");
            Console.WriteLine($"Attributes: {f.Attributes}");
            Console.WriteLine("*************\n");
            }

        }
        static void MakeDir()
        {
            string path = @"F:\";
            string newDirectory = @"CustomWallpaperDirectory";
            string newSubDirectory = @"CustomWallpaperDirectory2\Folder\FolderInner";
            DirectoryInfo dir = new DirectoryInfo(path);
            dir.CreateSubdirectory(newDirectory);
            dir.CreateSubdirectory(newSubDirectory);
            ShowWindowsDirectInfo(path + newDirectory);
        }// создать новую директорию

        }
}
