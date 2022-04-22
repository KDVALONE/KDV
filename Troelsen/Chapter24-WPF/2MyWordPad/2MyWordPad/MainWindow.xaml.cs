using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
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

namespace _2MyWordPad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetF1CommandBinding();
        }

        //метод привязки зправки на клавишу F1
        private void SetF1CommandBinding()
        {
            CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += CanHelpExecute;
            helpBinding.Executed += HelpExecuted;
            CommandBindings.Add(helpBinding);
        }



        private void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //Если нужно предотвратить выполнение команды,
            // то можно установить CanExecute в False.
            e.CanExecute = true;
        }
        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Look,it is not that difficult. Just type something!", "Help");

        }

        protected void FileExit_Click(object sender, RoutedEventArgs e)
        {
            //закрыть окно
            this.Close();
        }

        protected void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            string spellingHints = string.Empty;
            // попробовать получить ошиьку правописания
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                // построить строку с предполагаемыми вариантами правописания.
                foreach (string s in error.Suggestions)
                {
                    spellingHints += $"{s}\n";
                    // отобразить предполагаемые варианты и раскрыть элементы Expander
                    lblSpellingHints.Content = spellingHints;
                    expanderSpelling.IsExpanded = true;
                }
            }
        }
        protected void MouseEnterExitArea(object sender, RoutedEventArgs e)
        {
            statBarText.Text = "Exit the Application";
        }
        protected void MouseEnterToolsHintsArea(object sender, RoutedEventArgs e)
        {
            statBarText.Text = "Show Spelling Suggestions";
        }
        protected void MouseLeaveArea(object sender, RoutedEventArgs e)
        {
            statBarText.Text = "Ready";
        }

        protected void MenuItem_MouseLeave(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //создать диалоговое окно открытия файла и показать в нем только текстовые файлы
            var openDlg = new OpenFileDialog { Filter = "Text Files |*.txt" };

            // был ли совершен щелчек на кнопке ОК?
            if (true == openDlg.ShowDialog())
            {
                // загрузить содержимое выбранного файла.
                string dataFromFile = File.ReadAllText(openDlg.FileName);

                //Отобразить строку в TextBox.
                txtData.Text = dataFromFile;

            }
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveDlg = new SaveFileDialog { Filter = "Text Files | *.txt" };
            // был ли совершен щелчек на кнопке ОК?
            if (true == saveDlg.ShowDialog())
            {
                // сохранить данные из TextBox в указанном файле.
                File.WriteAllText (saveDlg.FileName, txtData.Text);
            }
        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }

}



