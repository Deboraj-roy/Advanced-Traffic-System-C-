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
    public partial class Form11 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form11()
        {
            InitializeComponent();
            BindGridView();
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
            SqlCommand cmd = new SqlCommand("Select max (SERIAL) from SPEED_TABLE", con);
            con.Open();
            int a =Convert.ToInt32(cmd.ExecuteScalar());
           //MessageBox.Show(a.ToString());
            for(int i=1;i<=a;i++)
            {
                SqlCommand cmd1 = new SqlCommand("update SPEED_TABLE set SPEED=150*Rand(),SIGNAL=10*Rand() Where SERIAL=@SERIAL", con);
                cmd1.Parameters.AddWithValue("@SERIAL",i);
                cmd1.ExecuteNonQuery();
            }
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select UID,SPEED,SIGNAL from SPEED_TABLE";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bool a, b,c;
            a = textBox1.Text != "";
            b = textBox2.Text != "";
            c = textBox3.Text != "";

            if (a && b && c)
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey3 = " Select * from SPEEDBREAK_TABLE  where UID=@UID";
                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                cmd3.Parameters.AddWithValue("@UID", textBox1.Text);
                con.Open();
                if (cmd3.ExecuteScalar() != null)
                {
                    MessageBox.Show("THIS USER'S ID IS ALREADY NOTIFIED");
                    textBox1.Text = "";
                    textBox2.Text="";
                    label1.Text = "";
                    label2.Text = "";
                }
                else
                {
                  
                        String qurey = " insert into SPEEDBREAK_TABLE values(@UID,@SPEED,@SIGNAL,@DATE)";
                        SqlCommand cmd = new SqlCommand(qurey, con);
                        cmd.Parameters.AddWithValue("@UID", textBox1.Text);
                        cmd.Parameters.AddWithValue("@SPEED", textBox2.Text);
                        cmd.Parameters.AddWithValue("@SIGNAL", textBox3.Text);
                        cmd.Parameters.AddWithValue("@DATE",dateTimePicker1.Value);
                        int d = cmd.ExecuteNonQuery();
                        if (d > 0)
                        {
                            MessageBox.Show("NOTIFIED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            label1.Text = "";
                            label2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("NOTIFY FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox2.Text = "";
                        }
                }
            }
            else
            {
                MessageBox.Show("You Have to allot everything");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                label1.Text = textBox1.Text;
                label2.Text = textBox2.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
