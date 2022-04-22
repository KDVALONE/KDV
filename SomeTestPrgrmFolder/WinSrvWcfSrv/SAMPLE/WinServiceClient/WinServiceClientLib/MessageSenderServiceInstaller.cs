using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;


namespace WinServiceClientLib
{
    [RunInstaller(true)]
    public partial class MessageSenderServiceInstaller : Installer
    {
        ServiceInstaller serviceInstaller1;
        ServiceProcessInstaller serviceProcessInstaller1;
        public MessageSenderServiceInstaller()
        {
            //В конструкторе вызывается метод InitializeComponent(), который призван выполнять начальную инициализацию. 
            //Он определен в файле дизайнера Installer1.Designer.cs и по сути ничего не делает:
            //InitializeComponent(); 
            serviceProcessInstaller1 = new ServiceProcessInstaller();
            serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
            serviceInstaller1 = new ServiceInstaller();
            serviceInstaller1.ServiceName = "MessageSenderClientSercvice";
            serviceInstaller1.DisplayName = "MessageSenderClientSercvice";
            serviceInstaller1.Description = "Windows Service as client to sending messages to WCFWindowsMessageCollectorServiceSample ";
            serviceInstaller1.StartType = ServiceStartMode.Automatic;
            Installers.Add(serviceProcessInstaller1);
            Installers.Add(serviceInstaller1);
        }
    }
}
