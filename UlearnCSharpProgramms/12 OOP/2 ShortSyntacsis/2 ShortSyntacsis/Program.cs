using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ShortSyntacsis
{/* Ваша команда пишет программу с оконным интерфейсом, 
    и вам надо реализовать инициализацию меню.
    Для каждого пункта меню указывается название, 
    горячая клавиша (далее указана в скобках) и список подменю (null, если подменю нет).
    На верхнем уровне должно находится два пункта: File (F) и Edit (E).
    Меню File должно содержать команды New (N), Save (S).
    Меню Edit (E) должно содержать команды Copy (C) и Paste (V).
    Решите задачу в одно выражение с использованием сокращенного синтаксиса создания объектов. 
    Используйте переводы строк и отступы, чтобы сделать код более читаемым.*/
    class Program
    {
        static void Main(string[] args)
        {

           MenuItem [] menu =  GenerateMenu();
            Console.WriteLine("Готово");
            Console.ReadKey();
        }

        public static MenuItem[] GenerateMenu()
        {
             return new[] {
                new MenuItem {
                    Caption = "File", HotKey = "F", Items = new MenuItem [2] {
                        new MenuItem {Caption = "New", HotKey = "N", Items = null,},
                        new MenuItem {Caption = "Save", HotKey = "S", Items = null,}
                    }
                },
             new MenuItem {
                Caption = "Edit", HotKey = "E", Items = new MenuItem [2]{
                    new MenuItem { Caption = "Copy", HotKey = "C", Items = null,},
                    new MenuItem {Caption = "Past", HotKey = "P", Items = null,}
                }
             }
            };

        }


    }
    public class MenuItem
    {
        public string Caption;
        public string HotKey;
        public MenuItem[] Items;
    }

}
