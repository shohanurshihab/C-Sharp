using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace KormoChari
{
    public partial class Emplve : Form
    {
        string cs8 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        public Emplve()
        {
            InitializeComponent();
        }

        private void Emplve_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpDash e2 = new EmpDash();
            e2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( numericUpDown1.Value!=0 && numericUpDown2.Value!=0 && textBox1.Text!=""){
                SqlConnection con = new SqlConnection(cs8);
                String query = "insert into notice_tbl(duration_days,leave,id) values(@duration,@leave,@id)"; 
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@duration", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@leave", textBox1.Text);
               cmd.Parameters.AddWithValue("@id", numericUpDown2.Value);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Application Registered Succesfully");
                    this.Hide();
                    EmpDash e3 = new EmpDash();
                    e3.Show();
                } }
            else
            {
                MessageBox.Show("Application Registration Failed");
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on Each Icons to Work", "Help!");
        }
    }
}
