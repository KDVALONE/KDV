using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_4_Programm_4_Arrays_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MenuMaker menu = new MenuMaker() { Randomizer = new Random() };

            label1.Text = menu.GetMenuItem();
            label2.Text = menu.GetMenuItem();
            label3.Text = menu.GetMenuItem();
            label4.Text = menu.GetMenuItem();
            label5.Text = menu.GetMenuItem();
            label6.Text = menu.GetMenuItem();

        }
        class MenuMaker
        {
            public Random Randomizer; // обьект Random встроенный класс который гинерит случ. числа.

            string[] Meats = { "Roast beef", "Salami", "Turkey", "Ham", "Pastrami" };
            string[] Condiments = { "Yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing" };
            string[] Breads = { "rye","white","wheat","pumpernickel","italian bread", "a roll" };

            public string GetMenuItem()
            {
                string randomMeat = Meats[Randomizer.Next(Meats.Length)];
                string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
                string randomBread = Breads[Randomizer.Next(Breads.Length)];
                return randomMeat + " with " + randomCondiment + " on " + randomBread;  
            }

        }
    }
}
