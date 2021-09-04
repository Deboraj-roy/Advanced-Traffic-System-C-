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
    public partial class Form23 : Form
    {
        decimal light = 0;
        public Form23()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(5);
            if (progressBar1.Value == 200)
            {
                timer1.Stop();
                this.Hide();
                Form4 f4 = new Form4();
                f4.Show();
            }
            else
            {


                if (light == 0)
                {
                    timer1.Interval = 90;
                    light = 1;
                    pictureBox2.ImageLocation = "C:\\Users\\Mehedi Tamim\\Downloads\\MicrosoftTeams-image (5).png";
                }
                else if (light == 1)
                {
                    timer1.Interval = 90;
                    light = 2;
                    pictureBox2.ImageLocation = "C:\\Users\\Mehedi Tamim\\Downloads\\MicrosoftTeams-image (6).png";
                }
                else if (light == 2)
                {
                    timer1.Interval = 90;
                    light = 3;
                    pictureBox2.ImageLocation = "C:\\Users\\Mehedi Tamim\\Downloads\\MicrosoftTeams-image (7).png";
                }
                else if (light == 3)
                {
                    timer1.Interval = 90;
                    light = 0;
                    pictureBox2.ImageLocation = "C:\\Users\\Mehedi Tamim\\Downloads\\MicrosoftTeams-image (8).png";
                }

            } 
          
            
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
