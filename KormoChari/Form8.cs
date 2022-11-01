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
    
    public partial class Form8 : Form
    {
        string cs5 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        public Form8()
        {
            InitializeComponent();
            instance = this;
            tb1 = numericUpDown1;
        }
        public static Form8 instance;
        public NumericUpDown tb1;

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f1 = new Admin();
            f1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Admin f1 = new Admin();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                SqlConnection con = new SqlConnection(cs5);
                string query = "select * from emp_info_tbl where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("id", numericUpDown1.Value);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    label1.Text = dr.GetValue(0).ToString();
                    label3.Text = dr.GetValue(1).ToString();
                    label6.Text = dr.GetValue(2).ToString();
                    label13.Text = dr.GetValue(3).ToString();
                    label14.Text = dr.GetValue(4).ToString();
                    label15.Text = dr.GetValue(5).ToString();
                    label16.Text = dr.GetValue(6).ToString();
                    label17.Text = dr.GetValue(7).ToString();
                    label18.Text = dr.GetValue(8).ToString();
                    pictureBox2.Image = GetPhoto((byte[])dr.GetValue(9));
                    con.Close();
                    string query1 = "select * from notice_tbl where id=@id";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("id", numericUpDown1.Value);
                    con.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        Notification();
                    }

                }
                else
                {
                    MessageBox.Show("Not Found", "Status");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Enter ID", "Status");
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
        public void Notification()
        {
            if (button2.Enabled == true)
            {
                pictureBox1.Image = Properties.Resources.icons8_notification1_96;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.icons8_notification1_96;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
                this.Hide();
                Notice_Admin fn1 = new Notice_Admin();
                fn1.Show();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
