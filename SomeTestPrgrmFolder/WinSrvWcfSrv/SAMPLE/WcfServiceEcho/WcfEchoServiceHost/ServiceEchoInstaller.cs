﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace WcfEchoServiceHost
{
    [RunInstaller(true)]
    public partial class ServiceEchoInstaller : System.Configuration.Install.Installer
    {
        public ServiceEchoInstaller()
        {
            //В конструкторе вызывается метод InitializeComponent(), который призван выполнять начальную инициализацию. 
            //Он определен в файле дизайнера Installer1.Designer.cs и по сути ничего не делает:
            // InitializeComponent(); // не понятно доконца почему не рекомендовано его использовать
            serviceProcessInstaller1 = new ServiceProcessInstaller();
            serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
            serviceInstaller1 = new ServiceInstaller();
            serviceInstaller1.ServiceName = "WCFWindowsMessageCollectorServiceSample";
            serviceInstaller1.DisplayName = "WCFWindowsMessageCollectorServiceSample";
            serviceInstaller1.Description = "WCF Service Hosted by Windows Service";
            serviceInstaller1.StartType = ServiceStartMode.Automatic;
            Installers.Add(serviceProcessInstaller1);
            Installers.Add(serviceInstaller1);
      
        }
    }
}
