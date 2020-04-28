using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asycron
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);

        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            show1();
            show2();
          

        }

        private async void show1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    SetText(txtData.Text+ i.ToString() +Environment.NewLine);
                }
            });
          
        }

        private void SetText(string text)
        {
            if (txtData.InvokeRequired)
            {
                SetTextCallback oCallback = new SetTextCallback(SetText);
                Invoke(oCallback, new object[] { text });
            }
            else
            {
                txtData.Text = text;
            }
        }
        private async void show2()
        {
            await Task.Run(() =>
            {

                for (int i = 5; i < 10; i++)
                {
                //System.Threading.Thread.Sleep(500);

                SetText(txtData.Text + i.ToString() +Environment.NewLine);

            }
            });

        }
      

        private async void button2_Click(object sender, EventArgs e)
        {
            for (int i = 10; i < 15; i++)
            {

                txtData.Text += await dostring(i.ToString());

            }
        }

        private Task<string> dostring(string txt)
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);

                return txt + Environment.NewLine;
            });
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            txtData.Text = await stringreturn();
        }
        private  Task<string> stringreturn()
        {
            return Task.Run(() =>
            {
                return "done";
            });

        }

        private void button4_Click(object sender, EventArgs e)
        {
             DoWork();
        }

        private async Task  DoWork()
        {
          await  Task.Run(() => {
                MessageBox.Show("Test");
            });
        }
    }
}
