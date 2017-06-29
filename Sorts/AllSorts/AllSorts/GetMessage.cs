using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSorts
{
    class GetMessage
    {
        enum SortName {Buble, Vstavka, Vibor, Sliyanie, Shell, QickSort }

        GetMessage(int sortType )
        {

            switch (sortType)
            {
                SortName Sn;

                case SortName.Buble :
                    Console.WriteLine("Вы выбрали сортировку Пузырьком ");
                    break;

                case SortName.Vstavka:
                    Console.WriteLine("Вы выбрали сортировку Вставкой ");
                    break;

                case SortName.Vibor:
                    Console.WriteLine("Вы выбрали сортировку Выбором ");
                    break;

                    /*      case SortName.Sliyanie:
                              Console.WriteLine("Вы выбрали сортировку Слиянием ");
                              break;

                          case SortName.Shell:
                              Console.WriteLine("Вы выбрали сортировку Шелла ");
                              break;
                          case SortName.QickSort:
                              Console.WriteLine("Вы выбрали сортировку Быструю сортировку ");
                             break;*/
            }

        }
    }
}
