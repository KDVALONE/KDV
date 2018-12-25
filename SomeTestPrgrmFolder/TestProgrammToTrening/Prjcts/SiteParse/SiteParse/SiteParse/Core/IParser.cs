using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParse.Core
{
    interface IParser<T> where T : class // обобщенный интерфейс, те кто его реализуют смогут возвр. 
        // данные любого ссылочного типа
    {
        T Parse(IHtmlDocument document);
    }
}
