using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_3_2v13
{/// <summary>
/// 13.  Дано натуральное число. Приписать к нему такое же число.
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Expression exp = new Expression();
            exp.Start();
            Console.ReadLine();
        }
    }
    public class Expression
    {
        public static Random rnd =  new Random();
        public void Start()
        {
            Display.ShowObjective();
            bool HandCraftedManual = Display.SelectInputMethodIsHandle() ? true : false;
            ulong n;
            if (HandCraftedManual)
            {
                n = Display.GetParametrs();
            }
            else
            {
                n = (ulong)rnd.Next(1, 100000);
            }
            Console.WriteLine($"N = {n}");
            RunExpression(n);
        }
        public void RunExpression(ulong n)
        {
            string nString = n.ToString();
            ulong nNew;    
            nString += nString;
            nNew = ulong.Parse(nString);
            Display.ShowAnswer(nNew);
        }
    }
    
    public class Display
    {
        static public bool SelectInputMethodIsHandle()
        {
            Console.WriteLine("Вы хотите ввести натуральное число  в ручную ? \n");
            bool doing = true;
            string enteredString;
            do
            {
                Console.WriteLine("Введите 'y' или нажмите Enter для ручного ввода \n" +
                "Введите 'n' для использования параметров по умолчанию. ");
                enteredString = Console.ReadLine();

                if (enteredString.Contains('y') || enteredString.Contains('Y') ||
                enteredString.Contains('у') || enteredString.Contains('У') ||
                enteredString == "" || enteredString.Contains('н') || enteredString.Contains('Н') ||
                enteredString.Contains('N') || enteredString.Contains('n'))
                { doing = false; }
                else
                {
                    doing = true;
                    Console.WriteLine("Вы ввели не корректные данные, попробуйте еще раз");
                }
            } while (doing);

            if (enteredString.Contains('y') || enteredString.Contains('Y') ||
                enteredString.Contains('у') || enteredString.Contains('У') ||
                enteredString == "")
            {
                return true;
            }
            else { return false; }
        }
        static public ulong GetParametrs()
        {

            ulong value;
            bool correctParametr = true;
            ulong parametr =0;

            string parametrName = "натуральное число";

            Console.WriteLine(" Введите в ручную натуральное число для функции: \n ");
                do
                {
                    correctParametr = false;
                    Console.WriteLine($"Введите {parametrName}: \n");
                    var enteredValue = Console.ReadLine();
                    if (!ulong.TryParse(enteredValue, out value) & ulong.Parse(enteredValue) <= 0)
                    {
                        Console.WriteLine(" Вы ввели не натуральное число, или 0. Попробуйте снова! \n");
                    }
                    else
                    {
                        parametr = ulong.Parse(enteredValue);
                        correctParametr = true;
                    }
                } while (!correctParametr);
            
            return parametr;
        }
        static public void ShowAnswer(ulong answer) { Console.WriteLine($"\n Ответ: получившеесе натуральное число = {answer}"); } 
        static public void ShowObjective()
        {
            string objective = " 13.  Дано натуральное число. Приписать к нему такое же число.";

            Console.WriteLine($"{objective}");
        }
    }
}
