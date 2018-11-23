using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rgbPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            /*InitializeComponent();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(getColor); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (10);             // Timer will tick evert 1 seconds
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getColor();
        }
        private void getColor(object sender, EventArgs e)
        {
            int redValue = redTrack.Value;
            int greenValue = greenTrack.Value;
            int blueValue = blueTrack.Value;
            rgbTextbox.Text = "R: " + redValue.ToString() + "/ G: " + greenValue.ToString() + "/ B: " + blueValue.ToString();
            labelColor.BackColor = Color.FromArgb(redValue, greenValue, blueValue);//(R, G, B) (0, 0, 0 = black)

            redLabel.ForeColor = Color.FromArgb(redValue, greenValue, blueValue);//(R, G, B) (0, 0, 0 = black)
            greenLabel.ForeColor = Color.FromArgb(redValue, greenValue, blueValue);//(R, G, B) (0, 0, 0 = black)
            blueLabel.ForeColor = Color.FromArgb(redValue, greenValue, blueValue);//(R, G, B) (0, 0, 0 = black)
        }

        private void labelColor_Click(object sender, EventArgs e)
        {

        }
    }
}
