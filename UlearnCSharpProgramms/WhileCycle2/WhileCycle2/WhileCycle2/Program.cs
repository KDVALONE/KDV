using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileCycle2
{
    class Program
    {

        //Враги вставили в начало каждого полезного текста целую кучу бесполезных пробельных символов!
        //Вася смог справиться с ситуацией, когда такой пробел был один, но продвинуться дальше ему не удается.Помогите ему.

        //на решение с помощью цикла я забил, так как легко, нужна проверка посимвольно на while (char.IsWhiteSpace(text[0]))

        static void Main(string[] args)
        {
            Console.WriteLine(RemoveStartSpaces("a"));
            Console.WriteLine(RemoveStartSpaces(" b"));
            Console.WriteLine(RemoveStartSpaces(" cd"));
            Console.WriteLine(RemoveStartSpaces(" efg"));
            Console.WriteLine(RemoveStartSpaces(" text"));
            Console.WriteLine(RemoveStartSpaces(" two words"));
            Console.WriteLine(RemoveStartSpaces("  two spaces"));
            Console.WriteLine(RemoveStartSpaces("	tabs"));
            Console.WriteLine(RemoveStartSpaces("		two	tabs"));
            Console.WriteLine(RemoveStartSpaces("                             many spaces"));
            Console.WriteLine(RemoveStartSpaces("               "));
            Console.WriteLine(RemoveStartSpaces("\n\r line breaks are spaces too"));
            Console.ReadKey();
    
    }
        public static string RemoveStartSpaces(string text)
        {
            //решение с сайта. можно вообще одной строкой. return text.TrimStart();
            //while (char.IsWhiteSpace(text[0]))
            //{
            //    text = text.Substring(1);
            //    if (text.Length == 0) break;
            //}
            //return text;

            //  решение при помощи метода trim()

            string result = "";
            char[] badSymbols = {' ','\r','\n'};

            result = text.Trim(badSymbols);
            return result = result.Trim();
        }

    }
}
