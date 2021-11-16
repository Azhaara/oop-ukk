using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mebel_Asoyyy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "admin" && txtpassword.Text == "admin")
            {
                new MainForm().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username Atau Password Kamu Salah :)");
                username.Clear();
                txtpassword.Clear();
                username.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            username.Clear();
            txtpassword.Clear();
            username.Focus();
        }

        private void labelext_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
