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
    public partial class Form13 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        public Form13()
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

        public static bool ISNUMERIC(String S)
        {
            return int.TryParse(S, out int m);
        }
        public static string id;
        public static string password;
        public static string Mobile;
        public static string Type="Sergeant";
        bool a, b, c, d;

        private void button3_Click(object sender, EventArgs e)
        {
            a = textBox1.Text != "";
            b = textBox3.Text != "";
            c = textBox5.Text != "";
            d = textBox6.Text != "";
            if (a && b && dateTimePicker1.Value != null && c && d && pictureBox1.Image != null&&comboBox1.SelectedItem!=null)
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey3 = " Select * from S_TABLE  where SID=@UID";
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
                    if (textBox3.Text.ToString().Length == 11 && ISNUMERIC(textBox3.Text))
                    {
                        Mobile = textBox3.Text;
                        String qurey0 = " Select MN from S_TABLE  where MN=@MN ";
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
                            String qurey = " insert into S_TABLE values(@SName,@DOB,@Gender,@SID,@Pass,@MN,@PIC)";
                            String qurey2 = " insert into LOGIN_TABLE values(@Type,@SID,@Pass,@MN)";
                            SqlCommand cmd = new SqlCommand(qurey, con);
                            SqlCommand cmd2 = new SqlCommand(qurey2, con);
                            cmd.Parameters.AddWithValue("@SName", textBox1.Text);
                            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                            cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                            cmd.Parameters.AddWithValue("@SID", textBox5.Text);
                            cmd.Parameters.AddWithValue("@MN", textBox3.Text);
                            cmd.Parameters.AddWithValue("@PIC", SavePhoto());
                            cmd2.Parameters.AddWithValue("@SID", textBox5.Text);
                            cmd.Parameters.AddWithValue("@Pass", textBox6.Text);
                            cmd2.Parameters.AddWithValue("@Pass", textBox6.Text);
                            cmd2.Parameters.AddWithValue("@Type", Type);
                            cmd2.Parameters.AddWithValue("@MN", textBox3.Text);

                            int a = cmd.ExecuteNonQuery();
                            int b = cmd2.ExecuteNonQuery();
                            if (a > 0 && b > 0)
                            {
                                BindGridView();
                                ResetContro();
                                MessageBox.Show("DATA INSERTED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("DATA INSERTION FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ResetContro();
                            }
                            con.Close();
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

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from S_TABLE";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }
        void ResetContro()
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.SelectedItem = null;
            pictureBox1.Image = null;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            a = textBox1.Text != "";
            b = textBox3.Text != "";
            c = textBox5.Text != "";
            d = textBox6.Text != "";
            if (a && b && dateTimePicker1.Value != null && c && d && pictureBox1.Image != null && comboBox1.SelectedItem != null)
            {
                SqlConnection con = new SqlConnection(cs);
                if (textBox3.Text.ToString().Length == 11 && ISNUMERIC(textBox3.Text))

                {
                    Mobile = textBox3.Text;
                    String qurey0 = " Select MN from S_TABLE  where MN=@MN and SID!=@UID";
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
                        String qurey = " Update  S_TABLE  set Sname=@SName,DOB=@DOB,GENDER=@Gender,Pass=@Pass,MN=@MN,PIC=@PIC where SID=@SID";
                        String qurey2 = " Update  LOGIN_TABLE  set Pass=@Pass,MN=@MN where UID=@SID";
                        SqlCommand cmd = new SqlCommand(qurey, con);
                        SqlCommand cmd2 = new SqlCommand(qurey2, con);
                        cmd.Parameters.AddWithValue("@SName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@SID", textBox5.Text);
                        cmd.Parameters.AddWithValue("@MN", textBox3.Text);
                        cmd.Parameters.AddWithValue("@PIC", SavePhoto());
                        cmd2.Parameters.AddWithValue("@SID", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Pass", textBox6.Text);
                        cmd2.Parameters.AddWithValue("@Pass", textBox6.Text);
                        cmd2.Parameters.AddWithValue("@Type", Type);
                        cmd2.Parameters.AddWithValue("@MN", textBox3.Text);
                        int a = cmd.ExecuteNonQuery();
                        int b = cmd2.ExecuteNonQuery();
                        if (a > 0 && b > 0)
                        {
                            BindGridView();
                            ResetContro();
                            MessageBox.Show("DATA Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("DATA Update FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetContro();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                pictureBox1.Image = GetPhoto((byte[])dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = " select * from S_TABLE where SID=@UID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UID", textBox2.Text);
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    string query1 = "select * from S_TABLE where SID='" + textBox2.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    ///Image Column
                    DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                    dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
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

        private void button1_Click(object sender, EventArgs e)
        {
            a = textBox1.Text != "";
            b = textBox3.Text != "";
            c = textBox5.Text != "";
            d = textBox6.Text != "";
            if (a && b && dateTimePicker1.Value != null && c && d && pictureBox1.Image != null && comboBox1.SelectedItem != null)
            {
            SqlConnection con = new SqlConnection(cs);
            String qurey = " Delete from  S_TABLE   where SID=@SID";
            String qurey2 = " Delete from  LOGIN_TABLE  where UID=@SID";
            SqlCommand cmd = new SqlCommand(qurey, con);
            SqlCommand cmd2 = new SqlCommand(qurey2, con);
            cmd.Parameters.AddWithValue("@SID", textBox5.Text);
            cmd2.Parameters.AddWithValue("@SID", textBox5.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            int b = cmd2.ExecuteNonQuery();
            if (a > 0 && b > 0)
            {
                BindGridView();
                ResetContro();
                MessageBox.Show("DATA DELETED", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("DATA Deletion FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetContro();
            }
            con.Close();
            }
            else
            {
                MessageBox.Show("You Have to fill everything", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
    }