using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "MathService" в коде и файле конфигурации.
    public class MathService : IBasicMath
    {
        public int Add(int x, int y)
        {
            System.Threading.Thread.Sleep(5000);
            return x + y;
        }
    }
}
