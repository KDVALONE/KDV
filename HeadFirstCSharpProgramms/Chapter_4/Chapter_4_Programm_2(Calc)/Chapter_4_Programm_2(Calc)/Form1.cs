using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_4_Programm_2_Calc_
{
    public partial class Form1 : Form
    {
        int startingMuleage;
        int endingMileage;
        double milesTraveled;
        double reimburseRate = .39;
        double amountOwed;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startingMuleage = (int)numericUpDown1.Value;
            endingMileage = (int)numericUpDown2.Value;
            if (startingMuleage < endingMileage)
            {
               
                milesTraveled = endingMileage - startingMuleage;
                amountOwed = milesTraveled * reimburseRate;
                label4.Text = amountOwed + "";
            } else {
                MessageBox.Show ("Не возможно расчитать");
            } 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(milesTraveled + "", "MILES TRAVELED");
        }
    }
}
