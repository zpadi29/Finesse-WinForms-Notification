using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        public Form2(string[] args)
        {
            InitializeComponent();

            if (args.Length == 3)
            {
                int numVal1;
                int numVal2;
                int numVal3;
                numVal1 = Convert.ToInt32(args[0]);
                numVal2 = Convert.ToInt32(args[1]);
                numVal3 = Convert.ToInt32(args[2]);
                BackColor = Color.FromArgb(numVal1, numVal2, numVal3);
                textBox2.BackColor = Color.FromArgb(numVal1, numVal2, numVal3);
                textBox3.BackColor = Color.FromArgb(numVal1, numVal2, numVal3);
                textBox4.BackColor = Color.FromArgb(numVal1, numVal2, numVal3);
                button1.BackColor = Color.FromArgb(numVal1, numVal2, numVal3);
            }
            
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PlaceLowerRight();
            timer1.Interval = 10000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void PlaceLowerRight()
        {
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
            this.TopMost = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
