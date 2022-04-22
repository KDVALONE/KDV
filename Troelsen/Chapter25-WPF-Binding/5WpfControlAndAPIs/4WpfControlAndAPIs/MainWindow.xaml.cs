using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Ink;
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
using AutoLotDAL.Repos;

namespace _5WpfControlAndAPIs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //установить режим INK в качестве стандартного
            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;
            SetBindings();
            ConfigureGrid();

        }
    
        private void ConfigureGrid()
        {
            using (var repo = new InventoryRepo())
            {
                //построить запрос линк извлекающий данные из таблицы Inventory
                gridInventory.ItemsSource =
                    repo.GetAll().Select(x => new { x.Id, x.Make, x.Color, x.PetName });
            }
        }

        private void SetBindings()
        {
            //создать обьет Binding
            Binding b = new Binding();
            // зарегестрировать преобразователь, источник и путь
            b.Converter = new MyDoubleConverter();
            b.Source = this.mySB;
            b.Path = new PropertyPath("Value");
            // вызвать метод SetBinding() обьекта Label
            this.labelSBThumb.SetBinding(ContentProperty, b);
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            // в зависимости от того какая кнопка отправида событие, поместить InkCanvas в нужный режим оперирования

            switch ((sender as RadioButton)?.Content.ToString())
            {
                //эти строки должны совпадать со значениями свойства Content
                //каждого элемента RadioButton

                case "Ink Mode":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode!":
                    this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;

            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // получить свойство Tag выбранного элемента StackPanel
            string colorToUse = (this.comboColors.SelectedItem as StackPanel).Tag.ToString();
            

            // получить выбраный элемент в раскрывающемся списке
            //string colorToUse =
            //    (this.comboColors.SelectedItem as ComboBoxItem)?.Content.ToString();
            // изменить цвет штрихов
            this.MyInkCanvas.DefaultDrawingAttributes.Color =
                (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            // сохранить данные InkCanvas в локальный файл
            using (FileStream fs = new FileStream("StrockeData.bin", FileMode.Create))
            {
                this.MyInkCanvas.Strokes.Save(fs);
                fs.Close();
            }

        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            // Наполнить StrokeCollection из файла
            using (FileStream fs = new FileStream("StrockeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.MyInkCanvas.Strokes = strokes;
            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            // очистить штрихи
            this.MyInkCanvas.Strokes.Clear();
        }

    }

    class MyDoubleConverter : IValueConverter
    {

        //метод вызывается при передаче значения от источника(ScrollBar) к цели (свойство Content элемента Lable)
        public object Convert(object value, Type targetType, object parametr, System.Globalization.CultureInfo culture)
        {
            // преобразовать значение double в int
            double v = (double)value;
            return (int)v;
        }

        // вызывается при при пересдаче значения от цели к источнику(если включен двунаправленный режим привязки)
        public object ConvertBack(object value, Type targetType, object parametr, System.Globalization.CultureInfo culture)
        {
            // т.к. заботиться о двунаправленной привязке не нужно, то просто возвращаем value
            return value;
        }
    }
}
