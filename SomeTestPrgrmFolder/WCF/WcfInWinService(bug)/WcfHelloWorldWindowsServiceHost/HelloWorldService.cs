using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfInWinServiceLib;

namespace WcfHelloWorldWindowsServiceHost
{
    public partial class HelloWorldService : ServiceBase
    {
        private ServiceHost serviceHost;
        public HelloWorldService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceHost?.Close();
            serviceHost = new ServiceHost(typeof(WcfHelloWorldService), 
                new Uri("http://localhost:8080/WcfInWinServiceLib/"));
            serviceHost.AddDefaultEndpoints();
            serviceHost.Open();
        }
        protected override void OnStop()
        {
            serviceHost?.Close();
        }
    }
}
