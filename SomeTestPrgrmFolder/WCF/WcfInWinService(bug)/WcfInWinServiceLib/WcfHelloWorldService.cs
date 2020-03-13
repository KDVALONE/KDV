using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfInWinServiceLib
{
    public class WcfHelloWorldService : IWcfHelloWorldService
    {
        public string SaySomething(string word = "Basic Value")
        {
            System.Threading.Thread.Sleep(5000);
            return $"I say from WCF Service : {word}";
            
        }
    }
}
