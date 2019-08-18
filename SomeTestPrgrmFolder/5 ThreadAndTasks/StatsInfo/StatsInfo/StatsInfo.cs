using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StatsInfo
{/// <summary>
 /// string netstatResult = await Stats.Netstat("");
 /// string pathPingResult = await Stats.Pathping("-4 yandex.ru");
 /// string pcInfo = await Stats.GeneralPcInfo();
 /// </summary>
 /// 
    [TestFixture]
    public class StatsTests
    {
        [Test]
        public void NetstatShouldAtLeastWork()
        {
            var value = Stats.Netstat("").Result;
           
            Debugger.Break();

            //var result = await Stats.Netstat("");
            //Assert.IsNotEmpty(result);
        }
    }
}
