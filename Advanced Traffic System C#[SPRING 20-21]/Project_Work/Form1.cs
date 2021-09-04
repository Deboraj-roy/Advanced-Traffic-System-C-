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
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
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
        //Making Numeric Check Function
        public static bool ISNUMERIC(String S)
        {
            return int.TryParse(S,out int m);
        }


        public static int SPEED=0;
        public static int SIGNAL = 0;
        public static String Mobile ;
        public static string id;
        public static string Type="Driver";
        bool a, b, c, d, f;

        private void button1_Click(object sender, EventArgs e)
        {
            a =  textBox1.Text != "";
            b =  textBox3.Text != "";
            c =  textBox5.Text != "";
            d =  textBox6.Text != "";
            f =  textBox2.Text != "";
            if (a && b && dateTimePicker2.Value != null && c && d && f && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && dateTimePicker1.Value != null && pictureBox1.Image!=null)
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey3 = " Select * from USERS_TABLE  where UID=@UID";
                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                cmd3.Parameters.AddWithValue("@UID", textBox5.Text);
                con.Open();
                if (cmd3.ExecuteScalar() != null)//UID Matched
                {
                    MessageBox.Show("Try Another USER ID", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Checking Mobile Number
                    if (textBox2.Text.ToString().Length == 11 && ISNUMERIC(textBox2.Text))
                    {
                        Mobile = textBox2.Text;
                        String qurey0 = " Select MN from USERS_TABLE  where MN=@MN";
                        String qurey11 = " Select MN from LOGIN_TABLE  where MN=@MN";
                        SqlCommand cmd0 = new SqlCommand(qurey0, con);
                        SqlCommand cmd11 = new SqlCommand(qurey11, con);
                        cmd0.Parameters.AddWithValue("@MN", Mobile);
                        cmd11.Parameters.AddWithValue("@MN", Mobile);
                        if (cmd0.ExecuteScalar() != null || cmd11.ExecuteScalar() != null)
                        {
                            MessageBox.Show("Try Another Mobile Number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //Start query
                            String qurey = " insert into USERS_TABLE values(@UName,@DOB,@Gender,@LN,@LID,@VT,@UID,@Pass,@MN,@PIC)";
                            String qurey2 = " insert into LOGIN_TABLE values(@Type,@UID,@Pass,@MN)";
                            String qurey4 = " insert into SPEED_TABLE values(@UID,@SPEED,@SIGNAL)";
                            SqlCommand cmd = new SqlCommand(qurey, con);
                            SqlCommand cmd2 = new SqlCommand(qurey2, con);
                            SqlCommand cmd4 = new SqlCommand(qurey4, con);
                            cmd.Parameters.AddWithValue("@UName", textBox1.Text);
                            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                            cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                            cmd.Parameters.AddWithValue("@LN", textBox3.Text);
                            cmd.Parameters.AddWithValue("@LID", dateTimePicker2.Value);
                            cmd.Parameters.AddWithValue("@VT", comboBox2.SelectedItem);
                            cmd.Parameters.AddWithValue("@UID", textBox5.Text);
                            cmd.Parameters.AddWithValue("@MN", Mobile);
                            cmd.Parameters.AddWithValue("@PIC", SavePhoto());
                            cmd2.Parameters.AddWithValue("@UID", textBox5.Text);
                            cmd.Parameters.AddWithValue("@Pass", textBox6.Text);
                            cmd2.Parameters.AddWithValue("@Pass", textBox6.Text);
                            cmd2.Parameters.AddWithValue("@MN", Mobile);
                            cmd.Parameters.AddWithValue("@Type", Type);
                            cmd2.Parameters.AddWithValue("@Type", Type);
                            cmd4.Parameters.AddWithValue("@UID", textBox5.Text);
                            cmd4.Parameters.AddWithValue("@SPEED", SPEED);
                            cmd4.Parameters.AddWithValue("@SIGNAL", SIGNAL);
                            int a = cmd.ExecuteNonQuery();
                            int b = cmd2.ExecuteNonQuery();
                            int c = cmd4.ExecuteNonQuery();

                            if (a > 0 && b > 0 && c > 0)
                            {
                                MessageBox.Show("SIGN-UP SUCCESSFUL", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("DATA INSERTION FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }



                            //****************************************************************************
                            this.Hide();
                            Form4 f4 = new Form4();
                            f4.Show();
                            con.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("MOBILE NUMBER MUST BE NUMERIC AND 11 DIGITS", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Please fill the fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);

            return ms.GetBuffer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Please enter your name ");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Please enter Username");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Please enter a strong Password");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

       
    }
}
