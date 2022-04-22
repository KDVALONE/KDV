using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringFolderSevice
{

    
    static class Program
    {
        //TODO: ВАЖНО, Добавить ссылку на службу WCF http://localhost:8000/GettingStarted/ChequeService/mex в Connetction Services в обозревателе
        //в момент когда она запущена! попобовать! - В данном случае он хочет связаться с 
        // F:\Программирование\Project\VS 2015-2017\SomeTestPrgrmFolder\WCF\GettingStarted2\
        // (ВНИМАНИЕ !) GettingStarted не подходит, так как там просто калькулятор, нужен GettingStarted2
        // там я не переимновел решени и сделал службу для Обращение к БД и работы с JSON

        /// <summary>
        /// Не работает
        /// (КОПИЯ BACKUP) - Более ранняя кажись. 
        /// Главная точка входа для приложения. 
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
