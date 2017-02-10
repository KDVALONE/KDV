using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using Telegram;
using Telegram.Reqest;

namespace TelegramBotProgramm2
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //TelegramRequest Tr = new TelegramRequest(Settings.Default.Token);
            //Tr.ResponseRecived += Tr_ResponseRecived;
            //Thread thr = new Thread(Tr.GetUpdate);
            //thr.IsBackground = true;
            ///------------------Методы-------------------------
            Method m = new Method(Settings.Default.Token);
            //Console.WriteLine(m.Getme()); // выводим на консоль резултат getMe
            m.Getme();
            m.SendMessage("Ну привет", 115774926);
            ///-------------------------------------------------
        }

        private static void Tr_ResponseRecived(object sender, ParameterResponse e)
        {
            Console.WriteLine("{0}: {1}  chatId:{2} ", e.name, e.message, e.chatId);
        }
     }
}

