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

namespace _1WpfTestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //проверка на точно ли пользователь хочет закрыть приложение
            this.Closed +=  MainWindow_Closed;
            this.Closing += MainWindow_Closing;
            this.MouseMove += MainWindow_MouseMove;
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // точно ли нужно закрыть окно
            string msg = "Do you want to close without saving";
            MessageBoxResult result = MessageBox.Show(msg, "My app", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                // если пользователь не желает закрыть окно, то отменить закрытие
                e.Cancel = true;
            }
        } 

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("See ya, space Cowboy!");

        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //Отобразить на кнопке информацию о нажатой клавише (стрелочки на клаве)
            ClickMe.Content = e.Key.ToString();

        }

            private void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //отобразить заголовок окна текущей позиции (x,y) курсора мыши
            this.Title = e.GetPosition(this).ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked the button!");
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }
    }
}
