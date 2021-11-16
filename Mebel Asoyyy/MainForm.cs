using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Mebel_Asoyyy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            string connection = "server=localhost; user id=root; database=mebel";
            string query = "SELECT * FROM tbl_produk";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dt.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["IMAGE"].ToString()));
            }

            dataGridView2.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string connection = "server=localhost; user id=root; database=mebel";
            string query = "INSERT INTO tbl_produk(nama_produk,harga_produk,stok_produk,IMAGE)VALUES('"+ this.NAMAPRODUK.Text + "','" + this.HARGAPRODUK.Text + "','" + this.STOKPRODUK.Text + "','" + Path.GetFileName(pictureBox2.ImageLocation) + "')";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data berhasil disimpan");
            conn.Close();
            File.Copy(imageText.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pictureBox2.ImageLocation));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string connection = "server=localhost; user id=root; database=mebel";
            string query = "UPDATE tbl_produk SET nama_produk='" + this.NAMAPRODUK.Text + "',harga_produk='"  + this.HARGAPRODUK.Text + "',stok_produk='" + this.STOKPRODUK + "' WHERE id_produk='"+ this.IDPRODUK.Text +"'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data berhasil diubah");
            conn.Close();

        }

        private void labelext_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string connection = "server=localhost; user id=root; database=mebel";
            string query = "SELECT * FROM tbl_produk";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dt.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["IMAGE"].ToString()));
            }
          
            dataGridView2.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string connection = "server=localhost; user id=root; database=mebel";
            string query = "DELETE FROM tbl_produk WHERE id_produk='" + this.IDPRODUK.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data berhasil dihapus");
            conn.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; database=mebel";
            MySqlConnection con = new MySqlConnection(connection);
            MySqlDataAdapter da;
            DataTable dt;
            con.Open();
            da = new MySqlDataAdapter("SELECT * FROM tbl_produk WHERE nama_produk LIKE'" + this.textBox1.Text + "%'", con);
            dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dt.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["IMAGE"].ToString()));
            }
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                imageText.Text = openfd.FileName;
                pictureBox2.Image = new Bitmap(openfd.FileName);
                pictureBox2.ImageLocation = openfd.FileName;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
    }
}
