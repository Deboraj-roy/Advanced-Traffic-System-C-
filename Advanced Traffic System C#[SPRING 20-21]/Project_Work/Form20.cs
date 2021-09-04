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
    public partial class Form20 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        String y = Form4.x;
        public Form20()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }
        public void reset()
        {
            textBox1.Clear();
            dateTimePicker1.Text = null;
            comboBox2.SelectedItem = null;
            textBox6.Clear();
            textBox2.Clear();
            pictureBox3.Image = null;
        }
        public static bool ISNUMERIC(String S)
        {
            return int.TryParse(S, out int m);
        }
        public static string Mobile;
        public static string password;
        public static string DOB;
        bool a, b, c, d;


        private void button1_Click(object sender, EventArgs e)
        {
            a = textBox1.Text != "";
            c = textBox2.Text != "";
            d = textBox6.Text != "";
            if (a && dateTimePicker1 != null && c && d && pictureBox1.Image != null)
            {
                SqlConnection con = new SqlConnection(cs);
                if (textBox2.Text.ToString().Length == 11 && ISNUMERIC(textBox2.Text))
                {
                    Mobile = textBox2.Text;
                    String qurey0 = " Select MN from USERS_TABLE  where MN=@MN and UID!=@UID";
                    String qurey11 = " Select MN from LOGIN_TABLE  where MN=@MN and UID!=@UID";
                    SqlCommand cmd0 = new SqlCommand(qurey0, con);
                    SqlCommand cmd11 = new SqlCommand(qurey11, con);
                    cmd0.Parameters.AddWithValue("@MN", Mobile);
                    cmd11.Parameters.AddWithValue("@MN", Mobile);
                    cmd0.Parameters.AddWithValue("@UID", y);
                    cmd11.Parameters.AddWithValue("@UID", y);
                    con.Open();
                    if (cmd0.ExecuteScalar() != null || cmd11.ExecuteScalar() != null)
                    {
                        MessageBox.Show("Try Another Mobile Number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        String qurey2 = " Update  LOGIN_TABLE  set Pass=@Pass where UID='" + y + "'";
                        SqlCommand cmd = new SqlCommand(" Update  USERS_TABLE  set  UName=@UName,DOB=@DOB,VT=@VT,Pass=@Pass,PIC=@PIC,MN=@MN where UID='" + y + "'", con);
                        SqlCommand cmd2 = new SqlCommand(qurey2, con);
                        cmd.Parameters.AddWithValue("@UName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@VT", comboBox2.SelectedItem);
                        cmd.Parameters.AddWithValue("@MN", textBox2.Text);
                        cmd.Parameters.AddWithValue("@PIC", SavePhoto());
                        cmd.Parameters.AddWithValue("@Pass", textBox6.Text);
                        cmd2.Parameters.AddWithValue("@Pass", textBox6.Text);
                        cmd2.Parameters.AddWithValue("@MN", textBox2.Text);
                        int a = cmd.ExecuteNonQuery();
                        int b = cmd2.ExecuteNonQuery();
                        if (a > 0 && b > 0)
                        {
                            BindGridView();
                            reset();
                            MessageBox.Show("DATA Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("DATA Update FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();

                    }

                }
                else
                {
                    MessageBox.Show("MOBILE NUMBER MUST BE NUMERIC AND 11 DIGITS", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("You Have to fill everything", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                pictureBox3.Image = GetPhoto((byte[])dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox3.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from USERS_TABLE where UID='"+y+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[9];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 60;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(ofd.FileName);
            }
        }
    }
}
