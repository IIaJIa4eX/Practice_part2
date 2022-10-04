
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FiboView = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Counter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FiboView
            // 
            this.FiboView.Location = new System.Drawing.Point(325, 190);
            this.FiboView.Name = "FiboView";
            this.FiboView.Size = new System.Drawing.Size(100, 23);
            this.FiboView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Числа фибоначчи";
            // 
            // Counter
            // 
            this.Counter.Location = new System.Drawing.Point(506, 189);
            this.Counter.Name = "Counter";
            this.Counter.Size = new System.Drawing.Size(100, 23);
            this.Counter.TabIndex = 2;
            this.Counter.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Задержка в секундах";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Counter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FiboView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox FiboView;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox Counter;
        private System.Windows.Forms.Label label2;
    }
}

