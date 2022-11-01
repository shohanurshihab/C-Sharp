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
    public partial class EmpProfile : Form
    {
        string cs7 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
            public EmpProfile()
        {
            InitializeComponent();

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            label1.Text = Form5.instance.tb1.Text;

            SqlConnection con = new SqlConnection(cs7);
            string query = "select * from emp_info_tbl where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("id", label1.Text);
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
                pictureBox2.Image = GetPhoto((byte[])dr.GetValue(9));
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
            EmpDash e4 = new EmpDash();
            e4.Show();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
