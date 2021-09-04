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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
          //  button1.BackColor = Color.Silver;
          //  button1.ForeColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  this.Hide();
           // Form4 f4 = new Form4();
           // f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  this.Hide();
          //  Form5 f5 = new Form5();
           // f5.Show();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
           // button1.BackColor = Color.Silver;
           // button1.ForeColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  this.Hide();
           // Form6 f6 = new Form6();
           // f6.Show();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
           //button1.BackColor = Color.Silver;
           //button1.ForeColor = Color.Blue;
        }

        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.Silver;
            button1.ForeColor = Color.Blue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Lavender;
            button1.ForeColor = Color.Black;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_MouseHover_1(object sender, EventArgs e)
        {
            button2.BackColor = Color.Silver;
            button2.ForeColor = Color.Blue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Lavender;
            button2.ForeColor = Color.Black;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void button3_MouseHover_1(object sender, EventArgs e)
        {
            button3.BackColor = Color.Silver;
            button3.ForeColor = Color.Blue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Lavender;
            button3.ForeColor = Color.Black;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
