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
    public partial class Form3 : Form
    {
        string cs1 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPrompt l = new LoginPrompt();
            l.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private bool button5WasClicked = false;

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && numericUpDown1.Value != 0 && textBox3.Text != "" && textBox4.Text != "" && button5WasClicked && pictureBox1.Image!=null)
            {
                SqlConnection con = new SqlConnection(cs1);
                String query = "insert into info_tbl values(@id,@name,@pass,@email,@img)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@img", SavePhoto());
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Registered Succesfully","Validation");

                    this.Hide();
                    LoginPrompt l = new LoginPrompt();
                    l.Show();
                }
                else
                {
                    MessageBox.Show("Registration Failed");
                }
            }
            else
            {
                MessageBox.Show("Enter all Credentials", "Validation");
            }


        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //
            ofd.Title = "CHOSSE IMAGE";
            ofd.Filter = "IMAGE FILE(*.*)| *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
            button5WasClicked = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
