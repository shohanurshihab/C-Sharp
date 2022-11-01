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

namespace KormoChari
{
    public partial class Admin : Form
    {
        string cs3 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        public Admin()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f2 = new Form7();
            f2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f3 = new Form8();
            f3.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f4 = new Form9();
            f4.Show();
        }

     

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logging Out", "Alert!");
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on Each Icons to Work", "Help!");
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            label8.Text = Form4.instance.tb1.Text;

            SqlConnection con = new SqlConnection(cs3);
            string query = "select * from info_tbl where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("id", label8.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label8.Text = dr.GetValue(0).ToString();
                label9.Text = dr.GetValue(1).ToString();
                label10.Text = dr.GetValue(3).ToString();
                pictureBox1.Image = GetPhoto((byte[])dr.GetValue(4));
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
