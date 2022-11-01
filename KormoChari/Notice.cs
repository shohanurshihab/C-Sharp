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
    public partial class Notice : Form
    {
        string cs9 = ConfigurationManager.ConnectionStrings["admdbcs"].ConnectionString;
        string x = Form5.instance.tb1.Text;
        SqlDataAdapter adapter;
        DataTable table = new DataTable();
        int pos = 0;
        public Notice()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpDash e1 = new EmpDash();
            e1.Show();
        }
        private void Notice_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(cs9);
            adapter = new SqlDataAdapter("select * from notice_tbl_2 where id=@id ", con);
            adapter.SelectCommand.Parameters.AddWithValue("id", x);
            adapter.Fill(table);
            showdata(pos);
        }
        public void showdata(int i)
        {
            int x = table.Rows.Count;

            if (x != 0)
            {

                label5.Text = table.Rows[i][1].ToString();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {

            pos++;
            if (pos < table.Rows.Count)
            {
                showdata(pos);

            }
            else
            {
                MessageBox.Show("END");
                pos = table.Rows.Count - 1;
            }
        }
    }
}
