using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;
using Microsoft.Win32;


namespace TestNameSpace
{

    class Program
    {
        public static void Main()
        {
            //MySecondEx mc = new MySecondEx();
            //mc.GetAllVariant();
            AntonEx aEx = new AntonEx();
            aEx.Go();


            Console.ReadKey();
        }
    }





    // решение CyberForum
    public class MyClass2
    {
        public void CodeVariantMethod(string s)
        {

            var dict = new Dictionary<char, List<char>>
            {
                {
                    '1', new List<char> {'1', '2', '4'}
                },
                {
                    '2', new List<char> {'1', '2', '3', '5'}
                },
                {
                    '3', new List<char> {'2', '3', '6'}
                },
                {
                    '4', new List<char> {'1', '4', '5', '7'}
                },
                {
                    '5', new List<char> {'2', '4', '5', '6', '8'}
                },
                {
                    '6', new List<char> {'3', '5', '6', '9',}
                },
                {
                    '7', new List<char> {'4', '7', '8'}
                },
                {
                    '8', new List<char> {'5', '7', '8', '9'}
                },
                {
                    '9', new List<char> {'6', '8', '9'}
                },
                {
                    '0', new List<char> {'0', '8'}
                },

            };



            for (int i = 0; i < s.Length; i++)
            {
                List<char> value;
                if (dict.TryGetValue(s[i], out value))
                {
                    for (int j = 0; j < value.Count; j++)
                    {

                        for (int k = 0; k < s.Length; k++)
                        {
                            if (k == i) Console.Write(value[j]);
                            else Console.Write(s[k]);
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
            }

            Debugger.Break();
        }
    }

    // Cyberforum O(n) перебор всех значений в массиве 
    public static class MyClass4
    {
        static List<List<int>> comb;
        static bool[] used;

        public static void GetCombinationSample()
        {
            // int[] arr = { 10, 50, 3, 1, 2 };
            int[] arr = { 1, 2 };
            used = new bool[arr.Length];
            //used.Fill(false);// заполняет каждую ячейку массива False, хотя по умолчанию и так фолс, так что можно выпилить
            comb = new List<List<int>>();
            List<int> c = new List<int>();
            GetComb(arr, 0, c);
            foreach (var item in comb)
            {
                foreach (var x in item)
                {
                    Console.Write(x + ",");
                }

                Console.WriteLine("");
            }
        }

        static void GetComb(int[] arr, int colindex, List<int> c)
        {

            if (colindex >= arr.Length)
            {
                comb.Add(new List<int>(c));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    c.Add(arr[i]);
                    GetComb(arr, colindex + 1, c);
                    c.RemoveAt(c.Count - 1);
                    used[i] = false;
                }
            }
        }
    }

    //CyberForum очень быстрый перебор всех элементов массива  (нет)
    public static class MyClass5
    {
        public static void GetArrayElement()
        {
            // string[] array = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            //string[] array = { "1", "2", "4" };
            string[] array = { "1", "2", "4", "2", "3", "6" };
            int arrDeep = 3; // до какой цифры осуществлять перебор
            int genues = 2; // до какого рзаряда делать вывод (123) - 3 разряда, 12 - 2 разряда

            // Math.Pow(x,y) это встроеная библиотека в С# с методом возведения в степень, где x - число, а y - степень в которую его нужно возвести.  
            for (int i = 0; i < Math.Pow(arrDeep, genues); i++)
            {
                string s = "";
                int ii = i;
                for (int j = 0; j < genues; j++)
                {
                    s = array[ii % arrDeep] + s;
                    ii /= arrDeep;
                }

                Console.WriteLine(s); // вывод на консоль
            }
        }
    }

    //************************************************
    // мое решение1
    public class MyClass
    {
        public List<List<string>> ArrList = new List<List<string>>();

        public MyClass()
        {
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            //ArrList.Add(new List<string> {"1","2","3","5"});
            //ArrList.Add(new List<string> {"2", "3", "6"});
            //ArrList.Add(new List<string> {"1", "4", "5","7"});
            //ArrList.Add(new List<string> {"2", "4", "5","6","8"});
            //ArrList.Add(new List<string> { "3", "5", "6","9"});
            //ArrList.Add(new List<string> {"4", "7", "8"});
            //ArrList.Add(new List<string> {"5", "7", "8","9"});
            //ArrList.Add(new List<string> {"0","6", "8", "9"});
            //ArrList.Add(new List<string> {"0", "8"});
        }

        public void Foo()
        {
            List<string> bufferListString = new List<string>();
            int n = ArrList.Count; // Колличество листов в листе, а так же кол-во итераций
            int iteration = 0; //текущая итерация
            if (ArrList.Count > 1)
            {
                int i = 0;
                for (int j = 0; j < ArrList[i].Count; j++)
                {

                    for (int x = iteration + 1; x < ArrList.Count; x++)
                    {
                        for (int y = 0; y < ArrList[x].Count; y++)
                        {
                            bufferListString.Add(ArrList[i][j] + ArrList[x][y]);
                        }
                    }

                    if (j + 1 >= ArrList[i].Count && iteration < n)
                    {
                        iteration++;
                        j = -1;
                        ArrList[i].Clear();
                        ArrList[i].AddRange(bufferListString);
                        bufferListString.Clear();
                    }

                    if (iteration == n - 1)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < (ArrList[0]).Count; i++)
                {
                    bufferListString.Add((ArrList[0])[i]);

                }
                ArrList[0].Clear();
                ArrList[0].AddRange(bufferListString);
                bufferListString.Clear();
            }

            foreach (var e in ArrList[0])
            {
                Console.WriteLine(e);

            }
        }


    }



    //Мое решение2 топчик
    public class MySecondEx
    {
        List<List<string>> ArrList = new List<List<string>>();
        private int[] IndexOfArrList;

        public MySecondEx()
        {
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });
            ArrList.Add(new List<string> { "1", "2", "4" });


        }


        public void GetAllVariant()
        {

            IndexOfArrList = new int[ArrList.Count];
            for (int i = 0; i < IndexOfArrList.Length; i++)
            {
                IndexOfArrList[i] = 0;
            }
            StringBuilder sb = new StringBuilder(); // 0.07cек 300 кб
            // var s = ""; //0.47 сек 150кб
            bool indexChange = false;
            //перебор массива с индексами для кода
            for (int i = 0; i < IndexOfArrList.Length; i++)
            {
                // s += (ArrList[i])[IndexOfArrList[i]];
                sb.Append((ArrList[i])[IndexOfArrList[i]]);

                // тут мы проверяме что дошли до последнего списка (последнего разряда)
                if (i == (ArrList).Count - 1)  //тут проверять!
                {
                    //  s += "\n";
                    sb.AppendLine();
                    // здесь мы обновляем индексы
                    for (int j = IndexOfArrList.Length - 1; j >= 0; j--)
                    {
                        if (IndexOfArrList[j] < (ArrList[j]).Count)
                        {
                            IndexOfArrList[j] += 1;
                            indexChange = true;
                        }

                        if (IndexOfArrList[j] == (ArrList[j]).Count)
                        {
                            if (IndexOfArrList[0] == (ArrList[0]).Count)
                            {
                                indexChange = false; break;
                            }
                            IndexOfArrList[j] = 0;
                            indexChange = false;
                        }

                        if (indexChange) { indexChange = false; break; }
                    }
                    if (IndexOfArrList[0] > ArrList[0].Count - 1)
                    {
                        break;
                    }
                    i = -1;
                }
            }

            Debugger.Break();
            Console.WriteLine(sb.ToString());
            // Console.WriteLine(s);
        }






        //array = 77777777 елементов
        //заполнение list<int> 0,7sec  524,318мб
        List<int> myList = new List<int>();

        public void Foo()
        {
            //  List<int> myList = new List<int>();
            for (int i = 11111111; i < 88888888; i++)
            {
                myList.Add(i);
            }


        }

        public void Foo2()
        {
            Console.WriteLine(myList);
        }

        //метод для заполнения массива
        public void Bar()
        {
            HashSet<char> hs = new HashSet<char>();
            SortedSet<int> ss = new SortedSet<int>();
            List<int> list = new List<int>();
            char a = 'a';
            for (int i = 11111111; i < 88888888; i++)
            {

                list.Add(i);

            }

            var s = String.Join(", ", list.ToArray());
            Console.WriteLine(hs);
        }






    }

    public class MyThirdEx
    {
        List<List<string>> ListSymVar = new List<List<string>>();
        private int[] ArrIndex;
        StringBuilder sb = new StringBuilder(); // 0.07cек 300 кб было

        public MyThirdEx()
        {
            ListSymVar.Add(new List<string> { "1", "2", "4" });
            ListSymVar.Add(new List<string> { "1", "2", "4" });
            ListSymVar.Add(new List<string> { "1", "2", "4" });
            ListSymVar.Add(new List<string> { "1", "2", "4" });
            ListSymVar.Add(new List<string> { "1", "2", "4" });
            ListSymVar.Add(new List<string> { "1", "2", "4" });
            ListSymVar.Add(new List<string> { "1", "2", "4" });
            ListSymVar.Add(new List<string> { "1", "2", "4" });
        }

        public void GetAllVariant()
        {
            // инициализация массива индексов
            ArrIndex = new int[ListSymVar.Count];
            for (int i = 0; i < ArrIndex.Length; i++)
            {
                ArrIndex[i] = 0;
            }

            bool gradeChanged = false;

            // ******** основной алгоритм ********

            // двигаем корретку по верхним элементам
            for (int i = 0; i < ArrIndex.Length; i++)
            {
                //записать все элементы в верхней корретке
                sb.Append((ListSymVar[i])[ArrIndex[i]]);
                //если дошли до последнего элемента 
                if (i + 1 == ArrIndex.Length)
                {
                    sb.Append(',');
                    // если это последний элемент в грейде
                    if (ArrIndex[i] + 1 == ListSymVar[i].Count && gradeChanged == false)
                    {
                        //Идем по грейдам с конца к началу
                        //увеличиваем грейды и записываем в индексы
                        for (int j = ArrIndex.Length - 1; j > -1; j--)
                        {
                            ArrIndex[j]++;
                            if (ArrIndex[j] > ListSymVar[j].Count)
                            {
                                gradeChanged = true;
                                ArrIndex[j] = 0;
                                if (gradeChanged) { gradeChanged = false; break; }
                            }
                        }
                    }

                }



            }




        }

    }

    // решение Антона друга Никиты
    public class AntonEx
    {
        public void Go()
        {
            List<string> End = new List<string>();


            string[][] Keypad = new string[10][];
            Keypad[0] = new string[] { "0", "8" };
            Keypad[1] = new string[] { "1", "2", "4" };
            Keypad[2] = new string[] { "1", "2", "3", "5" };
            Keypad[3] = new string[] { "2", "3", "6" };
            Keypad[4] = new string[] { "1", "4", "5", "7" };
            Keypad[5] = new string[] { "2", "4", "5", "6", "8" };
            Keypad[6] = new string[] { "3", "5", "6", "9" };
            Keypad[7] = new string[] { "4", "7", "8" };
            Keypad[8] = new string[] { "0", "5", "7", "8", "9" };
            Keypad[9] = new string[] { "6", "8", "9" };

            // string Pin = Console.ReadLine();
            string Pin = "11111111";
            int[] PinInt = new int[Pin.Length];// массив введенного пин-кода int
            for (int i = 0; i < Pin.Length; i++)
                PinInt[i] = Convert.ToInt32(Pin[i].ToString());

            int[] Index = new int[Pin.Length]; //массив кол-ва ошибок данного символа пинкода
            for (int i = 0; i < Pin.Length; i++)
                Index[i] = Keypad[PinInt[i]].Length;

            Console.WriteLine();
            switch (Pin.Length)
            {
                case 1:
                    for (int i = 0; i < Index[0]; i++)
                        End.Add(Keypad[PinInt[0]][i] + ",");
                    break;
                case 2:
                    for (int i = 0; i < Index[0]; i++)
                        for (int j = 0; j < Index[1]; j++)
                            End.Add(Keypad[PinInt[0]][i] + Keypad[PinInt[1]][j] + ",");
                    break;
                case 3:
                    for (int i = 0; i < Index[0]; i++)
                        for (int j = 0; j < Index[1]; j++)
                            for (int m = 0; m < Index[2]; m++)
                                End.Add(Keypad[PinInt[0]][i] + Keypad[PinInt[1]][j] + Keypad[PinInt[2]][m] + ",");
                    break;
                case 4:
                    for (int i = 0; i < Index[0]; i++)
                        for (int j = 0; j < Index[1]; j++)
                            for (int m = 0; m < Index[2]; m++)
                                for (int h = 0; h < Index[3]; h++)
                                    End.Add(Keypad[PinInt[0]][i] + Keypad[PinInt[1]][j] + Keypad[PinInt[2]][m] + Keypad[PinInt[3]][h] + ",");
                    break;
                case 5:
                    for (int i = 0; i < Index[0]; i++)
                        for (int j = 0; j < Index[1]; j++)
                            for (int m = 0; m < Index[2]; m++)
                                for (int h = 0; h < Index[3]; h++)
                                    for (int u = 0; u < Index[4]; u++)
                                        End.Add(Keypad[PinInt[0]][i] + Keypad[PinInt[1]][j] + Keypad[PinInt[2]][m]
                                            + Keypad[PinInt[3]][h] + Keypad[PinInt[4]][u] + ",");
                    break;
                case 6:
                    for (int i = 0; i < Index[0]; i++)
                        for (int j = 0; j < Index[1]; j++)
                            for (int m = 0; m < Index[2]; m++)
                                for (int h = 0; h < Index[3]; h++)
                                    for (int u = 0; u < Index[4]; u++)
                                        for (int f = 0; f < Index[5]; f++)
                                            End.Add(Keypad[PinInt[0]][i] + Keypad[PinInt[1]][j] + Keypad[PinInt[2]][m]
                                            + Keypad[PinInt[3]][h] + Keypad[PinInt[4]][u] + Keypad[PinInt[5]][f] + ",");
                    break;
                case 7:
                    for (int i = 0; i < Index[0]; i++)
                        for (int j = 0; j < Index[1]; j++)
                            for (int m = 0; m < Index[2]; m++)
                                for (int h = 0; h < Index[3]; h++)
                                    for (int u = 0; u < Index[4]; u++)
                                        for (int f = 0; f < Index[5]; f++)
                                            for (int d = 0; d < Index[6]; d++)
                                                End.Add(Keypad[PinInt[0]][i] + Keypad[PinInt[1]][j] + Keypad[PinInt[2]][m]
                                                + Keypad[PinInt[3]][h] + Keypad[PinInt[4]][u] + Keypad[PinInt[5]][f]
                                                + Keypad[PinInt[6]][d] + ",");
                    break;
                case 8:
                    for (int i = 0; i < Index[0]; i++)
                        for (int j = 0; j < Index[1]; j++)
                            for (int m = 0; m < Index[2]; m++)
                                for (int h = 0; h < Index[3]; h++)
                                    for (int u = 0; u < Index[4]; u++)
                                        for (int f = 0; f < Index[5]; f++)
                                            for (int d = 0; d < Index[6]; d++)
                                                for (int g = 0; g < Index[7]; g++)
                                                    End.Add(Keypad[PinInt[0]][i] + Keypad[PinInt[1]][j] + Keypad[PinInt[2]][m]
                                                    + Keypad[PinInt[3]][h] + Keypad[PinInt[4]][u] + Keypad[PinInt[5]][f]
                                                    + Keypad[PinInt[6]][d] + Keypad[PinInt[7]][g] + ",");
                    break;

            }

            for (int i = 0; i < End.Count; i++)
                Console.Write(End[i]);

        }
    }
}





