﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2v13
{

    /// <summary>
    /// Дан произвольный текст. Проверить, правильно ли в нем расставлены круглые скобки.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Expression exp = new Expression();
            exp.Start();
        }
    }

    class Expression
    {
        string Text;
        int[] BracketsCount = new int[2]; // [0]- openCount , [1] - closeCount


        public void Start()
        {
            Display.ShowObjectives();
            // Text = Display.GetParametrs(); // разкоменть, если нужен прользовательский ввод

             Text = " Мама, (поздно ночью) ,  мы((())л)а раму () сидя( стоя) за стол(б)ом , а Ивашка (  ) - ( Наша няшка ), кр(( икну)л) р(ад)остно: ( (Впер)(ед)! ";
           
            FindNotCorrectBracket(Text);
            Console.ReadLine();
        }

        private void FindNotCorrectBracket(string text)
        {
            List<int> indexBadBracket = new List<int>();
            List<int> indexBracketOpen = new List<int>();
            List<int> indexBracketBackspace = new List<int>();

            indexBracketOpen = FindOpeningBrackets(text);
            indexBadBracket = FindEmptyBrackets(text);
            indexBracketBackspace = FindBracketsBackspace(text);

            foreach (var e in indexBracketOpen)
            {
                indexBadBracket.Add(e);
            }
            foreach (var e in indexBracketBackspace)
            {
                indexBadBracket.Add(e);
            }

            Display.ShowAnswer(text, indexBadBracket.ToArray());
        }

        private List<int> FindOpeningBrackets(string text) // найти индекс не закрытых скобок
        {
            List<int> indexBracketOpen = new List<int>();
            List<int> indexBracketClose = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals('('))
                {
                    indexBracketOpen.Add(i);
                }
                else if (text[i].Equals(')'))
                {
                    indexBracketClose.Add(i);
                    if (indexBracketOpen.Count > 0)
                    {
                        indexBracketOpen.RemoveAt(indexBracketOpen.Count - 1);
                        indexBracketClose.RemoveAt(indexBracketClose.Count - 1);
                    }
                }
            }
            foreach (var e in indexBracketClose)
            {
                indexBracketOpen.Add(e);
            }

            return indexBracketOpen;
        }

        private List<int> FindEmptyBrackets(string text) // найти индекс пустых скобок
        {
            List<int> indexBracketOpen = new List<int>();
            List<int> indexBracketOpenFinal = new List<int>();
            List<int> indexBracketClose = new List<int>();

            List<int> indexBracketFull = new List<int>();

            bool bracketIsEpmty = true;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals('(') || text[i].Equals(' '))
                {
                    if (text[i].Equals('(')) { indexBracketOpen.Add(i); bracketIsEpmty = true; }
                }
                else if (text[i].Equals(')') & indexBracketOpen.Count > 0) // может и не надо & indexBracketOpen.Count > 0
                {
                    if (bracketIsEpmty)
                    {
                        indexBracketClose.Add(i);
                        indexBracketOpenFinal.Add(indexBracketOpen.Last());
                        indexBracketOpen.RemoveAt(indexBracketOpen.Count - 1);
                        bracketIsEpmty = true;
                    }
                    else
                    {
                        indexBracketOpen.RemoveAt(indexBracketOpen.Count - 1); //?
                    }
                }
                else
                {
                    bracketIsEpmty = false; // может удалит тут из опен последний эдемент ??
                }
            }
            foreach (var e in indexBracketOpenFinal)
            {
                indexBracketFull.Add(e);
            }
            foreach (var e in indexBracketClose)
            {
                indexBracketFull.Add(e);
            }
            return indexBracketFull;




        }

        private List<int> FindBracketsBackspace(string text) //найти индекс скобок содержащих внутри отступы
        {
            List<int> indexBracketWithBackspace = new List<int>();
            bool bracket = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals('(') & bracket == false)
                {
                    bracket = true;
                }
                else if (text[i].Equals(' ') & bracket == true)
                {
                    indexBracketWithBackspace.Add(i - 1);
                }
                else
                {
                    bracket = false;
                    if (text[i].Equals('(') & bracket == false)
                    {
                        bracket = true;
                    }
                    
                }
            }
            bracket = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(' ') & bracket == false)
                {
                    bracket = true;
                }
                else if (text[i].Equals(')') & bracket == true)
                {
                    indexBracketWithBackspace.Add(i);
                }
                else
                {
                    bracket = false;
                    if (text[i].Equals(' ') & bracket == false)
                    {
                        bracket = true;
                    }
                }
            }
            return indexBracketWithBackspace;
        }

    }

}

static public class Display
{
    public static void ShowObjectives()
    {
        string objectives = " Дан произвольный текст. \n Проверить, правильно ли в нем расставлены круглые скобки. \n\n" +
                " Ошибками считаются: \n" +
                " ()  (()) - пустые скобки любой вложенности \n" +
                " ( или ) - оставленные без пары скобки \n" +
                " ( слово) или ( слово ) - содержащие отступы скобки \n";

        Console.WriteLine(objectives);


    }

    public static string GetParametrs()
    {
        string text = "";
        do
        {
            Console.WriteLine(" Введите строку содержащую круглые скобки ( и ) \n\n");
            text = Console.ReadLine();
            if (text == "") Console.WriteLine("Вы ничего не ввели, попробуйте еще раз. \n");

        } while (text == "");
        return text;
    }

    public static void ShowAnswer(string text, int[] indexOfBadBrackets)
    {

        string textHaveBadBracket = indexOfBadBrackets.Length > 0 ? "имеет ошибки" : " ошибок нет";
        Console.WriteLine($"\n Ответ: \n Cтрока: '{text}' \n\n -{textHaveBadBracket} \n");

        if (textHaveBadBracket.Equals("имеет ошибки"))
        {
            for (int j = 0; j < text.Length; j++)
            {
                bool bracket = false;
                foreach (var e in indexOfBadBrackets)
                {
                    if (j == e)
                    {
                        bracket = true;
                    }
                }
                if (bracket)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(text[j]);
                    bracket = false;
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(text[j]);
                }

            }

        }

    }
}


