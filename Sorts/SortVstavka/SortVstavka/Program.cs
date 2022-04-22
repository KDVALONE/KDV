using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVstavka
{
    class Program
    {
        // Сортировка вставками. Она затратна для памяти и эффективна на небольших наборах данных. 
        // Рекомендуется использовать этот метод на наборах размером до десятков элементов.
        // эфективна на полседователтностях данных которые уже частично отсортированны.

        /*Первый элемент в массиве образует уже отсортированную последовательность. Сравниваем второй элемент с первым.
        Если порядок между ними нарушен, то первый элемент передвигается на одну позицию вправо. 
        Теперь отсортированный массив состоит из двух элементов.
        Далее, в течении каждой итерации, берем следующий элемент (третий, четвертый и т.д) и сравниваем его поочередно 
        с другими элементами в уже отсортированном списке, начиная с конца этого списка. Если порядок между сравниваемыми элементами нарушен,
        то меняем их местами, если нет, то “вставка” нового элемента закончена, переходим к следующему.*/

        public void SotrVst(int[] array)
        {
            int location, newElement, j = array.Length;

            
            for (int i = 1; i < j; i++)
            {
                newElement = array[i];
                location = i - 1;
                while (location >= 0 && array[location] > newElement)
                {
                    array[location + 1] = array[location];
                    location = location - 1;
                }
                array[location + 1] = newElement;

            }
            foreach(int e in  array)
            Console.WriteLine(e); 


        }

        static void Main()
        {
            Program p = new Program();
            int[] array = { 2, 4, 2, 9, 6 };
            foreach (int e in  array)
            Console.WriteLine(e);
            p.SotrVst(array);
            Console.ReadKey();
            

        }
    }
}
