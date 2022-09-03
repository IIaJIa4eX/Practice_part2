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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            Thread f = new Thread(new ThreadStart(FiboShow));
            f.Start();
        }


        public void FiboShow()
        {
            TextBox tb = new TextBox();
            int n_1 = 1;
            int n_2 = 1;

            for (int i = 3; i <= 20; ++i)
            {
                int sec = Convert.ToInt32(Counter.Text);

                var n_3 = n_1 + n_2;
                FiboView.BeginInvoke(new InvokeDelegate(WriteFibo),i , n_3);
                n_1 = n_2;
                n_2 = n_3;


                Thread.Sleep(sec * 1000);

               
            }
        }

        public delegate void InvokeDelegate(int i, int j);
        public void WriteFibo(int i, int f)
        {
            FiboView.Text = $"F{i}, {f}";
        }
    }
    
}
