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
    public partial class Form14 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form14()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
             this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }
        void ResetContro()
        {
            textBox3.Clear();
        }

        private void textBox3_leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider1.SetError(this.textBox3, "ENTER USER NAME");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("Select UID,UName,DOB,LN,LID,VT from USERS_TABLE where UID= '" + textBox3.Text + "'", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
         public void ResetControl()
        {
            textBox3.Clear();

        }
        public static string id;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != ""|| textBox3.Text !=null)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = " select * from USERS_TABLE where UID=@UID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UID", textBox3.Text);
                con.Open();
                SqlDataReader Type = cmd.ExecuteReader();

                if (Type.HasRows == true)
                {
                    Type.Read();
                    BindGridView();
                    ResetControl();

                }
                else
                {
                    MessageBox.Show("Please Insert valid credential", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

            }
            else
            {
                MessageBox.Show("Yor are not searching anything ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
