using System;
//hello world, для тестового использования Visual Studio Core


namespace HelloWorldVSCODE
{
    class Program
    {
        static void Main(string[] args)
        {
             var c1 = new MyClass();
             Console.WriteLine("Hello World!");
            
            System.Console.WriteLine(c1.ReturnMessage());
        }
    }
}
