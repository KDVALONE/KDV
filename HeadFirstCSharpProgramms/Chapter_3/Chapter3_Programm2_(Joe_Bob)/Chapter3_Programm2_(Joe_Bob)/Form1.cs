using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter3_Programm2__Joe_Bob_
{
    public partial class Form1 : Form
    {
        Guy joe;
        Guy bob;
        int bank = 100;
        public void UpdateForm() {
            joesCashLabel.Text = joe.Name + "имеет $" + joe.Cash;
            bobsCashLabel.Text = bob.Name + " имеет $" + bob.Cash;
            bankCashLabel.Text = "в банке сейчас $" + bank;
        }
        public Form1()
        {
            InitializeComponent();
            joe = new Guy() { Cash = 50, Name = "Joe" };

            bob = new Guy() { Name = "Bob", Cash = 100,  };
            UpdateForm();
        /*    bob.Name = "Bob";
            bob.Cash = 100;
            UpdateForm();
            */
        }
        

        class Guy
        {
            public string Name;
            public int Cash;

            public int GiveCash(int amount)
            {
                if (amount <= Cash && amount > 0)
                {
                    Cash -= amount;
                    return amount;
                }
                else {
                    MessageBox.Show("У меня не хватает денег " + amount,
                        Name + " Говорит...");
                    return 0;
                }
            }
         public int ReceiveCash(int amount){
                if (amount > 0)
                {
                    Cash += amount;
                    return amount;
                }else {
                    MessageBox.Show(amount + "мне не нужно", Name +
                        " говорит...");
                    return 0;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if (bank >= 10)            {
                bank -= joe.ReceiveCash(10);
                UpdateForm();
            } else
            {
                MessageBox.Show("В банке нет денег.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bank += bob.GiveCash(5);
            UpdateForm();
        }

        private void joeGivesToBob_Click(object sender, EventArgs e)
        {
            if (joe.Cash >= 10)
            {
                joe.Cash -= bob.ReceiveCash(10);
                UpdateForm();
            } else
            {
                MessageBox.Show("У Джо не хватает денег.");
            }
            
        }

        private void bobGivesToJoe_Click(object sender, EventArgs e)
        {
            if (bob.Cash >= 10)
            {
                bob.Cash -= joe.ReceiveCash(10);
                UpdateForm();
            }
            else
            {
                MessageBox.Show("У Боба не хватает денег.");
            }

        }
    }
}
