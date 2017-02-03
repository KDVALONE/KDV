using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleJSON;
using System.Collections.Specialized;
using System.Net;
using System.Threading;

namespace TelegrammBotTest
{
    class Program
    {
        public static string Token = @"249206099:AAHaLl2nxqwdmRR0mQZWJW5fsYLxL_mJnPU";
        public static int LastUpdateID = 0;


        static void Main(string[] args)
        {
            while (true)
            {
                GetUpdates();
                Thread.Sleep(1000);
            }

        }
        static void GetUpdates()
        {
            using (var webClient = new WebClient())
            {
                Console.WriteLine("Запрос обновление {0}", LastUpdateID + 1);

                string response = webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getUpdates" + "?offset=" + (LastUpdateID + 1));

                var N = JSON.Parse(response);

                foreach (JSONNode r in N["result"].AsArray)

                {
                    LastUpdateID = r["update_id"].AsInt;

                    Console.WriteLine("Пришло сообщение: {0}", r["message"]["text"]);

                    SendMessage("Я получил твоё сообщение", r["message"]["chat"]["id"].AsInt);
                }

            }
        }

        static void SendMessage(string message, int chatid)
        { 
            using (var webClient = new WebClient())
        {
            var pars = new NameValueCollection();

            pars.Add("text", message);
            pars.Add("chat_id", chatid.ToString());

            webClient.UploadValues("https://api.telegram.org/bot" + Token + "/sendMessage", pars);
        
            }
        }
        

    }
}
