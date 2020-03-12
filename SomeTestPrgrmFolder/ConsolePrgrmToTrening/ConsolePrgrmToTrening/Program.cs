using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using System.IO;
using static System.Linq.Enumerable;

public class Program
{
    public static void Main()
    {
           
    }
 


}


public class MyClassEvent
{
    public bool Enable { get; set; }

    public void ChangeProperty() { Enable = true; }


}

#region Old Program
//public class OLdProgram
//{
//    public static OldMain()
//    {
//        string path = "F:\\Garbage";
//        if (!Directory.Exists(path))
//        {
//            Console.WriteLine("Directory not found");
//            Console.ReadKey();
//            Directory.CreateDirectory(path);
//            Console.ReadKey();
//            Console.WriteLine("Directory created");
//        }
//        else
//        {
//            Console.WriteLine("Directory is existed");
//            Console.ReadKey();
//        }

//        //var a = ConfigurationManager.AppSettings.Get("TestFolder1");
//        //var b = ConfigurationManager.AppSettings.Get("TestFolder2");
//        //if (ConfigurationManager.AppSettings.Get("TestFolder1") == "") { Console.WriteLine("TestFolder1 is null"); }
//        //if (ConfigurationManager.AppSettings.Get("TestFolder2") == null) { Console.WriteLine("TestFolder2 is null"); }

//        Console.ReadKey();

//        Console.WriteLine("GetFileName");

//        string fileName = Path.GetFileName(path);
//        Console.WriteLine(fileName);
//        Console.ReadKey();
//        var destFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
//        string fName = "NTD.txt";

//        string suffix = fName.Substring(fName.Length - 4, 4);

//        var appStorageFolder = Path.Combine(destFolder, fName);

//        var oldFile = path + "\\" + fName;
//        Console.WriteLine();
//        //        var fullPath = Path.Combine(appStorageFolder, relativePath);
//        System.IO.File.Move(oldFile, appStorageFolder);
//        Console.ReadKey();
//    }
//}
#endregion