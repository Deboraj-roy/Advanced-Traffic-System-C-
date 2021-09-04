using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Project_Work
{
    public partial class Form8 : Form
    {
        String y = Form4.x;
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form8()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f10 = new Form10();
            f10.Show();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form21 f21 = new Form21();
            f21.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
