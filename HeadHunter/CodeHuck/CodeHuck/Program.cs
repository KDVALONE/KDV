using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeHuck
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass mc = new MyClass();
            //mc.FindAllCodeVariant();

           CodeListGenerator clg = new CodeListGenerator();
           var v = clg.GetListCode("0123456789");
            Debugger.Break();
            Console.Read();
        }
    }


    class MyClass
    {
        public int[][] CodePanel =
        {
            new int[]{3,6,9},
            new int[]{2,5,8,0},
            new int[]{1,4,7}
        };

        // public int Code = 1357;
        public int Code = 11;
        public StringBuilder CodeVariantsSb = new StringBuilder();
        public List<List<int>> SymbolVariant = new List<List<int>>();
        public void FindAllCodeVariant()
        {
           // CodeVariantsSb.AppendLine(Code.ToString());
            var codeArraySb = GetCodeArraySb();
            for (int i = 0; i < codeArraySb.Length; i++)
            {
                SymbolVariant.Add(new List<int>());
                SymbolVariant[i].Add(codeArraySb[i]);
                SetCodeVariants((int)char.GetNumericValue(codeArraySb[i]), i, codeArraySb);
                SymbolVariant[i].Sort();
            }

            for (int i = 0; i< SymbolVariant.Count; i++)
            {
                for (int j = SymbolVariant.Count; j >= 0; j--)
                {

                }
            }

            Console.WriteLine(CodeVariantsSb);
        }

        public StringBuilder GetCodeArraySb()
        {
            var temp = Code.ToString();
            StringBuilder codeSb = new StringBuilder();

            foreach (var e in temp)
            {
                codeSb.Append(e);
            }

            return codeSb;
        }

        public void SetCodeVariants(int symbol, int symbolCurrentIndex, StringBuilder codeArraySb)
        {
            GetIndexCodePanelElement(symbol, out int[] elementCpIndex); //y,x
            if (elementCpIndex[0] < 0 || elementCpIndex[1] < 0) { throw new Exception("Invalid element CodePanel index"); }
            GetCodeWithNewLeftElement(elementCpIndex, symbolCurrentIndex, codeArraySb);
            GetCodeWithNewUpElement(elementCpIndex, symbolCurrentIndex, codeArraySb);
            GetCodeWithNewRightElement(elementCpIndex, symbolCurrentIndex, codeArraySb);
            GetCodeWithNewDownElement(elementCpIndex, symbolCurrentIndex, codeArraySb);



        }

        private void GetIndexCodePanelElement(int symbol, out int[] elementCpIndex)
        {
            var x = -1;
            var y = -1;
            for (int i = 0; i < CodePanel.GetLength(0); i++)
            {
                for (int j = 0; j < CodePanel[i].GetLength(0); j++)
                {
                    if (symbol == CodePanel[i][j]) { y = i; x = j; break; }
                }
            }
            elementCpIndex = new[] { y, x };
        }

        private void GetCodeWithNewLeftElement(int[] elementCpIndex, int elementOldIndex, StringBuilder codeArraySb)
        {
            if ((elementCpIndex[1] - 1) >= 0)
            {
                var leftElement = CodePanel[elementCpIndex[0]][elementCpIndex[1] - 1];
                SymbolVariant[elementOldIndex].Add(leftElement);
               // ReplaceElementAtCode(elementOldIndex, leftElement, codeArraySb);
            }
        }
        private void GetCodeWithNewUpElement(int[] elementCpIndex, int elementOldIndex, StringBuilder codeArraySb)
        {
            if ((elementCpIndex[0] - 1) >= 0 &&
                (CodePanel[elementCpIndex[0] - 1].GetLength(0) >= elementCpIndex[1]))
            {
                var upElement = CodePanel[elementCpIndex[0] - 1][elementCpIndex[1]];
                SymbolVariant[elementOldIndex].Add(upElement);
             //   ReplaceElementAtCode(elementOldIndex, upElement, codeArraySb);
            }
        }
        private void GetCodeWithNewRightElement(int[] elementCpIndex, int elementOldIndex, StringBuilder codeArraySb)
        {
            if ((elementCpIndex[1] + 1) < CodePanel[elementCpIndex[0]].GetLength(0))
            {
                var rightElement = CodePanel[elementCpIndex[0]][elementCpIndex[1] + 1];
                SymbolVariant[elementOldIndex].Add(rightElement);
              //  ReplaceElementAtCode(elementOldIndex, rightElement, codeArraySb);
            }
        }
        private void GetCodeWithNewDownElement(int[] elementCpIndex, int elementOldIndex, StringBuilder codeArraySb)
        {
            if ((elementCpIndex[0] + 1) < CodePanel.GetLength(0) &&
                (CodePanel[elementCpIndex[0] + 1].GetLength(0) >= elementCpIndex[1]))
            {
                var downElement = CodePanel[elementCpIndex[0] + 1][elementCpIndex[1]];
                SymbolVariant[elementOldIndex].Add(downElement);
             //   ReplaceElementAtCode(elementOldIndex, downElement, codeArraySb);
            }
        }

        private void ReplaceElementAtCode(int elementOldIndex, int elementNew, StringBuilder codeArraySb)
        {
            var sbLocal = new StringBuilder();
            var code = int.Parse(codeArraySb.ToString());
            sbLocal.Append(code);
            sbLocal[elementOldIndex] = char.Parse(elementNew.ToString());
            CodeVariantsSb.Append(" " + sbLocal);
        }

    }

    //Переписываю код получения листа с вариантами числа
    class CodeListGenerator
    {
        public int[][] CodePanel =
        {
            new int[]{3,6,9},
            new int[]{2,5,8,0},
            new int[]{1,4,7}
        };

        public List<List<char>> GetListCode(string code)
        {
            List<List<char>> ListCode = new List<List<char>>();

            var codeArr = GetCodeAsCharArray(code);

            for (int i = 0; i < codeArr.Length; i++)
            {
                ListCode.Add(new List<char>());
                ListCode[i].Add(codeArr[i]);// а, ну мы собственно записываем сам символ
                SetCodeVariants((int)char.GetNumericValue(codeArr[i]), i, ListCode);
                ListCode[i].Sort();
            }

            Debugger.Break();
            return ListCode;
        }

        public void SetCodeVariants(int symbol, int symbolCurrentIndex, List<List<char>> ListCode)
        {
            int [] indexArr = new int[2];
            indexArr = GetIndexCodePanelElement(symbol, indexArr); //y,x
            GetCodeWithNewLeftElement(indexArr, symbolCurrentIndex, ListCode);
            GetCodeWithNewUpElement(indexArr, symbolCurrentIndex, ListCode);
            GetCodeWithNewRightElement(indexArr, symbolCurrentIndex, ListCode);
            GetCodeWithNewDownElement(indexArr, symbolCurrentIndex, ListCode);
        }

        
        private void GetCodeWithNewLeftElement(int[] elementCpIndex, int elementOldIndex, List<List<char>> ListCode)
        {
            if ((elementCpIndex[1] - 1) >= 0)
            {
                var leftElement = CodePanel[elementCpIndex[0]][elementCpIndex[1] - 1];
                ListCode[elementOldIndex].Add(Convert.ToChar(leftElement.ToString()));
            }
        }
        private void GetCodeWithNewUpElement(int[] elementCpIndex, int elementOldIndex, List<List<char>> ListCode)
        {
            if ((elementCpIndex[0] - 1) >= 0 &&
                (CodePanel[elementCpIndex[0] - 1].GetLength(0) >= elementCpIndex[1] + 1))
             {
                var upElement = CodePanel[elementCpIndex[0] - 1][elementCpIndex[1]];
                ListCode[elementOldIndex].Add(Convert.ToChar(upElement.ToString()));
            }

        }
        private void GetCodeWithNewRightElement(int[] elementCpIndex, int elementOldIndex, List<List<char>> ListCode)
        {
            if ((elementCpIndex[1] + 1) < CodePanel[elementCpIndex[0]].GetLength(0))
            {
                var rightElement = CodePanel[elementCpIndex[0]][elementCpIndex[1] + 1];
                ListCode[elementOldIndex].Add(Convert.ToChar(rightElement.ToString()));
            }
        }
        private void GetCodeWithNewDownElement(int[] elementCpIndex, int elementOldIndex, List<List<char>> ListCode)
        {
            if ((elementCpIndex[0] + 1) < CodePanel.GetLength(0) &&
                (CodePanel[elementCpIndex[0] + 1].GetLength(0) >= elementCpIndex[1] + 1))
            {
                var downElement = CodePanel[elementCpIndex[0] + 1][elementCpIndex[1]];
                ListCode[elementOldIndex].Add(Convert.ToChar(downElement.ToString()));
            }
        }


        //получить индекс элемента кода на СodePanel
        private int[] GetIndexCodePanelElement(int symbol,  int[] elementCpIndex)
        {
            var x = -1;
            var y = -1;
            for (int i = 0; i < CodePanel.GetLength(0); i++)
            {
                for (int j = 0; j < CodePanel[i].GetLength(0); j++)
                {
                    if (symbol == CodePanel[i][j]) { y = i; x = j; break; }
                }
            }
            return new[] { y, x };
        }

        // преобразовать код в массив char
        public char[] GetCodeAsCharArray(string code)
        {
            return code.ToCharArray();
        }
    }
}
