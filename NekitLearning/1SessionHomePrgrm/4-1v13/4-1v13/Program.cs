using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1v13
{/*1.Задачи решать в общем виде. Все константные значения, указанные в таблице,
    использовать для решения тестовых примеров. Все вводимые пользователем значения переменных 
    проверять на непротиворечивость данных. Три пункта задания организовать в 
    виде функций (методов). Реализовать возможность заполнения массива, как случайными числами,
    так и с помощью клавиатуры по желанию пользователя.
    Логически повторяющиеся части программы убрать в функции (методы). 
    
    1. Дан массив целых чисел из n элементов, 
    заполненный случайным образом числами из промежутка [-10,10].
    Найти сумму элементов, значения которых кратны 3 и 5. 
    2. Найти количество тех элементов, 
    значения которых положительны и по модулю не превосходят заданное число А.  

    Количество ?!?!?!, ну раз количество, так и будет количество

    3. Найти номер первой пары соседних элементов, сумма которых меньше заданного числа.*/
    class Program
    {
        static Random rnd = new Random();// экзепляр класса Random, нужен для присвоения случайных значений
        public static int X1 = -10;
        public static int X2 = 10;
        public static int A;
        public static int[] Array;
        static void Main(string[] args)
        {
            Array = IsHandeArrayFill() ? SetArrayHandcrafted() : SetArrayAuto(); // тренарный оператор
            A = SetA();

            Console.WriteLine($"1 - Сумма елементов массива кратных 3 и 5  равна {GetSumOfArrayElement(Array)}");
            Console.WriteLine($"2 - Количество не отрицательных елементов массива которые больше A={A} по модулю составляет {GetCountAbsOfElements(Array,A)} елементов");
            Console.WriteLine($"3 - Номер первой пары соседних элементов , " +
                                    $"сумма которых меньше заданного числа A={A} {GetFirstPairOfElement(Array,A)}");
            Console.ReadKey();
        }
        protected static int[] SetArray() 
        {
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            string[] splitedTextArray;
            int value;
            int[] enteredArray;
            

            do 
            {
                int i = 0;
                enteredValue = Console.ReadLine();
                splitedTextArray = enteredValue.Split(' '); // т.к. значения вводяться в одну строку, их нужно разбить по числам с помощью пробела

                enteredArray = new int[splitedTextArray.Length];
                foreach (string e in splitedTextArray)
                    if (!int.TryParse(e, out value))
                    {
                        Console.WriteLine($"Введеный вами символ '{e}' массива не является целым числом. Попробуйте еще раз.");
                        flagOfEnterdCount = false;
                        break;  
                    }
                    else
                    {
                        value = Convert.ToInt32(e);
                        enteredArray[i] = value;
                        i++;
                        if (i == splitedTextArray.Length) { flagOfEnterdCount = true; }

                    }
            } while ((flagOfEnterdCount == false));

            return enteredArray;
        }
        protected static bool IsHandeArrayFill()
        {
            Console.WriteLine("Вы хотите заполнить массив элементами в ручную ? \n");
            bool doing = true;
            string enteredString;
            do
            {
                Console.WriteLine("Введите 'y' или нажмите Enter для ручного ввода \n" +
                "Введите 'n' для автоматического заполнения массива ");
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
        protected static int[] SetArrayHandcrafted()
        {
            Console.WriteLine("Введите массив чисел:");
            int[] array = SetArray();
            return array;
        }
        protected static int[] SetArrayAuto()
        {
            Console.WriteLine($"Массив автоматически заполняется \n" +
                               $"в случайным количеством случайных значений от {X1} до {X2}");

            int[] arrayAuto = new int[rnd.Next(3, 21)];
            for (int i = 0; i < arrayAuto.Length - 1; i++)
            {
                arrayAuto[i] = rnd.Next(X1, X2); // присваеваем случайное значение от -10 до 10.
            }
            string arrayString = "";
            foreach (int e in arrayAuto)
            {
                arrayString += e + " ";
            }
            Console.WriteLine($"Автоматически заполненный массив {arrayString}");
            return arrayAuto;
        }
        protected static int SetA()
        {
            Console.WriteLine("Введите число A , для решения задания №2 и №3 ");
            bool flagOfEnterdCount = true;
            string enteredValue = "";
            int value;
            do
            {
                enteredValue = Console.ReadLine();
                if (!Int32.TryParse(enteredValue, out value))
                {
                    Console.WriteLine("Вы ввели не целое число.  Попробуйте еще раз.");
                    flagOfEnterdCount = false;
                }
                else
                {
                    value = Convert.ToInt32(enteredValue);
                    flagOfEnterdCount = true;
                }
            } while ((flagOfEnterdCount == false));

            return value;
        }

        protected static int GetSumOfArrayElement(int[] array)  //Найти сумму элементов, значения которых кратны 3 и 5. (тоесть по заданию они должны быть одновременно кратны 3 и 5.
                                                                // Такие цифры это 30 15 45 60), тоесть с диапазоном по умолчанию от -10 до 10 задача всегда будет выдавать 0
        {
            int sum = 0;
            foreach (int e in array)
            { if (e % 3 == 0 & e % 5 == 0)
                sum += e;
            }
            return sum;
        }
        protected static int  GetCountAbsOfElements(int[] array , int a)
        {
            int countElemtnts = 0;
            foreach (int e in array)
            {
                if (e > 0 && Math.Abs(e) > Math.Abs(a))
                {
                    countElemtnts++;
                }
            }
            return countElemtnts;
        }
        protected static string GetFirstPairOfElement(int[] array,int a)
        {
            int pairNumber = 1;
            int firsExistPair = 0; // найденная пара
            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (i + 1 <= array.Length - 1 && (array[i] + array[i + 1]) < a && (firsExistPair == 0))
                {
                    firsExistPair = pairNumber;
                }
                pairNumber++;
            }
           return firsExistPair > 0 ? "является " + firsExistPair.ToString() : "отсутствует, так как такой пары не существует.";
        }
    }
}

