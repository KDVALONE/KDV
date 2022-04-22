using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using static System.Linq.Enumerable;


public class Program
{
    public static void Main()
    {
        Method();
    }


    public  static void Method()
    {
        bool flag = false;
        Console.WriteLine($"start flag = @{flag}");
        int count = 0;
        while (!flag )
        {
            Console.WriteLine(flag);
            if (count == 5) { flag = true; }
            count++;
        }
        Console.WriteLine($"final flag = @{flag}");
        Console.ReadKey();
    }
    static IEnumerable<TreeNode1> GetChildren(TreeNode1 root)
    {
        foreach (TreeNode1 childNode in root.Children)
        {
            yield return childNode;
            foreach (TreeNode1 node in GetChildren(childNode))
            {
                yield return node;
            }
        }
    }

}
class TreeNode1
{
    public IEnumerable<TreeNode1> Children { get; }
}


