using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace N5SportsStore.Infrastructure
{
    /// <summary>
    /// класс расширяющих методов для кнопок
    /// </summary>
    public static class UrlExtensions
    {
        /// <summary>
        /// Метод расширения для класса HttpRequest для генерации URL по которому браузер будет возвращаться после обновления корзины
        /// принимая во внимание строку запроса, если она есть.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();
    }
}
