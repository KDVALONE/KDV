using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using System.IO;

namespace EchoLib
{
   // WCF служба MessageCollectorService ,  
   // которая хоститься внутри Виндовой службы WCFWindowsMessageCollectorServiceSample,
   // получающая сообщения от Клиента, 
   // который будет тоже хоститься на собственной Виндовс службе и мониторить указаннаую папку забирать
   // от туда данные и отправлять на хост WCF.






    /// <summary>
    /// библиотечка которая будет службой WinService для службы WCF
    /// попытаюсь сделать взаимодействие (WinService) to (WinService with WCF)
    /// за основу взято вот это
    /// https://docs.microsoft.com/ru-ru/dotnet/api/system.runtime.serialization.datamemberattribute?view=netframework-4.8
    /// 
    /// ТАК, Логично, это библиотека, после компиляции, не создается .exe, у майков за основу взято консольное приложение,
    /// там создается. Короче, чтоб все было норм, нужен ХОСТ.
    /// Хост. Добавить консольное приложение в решение, по примерам из инета, связать их. Все будет бэнч
    /// /// </summary>



    [ServiceContract(Namespace = "http://MyApp.ServiceModel.Samples")]
    public interface IMessageCollector
    {

        /// <summary>
        /// будет принимать сообщение формата MESSAGE записывать в файл и отправлять ответ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [OperationContract]
         string Talk(Message message);

        [OperationContract]
        string SendAnsewer(Message message);

        [OperationContract]
        void CollectMessage (Message message);
    }

    [DataContract]
    public class Message
    {
        [DataMember]
        public string SenderName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime SendingTime { get; set; }
        
    }



    // Implement the IMessageCollector service contract in a service class.
    public class MessageCollectorService : IMessageCollector
    {
        string writePath = @"F:\WcfServiceMessageCollection.txt";

        public string Talk(Message message)
        {
            CollectMessage(message);
            return SendAnsewer(message);
        }

        public void CollectMessage(Message message)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    streamWriter.WriteLine($"{message.SendingTime.ToString("F")} " +
                                           $"from {message.SenderName } \n" +
                                           $"desc: {message.Description} \n");
                }
            }
            catch (IOException) { throw; }
            catch (Exception){ throw; }
            SendAnsewer(message);
        }

        public string SendAnsewer(Message message)
        {
            return $"Hello from WCF_SERVICE! Dear '{message.SenderName}', I got and collect your message to {writePath} !";
        }

       

    }

    /*эта штука не в библиотеке не совем должна ратать, вынести в HOST  WCF*/
    //public class MessageCollectorWindowsService : ServiceBase
    //{
    //    public ServiceHost serviceHost = null;
    //    public MessageCollectorWindowsService()
    //    {
    //        ServiceName = "WCFWindowsMessageCollectorServiceSample";
    //    }
  

    //    public static void Main()
    //    {
    //        ServiceBase.Run(new MessageCollectorWindowsService());
    //    }

    //    // Start the Windows service.
    //    protected override void OnStart(string[] args)
    //    {
    //        if (serviceHost != null)
    //        {
    //            serviceHost.Close();
    //        }

    //        // Create a ServiceHost for the CalculatorService type and 
    //        // provide the base address.
    //        serviceHost = new ServiceHost(typeof(MessageCollectorService));

    //        // Open the ServiceHostBase to create listeners and start 
    //        // listening for messages.
    //        serviceHost.Open();
    //    }

    //    protected override void OnStop()
    //    {
    //        if (serviceHost != null)
    //        {
    //            serviceHost.Close();
    //            serviceHost = null;
    //        }
    //    }
    //}

    // Provide the ProjectInstaller class which allows 
    // the service to be installed by the Installutil.exe tool



     /* Инсталлер службы, вынести в ХОСТ WCF        */
    //[RunInstaller(true)]
    //public class ProjectInstaller : Installer
    //{
    //    private ServiceProcessInstaller process;
    //    private ServiceInstaller service;

    //    public ProjectInstaller()
    //    {
    //        process = new ServiceProcessInstaller();
    //        process.Account = ServiceAccount.LocalSystem;
    //        service = new ServiceInstaller();
    //        service.ServiceName = "WCFWindowsMessageCollectorServiceSample";
    //        Installers.Add(process);
    //        Installers.Add(service);
    //    }
    //}
}
