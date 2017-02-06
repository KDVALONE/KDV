using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace TelegramBotProgramm2
{
    class Program
    {
        public string Token = "249206099:AAHaLl2nxqwdmRR0mQZWJW5fsYLxL_mJnPU";
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
            
        }

    
    }
}
