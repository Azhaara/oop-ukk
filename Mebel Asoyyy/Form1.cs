﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            if (username.Text == "admin" && textBox1.Text == "admin")
            {
                new MainForm().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username Atau Password Kamu Salah :)");
                username.Clear();
                textBox1.Clear();
                username.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            username.Clear();
            textBox1.Clear();
            username.Focus();
        }

        private void labelext_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
