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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please enter your name ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider1.SetError(this.textBox2, "password !!!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        public static string id;
        public static string pass;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                this.Hide();
                id = textBox1.Text;
                pass = textBox2.Text;
                Form8 f8 = new Form8();
                f8.Show();
            }
            else
            {
                MessageBox.Show("You can't Log In without your Id and Password ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}