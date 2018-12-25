using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MyEBookReader
{
    public partial class Form1 : Form
    {
        string theEBook;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
                {
                    theEBook = eArgs.Result;
                    txtBox.Text = theEBook;
                };
            // Загрузить электронную книгу "A Tale of Two Cities", Чарльза Диккенса
            //DownloadStringAsync() ассинхронный метод System.WebClient , авт. порождает новый поток из пула потоков CLR
            // когда WebClient завершает работу, он инициализ. событие DownloadStringComleted (котор. обраб. с пом. лямбда выраж.)
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            // получить члова из электронной книги
            string[] words = theEBook.Split(new char[]
                {' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'},
                StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommon = null;
            string longestWord = string.Empty;
            Parallel.Invoke(() => // Parallel.Invoke() ожидает в качестве парам. массива делегатов Action<> который косвенно дается с помощью лябда выражения
            // теперь библиотека TPL, будет исп. все доступные процессы машины для вызова каждого метода, паралельно, если это возможно
            {
                //Найти 10 наиболее часто встречающихся слов
                tenMostCommon = FindTenMostCommon(words);
            },
            () =>
            {
                // Получить самое длинное слово
                longestWord = FindLongestWord(words);
            });
            //когда все задачи завершенны, постороить строку,
            //показывающую всю статистику в окне сообщений
            StringBuilder bookStats = new StringBuilder("Ten Most Coomon Words are: \n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }
            bookStats.AppendFormat($"Longest word is: {longestWord}");
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book info");
        }
        private string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;
            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }
        private string FindLongestWord(string[] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }
    }
}
