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

namespace KormoChari
{
    public partial class Form4 : Form
    {
        string cs2 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        public static Form4 instance;
        public TextBox tb1;

        public Form4()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPrompt l = new LoginPrompt();
            l.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs2);
                string query = "select * from info_tbl where id=@id and pass=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox2.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    //MessageBox.Show("Succuessful Login", "Validation");
                    this.Hide();
                    Admin a = new Admin();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Failed Login", "Validation");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Enter all Credentials", "Validation");
            }

            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginPrompt l = new LoginPrompt();
            l.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
