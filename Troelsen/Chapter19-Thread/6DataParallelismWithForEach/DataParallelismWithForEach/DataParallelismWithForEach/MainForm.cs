using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace DataParallelismWithForEach
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainForm()
        {
            InitializeComponent();
        }
        private void btnProcessImage_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            { 
            ProcessFiles();
            });
        }

        private void ProcessFiles()
        {
            //использовать экз. ParralelOption для хранения CancellationToken
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            //  Загрузить все файлы * .jpg и создать новый каталог
            //  для модификацированных данных
            string[] files = Directory.GetFiles(@"F:\Программирование\Project\VS 2015-2017\Troelsen\Chapter19-Thread\6DataParallelismWithForEach\DataParallelismWithForEach\FilesUndoModification", "*.jpg", SearchOption.AllDirectories);
            string newDir = @"F:\Программирование\Project\VS 2015-2017\Troelsen\Chapter19-Thread\6DataParallelismWithForEach\DataParallelismWithForEach\FilesAfterModification";
            Directory.CreateDirectory(newDir);
            // обработать данные изображений в блокирующей манере

            #region Предпоследняя реализация метода
            //foreach (string currentFile in files)
            //{
            //    string filename = Path.GetFileName(currentFile);
            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(newDir, filename));

            //        #region Этот оператор вызывает проблемы при паралельном программировании, нужно закоментить

            //        //вывести идентификатор потока, обрабатывающего текущее изоборажение
            //        // this.Text = string.Format("Processing {0} on thtread {1}", filename, Thread.CurrentThread.ManagedThreadId);
            //        #endregion
            //        this.Invoke((Action)delegate // анонимный делегат. Метод this.Invoke() уникален для API интерфейса Win Forms. Для WPF будет this.Dispetcher.Invoke();
            //        // вызвать Ivoke на обьекте Form,что позволяет вторичным потокам получать доступ к элементам управления в безопасном режиме 
            //        {
            //            this.Text = string.Format("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);
            //        });
            //    }
            //}
            # endregion

            // обработать данные изображения в параллельном режиме
            try
            {
                Parallel.ForEach(files, parOpts, currentFile =>
                 {
                     parOpts.CancellationToken.ThrowIfCancellationRequested();

                     string filename = Path.GetFileName(currentFile);
                     using (Bitmap bitmap = new Bitmap(currentFile))
                     {
                         bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                         bitmap.Save(Path.Combine(newDir, filename));
                         this.Invoke((Action)delegate
                         {
                             this.Text = string.Format("Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId);

                         });
                     }
                 });
                this.Invoke((Action)delegate
                {
                    this.Text = "Done!";
                });
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                 {
                     this.Text = ex.Message;
                 });
            }
           
        }       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
