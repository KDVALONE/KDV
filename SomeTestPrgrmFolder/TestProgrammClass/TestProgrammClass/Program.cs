using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgrammClass
{
    /// <summary>
    /// Прогармма для  отработки классов.
    /// Создать класс с статическими и динамическими полями 
    /// вызвать с помощью статических и динамических методов поля.
    /// отработать аксессоры
    /// 
    /// </summary>

    class SomeClass
    {
        private static int _b; //статическое поле
        private int _a;
        public int AcsessorA
        {
            get { return _a; }
            set { _a = value; }
        }
        public static int AcsessorB
            {
            get { return _b; }
            set { _b = value; }
            }
        
        public void Method1() // динамический метод
            {
            SomeClass sc = new SomeClass;
            sc.

            }
        static public void StaticMethod1() // статический метод
            {
            SomeClass._b = 1;
            SomeClass.AcsessorB(12);
            }     
     }
}
