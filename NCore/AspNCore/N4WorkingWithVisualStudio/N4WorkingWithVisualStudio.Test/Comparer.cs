using System;
using System.Collections.Generic;

namespace N4WorkingWithVisualStudio.Test
{
    /// <summary>
    /// В данных классах содержится код для возможности применения лямбда выражений в модульных тестакх
    /// это не обязательно, но упростит написание тестов.
    /// TODO: (Разобрать добавление лямбда выражений в модульные тесты) 
    /// </summary>
    
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }
    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisonFunction;
        public Comparer(Func<T, T, bool> func)
        {
            comparisonFunction = func;
        }

        public bool Equals(T x, T y)
        {
            return comparisonFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }

}