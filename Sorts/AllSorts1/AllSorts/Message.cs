using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{
    class Message
    {
      public void GetMessage()
            {
            Console.WriteLine("Выберите сортировку (введите цифру) /n 1 - Сортировка пузырьком ");
            }
      public void GetMessage (int sortName)
        {

            switch (sortName)
            {
                case 1:
                    Console.WriteLine("Сорктировка Пузырьком");
                    Console.ReadKey();
                    break;
            }
        }

    }
}
