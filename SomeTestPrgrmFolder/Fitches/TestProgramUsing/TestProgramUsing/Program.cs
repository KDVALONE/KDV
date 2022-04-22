using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramUsing
{
    class Program
    {
        static void Main(string[] args)
        {

            MyClass mc = new MyClass();
            MyClass1 mc1 = new MyClass1();
            mc.MethodClass();
            mc1.MethodClass3();
            mc.MethodClass2(mc1);
            Console.WriteLine("Используемя using");
            using (MyClass mcD = new MyClass())
            {
                mcD.MethodClass();
            }
            Console.WriteLine("Вроде как закончили блок Using и освободили память");
            Console.ReadKey();
        }
    }

    public class MyClass : IDisposable
    {
        public void MethodClass()
        { Console.WriteLine("Метод класса0"); }
        public void MethodClass2(MyClass1 mc1)
        {  Console.WriteLine("выводим вложенный метод класса0 "); mc1.MethodClass3(); }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MyClass() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

    public class MyClass1
    {
        public void MethodClass3() => Console.WriteLine("Метод класса1");  
    }
    public class MyClass2
    {
        MyClass mc = new MyClass();

        public void MethodClass4(MyClass mc) => mc.MethodClass();
    }


}
