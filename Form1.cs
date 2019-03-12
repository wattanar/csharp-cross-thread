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

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public delegate void UpdateControlsDelegate(int i);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread background = new Thread(() => Delay(10));
            background.IsBackground = true;
            background.Start();
        }

        private void Delay(int x)  
        {
            for (int i = x; i < 10000; i++)
            {
                if (label1.InvokeRequired)
                {
                    this.Invoke(new UpdateControlsDelegate(UpdateControls), new Object[] { i });
                }
                else
                {
                    UpdateControls(i);
                }
                
            }
        }

        private void UpdateControls(int i)
        {
            label1.Text = " Running..." + i;
        }
    }
}
