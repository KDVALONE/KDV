using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SomeXamlPrjct
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button myButton = new Button();
            myButton.Width = 200;
            myButton.Height = 30;
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            //Image image = new Image { Source = new BitmapImage(new Uri("C:/Users/Dmitry/Desktop/btnMy.png")) };
           
            myButton.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            myButton.Content = "Кнопка2";
            layoutGrid.Children.Add(myButton);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox1.Text;
            if (text != "")
            {
                MessageBox.Show(text);
            }
        }
        private void Button_Double_Click(object sender, RoutedEventArgs e)
        {

            string text = " Двойной клик";
            
                MessageBox.Show(text);
            
        }
    }

    public class Phone
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"Смартфон {this.Name}; цена: {this.Price}";
        }
    }
}
