using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParse.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; } // хранит url требуемой страници

        string Prefix { get; set; } 

        int StartPoint { get; set; }// с какой страници будем парсить данные

        int EndPoint { get; set; } // конечный индекс страницы для парсеров

    }
}
