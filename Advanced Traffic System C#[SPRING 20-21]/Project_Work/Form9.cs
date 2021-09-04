using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Work
{
    public partial class Form9 : Form
    {
        decimal light = 2;
        public Form9()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }
      
        
                      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 0")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 1")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 2")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 3")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 4")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 5")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 6")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 7")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 8")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Signal 9")
            {
                if (light == 0)
                {
                    timer1.Interval = 3000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 2000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            if (listBox1.SelectedItem=="Signal 0" || listBox1.SelectedItem == "Signal 1" ||
                listBox1.SelectedItem == "Signal 2" || listBox1.SelectedItem == "Signal 3" ||
                listBox1.SelectedItem == "Signal 4" || listBox1.SelectedItem == "Signal 5" ||
                listBox1.SelectedItem == "Signal 6" || listBox1.SelectedItem == "Signal 7" || 
                listBox1.SelectedItem == "Signal 8" || listBox1.SelectedItem == "Signal 9" )
            {
                if (light == 0)
                {
                    timer1.Interval = 1000;
                    light = 1;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Yellow.jpg";
                }
                else if (light == 1)
                {
                    timer1.Interval = 1000;
                    light = 2;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Green.jpg";
                }
                else if (light == 2)
                {
                    timer1.Interval = 1000;
                    light = 0;
                    pictureBox1.ImageLocation = "C:\\Users\\Mehedi Tamim\\Desktop\\Red.jpg";
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
