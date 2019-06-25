using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteParse.Core.Habra
{
    class HabraParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list  = new List<string>();
            // получаем из документа все теги <a>, которые содержаться в классах и содержат значение post_title_link
            // в итоге получаем коллекцию заголовков статей
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("post__title_link"));

            foreach (var item in items)
            {
                list.Add(item.TextContent); // так как item : IElement есть свойство TextContent, в нем содержиться заголовок статьи
            }

            return list.ToArray();
        }
    }
}
