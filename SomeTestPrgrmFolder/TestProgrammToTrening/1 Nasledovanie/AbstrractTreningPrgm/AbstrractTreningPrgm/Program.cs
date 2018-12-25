using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrractTreningPrgm
{
    class Program
    {
        /// <summary>
        /// Создать абстрактный класс Garland и специализировать его классами-потомками 
        /// TSimpleGarland и TColorGarland, что являются абстракциями одноцветной и цветной гирлянд 
        /// соответственно. В качестве элементов первой гирлянды использовать класс TLight .
        /// В качестве элементов цветной гирлянды использовать экземпляры класса TColorLight, 
        /// что является расширением класса TLight за счет введения одного поля FColor типа TLightColor 
        /// (может принимать значения: lcGreen, lcRed, lcYellow, lcBlue), метода SetColor 
        /// (устанавливает цвет лампочки через тип TLightColor) и метода GetColorAsString, 
        /// что возвращает цвет лампочки в виде строчной типа. Для хранения объектов-лампочек в обоих 
        /// гирляндах использовать экземпляр класса TList (объявлен в модуле classes). 
        /// Количество лампочек в обоих классах фиксированная и равен 12. Для обоих гирлянд создать 
        /// метод PrintStateOfLights, что выводит в консоль состояние лампочек: включена-выключена 
        /// для обоих случаев и цвет лампочки для случая цветной гирлянды. При создании цветной 
        /// гирлянды установить цвет лампочки в зависимости от кратности ее порядкового номера 
        /// в гирлянде: последовательно зеленая, красная, желтая, голубая.
        /// </summary>
        /// <param name="args"></param>


        static void Main(string[] args)
        {
            TColorGarland tCGrld = new TColorGarland();
            tCGrld.PrintStateOfLights();
            Console.ReadKey();
            

        }
        
    }
}
