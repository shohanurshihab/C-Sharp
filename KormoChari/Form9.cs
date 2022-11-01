using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace KormoChari
{
    public partial class Form9 : Form 
    {
        string cs6 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        public Form9()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f1 = new Admin();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f1 = new Admin();
            f1.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
               
                SqlConnection con = new SqlConnection(cs6);
                string query = "select * from emp_info_tbl where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("id", numericUpDown2.Value);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                    if (dr.Read())
                    {
                        label4.Text = dr.GetValue(1).ToString();
                        label16.Text = dr.GetValue(6).ToString();
                        if (dr.GetValue(6).ToString() == "Level 1")
                        {
                            int x;
                            x = (int)numericUpDown1.Value * 100;
                            label3.Text = x.ToString();
                        }
                        else if (dr.GetValue(6).ToString() == "Level 2")
                        {
                            int x;
                            x = (int)numericUpDown1.Value * 500;
                            label3.Text = x.ToString();
                        }
                        else if (dr.GetValue(6).ToString() == "Level 3")
                        {
                            int x;
                            x = (int)numericUpDown1.Value * 1000;
                            label3.Text = x.ToString();
                        }
                    } 
                else
                {
                    MessageBox.Show("Not valid");
                } 
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
