using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;

namespace TheGameOfLife
{
    public partial class Form1 : Form
    {
        private static readonly Random rand = new Random();
        CEsserevivente[,] CEv = new CEsserevivente[4, 4];
        CEsserevivente[,] ogg = new CEsserevivente[5, 5];
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void creaCarota()
        {
            PictureBox pCarrot;
            for (int i = 0; i < 4; i++)
            {
                pCarrot = new PictureBox();
                pCarrot.Image = Image.FromFile("C:/TGOL/carrot.png");
                pCarrot.Size = new Size(table.Width / 4, table.Height / 4);
                pCarrot.SizeMode = PictureBoxSizeMode.StretchImage;
                pCarrot.Tag = "Carota";
                int r = GetRandomNumber(0, 4);
                int c = GetRandomNumber(0, 4);
                table.Controls.Add(pCarrot, c, r);
                this.ogg[r, c] = new CCarota(r, c);
            }
        }
            /*
            public void randomSpawn()
            {
                PictureBox pCarrot;
                for (int i = 0; i < 4; i++)
                {
                    pCarrot = new PictureBox();
                    pCarrot.Image = Image.FromFile("C:/TGOL/carrot.png");
                    pCarrot.Size = new Size(table.Width / 4, table.Height / 4);
                    pCarrot.SizeMode = PictureBoxSizeMode.StretchImage;
                    //pCarrot.Enabled = false;
                    int r = GetRandomNumber(0, 4);
                    int c = GetRandomNumber(0, 4);
                    table.Controls.Add(pCarrot, c, r);
                    this.CEv[r, c] = new CCarota(r, c);
                }
                PictureBox pRabbit;
                for (int i = 0; i < 2; i++)
                {
                    pRabbit = new PictureBox();
                    pRabbit.Image = Image.FromFile("C:/TGOL/rabbit.png");
                    pRabbit.Size = new Size(table.Width / 4, table.Height / 4);
                    pRabbit.SizeMode = PictureBoxSizeMode.StretchImage;
                    int r = GetRandomNumber(0, 4);
                    int c = GetRandomNumber(0, 4);
                    table.Controls.Add(pRabbit, c, r);
                    this.CEv[r, c] = new CConiglio(r, c);
                }
                PictureBox pFox;
                for (int i = 0; i < 2; i++)
                {
                    pFox = new PictureBox();
                    pFox.Image = Image.FromFile("C:/TGOL/fox.png");
                    pFox.Size = new Size(table.Width / 4, table.Height / 4);
                    pFox.SizeMode = PictureBoxSizeMode.StretchImage;
                    int r = GetRandomNumber(0, 4);
                    int c = GetRandomNumber(0, 4);
                    table.Controls.Add(pFox, c, r);
                    this.CEv[r, c] = new CVolpe(r, c);
                }
            }
            */
        private void creaVolpe(CVolpe v)
        {
            PictureBox pFox;
            pFox = new PictureBox();
            pFox.Image = Image.FromFile("C:/TGOL/fox.png");
            pFox.Size = new Size(table.Width / 4, table.Height / 4);
            pFox.SizeMode = PictureBoxSizeMode.StretchImage;
            pFox.Tag = "Volpe";
            pFox.Enabled = false;
            table.Controls.Add(pFox, v.c, v.r);
            this.ogg[v.r, v.c] = v;
        }
        private void creaConiglio(CConiglio c)
        {
            PictureBox pRabbit;
            pRabbit = new PictureBox();
            pRabbit.Image = Image.FromFile("C:/TGOL/rabbit.png");
            pRabbit.Size = new Size(table.Width / 4, table.Height / 4);
            pRabbit.SizeMode = PictureBoxSizeMode.StretchImage;
            pRabbit.Tag = "Coniglio";
            pRabbit.Enabled = true;
            table.Controls.Add(pRabbit, c.c, c.r);
            this.ogg[c.r, c.c] = c;
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
            BPlay.Enabled = false;
            CVolpe v1 = new CVolpe(GetRandomNumber(0, 4), GetRandomNumber(0, 4));
            ogg[v1.r, v1.c] = v1;
            creaVolpe(v1);
            CVolpe v2 = new CVolpe(GetRandomNumber(0, 4), GetRandomNumber(0, 4));
            creaVolpe(v2);
            ogg[v2.r, v2.c] = v2;
            CConiglio c1 = new CConiglio(GetRandomNumber(0, 4), GetRandomNumber(0, 4));
            creaConiglio(c1);
            ogg[c1.r, c1.c] = c1;
            CConiglio c2 = new CConiglio(GetRandomNumber(0, 4), GetRandomNumber(0, 4));
            creaConiglio(c2);
            creaCarota();
            ogg[c2.r, c2.c] = c2;
            Thread T1 = new Thread(new ThreadStart(v1.Vivi));
            T1.Name = "volpe 1";
            Thread T2 = new Thread(new ThreadStart(v2.Vivi));
            T2.Name = "volpe 2";
            Thread T3 = new Thread(new ThreadStart(c1.Vivi));
            T3.Name = "coniglio 1";
            Thread T4 = new Thread(new ThreadStart(c2.Vivi));
            T4.Name = "coniglio 2";
            T1.Start();
            T2.Start();
            T3.Start();
            T4.Start();
            foreach (PictureBox space in this.table.Controls)
            {
                space.MouseClick += new MouseEventHandler(clickOnSpace);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Controlla evento click
            foreach (PictureBox space in this.table.Controls)
            {
                space.MouseClick += new MouseEventHandler(clickOnSpace);
            }
            foreach (Control control in Controls) // reflection to sort flickering.
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, control, new object[] { true });
            }
        }
        public void clickOnSpace(object sender, MouseEventArgs e)
        {
            int CimgSelected = table.GetColumn((PictureBox)sender);
            //Control control = table.GetControlFromPosition(CimgSelected, RimgSelected);
            //MessageBox.Show(RimgSelected + "," + CimgSelected + " -- " + control.Tag.ToString());
            //table.Controls.Remove(control);
            //ogg[r, c] = null;
            //Where(RimgSelected, CimgSelected);
        }
        private void Where()
        {
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (ogg[r, c] is CConiglio || ogg[r, c] is CVolpe)
                    {
                        int rprec = r;
                        int cprec = c;
                        Control img = table.GetControlFromPosition(c, r);
                        table.Controls.Remove(img);
                        ogg[r, c] = null;
                        int[] r1 = {-1, 1};
                        int[] c1 = { -1, 1 };
                        int index = GetRandomNumber(0, 1);
                        r = r + r1[index];
                        index = GetRandomNumber(0, 1);
                        c = c + c1[index];
                        if(r == 0)
                        {
                            r = r + 1;
                        }
                        if(c == 0)
                        {
                            c = c + 1;
                        }
                        if (r == 4)
                        {
                            r = r - 1;
                        }
                        if (c == 4)
                        {
                            c = c - 1;
                        }
                        if (r < 0)
                        {
                            r = 0;
                        }

                        if (r > 5)
                        {
                            r = 4;
                        }

                        if (c < 0)
                        {
                            c = 0;
                        }

                        if (c > 5)
                        {
                            c = 4;
                        }
                        if (img.Tag.ToString() == "Volpe")
                        {
                            if (ogg[r, c] is CCarota || ogg[r, c] is CConiglio)
                            {
                                Control control = table.GetControlFromPosition(c, r);
                                table.Controls.Remove(control);
                                ogg[r, c] = null;
                            }
                            table.Controls.Add(img, c, r);
                            ogg[r, c] = new CVolpe(r, c);
                        }
                        else
                        {
                            if (ogg[r, c] is CCarota || ogg[r,c] is CConiglio)
                            {
                                Control control = table.GetControlFromPosition(c, r);
                                table.Controls.Remove(control);
                                ogg[r, c] = null;
                            }
                            table.Controls.Add(img, c, r);
                            ogg[r, c] = new CConiglio(r, c);
                        } 
                    }
                }
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Where();
        }
    }
}