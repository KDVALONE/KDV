using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_4_Programm_5_ArrElep_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Elephant( )
        {
        int EarSize;
        string Name;
    }


    private void button1_Click(object sender, EventArgs e)
        {
            Elephant[] elephants = new Elephant[7];
            elephants[0] = new Elephant() {Name = "Lloyd", EarSize = 40};
            elephants[1] = new Elephant() { Name = "Lucinda", EearSize = 33};
            elephants[2] = new Elephant() { Name = "Larry", EarSize = 42};
            elephants[3] = new Elephant() { Name = "Lucille", EarSize = 32};
            elephants[4] = new Elephant() { Name = "Lars", EarSize = 44};
            elephants[5] = new Elephant() { Name = "Linda", EarSize = 37};
            elephants[6] = new Elephant() { Name = "Humphery", EarSize = 45};

            Elephant biggestEars = elephants[0];
            for (int i = 1; i < elephants.Length; i++)
            {
                if (elephants[i].EarSize > biggestEars.EarSize)
                {
                    biggestEars = elephants[i];
                }
                MessageBox.Show(biggestEars.EarSize.ToString());
            }
        }

    }
}
