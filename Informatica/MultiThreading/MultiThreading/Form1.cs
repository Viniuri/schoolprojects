using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MultiThreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            int i = await AccessTheWebAsync();
            txtRisultato.Text = "Fine" + i.ToString();
        }
        private async Task <int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            string risultato = await client.GetStringAsync(urlText.Text);
            DoWork();
            return (risultato.Length);
        }
        private void DoWork()
        {
            int i = 0;
            while (i++ < 10)
            {
                txtRisultato.Text += "working...";
                Thread.Sleep(1000);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
