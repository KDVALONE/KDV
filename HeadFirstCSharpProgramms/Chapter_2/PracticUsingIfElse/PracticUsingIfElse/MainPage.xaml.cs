using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PracticUsingIfElse
{
  
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        int f = 0;
        private void changeText_Click(object sender, RoutedEventArgs e)
        {
            if (enableCheckBox.IsChecked == true)
            {
                if (labelToChange.Text == "Right")
                {
                    labelToChange.Text = "Left";
                    labelToChange.HorizontalAlignment = HorizontalAlignment.Left;
                }
                else
                {
                    labelToChange.Text = "Right";
                    labelToChange.HorizontalAlignment = HorizontalAlignment.Right;
                    f = 1;
                }
            }
            else
            {
                labelToChange.Text = "Text changing is disabled ";
                labelToChange.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }
    }
}
