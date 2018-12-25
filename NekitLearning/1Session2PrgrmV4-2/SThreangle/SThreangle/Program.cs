using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SThreangle
{
    //вычислить площадь треугольника по заданным сторонам.

    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            do
            {
                Console.WriteLine("Введите стороны треугольника");
                GetSides(out a, 'a');
                GetSides(out b, 'b');
                GetSides(out c, 'c');

                if (IsDegenerateTriangle(a, b, c) == true) //вырожденный ли треугольник? 
                {
                    Console.WriteLine("Треугольник вырожденный, сумма длин двух его сторон должна быть больше третей стороны");
                    Console.WriteLine("Введите значения еще раз");
                }
            } while (IsDegenerateTriangle(a, b, c) == true);

            Console.WriteLine($"площадь треугольника равна S = {GetTriangleS(a, b, c)}");
            Console.ReadKey();
        }
        public static bool IsDegenerateTriangle(double a, double b, double c) // вырожденный ли треугольник, сумма длин двух его сторон должан быть больше третей
        {
            if ((a + b > c)) { return false; } else { return true; }
        }

        public static double GetSides(out double side, char sideName) // задать значения сторонам треугольника
        {
            bool isValueEntered;
            do
            {

                Console.WriteLine($"Введите сторону {sideName}= ");
                string enteredValue = Console.ReadLine();
                if (Double.TryParse(enteredValue, out side))
                {   // проверка, можем ли мы привести int к string  (прочти про ref,out)
                    side = Convert.ToDouble(enteredValue);
                    isValueEntered = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректный символ,(дроби вводяться через запятаю 4,05) попробуйте снова");//если вводить тип double то нужно через запятую 4,05  
                    isValueEntered = false;
                }
            } while (isValueEntered==false);

            return side;

        }
        public static double GetTriangleS(double a, double b, double c)
        {
            //Площадь тругольника по формуле Герона равна корню из произведения разностей
            //полупериметра треугольника (p) и каждой из его сторон (a, b, c):
            double p = 0.5 * (a + b + c);
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
    }
}
        #region old program, very difficult!! HARDCORE=)
//        static void Main(string[] args)
//    {
//        int a,b,c; // 
//        double angleA;
//        double angleB;
//        double angleC;
//        double s;
//        do {
//            GetSides(out a);
//            GetSides(out b);
//            GetSides(out c);

//            if (IsDegenerateTriangle(a, b, c) == true) //вырожденный ли треугольник? 
//            { 
//                Console.WriteLine("Треугольник вырожденный, сумма длин двух его сторон должна быть больше третей стороны");
//                Console.WriteLine("Введите значения еще раз");
//            }
//        } while(IsDegenerateTriangle(a, b, c) == true);



//        if (IsEquilateralTriangle(a, b, c) == true) // треугольник равносторонний?
//        {
//            s = GetSEquilateralTriangle(a);
//            Console.WriteLine($"Площадь равностороннего треугольника равна {s}");
//        }
//        else if (IsOscelesTriangle(a, b, c)) // треугольник равнобедренный?
//        {
//            s = (GetOscelesTrianglee(a, b, c));
//            Console.WriteLine($"Площадь равнобедренного треугольника равна {s}");
//        }
//        else if (IsRightTriangle(a, b, c)) // треугольник прямоугольный ?
//        {

//        }
//        else if (IsObtuseTriangle(a, b, c)) // треугольник тупоугольный ?
//        {

//        }
//        else  // если ничего из вышеперечисленного то треугольник остроугольный!
//        {

//        }


//    }
//    public static int GetSides(out int side) // задать значения сторонам треугольника
//    {
//        Console.WriteLine("Введите стороны треугольника");
//        int sideNumber = 0;

//        do {
//            Console.WriteLine($"Введите {sideNumber + 1}ю сторону = ");
//            string enteredValue = Console.ReadLine();
//            if (Int32.TryParse(enteredValue, out side))  {   // проверка, можем ли мы привести int к string  (прочти про ref,out)
//                side = Convert.ToInt32(enteredValue);
//                sideNumber++;
//            }else {
//                Console.WriteLine("Вы ввели неверное значение, попробуйте снова");
//            }
//        }
//        while (sideNumber <= 2);
//        return side;

//    }

//    public static bool IsDegenerateTriangle(int a,int  b,int  c) // вырожденный ли треугольник, сумма длин двух его сторон должан быть больше третей
//    {
//        if (!(a + b > c))
//        { return false; } else { return true; }
//    }

//    public static bool IsEquilateralTriangle(int a,int b, int c) // проверка равносторонний  ли треугольник так как формулы разные
//    {   
//        if (a == b && b == c)
//        {
//        return true;
//        }
//        return false;
//    }

//    public static bool IsOscelesTriangle(int a, int b, int c) // проверка равнобедренный ли треугольник так как формулы разные
//    {
//        if (a == b || b == c || c == a)
//        {
//            return true;
//        }
//        return false;
//    }

//    public static void GetAngles(out double angleA, out double angleB, out double angleC , int a,  int b, int c )
//    {
//        angleA = Math.Acos((Math.Pow(b,2)+ Math.Pow(c, 2) - Math.Pow(a, 2))/(2 *b * c));
//        angleB = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c));
//        angleC = Math.PI - angleA - angleB;
//    }

//    public static bool IsRightTriangle(double angleA, double angleB, double angleC) // проверка прямоугольный ли треугольник так как формулы разные
//    {
//        if (angleA == 90 || angleB == 90 || angleC == 90)
//        {
//            return true;
//        }
//        else {
//            return false;
//        } 

//    }

//    public static bool IsObtuseTriangle(double angleA, double angleB, double angleC) // проверка тупоугольный ли треугольник так как формулы разные
//    {
//        if (angleA > 90 || angleB > 90 || angleC > 90)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }




//    public static double GetSEquilateralTriangle(int a)// ищем площадь равностороннего треугольника
//    {
//         double h = Math.Sqrt(Math.Pow(a,2)- Math.Pow(a,2)/4); // находим высоту равностороннего треугольника
//         double S = 1/2 * a * h;
//         return S;
//    }

//    public static double GetOscelesTrianglee(int a, int b, int c) // ищем площадь равнобедренного треугольника
//    {
//        if (b == c) // тут мы временно меняем местами значения, так как мы не знаем какие именно стороны равны
//        {
//            a = b;
//            c = a;
//        }
//        double h = Math.Sqrt(Math.Pow(a,2)-(Math.Pow(b,2)/4));
//        double s = 0.5 * b * h;
//        return s;
//    }

//    public static double GetRightTriangle(int a, int b, int c, double angleA, double angleB, double angleC)// ищем площадь прямоугольного треугольника
//    {
//        //TODO: Доделать ебучую площадь треугольнирков, осталось прямоугольный, тупоугльный, остроугольный
//        // блин, для этого нужно еще постоянно проверят какие именно стороны 

//        //!!!!!!!!!!!!!!!!!!!!!!!
//        // БЛЯ!!!!  , походу, любую пдощадь треугольника можно посчитать через формулу Герона  
//        //!!!!!!!!!!!!!!!!!!!!!!!
//    }

//    public static double GetIsOscelesTrianglee(int a, int b, int c ) // ищем площадь тупоугльный треугольника
//    { }

//    public static double GetАcuteTrianglee(int a, int b, int c)// ищем площадь остроугольный треугольника
//    { }

//}
#endregion


