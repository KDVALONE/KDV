using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgrammToTrening
{
    struct Temperature  // структура температуры
    {

        private const int zeroTemp = 0; //
        private int cold; // холодно
        private int heat; // жарко
        private int wet; // влажно
        private int soft; // оптимально

        void GetTemperature()
        {
            int temperature;
           
        }

        public int ZeroTemp { get; } 
        public int Cold { get { return cold; } set { cold = value; } } // поля структуры
        public int Heat { get { return heat; } set { heat = value; } }
        public int Wet { get { return wet; } set { wet = value; } }
        public int Soft { get { return soft; } set { soft = value; } }

        public Temperature(int WCold, int WHeat, int WWet, int WSoft) : this()//конструктор
                                                                              //без вызова конструктора по умолчанию (:this()) идет попытка вызвать функцию set для установки поля, 
                                                                              // а это запрещено, так как в структуре поля должны быть проиницилизированы до обращения к ним.
        {   
            Cold = WCold;
            Heat = WHeat;
            Wet = WWet;
            Soft = WSoft;
        }


    }
}
