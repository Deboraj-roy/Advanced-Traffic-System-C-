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
    public partial class Form22 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        int OTP;
        public Form22()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }
        public void reset()
        {
            textBox1.Clear();
            textBox3.Clear();;
            textBox5.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey = " Select UID from LOGIN_TABLE where MN=@MN";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@MN", textBox1.Text);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    if (textBox5.Text == OTP.ToString())
                    {
                        if (textBox3.Text == textBox4.Text)
                        {
                            String qurey1 = " Update  LOGIN_TABLE set PASS=@password  where MN=@MN";
                            SqlCommand cmd1 = new SqlCommand(qurey1, con);
                            cmd1.Parameters.AddWithValue("@MN", textBox1.Text);
                            cmd1.Parameters.AddWithValue("@password", textBox3.Text);
                            int a = cmd1.ExecuteNonQuery();
                            if (a > 0)
                            {
                                String qurey2 = " Update  USERS_TABLE set PASS=@password  where MN=@MN";
                                String qurey3 = " Update  S_TABLE set PASS=@password  where MN=@MN";
                                SqlCommand cmd2 = new SqlCommand(qurey2, con);
                                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                                cmd2.Parameters.AddWithValue("@MN", textBox1.Text);
                                cmd2.Parameters.AddWithValue("@password", textBox3.Text);
                                cmd3.Parameters.AddWithValue("@MN", textBox1.Text);
                                cmd3.Parameters.AddWithValue("@password", textBox3.Text);
                                cmd2.ExecuteNonQuery();
                                cmd3.ExecuteNonQuery();
                                reset();
                                MessageBox.Show("PASSSWORD CHANGE SUCCESSFULLY");
                   
                            }
                            else
                            {
                                MessageBox.Show("PASSSWORD CHANGE DECLINED");
                            }
                        }
                        else
                        {
                            MessageBox.Show("PREVIOUS AND CONFIRM PASSWORD DOESN'T MATCH");
                        }
                    }
                    else
                    {
                        reset();
                        MessageBox.Show("INCORRECT OTP");
                    }
                }
                else
                {
                    MessageBox.Show("PLEASE ENTER CORRECT PASSWORD");
                }
            }
            else
            {
                MessageBox.Show("YOU HAVE TO  FILL EVERYTHING ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey = " Select MN from LOGIN_TABLE where MN=@MN";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@MN", textBox1.Text);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    Random random = new System.Random();
                    int value = random.Next(1111, 9999);
                    OTP = value;
                    MessageBox.Show("OTPS IS: " + OTP);
                    textBox5.Text = OTP.ToString();
                }
                else
                {
                    reset();
                    MessageBox.Show("PLEASE ENTER CORRECT USER_ID");
                }
            }
            else
            {
                MessageBox.Show("YOU HAVE TO  FILL USER_ID ");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
