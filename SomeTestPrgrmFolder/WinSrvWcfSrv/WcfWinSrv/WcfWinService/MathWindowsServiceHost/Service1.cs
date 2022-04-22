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
using WcfServiceLibrary;

namespace MathWindowsServiceHost
{
    public partial class MathWinService : ServiceBase
    {
        private ServiceHost serviceHost;
        public MathWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceHost?.Close();
            serviceHost = new ServiceHost(typeof(MathService), new Uri("http://loaclhost:8080/MathServiceLibrary"));

            serviceHost.AddDefaultEndpoints();
            serviceHost.Open();
 
        }

        protected override void OnStop()
        {
        }
    }
}
