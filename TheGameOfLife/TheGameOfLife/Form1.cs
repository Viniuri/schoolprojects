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
        public void randomSpawn()
        {
            PictureBox pCarrot;
            for (int i = 0; i < 4; i++)
            {
                pCarrot = new PictureBox();
                pCarrot.Image = Image.FromFile("C:/TGOL/carrot.png");
                pCarrot.Size = new Size(table.Width / 4, table.Height / 4);
                pCarrot.SizeMode = PictureBoxSizeMode.StretchImage;
                pCarrot.Tag = "Carota";
                pCarrot.Enabled = false;
                int r = GetRandomNumber(0, 4);
                int c = GetRandomNumber(0, 4);
                table.Controls.Add(pCarrot, c, r);
                this.ogg[r, c] = new CCarota(r, c);
            }
            PictureBox pRabbit;
            for (int i = 0; i < 2; i++)
            {
                pRabbit = new PictureBox();
                pRabbit.Image = Image.FromFile("C:/TGOL/rabbit.png");
                pRabbit.Size = new Size(table.Width / 4, table.Height / 4);
                pRabbit.SizeMode = PictureBoxSizeMode.StretchImage;
                pRabbit.Tag = "Coniglio";
                int r = GetRandomNumber(0, 4);
                int c = GetRandomNumber(0, 4);
                table.Controls.Add(pRabbit, c, r);
                this.ogg[r, c] = new CConiglio(r, c);
            }
            PictureBox pFox;
            for (int i = 0; i < 2; i++)
            {
                pFox = new PictureBox();
                pFox.Image = Image.FromFile("C:/TGOL/fox.png");
                pFox.Size = new Size(table.Width / 4, table.Height / 4);
                pFox.SizeMode = PictureBoxSizeMode.StretchImage; pFox.Tag = "Volpe";
                pFox.Tag = "Volpe";
                int r = GetRandomNumber(0, 4);
                int c = GetRandomNumber(0, 4);
                table.Controls.Add(pFox, c, r);
                this.ogg[r, c] = new CVolpe(r, c);
            }
        }
        /*
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
            pFox.MouseClick += new MouseEventHandler(clickOnSpace);
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
            pRabbit.MouseClick += new MouseEventHandler(clickOnSpace);
        }
        */
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
            randomSpawn();
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
            int RimgSelected = table.GetRow((PictureBox)sender);
            Control control = table.GetControlFromPosition(CimgSelected, RimgSelected);
            MessageBox.Show(RimgSelected + "," + CimgSelected + " -- " + control.Tag.ToString());
            //table.Controls.Remove(control);
            //ogg[RimgSelected, CimgSelected] = null;
            //Where(RimgSelected, CimgSelected);
        }

        private static int limitiR(int r)
        {
            if (r == 0)
            {
                r = r + 1;
            }
            else
            {
                if (r < 0)
                {
                    r = 0;
                }
                else
                {
                    if (r == 4)
                    {
                        r = r - 1;
                    }
                    else
                    {
                        if (r > 4)
                        {
                            r = 4;
                        }
                    }
                }
            }
            return r;
        }

        private static int limitiC(int c)
        {
            if (c == 0)
            {
                c = c + 1;
            }
            else
            {
                if (c < 0)
                {
                    c = 0;
                }
                else
                {
                    if (c == 4)
                    {
                        c = c - 1;
                    }
                    else
                    {
                        if (c > 4)
                        {
                            c = 4;
                        }
                    }
                }
            }
            return c;
        }

        private void Where()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (ogg[i, k] is CConiglio || ogg[i, k] is CVolpe)
                    {
                        int r = i;
                        int c = k;
                        int rprec = r;
                        int cprec = c;
                        Control img = table.GetControlFromPosition(c, r);
                        table.Controls.Remove(img);
                        ogg[r, c] = null;
                        int[] r1 = {-1, 1};
                        int[] c1 = { -1, 1};
                        int index1 = GetRandomNumber(0, 1);
                        r = r + r1[index1];
                        int index2 = GetRandomNumber(0, 1);
                        c = c + c1[index2];
                        r = limitiR(r);
                        c = limitiC(c);

                        if (ogg[r, c] is CConiglio)
                        {
                            if(ogg[r, c] is CVolpe)
                            {
                                r = r + r1[index1] *-1;
                                c = c + c1[index2] *-1;
                                r = limitiR(r);
                                c = limitiC(c);
                            }
                        }

                        if (ogg[r, c] is CVolpe)
                        {
                            if (ogg[r-1, c-1] is CConiglio)
                            {
                                Control control = table.GetControlFromPosition(c - 1, r - 1);
                                table.Controls.Remove(control);
                                ogg[r - 1, c - 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r + 1, c - 1] is CConiglio)
                            {
                                    Control control = table.GetControlFromPosition(c - 1, r + 1);
                                    table.Controls.Remove(control);
                                    ogg[r + 1, c - 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r - 1, c + 1] is CConiglio)
                            {
                                    Control control = table.GetControlFromPosition(c + 1, r - 1);
                                    table.Controls.Remove(control);
                                    ogg[r - 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r + 1, c + 1] is CConiglio)
                            {
                                    Control control = table.GetControlFromPosition(c + 1, r + 1);
                                    table.Controls.Remove(control);
                                    ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r , c + 1] is CConiglio)
                            {
                                    Control control = table.GetControlFromPosition(c + 1, r + 1);
                                    table.Controls.Remove(control);
                                    ogg[r + 1, c + 1] = null;
                                    table.Controls.Add(img, c, r);
                                    ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r, c - 1] is CConiglio)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r + 1, c] is CConiglio)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r - 1, c] is CConiglio)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                        }

                        if (ogg[r, c] is CConiglio)
                        {
                            if (ogg[r - 1, c - 1] is CCarota)
                            {
                                Control control = table.GetControlFromPosition(c - 1, r - 1);
                                table.Controls.Remove(control);
                                ogg[r - 1, c - 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r + 1, c - 1] is CCarota)
                            {
                                Control control = table.GetControlFromPosition(c - 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c - 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r - 1, c + 1] is CCarota)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r - 1);
                                table.Controls.Remove(control);
                                ogg[r - 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r + 1, c + 1] is CCarota)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r, c + 1] is CCarota)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r, c - 1] is CCarota)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r + 1, c] is CCarota)
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                            else if (ogg[r - 1, c] is CCarota )
                            {
                                Control control = table.GetControlFromPosition(c + 1, r + 1);
                                table.Controls.Remove(control);
                                ogg[r + 1, c + 1] = null;
                                table.Controls.Add(img, c, r);
                                ogg[r, c] = new CVolpe(r, c);
                            }
                        }

                        if (img.Tag.ToString() == "Volpe")
                        {
                            if(ogg[r, c] is CCarota || ogg[r, c] is CConiglio)
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
                            if (ogg[r, c] is CCarota || ogg[r, c] is CConiglio)
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