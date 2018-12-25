using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FunWithCSharpAsync
{/// <summary>
/// Применение Async / Await . Возможно с .Net Fraimwork 4.5
/// Современный и удобный способ
/// Важно! Методы, лямда вырожения а также анонимные методы, 
/// будут работать в "блокирующей модели"
/// пока не встретят await.  По этому нужно помещать внутренний код таких методов 
/// в, например, анонимный метод, и помещайть его await.
/// 
/// При встречи awit вызывающий поток приостанваливается пока задача не решитсья, но управление возвращается коду, вызвавшему метод
/// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnCallMethod_Click(object sender, EventArgs e) // обработчики событий для пользовательского интерфейса суффиксы async иметь не должны
        {
            this.Text = await DoWorkAsync(); // Согласно соглашению все методы возвращающие обьект Task 
                                             // (тоесть помеченые как await который как раз и отвечает за то что метод будет возвращать обьект Task<T>, 
                                             // где Т - реально возвращемое значение) должны иметь суффикс Async.
                                             
        }
        

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }
        private async Task MethodReturningVoidAsync() // Для void методов
        {
            await Task.Run(() => {/*выполнение какой то работы*/ Thread.Sleep(4000); });
        }

        private async Task<string>DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done with work!";
            });
            
        }

        private async void btnVoidMethodCall_Click(object sender, EventArgs e)// обработчики событий для пользовательского интерфейса суффиксы async иметь не должны
        {
            await MethodReturningVoidAsync();
            MessageBox.Show("Done!");
        }

        private async void btnMultiAwaits_Click(object sender, EventArgs e) // более простой код, вызова задач в потоках
        {
            await Task.Run(() => { Thread.Sleep(3000); }); 
            MessageBox.Show("Done! task 1 "); // метод приостанавлевает поток
            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done! task 2 ");// метод приостанавлевает поток
            await Task.Run(() => { Thread.Sleep(4000); });
            MessageBox.Show("Done! task 3");// метод приостанавлевает поток
        }
    }
}
