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

namespace WpfAppMVVM1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Сделать, MVVM проектик, оттренить навыки WPF
    /// Сделать приложение, по учету телефонов.
    /// Окно0 Запрос авторизцаии, после авторизации, на верху во всех окнах будут приветствие сотрудника
    /// Окно1 поиск и выведение и сортировка по моделям телефонов.
    /// Окно2 Заведение новых телефонов
    /// Все на разных вьюхах, так же пробовать сопоставить разные XAMLы для разных фич.
    /// Что конкретно обязательно использовать:
    ///  - Дата контекст,
    ///  - Конвертер
    ///  - Вьюхи
    ///  - Модели
    ///  - Классы ВьюМодел с логикой
    ///  - Реализовать использование СвойствЗависимости
    ///  - Так же работать с ObservableCollection
    ///  - Привязки
    ///  - События (RoutedEvent)
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
