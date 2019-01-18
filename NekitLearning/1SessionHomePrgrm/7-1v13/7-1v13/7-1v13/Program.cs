﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_1v13
{/// <summary>
 /// Дан текст. Определить, сколько в нем символов «*», «;», «:»
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
       

        string[] Parametrs;
        /// <summary>
        /// [0] -* [1] -; [2] - :
        /// </summary>
        int[] CountElement;
        

        public void Start()
        {
            Display.ShowObjectives();
            Parametrs = Display.GetParametrs();
            Text = Parametrs[0];


            CountElement = GetCountElement(Text);
            Display.ShowAnswer(Text,  CountElement);

            Console.ReadLine();
        }

        private int [] GetCountElement(string text)
        {

            int[] symbolCount = new int[3];
            foreach (var e in text)
            {
                switch (e)
                {
                    case '*':
                      {
                            symbolCount[0] ++;
                            break;
                      }
                    case ';':
                        {
                            symbolCount[1]++;
                            break;
                        }
                    case ':':
                        {
                            symbolCount[2]++;
                            break;
                        }

                }
            }

            return symbolCount;
        }

    }

    class Display
    {
        public static void ShowObjectives()
        {
            string objectives = " Дан текст. Определить, сколько в нем символов «*», «;», «:» \n";
                

            Console.WriteLine(objectives);
        }
        /// <summary>
        /// [0] -text 
        /// </summary>
        /// <returns></returns>
        public static string[] GetParametrs()
        {
            string[] parameters = new string[1];
            parameters[0] = GetText();
           
            return parameters;
        }

        private static string GetText()
        {
            string text = "";
            do
            {
                Console.WriteLine(" Введите текст: ");
                text = Console.ReadLine();
                if (text == "") Console.WriteLine("Вы ничего не ввели, попробуйте еще раз. \n");

            } while (text == "");
            return text;
        }

      
        public static void ShowAnswer(string text, int [] symbolCounts)
        {
            string answer = "\n\n Ответ: \n" +
                $" В Тексте :'{text}' \n \n" +
                $" Символ: '*' в тексте встречается  = {symbolCounts[0]} раз. \n" +
                $" Символ: ';' в тексте встречается  = {symbolCounts[1]} раз. \n" +
                $" Символ: ':' в тексте встречается  = {symbolCounts[2]} раз. \n" ;

            Console.WriteLine(answer);

        }
    }
}
