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

namespace _3WpfRoutedEvents
{
    /// ПРОЕКТ ДЛЯ ТРЕНИРОВКИ МАРШРУТИЗИРОВАННЫХ СОБЫТИЙ ТРОЕЛСЕН СТР 1000 + -


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //добавим переменную для отслеживания потока событий в фоновом режиме
        string _mouseActivity = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClickMe_Cliked(object sender, RoutedEventArgs e)
        {
            AddEventInfo(sender, e);
            MessageBox.Show(_mouseActivity,"Your Event Info");

            //очистить строку для следующего цикла
            _mouseActivity = "";
        }

        private void AddEventInfo(object sender, RoutedEventArgs e)
        {
            _mouseActivity += string.Format(
                "{0} sent a {1} event named {2}. \n", sender,
                e.RoutedEvent.RoutingStrategy,
                e.RoutedEvent.Name);
                
             
        }

        private void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
        
            AddEventInfo(sender, e);

        }
        private void outerEllipse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
       
            AddEventInfo(sender, e);

        }
    }
}
