using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQIntensivePrgrm
{
    class Program
    {
        static string[] names = {"Генри","Ллойд","Арон","Вилсон" };
        static void Main(string[] args)
        {
            var list = new List<string>();
            foreach (var name in names)
            {
                if (name.Contains("л"))
                    list.Add(name.ToUpper());
            }
            var query = names.Where(x => x.Contains("л")).Select(x => x.ToUpper());
            var query2 = from n in names   // то же самое что и в строке выше
                         where n.Contains("л")
                         select n.ToUpper(); 
        }
    }
}
