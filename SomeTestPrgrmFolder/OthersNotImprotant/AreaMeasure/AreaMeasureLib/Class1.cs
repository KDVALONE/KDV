using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaMeasureLib
{
    public class Class
    {
        public static double GetArea(double a, double b, double c)
        {
            //Площадь тругольника по формуле Герона равна корню из произведения разностей
            //полупериметра треугольника (p) и каждой из его сторон (a, b, c):
            double p = 0.5 * (a + b + c);
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
    }
}
}
