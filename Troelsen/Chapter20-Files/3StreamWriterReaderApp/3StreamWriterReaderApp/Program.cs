using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _3StreamWriterReaderApp
{   //Добавить текст с помощью StreamWriter
    //Прочитать текст с помошью StramReadr
    // Можно еще использовать StingReader и StringWriter, все почти так же но они могут
    // возвращать StringBuilder
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Fun With StreamWriter | StreamReader *********");
            // прочитать данные в файл
            using (StreamWriter writer = File.CreateText("remiders.text"))// так как путь не указан, файл будет в папке Debug
            {
                writer.WriteLine("Dont forget Mother Days in this year: "); //Console.WriteLine() - это оболочка для StreamWriter
                writer.WriteLine("Dont forget Mother Days in this year: ");
                writer.WriteLine("Dont forget these numbers: ");

                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + "");
                    //Вставить новую строку
                    writer.Write(writer.NewLine);
                }
            }
            // прочитать данные из файла
            Console.WriteLine("Here are you thouchts: \n");
            using (StreamReader sr = File.OpenText("remiders.text"))// так как путь не указан, файл будет в папке Debug
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
            Console.ReadLine();
        }
    }
}
