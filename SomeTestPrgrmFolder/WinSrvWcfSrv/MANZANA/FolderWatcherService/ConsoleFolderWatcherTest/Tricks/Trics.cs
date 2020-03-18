using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFolderWatcherTest.Tricks
{
    /// <summary>
    /// Временный класс, сюда как в записную книжку всякое.
    /// </summary>
    
    [Obsolete]
    class Trics
    {
        /*
         Logger - не сохраняет в <user> АppData логи 
         Потому что это служба, у службы по умолчанию идет запуск не от пользователя а от системы, и путь он прописывает такой 
         C:\Windows\System32\config\systemprofile\AppData\Local
         вместо
         C:\Users\Dmitriy\AppData\Local

         По этому, по хорошему, нужно лог файла делать не в AppData у службы, а в ProgramData
         эта папка как раз и служит для обобщенных данныхпрограмм. Многие анитиврусы хранят там логи свои. Яндекс браузер опятьже.

        вот код
         var expectedFile = Path.Combine( 
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"test.txt");

        ---- 
        //TEST проверки пути к логу
            //var fileAppender = LogManager.GetRepository()
            //.GetAppenders().First(appender => appender is RollingFileAppender);
            //Debugger.Break();

        ---

         
         */



    }
}
