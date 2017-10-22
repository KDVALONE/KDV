using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegramGlpiBot.Reqest;

namespace TelegramGlpiBot
{
    class Program
    {
        /// <summary>
        /// Основной класс программы
        /// Версия 0.0.0.3
        /// ---------Только демонстрация базового функционала
        /// TODO:
        /// Сделать методы асинхронными
        /// использовать Webhoock и SSL
        /// разобраться с авторизациией и аутентификацией(победть BlouwFish)
        /// Убрать нахрен левые парсеры JSON использовать библиотеки
        /// Переделать в апликейшн проет
        /// Добавить кнопки для комманд
        /// 
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {

            TelegramMethod telegramMetod = new TelegramMethod();
            telegramMetod.StartBot();


        }
       
    }
}
