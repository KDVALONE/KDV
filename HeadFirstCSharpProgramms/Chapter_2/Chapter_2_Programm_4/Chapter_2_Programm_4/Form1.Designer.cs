namespace Chapter_2_Programm_4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.changeText = new System.Windows.Forms.Button();
            this.enableChekbox = new System.Windows.Forms.CheckBox();
            this.labelToChange = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // changeText
            // 
            this.changeText.Location = new System.Drawing.Point(28, 22);
            this.changeText.Name = "changeText";
            this.changeText.Size = new System.Drawing.Size(158, 23);
            this.changeText.TabIndex = 0;
            this.changeText.Text = "Change the lable if cheked";
            this.changeText.UseVisualStyleBackColor = true;
            this.changeText.Click += new System.EventHandler(this.changeText_Click);
            // 
            // enableChekbox
            // 
            this.enableChekbox.AutoSize = true;
            this.enableChekbox.Checked = true;
            this.enableChekbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableChekbox.Location = new System.Drawing.Point(302, 28);
            this.enableChekbox.Name = "enableChekbox";
            this.enableChekbox.Size = new System.Drawing.Size(131, 17);
            this.enableChekbox.TabIndex = 1;
            this.enableChekbox.Text = "Enable label changing";
            this.enableChekbox.UseVisualStyleBackColor = true;
            // 
            // labelToChange
            // 
            this.labelToChange.Location = new System.Drawing.Point(-2, 57);
            this.labelToChange.Name = "labelToChange";
            this.labelToChange.Size = new System.Drawing.Size(485, 34);
            this.labelToChange.TabIndex = 2;
            this.labelToChange.Text = "Press the batton to change my text";
            this.labelToChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 91);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelToChange);
            this.Controls.Add(this.enableChekbox);
            this.Controls.Add(this.changeText);
            this.Name = "Form1";
            this.Text = "My Desktop App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeText;
        private System.Windows.Forms.CheckBox enableChekbox;
        private System.Windows.Forms.Label labelToChange;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

