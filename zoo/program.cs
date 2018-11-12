using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Inserts rows and columns and autosize
            InitializeComponent();
            initializeTable(8);
            insertImages();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Controlla evento click
            foreach (PictureBox space in this.table1.Controls)
            {
                space.MouseClick += new MouseEventHandler(clickOnSpace);
            }
        }

        public void clickOnSpace(object sender, MouseEventArgs e)
        {
            int CimgSelected = table1.GetColumn((PictureBox)sender);
            int RimgSelected = table1.GetRow((PictureBox)sender);
            animalSound(CimgSelected, RimgSelected);
        }
        public void initializeTable(int n)
        {
            this.table1.RowCount = (int)Math.Round((Math.Sqrt(n)));
            this.table1.ColumnCount = (int)Math.Round((Math.Sqrt(n)));
            this.table1.RowStyles.Clear();
            this.table1.ColumnStyles.Clear();
            /*
            for (int i = 1; i <= this.table1.RowCount; i++)
            {
                table1.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
            }
            for (int i = 1; i <= this.table1.ColumnCount; i++)
            {
                table1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
            }
            */
            for(int r = 0; r < this.table1.RowCount; r++)
            {
                table1.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
                for (int c = 0; c < this.table1.ColumnCount; c++)
                {
                    table1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
                }
            }
        }

        public void insertImages()
        {
            PictureBox[] imagesBox = new PictureBox[9];
            string[] nameFile = new String[9];
            nameFile[0] = "C:/img_snd/lion.jpg";
            nameFile[1] = "C:/img_snd/cat.jpg";
            nameFile[2] = "C:/img_snd/dog.jpg";
            nameFile[3] = "C:/img_snd/cow.jpg";
            nameFile[4] = "C:/img_snd/tiger.jpg";
            nameFile[5] = "C:/img_snd/crocodile.jpg";
            nameFile[6] = "C:/img_snd/snake.jpg";
            nameFile[7] = "C:/img_snd/seagull.jpg";
            nameFile[8] = "C:/img_snd/shark.jpg";

            for (int i = 0; i < imagesBox.Length; i++)
            {
                imagesBox[i] = new PictureBox();
                imagesBox[i].Image = Image.FromFile(nameFile[i]);
                imagesBox[i].Tag = i;
                imagesBox[i].Size = new Size(table1.Width / 3, table1.Height / 3);
                imagesBox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                table1.Controls.Add(imagesBox[i],i, 0);
            }
        }
        public void animalSound(int nImg, int cImg)
        {
            IAnimals[] Animals = new IAnimals[9];
            Animals[0] = new CLion();
            Animals[1] = new CCat();
            Animals[2] = new CDog();
            Animals[3] = new CCow();
            Animals[4] = new CTiger();
            Animals[5] = new CCrocodile();
            Animals[6] = new CSnake();
            Animals[7] = new CSeagull();
            Animals[8] = new CShark();
            for (int i = 0; i < Animals.Length; i++)
            {
                Animals[nImg].sound();
                if (i == nImg)
                {
                    Animals[nImg].sound();
                }
            }
        }
    }
}
