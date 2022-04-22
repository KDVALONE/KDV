namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            string strCount = count.ToString();
            int lustChrNum = strCount.Length;
            
            int b = int.Parse(strCount.Substring(lustChrNum - 1, 1));
            if (lustChrNum >= 2)
            {
                int a = int.Parse(strCount.Substring(lustChrNum - 2, 1));
                return RefFirstSymbol(a, b, lustChrNum);
                // int a = int.Parse(strCount.Substring(lustChrNum - 2, 1));
                // int b = int.Parse(strCount.Substring(lustChrNum - 1, 1));

                /*if ((a != 0) && (a == 1)) { return "рублей"; }
                else {
                    if (b == 1) { return "рубль"; }
                    else {
                        if ((b == 2) || (b == 3) || (b == 4)) { return "рубля"; }
                        else return "рублей";
                    }
                }*/
            }
            // Напишите
            else {
                return RefSecondSymbol(b, lustChrNum);

                // int b = int.Parse(strCount.Substring(lustChrNum - 1, 1));
                /* if (b == 1) { return "рубль"; }
                 else {
                     if ((b == 2) || (b == 3) || (b == 4)) { return "рубля"; }
                     else return "рублей";
                 }*/
            }
            // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
        }

        static string RefFirstSymbol(int a, int b, int lustChrNum)
        {
            if ((a != 0) && (a == 1)) { return "рублей"; }
            else  return RefSecondSymbol(b, lustChrNum);  
              
            
        }
        static string RefSecondSymbol(int b, int lustChrNum )
        {
            if (b == 1) { return "рубль"; }
            else {
                if ((b == 2) || (b == 3) || (b == 4)) { return "рубля"; }
                else return "рублей";
                 }
         }
    }
}
 

