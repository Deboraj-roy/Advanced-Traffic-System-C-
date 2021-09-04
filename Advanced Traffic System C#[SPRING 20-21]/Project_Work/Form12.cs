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
    public partial class Form12 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form12()
        {
            InitializeComponent();
            BindGridView();
        }
        public static String x = "YES";
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select UID , PAYMENT from LISTING_TABLE where PAYMENT='" + x + "' or SV = '" + x + "'";
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

        public static String status = "PAID";
        public static String status1 = "PENDING";

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String qurey = " Delete from  LISTING_TABLE   where UID=@UID and PAYMENT = '" + x + "' or SV = '" + x + "'";
            String qurey2 = " Delete from  PENALTY_TABLE   where UID=@UID";
            String qurey3 = " Update HISTORY_TABLE set STATUS=@STATUS where UID=@UID and STATUS=@status1";
            SqlCommand cmd = new SqlCommand(qurey, con);
            SqlCommand cmd2 = new SqlCommand(qurey2, con);
            SqlCommand cmd3 = new SqlCommand(qurey3, con);
            cmd.Parameters.AddWithValue("@UID", textBox1.Text);
            cmd2.Parameters.AddWithValue("@UID", textBox1.Text);
            cmd3.Parameters.AddWithValue("@UID", textBox1.Text);
            cmd3.Parameters.AddWithValue("@STATUS", status);
            cmd3.Parameters.AddWithValue("@status1", status1);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            int b = cmd2.ExecuteNonQuery();
            int c = cmd3.ExecuteNonQuery();

            if (a > 0 && b>0 && c>0)
            {
                BindGridView();
                MessageBox.Show("PAYMENT CONFIRMED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("PAYMENT FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            label2.Text = "";
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                label2.Text = textBox1.Text;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
