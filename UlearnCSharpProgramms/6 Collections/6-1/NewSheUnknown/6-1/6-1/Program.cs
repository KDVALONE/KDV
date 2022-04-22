using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _6_1
{/*
решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ
дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой
Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть
если особенно упорно подойдешь к делу

будет Трудно конечнО
Код ведЬ не из простых
очень ХОРОШИЙ код
то у тебя все получится
и я буДу Писать тЕбЕ еще

чао
*/
    #region old version


    //List<string> result = new List<string>();
    //foreach (string line in lines)
    //{
    //    string[] someText = line.Split(' ');
    //    foreach (string element in someText)
    //        if (element != "" && Char.IsUpper(element[0]))
    //            result.Add(element);
    //}
    //result.Reverse();
    //return string.Join(" ", result.ToArray());
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            string[] code = { "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ",
                            "дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой",
                            "Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть",
                            "если особенно упорно подойдешь к делу","   ",
                            "будет Трудно конечнО",
                            "Код ведЬ не из простых",
                            "очень ХОРОШИЙ код",
                            "то у тебя все получится",
                            "и я буДу Писать тЕбЕ еще","   ","чао"};

            Console.WriteLine( $"{DecodeMessage(code)}" );
            Console.ReadKey();
        }

        private static string DecodeMessage(string[] lines)
        {
            List<string> result = new List<string>();
            foreach (string e in lines){
                (from Match m in new Regex(@"\b\p{Lu}\w+").Matches(e)
                 select m.Value).ToList().ForEach(i => result.Add(i));
            }
            result.Reverse();
            return string.Join(" ", result.ToArray());
        }
    }
}
