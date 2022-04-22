using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerEvent
{/// <summary>
/// Тестовая прога для тренировки евентов
/// Создать событие прием письма, подписать на него два класса
/// Fax и Printer каждый из которых будет его обрабатывать по своему
/// По Рихтеру
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Привет";
            MailMessanger mm = new MailMessanger();
            Fax fax = new Fax(mm);
            Printer printer = new Printer(mm);

            mm.SimilateNewMail(message);

            Console.ReadKey();
            

        }
    }


   

    // 1. Класс для хранения иноформации передоваемоего как параметр получателям уведомления о событиях
    class MessagnerEventArgs : EventArgs
    {
        public string Message;
        public MessagnerEventArgs(string msg)
        {
            Message = msg;
        }
    }

    // 2. Класс для для вызова события
    class MailMessanger
    {
        // 3. Обьявляем событие с типом обобщенного делегата EventHandler<T>, где Т это мой тип параметр унаследованый от EventArgs  
        public event EventHandler<MessagnerEventArgs> NewMail;

        // 4. Определяем метод ответсвенный за преобразование входных пользовательских данных о сообщении, в мой подходящий тип для параметров события
        public void SimilateNewMail(string message)
        {
            //Обьект для хранения информации которую нужно передать наблюдателям
            MessagnerEventArgs e = new MessagnerEventArgs(message);

            //оповещаем подписчиков события
            OnNewMail(e);
        }

        // 5. Обьявляем метод уведомляющий о событии подписчиков, принимающий мой тип параметров
        public void OnNewMail(MessagnerEventArgs e)
        {
            // проверяем есть ли подписчики на событие, если есть то вызываем его
            NewMail?.Invoke(this, e);
        }
       
        
    }

    // 6. класс подписчик на событие  
    class Fax
    {
        public Fax()
        {
            // определяем коструктор по умолчанию в ручную, так как далее конструктор с праметрами
        }
        public Fax(MailMessanger mm)
        {
            // подписываемся на событие в конструкторе, можно вывести в отдельный метод или вообще в отдельном классе сделать
            mm.NewMail += FaxMsg;
        }

        // Метот выполняющийся при наступлении события, должен удовлетворять типу делегата события,
        // тоесть EventHandler<T> , где Т это мой тип параметр унаследованый от EventArgs 
        public void FaxMsg(object sender, MessagnerEventArgs e)
        {
            Console.WriteLine($"Fax выводит сообщение: {e.Message}");
        }

    }
    // 7. класс подписчик на событие 
    class Printer
    {
        public Printer()
        {
            // определяем коструктор по умолчанию в ручную, так как далее конструктор с праметрами
        }
        public Printer(MailMessanger mm)
        {
            // подписываемся на событие в конструкторе, можно вывести в отдельный метод или вообще в отдельном классе сделать
            mm.NewMail += PrinterMsg;
        }

        // Метот выполняющийся при наступлении события, должен удовлетворять типу делегата события,
        // тоесть EventHandler<T> , где Т это мой тип параметр унаследованый от EventArgs 
        public void PrinterMsg(object sender, MessagnerEventArgs e)
        {
            Console.WriteLine($"Printer печатает сообщение: {e.Message}");
        }

    }

}
