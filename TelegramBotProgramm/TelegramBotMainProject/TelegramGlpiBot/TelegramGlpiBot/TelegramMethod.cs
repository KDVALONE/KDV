using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramGlpiBot.SimpleJSON;
using TelegramGlpiBot.Reqest;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace TelegramGlpiBot
{   /// <summary>
    ///TelegramMethod - класс для работы с отправкой ссобщений в телеграм
    /// </summary>
    class TelegramMethod
    {
        string Token { get; set; }
        string Link { get; set; }
        string CmdSting { get; set; }

        SqlMethod sqlMethod = new SqlMethod();

        public TelegramMethod()
        {
            Token = Settings.Default.Token;
            Link = Settings.Default.Link;
        }


        public void ForwardMessage(int fromChatId, int ChatId, int messageId)  //пересылает сообщение
        {
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection pars = new NameValueCollection();
                pars.Add("chat_id", ChatId.ToString());
                pars.Add("from_chat_id", fromChatId.ToString());
                pars.Add("message_id", messageId.ToString());
                webClient.UploadValues(Link + Token + "/forwardMessage", pars);
            }
        }

        public void StartBot()  //запуск бота
        {
            TelegramRequest telegramRequest = new TelegramRequest(Settings.Default.Token);
            TelegramMethod telegramMetod = new TelegramMethod();

            new Thread(telegramRequest.GetUpdate).Start(); // запускаем поток с методом GetUpdate,для прослушки сообщений
            telegramRequest.ResponseRecived += telegramMetod.GetComand;

        }

        public void GetComand(object sender, ParameterResponse e) //работа командами
        {
            //TODO:
            //переделать на enum и switch/case

            //Console.WriteLine("{0}: {1}  chatId:{2} ", e.name, e.message, e.chatId);  вывод в консоль иныфы с информацией о последнем ммообщении

            if (e.message == "/hello")
            {
            ///TODO:
            ///вставить метод
            }
            if (e.message == "/gettickets")
            {
             ///TODO:
             ///Вставить метод
             
             //ниже корректная реализация, работать с ней, сверху вызов ложного показного метода, убрать.
             //CmdSting = "SELECT name FROM glpi_tickets WHERE id = '1'";
             //sqlMethod.GetTickets(CmdSting);
            }
            if (e.message == "/getticketsall")
            {             
                //TODO:
                //Втавить метод

                //ниже корректная реализация, работать с ней, сверху вызов ложного показного метода, убрать.
                //CmdSting = "SELECT name FROM glpi_tickets WHERE id = '1'";
                //sqlMethod.GetTickets(CmdSting);
            }

        }

        public void FalseGetticket(int ChatId)
        {
           
            using (WebClient webClient = new WebClient())
            {
                string message = "Текущая заявка: \n 13666 \n п1 Центральный корпус, Болдорева М.Ю. \n  Установка ПК в Взрослой поликлинике \n Установить Пк в кабинете №15, Старый забрать. ";
                NameValueCollection pars = new NameValueCollection();
                pars.Add("chat_id", ChatId.ToString());
                pars.Add("text", message);
                webClient.UploadValues(Link + Token + "/sendMessage", pars);

            }
        } //отправляет сообщение
          // Console.WriteLine("Ваши заявки: /n 13666 \n п1 Центральный корпус, Болдорева М.Ю. /n  Установка ПК в Взрослой поликлинике /n Установить Пк в кабинете №15, Старый забрать. "); }
        public void FalseHello(int ChatId)
        {

            using (WebClient webClient = new WebClient())
            {
                string message = "Начинаем работу с ботом GLPI";
                NameValueCollection pars = new NameValueCollection();
                pars.Add("chat_id", ChatId.ToString());
                pars.Add("text", message);
                webClient.UploadValues(Link + Token + "/sendMessage", pars);

            }
        }
        public void FalseGetticketAll(int ChatId)
        {

            using (WebClient webClient = new WebClient())
            {
                string message = "Ваши заявк: \n 13666 \n п1 \n Центральный корпус\n Болдорева М.Ю. \n  Установка ПК в Взрослой поликлинике \n Установить Пк в кабинете №15, Старый забрать. "+
                                    "\n\n 13667 \n п1 \n Центральный корпус \n Багров Д.С. \n  Протяжка сети \n Протянуть сеть  в кб 12.";
                NameValueCollection pars = new NameValueCollection();
                pars.Add("chat_id", ChatId.ToString());
                pars.Add("text", message);
                webClient.UploadValues(Link + Token + "/sendMessage", pars);

            }
        }
    }
  
    }


