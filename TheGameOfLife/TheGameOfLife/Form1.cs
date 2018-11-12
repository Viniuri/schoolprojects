using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGameOfLife
{
    public partial class Form1 : Form
    {
        private static readonly Random rand = new Random();
        CEsserevivente[,] CEv = new CEsserevivente[10,10]; 
        public Form1()
        {
            InitializeComponent();
            randomSpawn();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void randomSpawn()
        {
            PictureBox pCarrot;
            for (int i = 0; i < 12; i++)
            {
                pCarrot = new PictureBox();
                pCarrot.Image = Image.FromFile("C:/TGOL/carrot.png");
                pCarrot.Size = new Size(table.Width / 10, table.Height / 10);
                pCarrot.SizeMode = PictureBoxSizeMode.StretchImage;
                int r = GetRandomNumber(0, 10);
                int c = GetRandomNumber(0, 10);
                table.Controls.Add(pCarrot, c, r);
                this.CEv[r, c] = new CCarota(r, c); 
            }
            PictureBox pRabbit;
            for (int i = 0; i < 8; i++)
            {
                pRabbit = new PictureBox();
                pRabbit.Image = Image.FromFile("C:/TGOL/rabbit.png");
                pRabbit.Size = new Size(table.Width / 10, table.Height / 10);
                pRabbit.SizeMode = PictureBoxSizeMode.StretchImage;
                int r = GetRandomNumber(0, 10);
                int c = GetRandomNumber(0, 10);
                table.Controls.Add(pRabbit, c, r);
                this.CEv[r, c] = new CConiglio(r, c);
            }
            PictureBox pFox;
            for (int i = 0; i < 5; i++)
            {
                pFox = new PictureBox();
                pFox.Image = Image.FromFile("C:/TGOL/fox.png");
                pFox.Size = new Size(table.Width / 10, table.Height / 10);
                pFox.SizeMode = PictureBoxSizeMode.StretchImage;
                int r = GetRandomNumber(0, 10);
                int c = GetRandomNumber(0, 10);
                table.Controls.Add(pFox, c, r);
                this.CEv[r, c] = new CVolpe(r, c);
            }
        }
        //Different random number from previous
        public static int GetRandomNumber(int min, int max)
        {
            lock (rand)
            {
                return rand.Next(min, max);
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            int[] v = new int[2];
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if(CEv[r,c] is CConiglio || CEv[r,c] is CVolpe)
                    {
                        //v = Where(r, c);
                        MessageBox.Show(v[0] + ", " + v[1]);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Controlla evento click
            foreach (PictureBox space in this.table.Controls)
            {
                space.MouseClick += new MouseEventHandler(clickOnSpace);
            }
        }
        public void clickOnSpace(object sender, MouseEventArgs e)
        {
            int CimgSelected = table.GetColumn((PictureBox)sender);
            int RimgSelected = table.GetRow((PictureBox)sender);
            MessageBox.Show(RimgSelected.ToString() + "," + CimgSelected.ToString());
        }
        /*private int[] Where(int r, int c)
        {

        }
        */
    }
}
