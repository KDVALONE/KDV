using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrractTreningPrgm
{
    class TColorGarland : Garland
    {
        public TColorLights Color { get; set; }
      
        private void SetColor()
        {
        }
        private string GetColorAsString()
        {
            return Color.ToString();
        }
        public override void PrintStateOfLights()
        {
            var a = GetColorAsString();
            Console.WriteLine(a);
        }
    }
}
