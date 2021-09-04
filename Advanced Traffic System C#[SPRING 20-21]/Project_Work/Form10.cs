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
    public partial class Form10 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form10()
        {
            InitializeComponent();
            BindGridView();
        }
        public static String x = "YES";

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select UID ,DES, REASON from LISTING_TABLE where ER='"+x+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String qurey = " Delete from  LISTING_TABLE   where UID=@UID";
            SqlCommand cmd = new SqlCommand(qurey, con);
            cmd.Parameters.AddWithValue("@UID", textBox1.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                BindGridView();
                MessageBox.Show("Request DECLINE for Selected Vehicles", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("DATA DECLINATION FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String qurey = " Delete from  LISTING_TABLE   where UID=@UID and ER='" + x + "'";
            SqlCommand cmd = new SqlCommand(qurey, con);
            cmd.Parameters.AddWithValue("@UID", textBox1.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0 )
            {
                BindGridView();
                MessageBox.Show("Request Accepted for Selected Vehicles", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("DATA ACCEPTATION FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            Reset();
        }

        private void Reset()
        {
            label1.Text = "";
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                label1.Text = textBox1.Text;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
