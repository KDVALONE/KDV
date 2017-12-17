using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShesUnknownCypher
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] lines = { "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть если особенно упорно подойдешь к делу будет Трудно конечнО Код ведЬ не из простых очень ХОРОШИЙ код то у тебя все получится то у тебя все получится и я буДу Писать тЕбЕ еще чао" };
            string text = lines[0];
            Console.WriteLine(text);
            Console.ReadKey();
            //string text = "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ " 
            //              +"дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой "
            //              +"Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть "
            //              +"если особенно упорно подойдешь к делу "
            //              +"будет Трудно конечнО "
            //              +"Код ведЬ не из простых "
            //              +"очень ХОРОШИЙ код "
            //              +"то у тебя все получится "
            //              +"и я буДу Писать тЕбЕ еще "
            //              +"чао";

            //List<string> textList = new List<string>();
            //textList.AddRange(text.Split(' ')); 
            //textList.Reverse();
            //List<string> rezult = new List<string>();
            //foreach (string element in textList)
            //    {
            //        if (Char.IsUpper(element[0]))
            //            rezult.Add(element);
            //    }
            //Console.WriteLine(string.Join(" ", rezult.ToArray()));
            //Console.ReadKey();
        }

        //private static string DecodeMessage(string[] lines)
        //{

        //    return cypher;
        //}

    }
}
