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
    public partial class Form17 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        String y = Form4.x;
        public Form17()
        {
            InitializeComponent();
            BindGridView();
        }
        void BindGridView()
        {

            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("Select UID,REASON,AMOUNT,SIGNAL,SID,DATE,STATUS from HISTORY_TABLE where UID= '" + y + "'", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
