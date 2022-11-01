using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KormoChari
{
    public partial class Startpage : Form
    {
        public Startpage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPrompt l = new LoginPrompt();
            l.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By \n\nMuntakim Mustafa\nMD.Towhid Ahmed\nShohanur Rahman Shihab\n\nParent Company\nAIUB\nAll Rights Reserved 2021©\n", "KormoChari Team");
        }

        private void Startpage_Load(object sender, EventArgs e)
        {

        }
    }
}
