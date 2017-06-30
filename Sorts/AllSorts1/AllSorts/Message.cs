using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{
    class Message
    {/// <summary>
    /// класс для вывода сообщений
    /// </summary>
        public int SortName { get; set; }
        public int[] Array = new int[5];
      
        public void GetStartMessage()
        {
            Console.WriteLine("Выберите сортировку (введите цифру)\n 1 - Сортировка пузырьком ");
        } // вывести 1 сообщение
        public int SetSortName()
        {
            try
            {
                SortName = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ошибка: это не число:" + ex.Message + "/n/n");
                SetSortName();
            }
            if (SortName < 1 && SortName > 4)
            {
                Console.WriteLine("Ошибка:введите числа с 1 до 4");
                SetSortName();
            }
            return SortName;
        }// задать имя сорти ровки
        public void GetSortNameMessage(int sortName)
        {
            switch (sortName)
            {
                case 1:
                    Console.WriteLine( "Выбрана: Сортировка Пузырьком \n ");
                    break;
            }
        } // вывести название сортировки 
        public void GetSetArrayMessage()
        {
            Console.WriteLine("введите массив  цифр: \n" );
        } // вывести сообщение о вводе массива
        public int[] SetArray()
            {
            for (int i = 0; i < 5; i++)
                try
                {
                    Array[i] = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {   Console.WriteLine("Ошибка: введено не число  " + ex.Message);
                    SetArray();
                }
            return Array;
            }
       static public void GetArrayCountMessage(int [] array) //вывести значение массива на экран
        {
            string stringArray = string.Concat(array);
            Console.WriteLine(" ОТВЕТ: \n Отсортированный массиив:  {0}", stringArray);
            Console.ReadKey();

        }
    }
}
