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
    public partial class EmpDash : Form
    {
        string cs3 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        public EmpDash()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logging Out", "Alert!");
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notice n = new Notice();
            n.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpProfile e3 = new EmpProfile();
            e3.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Emplve e1 = new Emplve();
            e1.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on Each Icons to Work", "Help!");
        }

        private void EmpDash_Load(object sender, EventArgs e)
        {

            label8.Text = Form5.instance.tb1.Text;

            SqlConnection con = new SqlConnection(cs3);
            string query = "select * from emp_info_tbl where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("id", label8.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label8.Text = dr.GetValue(0).ToString();
                label9.Text = dr.GetValue(1).ToString();
                label10.Text = dr.GetValue(2).ToString();
                pictureBox1.Image = GetPhoto((byte[])dr.GetValue(9));
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
