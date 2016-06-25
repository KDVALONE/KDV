using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_2_Programm_5_WpfColor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* ТУТ МОЙ КОД. НЕ КОРРЕКТНО РАБОТАЕТ    
        private void button1_Click(object sender, EventArgs e)
            {

                for (int i = 0; i < 254; i++)
                {
                    this.BackColor = Color.FromArgb(i, 255 - i, i);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(3);
                }
                 for (int j = 254; j >= 0; j--)
                        {
                            this.BackColor = Color.FromArgb(j, 0 + j, j);
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(3);
                        }
              }
              
        НИЖЕ ПРИВЕДЕН ПРИМЕР ИЗ УЧЕБНИКА*/
        
  private void button1_Click(object sender, EventArgs e)
  {
      while (Visible)
      {
          for (int c = 0; c < 254 && Visible; c++)
          {
              this.BackColor = Color.FromArgb(c, 255 - c, c);
              Application.DoEvents();
              System.Threading.Thread.Sleep(3);
          }
          for (int c = 254; c >= 0 && Visible; c--)
          {
              this.BackColor = Color.FromArgb(c, 255 - c, c);
              Application.DoEvents();
              System.Threading.Thread.Sleep(3);
          }
      }
  }

        //    Доп задание, сделать без FOR, только с while чуть позже попробовать.
     
        }

     }
           
        
        
