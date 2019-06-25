using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSeeLayer
{/// <summary>
 /// Написать функцию обхода дерева от корневого элемента.
 /// Как пример использовать класс подразделения(описать класс)
 /// В каждом подразделении есть дочерние подразделения.
 /// Нужно написать фунецию вывода названия подразеделения и уровня вложенности.
 /// К примеру есть иерархия подразделений:
 /// П1( первый уроввень влож.) и у него 2 дочерних.(П1.1 и П1.2)
 /// У подразделения 1.1 есть 3 дочерних подразделения П1.1.1 , П1.1.2, П1.1.3
 /// В консоль вывести след результат:
    /// 1(1)
    /// 1.1(2)
     /// 1.1.1(3)
    /// 1.1.2(3)
    /// 1.1.3(3)
    /// 1.2(2)
    /// </summary>

    class Departament
    {
        public string DepartamentName;
        public int LayerCurrent;
        int IncludedClassNumber;

        public List<Departament> DepIncluded = new List<Departament>();
        public Departament()
        {
            DepartamentName = "1";
            LayerCurrent = 1;
            IncludedClassNumber = 2; 
            for (int i = 1; i <= IncludedClassNumber; i++)
            { 
                DepIncluded.Add(new Departament(DepartamentName, i, LayerCurrent+1));
            }
        }
        public Departament(string depName, int number, int layerCurrent)
        {
            DepartamentName = depName + $"." + number;
            LayerCurrent = layerCurrent;
            switch (layerCurrent)
            {
                case 2:
                    IncludedClassNumber = 3;
                    break;
                case 3:
                    IncludedClassNumber = 0;
                    break;
            }
            if (IncludedClassNumber == 3 && number != 2)
            { 
            for (int i = 1; i <= IncludedClassNumber; i++)
                {
                    DepIncluded.Add(new Departament(DepartamentName, i, LayerCurrent + 1));
                }
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Departament Departament = new Departament();
            SeeDepOnTree(Departament);
            Console.ReadLine();

        }

        public static void SeeDepOnTree(Departament dep)
        {
            ShowDepName(dep);
            if (dep.DepIncluded.Count > 0)
            { 
                foreach (Departament e in dep.DepIncluded)
                {
                    SeeDepOnTree(e);
                }
            }

        }
        public static void ShowDepName(Departament dep)
        {
            Console.WriteLine(dep.DepartamentName + $"({dep.LayerCurrent})");
        }

    }
}
