﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.IO;
using System.Threading;
using WinServiceClientLib.ServiceReferenceCustomWCFService; 

namespace WinServiceClientLib
{

    /// <summary>
    /// Класс мониторит папку. И при помещении туда любого файла отправляет сообщение в службу
    /// Да вот такая вот долбанутая логика, "просто потому что" ! =)
    /// Еще раз.  Класс мониторит указанную папку, и как только там создается любой файл
    /// Она отправляет сообщение другой службе. С файлом никак не взаимодействуя болле, просто как повод для отработки))
    /// </summary>
    class MessageSender
    {
        MessageCollectorClient proxy; //!!!! MessageCollectorClient СОЗДАЕТСЯ НЕЯВНО, КОГДА ДОБАВЛЯЕШЬ ССЫЛКУ НА СЛУЖБУ. 
        //закулисами генерируется этот класс, который мы теперь используем как прокси для вызова методов из нужной службы!!!

        FileSystemWatcher watcher;
        bool enabled = true;
        string monitoredFolder = "F:\\Temp";
        string writePath = @"F:\MessagesFromWcfService.txt";

        public MessageSender()
        {
            proxy = new MessageCollectorClient();
            watcher = new FileSystemWatcher(monitoredFolder);
            // Add event handlers.
            watcher.Created += Watcher_Created;  // почитать про имена методов для событий
        }

        public void Start()
        {
            // Begin watching.
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {

            WcfServiceAnswerLogerd( proxy.Talk(CreateMessage()));
        }

        private void WcfServiceAnswerLogerd(string answer)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    streamWriter.WriteLine($"{DateTime.Now.ToString("F")} Принял ответ от WCF : '{answer}' \n");
                }
            }
            catch (IOException) { throw; }
            catch (Exception) { throw; }
        }
        private Message CreateMessage()
        {
            return new Message() {SenderName = "WinSRV", Description = "hello world", SendingTime = DateTime.Now };
            
        }
    }
}
