using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTConsApp2.Test
{
    [TestClass]
    public class UnitTest1
    {
        //Если незнаешь как назвать unitTest метод, то наверное слишком много хочешь тестировать за раз.
        //Тестовый метод считает факториал получает 5 и возвращает 120
        [TestMethod]
        public void GetFactorial_5_120returned()
        {
            //arrange (подготовка к тестированию, входные параметры и тд.)
            int x = 5;
            int expected = 30;

            //act (собственно действие тестирования)
            Factorial f = new Factorial();
            int actual = f.GetFactorial(x);

            //assert (провести сравенние получаемого и ожидаемого результата)
        }
    }
}
