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
    public partial class Notice_Admin : Form
    {
        string cs3 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        int x = (int)Form8.instance.tb1.Value;
        SqlDataAdapter adapter;
        DataTable table = new DataTable();
        int pos = 0;
        public Notice_Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Notice_Admin_Load(object sender, EventArgs e)
        {           
            SqlConnection con = new SqlConnection(cs3);
            adapter = new SqlDataAdapter("select * from notice_tbl where id=@id ",con);
            adapter.SelectCommand.Parameters.AddWithValue("id", x);
            adapter.Fill(table);
            
            
                showdata(pos);
            
        }
        public void showdata(int i)
        {
            int x = table.Rows.Count;
            
                if (x!=0)
            {
                label7.Text = table.Rows[i][2].ToString();
                label5.Text = table.Rows[i][0].ToString();
                label4.Text = table.Rows[i][1].ToString();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs3);
            String query = "insert into notice_tbl_2 values(@id,@notice)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", x);
            cmd.Parameters.AddWithValue("@notice", textBox1.Text);         
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Insetred Succesfully");
               
            }
            else
            {
                MessageBox.Show("Data Insetred Succesfully");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pos++;
            if(pos<table.Rows.Count)
            {
                showdata(pos);

            }
            else
            {
                MessageBox.Show("END");
                pos = table.Rows.Count - 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pos = 0;
            showdata(pos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                showdata(pos);

            }
            else
            {
                MessageBox.Show("END");
                
            }
        }
    }
}

