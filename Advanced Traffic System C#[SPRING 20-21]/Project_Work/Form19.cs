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
    public partial class Form19 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sq"].ConnectionString;
        String y = Form4.x;
        public Form19()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }
        public static string ER = "NO";
        public static string SV = "NO";
        public static string PAYMENT = "YES";
        public static string DES = "N/A";
        public static String status = "PENDING";
        public static String status1 = "UNKNOWN";



        private void button2_Click(object sender, EventArgs e)
        {

            if ((label5.Text!=null && label5.Text!="") && (Convert.ToInt32(label3.Text) > 0 ))
            {
                SqlConnection con = new SqlConnection(cs);
                String qurey3 = " Select * from LISTING_TABLE  where UID=@UID";
                SqlCommand cmd3 = new SqlCommand(qurey3, con);
                cmd3.Parameters.AddWithValue("@UID", y);
                con.Open();
                if (cmd3.ExecuteScalar() != null)
                {
                    MessageBox.Show("YOUR PAYMENT IS ALREADY SENT");
                }
                else
                {
                    String qurey = " insert into LISTING_TABLE values(@UID,@DES,@REASON,@ER,@SV,@PAYMENT)";
                    String qurey2 = " Update HISTORY_TABLE set STATUS=@STATUS where UID=@UID and STATUS=@Status1";

                    SqlCommand cmd = new SqlCommand(qurey, con);
                    SqlCommand cmd2 = new SqlCommand(qurey2, con);
                    cmd.Parameters.AddWithValue("@UID", y);
                    cmd.Parameters.AddWithValue("@DES", DES);
                    cmd.Parameters.AddWithValue("@REASON", label5.Text);
                    cmd.Parameters.AddWithValue("@ER", ER);
                    cmd.Parameters.AddWithValue("@SV", SV);
                    cmd.Parameters.AddWithValue("@PAYMENT", PAYMENT);
                    cmd2.Parameters.AddWithValue("@UID", y);
                    cmd2.Parameters.AddWithValue("@STATUS", status);
                    cmd2.Parameters.AddWithValue("@status1", status1);
                    int a = cmd.ExecuteNonQuery();
                    int b = cmd2.ExecuteNonQuery();
                    if (a > 0 && b > 0)
                    {
                        MessageBox.Show("PAYMENT SENT AND WAIT FOR ADMIN APRROVAL", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("PAYMENT FAILED", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }             
            }
            else
            {
                MessageBox.Show("YOU HAVE NOTHING TO PAY");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand(" select CR from PENALTY_TABLE where UID= '" + y + " ' ", con);
            SqlCommand cmd2 = new SqlCommand(" select P_AMOUNT from PENALTY_TABLE where UID= '" + y + " ' ", con);
            con.Open();
            if ( cmd1.ExecuteScalar() != null &&  cmd2.ExecuteScalar() != null)
            {
                label5.Text = cmd1.ExecuteScalar().ToString();
                label3.Text = cmd2.ExecuteScalar().ToString();
            }
            else { MessageBox.Show("YOU DON'T HAVE ANY PENALTY"); }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
    
}
