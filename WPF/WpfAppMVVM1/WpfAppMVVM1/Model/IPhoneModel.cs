using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVM1.Model
{
    interface IPhoneModel : INotifyPropertyChanged
    {
        string Name { get; set; }

    }
}
