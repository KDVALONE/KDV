using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static System.Linq.Enumerable;

public class Program
{
    public static void Main()
    {
      
        
        Debugger.Break();
        List<List<int>> DictSortVal = new List<List<int>>();
        List<List<int>> DictBuf = new List<List<int>>();
        List<int> Key = new List<int>   {5,  4, 4,  3,  4, 5,  5, 3, 4,    1,  2, 4,  3, 5, 1,   1, 4, 5};
        List<int> Val = new List<int>() {0, 13, 2,  4, 11, 2,  1, 3, 5,  123, 31, 2,  1, 0, 23,  1, 0, 1};

        Console.WriteLine("before Sort");
        for (int i = 0; i < Key.Count-1; i++)
        {
           
            Console.Write($"{Key[i]} = {Val[i]}, ");
        }

        DictSortVal = BubbleSortVal(  Key.ToArray(), Val.ToArray());
        Console.WriteLine("\n after Sort for  Val");
        for (int i = 0; i < DictSortVal[0].Count - 1; i++)
        {
          
            Console.Write($"{DictSortVal[0][i]} = {DictSortVal[1][i]}, ");
        }
        Debugger.Break();
        DictBuf = BubbleSortKey(DictSortVal[0].ToArray(), DictSortVal[1].ToArray());

        Console.WriteLine("\n after Sort for Key");
        for (int i = 0; i < DictSortVal[0].Count-1; i++)
        {
          Console.Write($"{DictBuf[0][i]} = {DictBuf[1][i]}, ");
        }
        
        #region  some list

        //List<KeyValuePair<int, int>> MyList = new List<KeyValuePair<int, int>>()
        //    {
        //    //new KeyValuePair<int, int>(0, 11),
        //    //new KeyValuePair<int, int>(1, 13),
        //    //new KeyValuePair<int, int>(0, 0),
        //    //new KeyValuePair<int, int>(1, 12),
        //    //new KeyValuePair<int, int>(1, 70),
        //    //new KeyValuePair<int, int>(0, 10),
        //    //new KeyValuePair<int, int>(0, 2)

        //    //new KeyValuePair<int, int>(5, 0),
        //    //new KeyValuePair<int, int>(4, 1),
        //    //new KeyValuePair<int, int>(4, 2),
        //    //new KeyValuePair<int, int>(3, 3),
        //    //new KeyValuePair<int, int>(4, 4),
        //    //new KeyValuePair<int, int>(5, 5),
        //    //new KeyValuePair<int, int>(5, 6),
        //    //new KeyValuePair<int, int>(4, 7),
        //    //new KeyValuePair<int, int>(4, 8),
        //    //new KeyValuePair<int, int>(3, 9),
        //    //new KeyValuePair<int, int>(5, 10),
        //    //new KeyValuePair<int, int>(5, 11),
        //    //new KeyValuePair<int, int>(3, 13),
        //    //new KeyValuePair<int, int>(4, 14),
        //    //new KeyValuePair<int, int>(3, 15),
        //    //new KeyValuePair<int, int>(5, 16),
        //    //new KeyValuePair<int, int>(5, 17),
        //    //new KeyValuePair<int, int>(3, 24),
        //    //new KeyValuePair<int, int>(3, 25),
        //    //new KeyValuePair<int, int>(3, 28),
        //    //new KeyValuePair<int, int>(4, 29),
        //    //new KeyValuePair<int, int>(3, 30),
        //    //new KeyValuePair<int, int>(3, 32),
        //    //new KeyValuePair<int, int>(3, 34)
        //}
        #endregion

        Console.ReadKey();
    }

    static void Swap(ref int e1, ref int e2)
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;
    }

    //сортировка пузырьком
    static List<List<int>> BubbleSortKey(int[] key,int [] val)
    {
        var len = key.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (key[j] > key[j + 1])
                {
                    Swap(ref key[j], ref key[j + 1]);
                    Swap(ref val[j],ref val[j+1]);
                }
            }
        }
        List<int> sortKey = new List<int>();
        List<int> sortVal = new List<int>();

        foreach (var e in key) { sortKey.Add(e); }
        foreach (var e in val) { sortVal.Add(e); }
        List<List<int>> custDict = new List<List<int>>();
        custDict.Add(sortKey);
        custDict.Add(sortVal);
        return custDict;
    }
    static List<List<int>> BubbleSortVal(int[] key, int[] val)
    {
        var len = key.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (val[j] > val[j + 1])
                {
                    Swap(ref key[j], ref key[j + 1]);
                    Swap(ref val[j], ref val[j + 1]);
                }
            }
        }
        List<int> sortKey = new List<int>();
        List<int> sortVal = new List<int>();

        foreach (var e in key) { sortKey.Add(e); }
        foreach (var e in val) { sortVal.Add(e); }
        List<List<int>> custDict = new List<List<int>>();
        custDict.Add(sortKey);
        custDict.Add(sortVal);
        return custDict;
    }


}

