using SiteParse.Core;
using SiteParse.Core.Habra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteParse
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;

        
        public Form1()
        {
            InitializeComponent();

            parser = new ParserWorker<string[]>(
                     new HabraParser()
                     );

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }
       

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);

        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabraSettings((int)numericStart.Value, (int)numericEnd.Value);
            parser.Start();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
