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

namespace WpfPhone
{
    /// <summary>
    /// Логика взаимодействия для Phone.xaml
    /// </summary>
    /// <summary>
    /// Логика взаимодействия для Phone.xaml
    /// </summary>
    public partial class Phone : UserControl
    {
        //обьявление свойства зависимости
        //*** Свойство зависимости чуть скорректировала по видео которое вчера присылала https://www.youtube.com/watch?v=jlcmmWuZyvY&t=1179s
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title",
             typeof(string),
             typeof(Phone),
             new UIPropertyMetadata("", CurrentPhoneNameChanged));

        public static Random rnd = new Random();

        private static List<string> phoneList = new List<string>() { "Nokia", "Apple", "Samsung", "Siemens" };

        public Phone()
        {
            //*** Добавляем инициализацию компонентов (наверное их отрисовку)
            InitializeComponent();
        }



        //упаковка свойства зависимости в простое свойство
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static string GetPhoneType()
        {
            return phoneList[rnd.Next(phoneList.Count)];

        }

        private static void CurrentPhoneNameChanged(
            DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {

            Phone p = (Phone)depObj;

            // Get the Label control in the ShowNumberControl.
            Label phoneLabel = p.phoneTypeDisplay;

            // Set the Label with the new value.
            phoneLabel.Content = args.NewValue.ToString();

        }


    }
}
