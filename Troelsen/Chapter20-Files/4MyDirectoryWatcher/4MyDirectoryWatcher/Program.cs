using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4MyDirectoryWatcher
{/// <summary>
/// Слежение за файлом.
/// на диске F создается каталог МyFolder
/// в нем файлы .txt, при измении в каталоге, выводит сообщения что произошло
/// 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Amazing File App ******\n");
            //Создаем директорию
            Directory.CreateDirectory(@"F:\МyFolder\");
            //установить путь к каталогу наблюдения
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"F:\МyFolder";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // указать цели наблюдения
            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
            // следить только за текстовыми файлами
            watcher.Filter =  "*.txt";
            
            //добавить обработчики событий
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created+= new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            //начать наблюдение за каталогом.
            watcher.EnableRaisingEvents = true;
            // ожидать комманду пользователя на завершение программы
            Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.Read() != 'q');
        }
        //Следующие 2 обработчика событий, выводят сообщения о модификации файла
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            //Сообщение о действии изменения/создания/удаления файла
            Console.WriteLine($"File {e.FullPath} {e.ChangeType} !");
        }
        static void OnRenamed(object source, RenamedEventArgs e)
        {
            //Сообщение о действии переименования файла
            Console.WriteLine($"File {e.OldFullPath} {e.FullPath} !");
        }
    }
}
