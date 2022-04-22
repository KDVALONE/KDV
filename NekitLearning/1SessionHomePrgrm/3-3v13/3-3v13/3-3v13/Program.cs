using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_3v13
{/// <summary>
 /// Протабулировать заданную функцию и сумму функционального ряда 
 /// разложения этой функции на интервале [a,b] и с шагом h (шаг и интервал задается в константах).
 /// Функциональнй ряд вычисляется по соответствующей рекуррентной формуле с заданной точностью ɛ.
 /// В результате показать три столбца: значение аргумента, значение функции в данной точке 
 /// и значение суммы ряда, вычисленное с заданной точностью в данной точке. 
 /// Два последних столбца должны иметь близкие результаты.
 /// 
 /// ___________
 /// Вычисление суммы ряда с определенной точностью ε означает, что сумма ряда вычисляется до тех пор,
 /// пока модуль разности между текущим и предыдущим членом последовательности больше ε
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
        
        double h = 0.1; // шаг, задали сами. 
        double a = -2;//начало отрезка
        double b = -0.1; // конец отрезка

        double e = Math.Pow(40, -5); // точность
    
        private double GetY(double x) //значение функции в данной точке
        {
            return Math.Log(1 / (2 + (2 * x) + Math.Pow(x, 2)));
        }
        public void Start()
        {
            Tabulation(a,b,h,e);
            Console.ReadLine();
        }

        private void Tabulation( double a, double b, double h, double e)
        {
            Console.WriteLine("|X - значение аргумента| \n" +
                "|Y= значение функции в данной точке| \n" +
                "|S- значение суммы ряда, вычисленное с заданной точностью в данной точке.| ");
            Console.WriteLine("|X    | |Y    | |S    |");
            double y;
            double x ;
            
            double f = 0; // член ряда
            for (x = a; x <= b; x += h)
            {
                x = Math.Round(x, 2); // округляем до двух знаков после запятой, так как при операции x+=h с типом дабл идет погрешность в миллионных знаках 
                double s = 0;// cумма ряда
                double n = 1;// номер элемента ряда 
                y = GetY(x);
                
                do
                {
                    f = RowElement(n, x);
                    s += f;
                    n += 1;

                   
                    Console.Write($"|{x:0.00}| ");
                    Console.Write($"|{y:0.00}| ");
                    Console.Write($"|{s:0.00}|\n");

                } while (f > e); 
            }

        }

        private double RowElement(double n, double x) //вычесление члена ряда
        {
           return Math.Pow(-1,n)* (Math.Pow((1+x), (2*n)) / n);
        }

    }
}

