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

namespace Project_Work
{
    public partial class Form4 : Form
    {
        public static String x;
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        public static string id;
        public static string pass;

        private void button1_Click(object sender, EventArgs e)
        {
            //toolTip1.SetToolTip(button1, "Login to the System!");
            if ((textBox1.Text != "" || textBox1.Text != null) && (textBox2.Text != "" || textBox2.Text != ""))
            {
                SqlConnection con = new SqlConnection(cs);
                string query = " select * from LOGIN_TABLE where UID=@UID and Pass=@Pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Pass", textBox2.Text);
                con.Open();
                SqlDataReader Type = cmd.ExecuteReader();
                x = textBox1.Text;
               // label3.Text =" " + Form4.UID;
                

                if(Type.HasRows == true)
                {
                    Type.Read();
                    if(Type[0].ToString()=="Admin")
                    {
                        this.Hide();
                        Form8 f8 = new Form8();
                        f8.Show();
                    }
                    else if(Type[0].ToString() == "Sergeant")
                    {
                        this.Hide();
                        Form5 f5 = new Form5();
                        f5.Show();
                    }
                    else if (Type[0].ToString() == "Driver")
                    {
                        this.Hide();
                        Form6 f6 = new Form6();
                        f6.Show();
                        
                    }

                }
                else
                {
                    MessageBox.Show("Please Insert valid credential", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

            }
            else
            {
                MessageBox.Show("You can't Log In without your Id and Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form22 form22 = new Form22();
            form22.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}