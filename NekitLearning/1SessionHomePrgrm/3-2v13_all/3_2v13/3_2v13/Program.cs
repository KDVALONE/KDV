using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2v13
{/// <summary>
 ///  " \n Протабулировать заданную функцию на интервале,\n" +
 ///  " задаваемом пользователем, и с шагом, задаваемым пользователем. \n" +
 ///  " Пользовательский ввод проверять на корректность ввода чисел с плавающей точкой.\n" +
 ///  " При невозможности расчета функции в конккретной точке выводить значение этой точки \n" +
 ///  " и надпись, означающую отсутствие решения. \n" +
 ///  " Константные значения границы отрезка табулирования и шага, заданные в таблице,\n" +
 ///  " использовать для решения тестовых примеров";
 /// </summary>
 /// 
    class Program
    {

        static void Main(string[] args)
        {
            Start strt = new Start();
            strt.StartProgram(); 
        }
    }


    class Start // класс начала программы
    {
        Expression exp = new Expression();

        public void StartProgram()
        {
            exp.RunExpression();
            Console.ReadKey();
        }
    }

    class Expression
   {
       

        public void RunExpression()
        {
            if (Display.SelectInputMethodIsHandle() ? true : false)
            {
               double [] param = Display.GetParametrs();
               FindY(param[0], param[1], param[2], param[3], param[4], param[5]);
            }
            else
            {
                FindY();
            }
        }
        private void FindY(double A = 2.1, double B= 1.9, double C = -20.5, double I = 0, double IFinish = 12, double IStep = 1)//Заданное выражение, параметрами по умолчанию, 
        {
            bool iIsInscrement = IsIncrement(I, IFinish);
            List<double> YList = new List<double>(); // это список, от массива отличается тем, что он позволяет динамически
                                                     //присваивать данные, а массив должен заранее знать сколько в него положут елементов 
                                                     //данный список получившихся решений выражения
            List<double> DotList = new List<double>(); // список с точками табуляции
            List<double> NotCorrectDot = new List<double>(); // список с некорректными точами

            for ( ;I <= IFinish; I = DoStep(iIsInscrement,I,IStep))
            {

                if (I < 4)
                {
                        YList.Add((A / I) + (B * Math.Pow(I, 2)) + C);
                        DotList.Add(I);
                }
                else if (I > 6)
                {
                    YList.Add((A * I) + (B * Math.Pow(I, 3)));
                    DotList.Add(I);
                }  
                else
                {
                    YList.Add(I);
                    DotList.Add(I);
                }
            }

            Display.ShowAnswer(YList,DotList);
        }
        private bool IsIncrement( double i, double iFinish)
        {
            return i < iFinish ? true : false;
        }
        private double DoStep(bool increment, double i, double  iStep)
        {
            double I;
            if (increment)
            {
               I =  i+iStep;
            }
            else
            {
                I = i - iStep;
            }
            return I;
        }
    }
    static class Display
    {
        static public bool SelectInputMethodIsHandle()
        {
            Console.WriteLine("Вы хотите ввести параметры в ручную ? \n");
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
        static public double [] GetParametrs()
        {

            double value;
            bool correctParametr = true;
            double[] parametrs = new double[6]; //a, b, c, i, ifinish, istep
            
            string[] parametrsName = {"a","b","c","Начальное i "," Конечное i ","шаг для i" };

            Console.WriteLine(" Введите в ручную параметры для функции: \n " +
                "ввдодите дробные значения через запятую (пример: 3,14) \n");

                for (int i = 0; i < parametrsName.Length; i++)
                {
                    do
                    {
                        correctParametr = false;
                        Console.WriteLine($"Введите {parametrsName[i]}: \n");
                        var enteredValue = Console.ReadLine();
                        if (!double.TryParse(enteredValue, out value))
                        {
                            Console.WriteLine(" Вы ввели не двоичное число, или ввели его не через запятую! \n" +
                                " (Пример 3,14)Попробуйте снова! \n"); 
                        }
                        else {
                            parametrs[i] = Convert.ToDouble(enteredValue);
                            correctParametr = true;
                        }
                    } while (!correctParametr);               
                }
                return parametrs;
        }
        static public void ShowObjective()
        {
            string objective = " \n Протабулировать заданную функцию на интервале,\n" +
                " задаваемом пользователем, и с шагом, задаваемым пользователем. \n" +
                " Пользовательский ввод проверять на корректность ввода чисел с плавающей точкой.\n" +
                " При невозможности расчета функции в конккретной точке выводить значение этой точки \n" +
                " и надпись, означающую отсутствие решения. \n" +
                " Константные значения границы отрезка табулирования и шага, заданные в таблице,\n" +
                " использовать для решения тестовых примеров";

            Console.WriteLine($"{objective}");
        }
        static public void ShowAnswer(List<double> Y, List<double> DotList)
        {
            Y.Reverse(); // переворачиваем список, так как он заполнялся по принципу, FILO - first in lust out
            Console.WriteLine("\n Ответ: Получившиеся значения: ");

            for (int i = 0; i < Y.Count(); i++)
            {
                Console.Write($"В точке {DotList[i]:0.00} Y= ");
                if (Double.IsNaN(Y[i]) || Double.IsInfinity(Y[i]))
                {
                    Console.WriteLine($"решений нет,"); 
                }
                else {
                    Console.WriteLine($"{Y[i]:0.00},"); // DotList[i]:0.00 отображение ответа до двух знаков после запятой
                }
             

            }
                
            
        }
       
    }

}

