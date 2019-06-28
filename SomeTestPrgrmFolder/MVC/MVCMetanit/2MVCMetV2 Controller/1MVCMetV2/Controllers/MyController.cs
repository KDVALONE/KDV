using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using _1MVCMetV2.Util;

namespace _1MVCMetV2.Controllers
{
    public class MyController : IController
    {/*
        При обращении к любому контроллеру система передает в него контекст запроса.
        В этот контекст запроса включается все: куки, отправленные данные форм, строки запроса, идентификационные данные пользователя и т.д.
        Реализация интерфейса IController позволяет получить этот контекст запроса в методе Execute через параметр RequestContext.
        В нашем случае мы получаем IP-адрес пользователя через свойство requestContext.HttpContext.Request.UserHostAddress.

        в реальности чаще оперируют более высокоуровневыми классами, как например класс Controller,
        поскольку он предоставляет более мощные средства для обработки запросов.
        И если при реализации интерфейса IController мы имеем дело с одним методом Execute,
        и все запросы к этому контроллеру, будут обрабатываться только одним методом,
        то при наследовании класса Controller мы можем создавать множество методов действий,
        которые будут отвечать за обработку входящих запросов, и возвращать различные результаты действий
     */
        public void Execute(RequestContext requestContext)
        {
            string ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");
        }
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }
        //Здесь предполагается, что в проекте есть папка Images,
        //в которой имеется изображение visualstudio.png. 
        //И тогда, если мы в браузере обратимся к этому действию, например, Home/GetImage, то сможем увидеть изображение.

        /*В реальности нам вряд ли потребуется часто создавать свои классы для обработки результата действия.
         * Фрейморк ASP.NET MVC предлагает нам богатую палитру классов результатов действий,
         * которые охватывают большинство, если не все возможные ситуации.*/
        public ActionResult GetImage()
        {
            string path = "../Images/visualstudio.png";
            return new ImageResult(path);
        }
    }
}