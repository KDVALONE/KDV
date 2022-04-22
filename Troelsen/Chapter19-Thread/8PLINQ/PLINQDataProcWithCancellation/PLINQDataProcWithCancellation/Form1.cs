using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLINQDataProcWithCancellation
{/// <summary>
/// Можно использовать методы расширения для запроса LINQ, который распределит свою нагрузку по 
/// парралельным потокам (если это возможно), Такие запросы это PLINQ
/// PLINQ оптимизирован. и проверяет будет ли запрос лучше выполняться в паралельном режиме или в синхронном
/// однако если парал. запросы ухудшает производительность, то будет выбранно выполнение в синхронной манере
/// </summary>
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // запустить новую задачу для обработки целых чисел
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }

        private void ProcessIntData()
        {
            // получить очень большой массив целых чисел
            int[] source = Enumerable.Range(1, 10000000).ToArray();

            //найти числа, для которых истинно условие num % 3 == 0,
            //и возвратить их в убывающем порядке
            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token) // WithCancellation информирование процесса о том что он должен ожидать процесса отмены
                                  where num % 3 == 0
                                  orderby num descending
                                  select num).ToArray();
                MessageBox.Show(string.Format("Found {0} numbers that mtach query!", modThreeIsZero.Count()));
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                  {
                      this.Text = ex.Message;
                  });
            }

        }
    }
}
