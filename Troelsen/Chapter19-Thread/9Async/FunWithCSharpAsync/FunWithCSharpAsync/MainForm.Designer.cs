namespace FunWithCSharpAsync
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCallMethod = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnVoidMethodCall = new System.Windows.Forms.Button();
            this.btnMultiAwaits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallMethod
            // 
            this.btnCallMethod.Location = new System.Drawing.Point(271, 151);
            this.btnCallMethod.Name = "btnCallMethod";
            this.btnCallMethod.Size = new System.Drawing.Size(149, 23);
            this.btnCallMethod.TabIndex = 0;
            this.btnCallMethod.Text = "CallMethodReturnString";
            this.btnCallMethod.UseVisualStyleBackColor = true;
            this.btnCallMethod.Click += new System.EventHandler(this.btnCallMethod_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(87, 154);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 20);
            this.txtInput.TabIndex = 1;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // btnVoidMethodCall
            // 
            this.btnVoidMethodCall.Location = new System.Drawing.Point(435, 151);
            this.btnVoidMethodCall.Name = "btnVoidMethodCall";
            this.btnVoidMethodCall.Size = new System.Drawing.Size(137, 23);
            this.btnVoidMethodCall.TabIndex = 2;
            this.btnVoidMethodCall.Text = "CallMethodVoid";
            this.btnVoidMethodCall.UseVisualStyleBackColor = true;
            this.btnVoidMethodCall.Click += new System.EventHandler(this.btnVoidMethodCall_Click);
            // 
            // btnMultiAwaits
            // 
            this.btnMultiAwaits.Location = new System.Drawing.Point(603, 151);
            this.btnMultiAwaits.Name = "btnMultiAwaits";
            this.btnMultiAwaits.Size = new System.Drawing.Size(75, 23);
            this.btnMultiAwaits.TabIndex = 3;
            this.btnMultiAwaits.Text = "MultiAwaits";
            this.btnMultiAwaits.UseVisualStyleBackColor = true;
            this.btnMultiAwaits.Click += new System.EventHandler(this.btnMultiAwaits_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMultiAwaits);
            this.Controls.Add(this.btnVoidMethodCall);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnCallMethod);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCallMethod;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnVoidMethodCall;
        private System.Windows.Forms.Button btnMultiAwaits;
    }
}

