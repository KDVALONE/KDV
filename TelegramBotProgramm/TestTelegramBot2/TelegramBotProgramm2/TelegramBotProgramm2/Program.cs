using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using 


namespace TelegramBotProgramm2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public delegate void Response(object sender, ParameterResponse e);
        public class ParameterResponse : EventArgs
        {
            public string name;
            public string message;
            public string chatId;
        }

        public class TelegramRequest
        {   
            // класс обработчик запросов
            public string Token;
            int LastUpdateId = 0;

            public event Response ResponseRecived; //событие, при получение ответа
            ParameterResponse e = new ParameterResponse();

            public void GetUpdate()
            {
                while(true)
                    string
            }
        }
    }
}
