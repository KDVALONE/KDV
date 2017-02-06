using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SimpleJSON;
using System.Threading;

namespace TelegramBotProgramm2
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramRequest Tr = new TelegramRequest();
            Tr.ResponseRecived += Tr_ResponseRecived;
            Thread thr = new Thread(Tr.GetUpdate);
            thr.IsBackground = true;

            while (true)
            {
                Console.WriteLine("Фоновый поток работает");
                Thread.Sleep(500);

            }
            Tr.GetUpdate();
        }

        private static void Tr_ResponseRecived(object sender, ParameterResponse e)
        {
            Console.WriteLine("{0}:{1} chatId:{2}", e.name, e.message, e.chatId);
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
            public string Token = "249206099:AAHaLl2nxqwdmRR0mQZWJW5fsYLxL_mJnPU";
            int LastUpdateID = 0;

            public event Response ResponseRecived; //событие, при получение ответа
            ParameterResponse e = new ParameterResponse();

            public void GetUpdate()
            {
                while (true)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        string response = webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getUpdates?offset=" + (LastUpdateID + 1)); //переменная для ответа
                        if (response.Length <= 23)
                            continue;
                        var N = JSON.Parse(response);
                        foreach (JSONNode r in N["result"].AsArray)
                        {
                            LastUpdateID = r["update_id"].AsInt;
                            e.name = r["message"]["from"]["first_name"];
                            e.message = r["message"]["text"];
                            e.chatId = r["message"]["chat"]["id"];
                        }
                        ResponseRecived(this, e);
                    }
                }
           }
        }
    }
}
