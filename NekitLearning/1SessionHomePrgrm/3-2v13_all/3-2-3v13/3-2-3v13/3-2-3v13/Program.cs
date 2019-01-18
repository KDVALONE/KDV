using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2_3v13
{
    /// <summary>
    /// .  Найти количество трехзначных чисел, сумма цифр которых равна А,
    ///    а само число заканчивается цифрой В. А и В задаются.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Expression exp = new Expression();
            exp.Start();
        }
    }

    public class Expression
    {
        int[] Ab;
        int[] numbersArray;
        public void Start()
        {
             Display.ShowObjective();
             Ab = Display.GetParametrs();
             numbersArray = GetArrayNumbers();
             FindNumbers(Ab[0],Ab[1],numbersArray);

             Console.ReadKey();
        }
        private void FindNumbers(int a, int b , int[] numbersArray)
        {
            int numberCount = 0;//количество найденных чисел
            List<int> correctNumbers = new List<int>();//список найденных чисел
            int[] numeberElement; // переменная для записи цифр числа
            for (int i = 0; i < numbersArray.Length; i++)
            {
                numeberElement = GetElementsOfNumber(numbersArray[i]);
                if (GetSummOfNumElements(numeberElement) == a & numeberElement[0] == b)
                {
                    numberCount++;
                    correctNumbers.Add(numbersArray[i]);
                }
            }
            Display.ShowAnswer(correctNumbers, numberCount, a, b);
        }

        private int[] GetElementsOfNumber(int number)
        {
            int a = number;
            List<int> listElements = new List<int>();
            while (a > 0)
            {
                listElements.Add(a % 10);
                a = a / 10;
            }
            return listElements.ToArray();
        } // разбиение числа на цифры 
        private int[] GetArrayNumbers()
        {
            List<int> arrayNumbers = new List<int>();

            for (int i = 100; i < 1000; i++)
            {
                arrayNumbers.Add(i);
            }
            return arrayNumbers.ToArray();

        } //получение массива всех трехзначных чисел
        private int GetSummOfNumElements(int[] elements) // получение суммы чисел массива
        {
            int s = 0;  
            foreach (var e in elements)
            {
                s += e;
            }
            return s;

        } 

    }
    public static class Display
    {
        //static public bool SelectInputMethodIsHandle()
        //{
        //    Console.WriteLine("Вы хотите ввести натуральное число  в ручную ? \n");
        //    bool doing = true;
        //    string enteredString;
        //    do
        //    {
        //        Console.WriteLine("Введите 'y' или нажмите Enter для ручного ввода \n" +
        //        "Введите 'n' для использования параметров по умолчанию. ");
        //        enteredString = Console.ReadLine();

        //        if (enteredString.Contains('y') || enteredString.Contains('Y') ||
        //        enteredString.Contains('у') || enteredString.Contains('У') ||
        //        enteredString == "" || enteredString.Contains('н') || enteredString.Contains('Н') ||
        //        enteredString.Contains('N') || enteredString.Contains('n'))
        //        { doing = false; }
        //        else
        //        {
        //            doing = true;
        //            Console.WriteLine("Вы ввели не корректные данные, попробуйте еще раз");
        //        }
        //    } while (doing);

        //    if (enteredString.Contains('y') || enteredString.Contains('Y') ||
        //        enteredString.Contains('у') || enteredString.Contains('У') ||
        //        enteredString == "")
        //    {
        //        return true;
        //    }
        //    else { return false; }
        //}
        static public int[] GetParametrs()
        {

            int value;
            bool correctParametr = true;

            int[] parametrs = new int[2]; 
            string[] parametrName = { "A", "B" };
            

            Console.WriteLine(" Введите в ручную натуральное число для функции: \n ");
            for (int i = 0; i < parametrName.Length; i++)
            {       
            do
            {
                correctParametr = false;
                Console.WriteLine($"Введите {parametrName[i]}: \n");
                var enteredValue = Console.ReadLine();
                if (!int.TryParse(enteredValue, out value) || (i == 1 & (int.Parse(enteredValue) < 0 || int.Parse(enteredValue) > 9)))
                {
                    Console.WriteLine($" Вы ввели не натуральное число, или значение {parametrName[i]} не цифра . Попробуйте снова! \n");
                }
                else
                {
                    parametrs[i] = int.Parse(enteredValue);
                    correctParametr = true;
                }
            } while (!correctParametr);
            }
            return parametrs;
        }

        static public void ShowAnswer(List<int>answer, int numberCount, int a, int b)
        {
            Console.WriteLine($"\n Ответ:Количество чисел сумма которых равна {a} и последняя цифра которых {b} \n" +
                $" S = {numberCount} \n");
            foreach (var e in answer)
            {
                Console.WriteLine(" " + (int)e);
            }
        }

        static public void ShowObjective()
        {
            string objective = " Найти количество трехзначных чисел, сумма цифр которых равна А, \n" +
                               " а само число заканчивается цифрой В. А и В задаются.";
        

            Console.WriteLine($"{objective}");
        }

    }
}
