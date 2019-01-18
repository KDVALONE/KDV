﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_3v13
{
/// <summary>
/// Дан текст на русском языке.
/// Выяснить, входит ли данное слово в указанный текст, и если да, то сколько раз.
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
        string Word;
        string [] Parametrs;
        int WordCount;

        public void Start()
        {
            Parametrs = Display.GetParametrs(); 
            Text = Parametrs[0];
            Word = Parametrs[1];

          

            WordCount = GetWordCountText(Text, Word);
            Display.ShowAnswer(Text,Word,WordCount);

            Console.ReadLine();
        }

        public int GetWordCountText(string text, string word)
        {
            int wordCount = 0;
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var e in words)
            {
                if (e == word) { wordCount++; }
            }
            return wordCount;
        }
     
    }

    class Display
    {
        public static void ShowObjectives()
        {
            string objectives = " Дан текст на русском языке. \n" +
                " Выяснить, входит ли данное слово в указанный текст, и если да, то сколько раз. \n";

            Console.WriteLine(objectives);
        }
        /// <summary>
        /// [0] -text , [1] - word
        /// </summary>
        /// <returns></returns>
        public static string [] GetParametrs()
        {
            string [] parameters = new string [2];
            parameters[0] = GetText();
            parameters[1] = GetWord();
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

        private static string GetWord()
        {
            string word = "";
            do
            {
                Console.WriteLine(" Введите слово: ");
                word = Console.ReadLine();
                if (word == "") Console.WriteLine("Вы ничего не ввели, попробуйте еще раз. \n");

            } while (word == "");
            return word;
        }


        public static void ShowAnswer(string text, string word, int wordCount)
        {
            string answer = "Ответ: \n" +
                $" В Тексте :'{text}' \n \n" +
                $" Слово: '{word}' в тексте встречается  = {wordCount} раз.";

            Console.WriteLine(answer);

        }
    }
}
