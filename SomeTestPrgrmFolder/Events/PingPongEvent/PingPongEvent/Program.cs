using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongEvent
{/// <summary>
 /// Есть два класса, у каждого свой метод для вывода информации, 
 /// в обоих вызывается метод который связан на метод другого класса.
 /// 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    public class Ping
    {

        private event PingPongEventArgs PingPongEvent; 

        public string Name = "Ping";

        public void ShowPing()
        {

        }
    }

    public class Pong
    {
        public string Name = "Pong";

        public void ShowPong()
        {

        }
    }

    // нужен для сигнатуры параметров событий
    public class PingPongEventArgs
    {
        string Msg;

        public PingPongEventArgs(string msg)
        {
            Msg = msg;
        }
    }
    // подписчик на события
    public class PingPongHandler
    {
        PingPongEvent
        PingPongEvent

    }
}
