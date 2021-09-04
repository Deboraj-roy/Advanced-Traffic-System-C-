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
    public partial class Form16 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        String p = Form4.x;
        public Form16()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }
        public void reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Text = null;
            label1.Text = "";
        }
        static String SP = "SPEED BREAK";
        int A = 500;
        public static String status = "Unknown";

        public static String REASON = "SPEED VIOLATTION";
        public static String ER = "NO";
        public static String SV = "YES";
        public static String DES = "  ";
        public static String PAYMENT = "NO";

        private void button3_Click(object sender, EventArgs e)
        {
            bool m =  textBox1.Text != "";
            bool n = textBox2.Text != "";
            if (m&&n)
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey4 = " Select * from PENALTY_TABLE  where UID=@UID";
                SqlCommand cmd4 = new SqlCommand(qurey4, con);
                cmd4.Parameters.AddWithValue("@UID", textBox1.Text);
                con.Open();
                if (cmd4.ExecuteScalar() != null)
                {
                    MessageBox.Show("THIS USER IS ALREADY PENALIZED","Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    String qurey3 = " Delete from  SPEEDBREAK_TABLE where UID=@UID";
                    String qurey1 = " insert into PENALTY_TABLE values(@UID,@CR,@P_AMOUNT,@DATE,@SIGNAL)";
                    String qurey2 = " insert into HISTORY_TABLE values(@UID,@CR,@P_AMOUNT,@SIGNAL,@SNAME,@DATE,@STATUS)";
                    SqlCommand cmd1 = new SqlCommand(qurey1, con);
                    SqlCommand cmd2 = new SqlCommand(qurey2, con);
                    SqlCommand cmd3 = new SqlCommand(qurey3, con);
                    cmd3.Parameters.AddWithValue("@UID", textBox1.Text);
                    cmd1.Parameters.AddWithValue("@UID", textBox1.Text);
                    cmd1.Parameters.AddWithValue("@CR", SP);
                    cmd1.Parameters.AddWithValue("@P_AMOUNT", A);
                    cmd1.Parameters.AddWithValue("DATE", dateTimePicker1.Value);
                    cmd1.Parameters.AddWithValue("@SIGNAL",textBox2.Text );
                    cmd2.Parameters.AddWithValue("@UID", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@CR", SP);
                    cmd2.Parameters.AddWithValue("@P_AMOUNT", A);
                    cmd2.Parameters.AddWithValue("@STATUS", status);
                    cmd2.Parameters.AddWithValue("DATE", dateTimePicker1.Value);
                    cmd2.Parameters.AddWithValue("@SIGNAL", textBox2.Text);
                    cmd2.Parameters.AddWithValue("@SNAME", p);
                    int a = cmd1.ExecuteNonQuery();
                    int b = cmd2.ExecuteNonQuery();
                    int c = cmd3.ExecuteNonQuery();


                    if (a > 0 && b > 0 && c > 0)
                    {

                        BindGridView();
                        reset();
                        MessageBox.Show("ACTION TAKEN", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("SOMETHING IS WRONG", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("No User Is Select", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from SPEEDBREAK_TABLE";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                label1.Text = textBox1.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
