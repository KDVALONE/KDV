using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_5_Programm_1_inkaps_
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;

        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty() { NuumberOfPeople = 5};
            dinnerParty.SetHealthyOption(false){ }
            dinnerParty.CalculateCostOfDecorations(true){ }
            DisplayDinnerPartyCost() 
                {
                decimal Cost = dinnerParty.CalculateCost(checkBox2.Checked);
                costLabel.Text = Cost.ToString("c");
                }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dinnerParty.NuumberOfPeople = (int)numericUpDown1.Value;
            DisplayDinnerPartyCost();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
