using System;
using System.Collections.Generic;

namespace N4WorkingWithVisualStudio.Test
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }

 
}