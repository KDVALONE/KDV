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
            int ChatID = 115774926;
            //TelegramRequest Tr = new TelegramRequest(Settings.Default.Token);
            //Tr.ResponseRecived += Tr_ResponseRecived;
            //Thread thr = new Thread(Tr.GetUpdate);
            //thr.IsBackground = true;
            ///------------------Методы-------------------------
            Method m = new Method(Settings.Default.Token);
            //Console.WriteLine(m.Getme()); // выводим на консоль резултат getMe
            // m.Getme();
             m.SendMessage("Ну привет", ChatID); //отправим сообщение(текст отправки и ID чата)
            // m.ForwardMessage(ChatID, ChatID, 16);//перешлем сообщение(откуда,куда,ID сообщегия)
            // m.SendPhotoInputFile(ChatID, @"D:\GitLocalRepo\TelegramBotProgramm\TestTelegramBot2\TelegramBotProgramm2\TelegramBotProgramm2\1.jpg", "держи картинку" ); // отправляем картинку(куда ID, путь к картинке, и текст сопутствующий )
            // m.SendPhotoLink(ChatID, "http://vnokia.net/images/wallpaper/2014/wallpaper_480x800_14_images.jpg","передаем фото по ссылке"); //передаем фото по ссылке
            //m.SendDocumentInputFile(ChatID, @"D:\GitLocalRepo\TelegramBotProgramm\TestTelegramBot2\TelegramBotProgramm2\TelegramBotProgramm2\TestDocument.txt", "отправил документ по из корня");//отправил документ по из корня
            //m.SenDocumentLink(ChatID, @"http://korolev.clinic/wp-content/uploads/2016/12/Реализация-2-этапа-программы-социальная-ипотека-2016-2027.pdf", "отправил документ по из по ссылке из инета");//отправил документ по ссылке
            //SendChatAction(ChatID, Method.CahtAction.typing);// отображает действия бота в чате телеграмма
            Console.ReadLine();//нужно для потоковых методов.так как метод ждет пока не запуститься новый(уточнить)
            ///-------------------------------------------------
        }

        private static void Tr_ResponseRecived(object sender, ParameterResponse e)
        {
            Console.WriteLine("{0}: {1}  chatId:{2} ", e.name, e.message, e.chatId);
        }
     }
}

