using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_4_Programm_3_ClassElep_
{
    public partial class Form1 : Form
    {
        Elephant lucinda;
        Elephant lloyd;
        Elephant buf;
        public Form1()
        {
            InitializeComponent();
             lucinda = new Elephant() { Name = "Lucinda",EarSize = 33  };
             lloyd = new Elephant() { Name = "Lloyd", EarSize = 40  };
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            lucinda.WhoAml();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lloyd.WhoAml();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buf = lucinda;
            lucinda = lloyd;
            lloyd = buf;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lloyd.TellMe("Hi", lucinda);
        }
    }
    public class Elephant
    {
        public int EarSize;
        public string Name;

        public void WhoAml()
        {
            MessageBox.Show("My ears are " + EarSize + " inherit tall.", Name + "says...");
        }
        public void TellMe(string message, Elephant whoSaidIt)
        {
            MessageBox.Show (whoSaidIt.Name + " says: " + message);
        }
        public void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.TellMe(message, this);
        }
    }
}
