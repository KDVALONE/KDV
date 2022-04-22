using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IBasicMath" в коде и файле конфигурации.
    [ServiceContract]
    public interface IBasicMath
    {

        [OperationContract]
        int Add(int X, int Y);
    }

    
}
