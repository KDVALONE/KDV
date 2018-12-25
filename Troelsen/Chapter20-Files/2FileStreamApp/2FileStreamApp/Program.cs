using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace _2FileStreamApp
{
    // Записать простое текстовое обращение в новый файл.
    // FileSystemStream может работать только низкоуровневыми байтами, обьект  System.String придется закодировать

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** Fun with FileStream *********");
            using (FileStream fStream = File.Open(@"F:\myMessage.dat", FileMode.Create)) //получить обьект FileStream
            {
                //Закодировать строку в массив байтов
                string msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                // Записать byte[] в файл
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                // сбросить внутреннюю позицию потока(stream) 
                fStream.Position = 0;
                // прочитать byte[] из файла и вывести на консоль
                Console.WriteLine("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                   bytesFromFile[i] =(byte) fStream.ReadByte();
                   Console.WriteLine(bytesFromFile[i]);
                }
                //Вывести декодированное сообщение
                Console.WriteLine("\n Decoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
            Console.ReadKey();
        }
    }
}
