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
    public partial class Form5 : Form
    {
        String y = Form4.x;
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form5()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(cs);
            String qurey3 = " Select SNAME from S_TABLE  where SID=@UID";
            String qurey4 = " Select PIC from S_TABLE  where SID=@UID";
            SqlCommand cmd3 = new SqlCommand(qurey3, con);
            SqlCommand cmd4 = new SqlCommand(qurey4, con);
            cmd3.Parameters.AddWithValue("@UID", y);
            cmd4.Parameters.AddWithValue("@UID", y);
            con.Open();
            label3.Text = cmd3.ExecuteScalar().ToString();
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
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 f16 = new Form16();
            f16.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
