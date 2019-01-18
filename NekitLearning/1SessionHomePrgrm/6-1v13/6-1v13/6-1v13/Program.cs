﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_1v13
{
    /// <summary>
    /// Проверить, одинаковое ли число открывающихся и закрывающихся скобок в данной строке.
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
        int [] BracketsCount = new int[2]; // [0]- openCount , [1] - closeCount

        public void Start()
        {
            Display.ShowObjectives();
            Text = Display.GetParametrs();
            BracketsCount =  GetBracketCount(Text);
            Display.ShowAnswer(Text, BracketsIsEquel(BracketsCount), BracketsCount[0], BracketsCount[1]);

            Console.ReadLine();
        }

        private int[] GetBracketCount(string text)
        {
            int openBracketCount = 0;
            int closeBracketCount = 0;

            int[] bracketsCount = new int[2];

            foreach (var e in text)
            {
                if (e == '{')
                {
                    openBracketCount++;
                }
                else if (e == '}') 
                {
                    closeBracketCount++;
                }
            }

            bracketsCount[0] = openBracketCount;
            bracketsCount[1] = closeBracketCount;
            return bracketsCount;

        }

        private bool BracketsIsEquel(int [] bracketsCount)
        {
            return bracketsCount[0] == bracketsCount[1] ? true : false;
        }


    }



    static public class Display
    {
        public static void ShowObjectives()
        {
            string objectives = " Проверить, одинаковое ли число открывающихся и закрывающихся скобок в данной строке. \n";
            Console.WriteLine(objectives);
        }

        public static string GetParametrs()
        {
            string text = null;
            do
            {
                Console.WriteLine(" Введите строку содержащую символы } и { \n\n");
                text = Console.ReadLine();
                if (text == null) Console.WriteLine("Вы ничего не ввели, попробуйте еще раз. \n");

            } while (text == null);
            return text;
        }

        public static void ShowAnswer(string text, bool bracketsIsEquel, int bracketsOpen ,int  bracketClose )
        {
            string answer;
            if (bracketsOpen == 0 & bracketClose == 0)
            {
                answer = $"\n Ответ: В строке скобок нет";
            }
            else
            {
                string equel = bracketsIsEquel == true ? "одинаковое" : "не одинаковое";
                answer = $"\n Ответ: В строке: '{text}' \n Кол-во скобок {equel}, "+"\n количество } ="+$"{bracketsOpen}," + "\n количество { =" + $"{bracketClose}";
            }
            Console.WriteLine(answer);

            

        }
    }
}
