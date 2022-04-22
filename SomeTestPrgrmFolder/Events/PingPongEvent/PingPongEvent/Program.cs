using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PingPongEvent
{/// <summary>
 /// Есть два класса, у каждого свой метод для вывода информации, 
 /// в обоих вызывается событие которое подписано на метод другого класса.
 /// 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            StartGame strgm = new StartGame();
            // запускаем бесконечный пинг понг
            strgm.Start();

            Console.ReadKey();
        }
    }

    // управляющий класс для игры
    class StartGame
    {
        Ping ping = new Ping();
        Pong pong = new Pong();
        int Count;

        public StartGame()
        {
            Random rnd = new Random();
            Count = rnd.Next(1, 100);
        }

        public void Start()
        {
            // метод подписывающий методы классов на события
            ReachedEvent();

            // случайный выбор подающего условный шарик, кто первый будет отрабатовать короче. При первом запуске программы.
            if (Count <= 50)
            {
                ping.ShowPing(pong,EventArgs.Empty);
            }else
            {
                pong.ShowPong(ping, EventArgs.Empty);
            }
        }

        // метод подписывающий методы классов на события
        public void ReachedEvent()
        {
            ping.PongEvent += pong.ShowPong;
            pong.PingEvent += ping.ShowPing;
        }


        
    }

    public class Ping
    {
        // обьявляем событие делегатного типа EventHandler
        public event EventHandler PongEvent; 

        public string Name = "Ping";

        // имполняющий метод, должен удовлетворять сигнатуре делегата, у EventHandler он (object sender, EventArgs e)
        public void ShowPing(object sender, EventArgs e)
        {
            //ждем пол секунды, чтоб не слишком быстро выводило инфу в консоль
            Thread.Sleep(500);
            // выводим имя класса исполняющегося метода
            Console.WriteLine(Name);
            // оповещаем класс Пинг он наступлении события, для его вызова обязательно передаем требуемые параметры,
            // так как фактических параметров мы ему ни каких не передаем, то в первом обязательном требуемом параметре мы передаем ссылку на вызывающий событие класс,
            // а вторым ставим заглушку  EventArgs.Empty, показывающую что вместо обьекта параметров типа EventArgs мы ничего не передаем.
            // передача параметров в метод всегда осуществляется посредством обертки их в тип наследумый от EventArgs и должно иметь наименование e.
            // так как мы ниче не передаем, то просто пишем EventArgs.Empty
            PongEvent?.Invoke(this,EventArgs.Empty);
        }
    }

    public class Pong
    {
        public event EventHandler PingEvent;
        public string Name = "Pong";

        // имполняющий метод, должен удовлетворять сигнатуре делегата, у EventHandler он (object sender, EventArgs e)
        public void ShowPong(object sender, EventArgs e)
        {
            //ждем пол секунды, чтоб не слишком быстро выводило инфу в консоль
            Thread.Sleep(500);
            // выводим имя класса исполняющегося метода
            Console.WriteLine(Name);
            // оповещаем класс Пинг он наступлении события, для его вызова обязательно передаем требуемые параметры,
            // так как фактических параметров мы ему ни каких не передаем, то в первом обязательном требуемом параметре мы передаем ссылку на вызывающий событие класс,
            // а вторым ставим заглушку  EventArgs.Empty, показывающую что вместо обьекта параметров типа EventArgs мы ничего не передаем.
            // передача параметров в метод всегда осуществляется посредством обертки их в тип наследумый от EventArgs и должно иметь наименование e.
            // так как мы ниче не передаем, то просто пишем EventArgs.Empty
            PingEvent?.Invoke(this, EventArgs.Empty);
        }
    }


   
}
