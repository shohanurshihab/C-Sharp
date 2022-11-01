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
    public partial class Form5 : Form
    {
        string cs4 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;

        public static Form5 instance;
        public TextBox tb1;


        public Form5()
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
                SqlConnection con = new SqlConnection(cs4);
                string query = "select * from emp_info_tbl where id=@id and pass=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox2.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    //MessageBox.Show("Succuessful Login", "Validation");
                    this.Hide();
                    EmpDash e1 = new EmpDash();
                    e1.Show();
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginPrompt l = new LoginPrompt();
            l.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            LoginPrompt l = new LoginPrompt();
            l.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
