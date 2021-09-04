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
    public partial class Form21 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form21()
        {
            InitializeComponent();
            BindGridView();
        }
        public static string id;
        public static string password;
        public static string name;
        public static string Type = "Driver";
        public static string Mobile;
        bool a, b, c, d,f;
        public void reset()
        {
            textBox1.Clear();
            dateTimePicker1.Text = null;
            textBox3.Clear();
            dateTimePicker2.Text = null;
            comboBox2.SelectedItem = null;
            comboBox1.SelectedItem = null;
            textBox5.Clear();
            textBox6.Clear();
            textBox4.Clear();
            pictureBox3.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            a = textBox1.Text != "";
            b = textBox3.Text != "";
            c = textBox5.Text != "";
            d = textBox6.Text != "";
            f = textBox4.Text != "";
            if (a && b && dateTimePicker2.Value != null && c && d && f && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && dateTimePicker1.Value != null && pictureBox1.Image != null)
            {
                SqlConnection con = new SqlConnection(cs);
                if (textBox4.Text.ToString().Length == 11 && ISNUMERIC(textBox4.Text))
                {
                    Mobile = textBox4.Text;
                    String qurey0 = " Select MN from USERS_TABLE  where MN=@MN and UID!=@UID";
                    String qurey11 = " Select MN from LOGIN_TABLE  where MN=@MN and UID!=@UID";
                    SqlCommand cmd0 = new SqlCommand(qurey0, con);
                    SqlCommand cmd11 = new SqlCommand(qurey11, con);
                    cmd0.Parameters.AddWithValue("@MN", Mobile);
                    cmd11.Parameters.AddWithValue("@MN", Mobile);
                    cmd0.Parameters.AddWithValue("@UID", textBox5.Text);
                    cmd11.Parameters.AddWithValue("@UID", textBox5.Text);
                    con.Open();
                    if (cmd0.ExecuteScalar() != null || cmd11.ExecuteScalar() != null)
                    {
                        MessageBox.Show("Try Another Mobile Number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        String qurey = " Update  USERS_TABLE  set  UName=@UName,DOB=@DOB,GENDER=@Gender,LN=@LN,LID=@LID,VT=@VT,Pass=@Pass,MN=@MN,PIC=@PIC where UID=@UID";
                        String qurey2 = " Update  LOGIN_TABLE  set Pass=@Pass,MN=@MN where UID=@SID";
                        SqlCommand cmd = new SqlCommand(qurey, con);
                        SqlCommand cmd2 = new SqlCommand(qurey2, con);
                        cmd.Parameters.AddWithValue("@UName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@LN", textBox3.Text);
                        cmd.Parameters.AddWithValue("@LID", dateTimePicker2.Value);
                        cmd.Parameters.AddWithValue("@VT", comboBox2.SelectedItem);
                        cmd.Parameters.AddWithValue("@UID", textBox5.Text);
                        cmd.Parameters.AddWithValue("@MN", Mobile);
                        cmd.Parameters.AddWithValue("@PIC", SavePhoto());
                        cmd2.Parameters.AddWithValue("@UID", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Pass", textBox6.Text);
                        cmd2.Parameters.AddWithValue("@SID", textBox5.Text);
                        cmd2.Parameters.AddWithValue("@Pass", textBox6.Text);
                        cmd2.Parameters.AddWithValue("@Type", Type);
                        cmd2.Parameters.AddWithValue("@MN", Mobile);
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

        private void button2_Click(object sender, EventArgs e)
        {
            a = textBox1.Text != "";
            b = textBox3.Text != "";
            c = textBox5.Text != "";
            d = textBox6.Text != "";
            f = textBox4.Text != "";
            if (a && b && dateTimePicker2.Value != null && c && d && f && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && dateTimePicker1.Value != null && pictureBox1.Image != null)
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey = " Delete from  USERS_TABLE   where UID=@UID";
                String qurey2 = " Delete from  LOGIN_TABLE  where UID=@UID";
                String qurey3 = "Delete from  SPEED_TABLE  where UID=@UID";
                SqlCommand cmd = new SqlCommand(qurey, con);
                SqlCommand cmd2 = new SqlCommand(qurey2, con);
                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                cmd.Parameters.AddWithValue("@UID", textBox5.Text);
                cmd2.Parameters.AddWithValue("@UID", textBox5.Text);
                cmd3.Parameters.AddWithValue("@UID", textBox5.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                int b = cmd2.ExecuteNonQuery();
                int c = cmd3.ExecuteNonQuery();

                if (a > 0 && b > 0 && c>0)
                {
                    BindGridView();
                    reset();
                    MessageBox.Show("DATA DELETED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("DATA Deletion FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("You Have to fill everything", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                pictureBox3.Image = GetPhoto((byte[])dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = " select * from USERS_TABLE where UID=@UID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UID", textBox2.Text);
                con.Open();
                if(cmd.ExecuteScalar() != null)
                {
                    string query1 = "select * from USERS_TABLE where UID='" + textBox2.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con);
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
                    dataGridView1.RowTemplate.Height = 50;
                    textBox2.Text = null;

                }
                else
                {
                    MessageBox.Show("Please Insert valid credential", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Yor are not searching anything ");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static int SPEED = 0;
        public static int SIGNAL = 0;

        //Making Numeric Check Function
        public static bool ISNUMERIC(String S)
        {
            return int.TryParse(S, out int m);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            a = textBox1.Text != "";
            b = textBox3.Text != "";
            c = textBox5.Text != "";
            d = textBox6.Text != "";
            f = textBox4.Text != "";
            if (a && b && dateTimePicker2.Value != null && c && d && f && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && dateTimePicker1.Value != null && pictureBox3.Image != null)
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey3 = " Select * from USERS_TABLE  where UID=@UID";
                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                cmd3.Parameters.AddWithValue("@UID", textBox5.Text);
                con.Open();
                if (cmd3.ExecuteScalar() != null)
                {
                    MessageBox.Show("Try Another USER ID", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Checking Mobile Number
                    if (textBox4.Text.ToString().Length == 11 && ISNUMERIC(textBox4.Text))
                    {
                        Mobile = textBox4.Text;
                        String qurey0 = " Select MN from USERS_TABLE  where MN=@MN";
                        String qurey11 = " Select MN from LOGIN_TABLE  where MN=@MN";
                        SqlCommand cmd0 = new SqlCommand(qurey0, con);
                        SqlCommand cmd11 = new SqlCommand(qurey11, con);
                        cmd0.Parameters.AddWithValue("@MN", Mobile);
                        cmd11.Parameters.AddWithValue("@MN", Mobile);
                        if (cmd0.ExecuteScalar() != null || cmd11.ExecuteScalar() != null)
                        {
                            MessageBox.Show("Try Another Mobile Number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //Start query
                            String qurey = " insert into USERS_TABLE values(@UName,@DOB,@Gender,@LN,@LID,@VT,@UID,@Pass,@MN,@PIC)";
                            String qurey2 = " insert into LOGIN_TABLE values(@Type,@UID,@Pass,@MN)";
                            String qurey4 = " insert into SPEED_TABLE values(@UID,@SPEED,@SIGNAL)";
                            SqlCommand cmd = new SqlCommand(qurey, con);
                            SqlCommand cmd2 = new SqlCommand(qurey2, con);
                            SqlCommand cmd4 = new SqlCommand(qurey4, con);
                            cmd.Parameters.AddWithValue("@UName", textBox1.Text);
                            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                            cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                            cmd.Parameters.AddWithValue("@LN", textBox3.Text);
                            cmd.Parameters.AddWithValue("@LID", dateTimePicker2.Value);
                            cmd.Parameters.AddWithValue("@VT", comboBox2.SelectedItem);
                            cmd.Parameters.AddWithValue("@UID", textBox5.Text);
                            cmd.Parameters.AddWithValue("@MN", Mobile);
                            cmd.Parameters.AddWithValue("@PIC", SavePhoto());
                            cmd2.Parameters.AddWithValue("@UID", textBox5.Text);
                            cmd.Parameters.AddWithValue("@Pass", textBox6.Text);
                            cmd2.Parameters.AddWithValue("@Pass", textBox6.Text);
                            cmd2.Parameters.AddWithValue("@MN", Mobile);
                            cmd.Parameters.AddWithValue("@Type", Type);
                            cmd2.Parameters.AddWithValue("@Type", Type);
                            cmd4.Parameters.AddWithValue("@UID", textBox5.Text);
                            cmd4.Parameters.AddWithValue("@SPEED", SPEED);
                            cmd4.Parameters.AddWithValue("@SIGNAL", SIGNAL);
                            int a = cmd.ExecuteNonQuery();
                            int b = cmd2.ExecuteNonQuery();
                            int c = cmd4.ExecuteNonQuery();

                            if (a > 0 && b > 0 && c > 0)
                            {
                                BindGridView();
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
                        MessageBox.Show("MOBILE NUMBER MUST BE NUMERIC AND 11 DIGITS", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please fill the fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(ofd.FileName);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form21_Load(object sender, EventArgs e)
        {

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
            string query = "select * from USERS_TABLE";
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
            dataGridView1.RowTemplate.Height = 50;
        }
      


    }
}
