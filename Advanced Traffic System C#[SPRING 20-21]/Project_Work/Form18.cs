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
    public partial class Form18 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        String y = Form4.x;
        public Form18()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        public void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {

        }
        public static string ER="YES";
        public static string SV = "NO";
        public static string PAYMENT = "NO";



        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey3 = " Select * from LISTING_TABLE  where UID=@UID and ER=@ER";
                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                cmd3.Parameters.AddWithValue("@UID", y);
                cmd3.Parameters.AddWithValue("@ER", ER);
                con.Open();
                if (cmd3.ExecuteScalar() != null)
                {
                    MessageBox.Show("Already Pending a Request", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    String qurey = " insert into LISTING_TABLE values(@UID,@DES,@REASON,@ER,@SV,@PAYMENT)";
                    SqlCommand cmd = new SqlCommand(qurey, con);
                    cmd.Parameters.AddWithValue("@UID", y);
                    cmd.Parameters.AddWithValue("@DES", textBox1.Text);
                    cmd.Parameters.AddWithValue("@REASON", textBox2.Text);
                    cmd.Parameters.AddWithValue("ER", ER);
                    cmd.Parameters.AddWithValue("SV", SV);
                    cmd.Parameters.AddWithValue("PAYMENT", PAYMENT);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        reset();
                        MessageBox.Show("DATA INSERTED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("DATA INSERTION FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("You Have to fill everything");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
