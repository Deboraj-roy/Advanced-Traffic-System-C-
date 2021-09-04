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
    public partial class Form6 : Form
    {
        String y = Form4.x;
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form6()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(cs);
            String qurey3 = " Select UNAME from USERS_TABLE  where UID=@UID";
            String qurey4 = " Select PIC from USERS_TABLE  where UID=@UID";
            SqlCommand cmd3 = new SqlCommand(qurey3, con);
            SqlCommand cmd4 = new SqlCommand(qurey4, con);
            cmd3.Parameters.AddWithValue("@UID", y);
            cmd4.Parameters.AddWithValue("@UID", y);
            con.Open();
            label2.Text = cmd3.ExecuteScalar().ToString();
            pictureBox1.Image = GetPhoto((byte[])cmd4.ExecuteScalar());
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 f17 = new Form17();
            f17.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form18 f18 = new Form18();
            f18.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form19 f19 = new Form19();
            f19.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form20 f20 = new Form20();
            f20.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
