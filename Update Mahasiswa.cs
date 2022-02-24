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

namespace UAS_OOP_1204025
{
    public partial class Update_Mahasiswa : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public Update_Mahasiswa()
        {
            InitializeComponent();
        }
        void munculprogramstudi()
        {
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_prodi", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                comboBox1.Items.Add(rd[0].ToString());

            }
            rd.Close();
            conn.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                mahasiswa();
            }
        }


        void mahasiswa()
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_mhs where npm='" + textBox1.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows)


            {
                textBox1.Text = rd[0].ToString();
                textBox2.Text = rd[1].ToString();
                comboBox1.Text = rd[2].ToString();
                

            }
        }
        void kondisiawal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            
        }
        private void Update_Mahasiswa_Load(object sender, EventArgs e)
        {
            munculprogramstudi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || comboBox1.Text.Trim() == "" )
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update ms_mhs set nama_mhs='" + textBox2.Text + "',kode_prodi='" + comboBox1.Text + "' where npm='" + textBox1.Text + "'", conn);
                //cmd1 = new MySqlCommand("Update stokin set namabarang='" + textBox2.Text + "',pemasok='" + comboBox3.Text + "',hargabeli='" + textBox5.Text + "',jumlahbarang='" + textBox3.Text + "',level_barang='" + comboBox1.Text + "',satuan='" + comboBox2.Text + "',tanggal='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where idbarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Ganti");
                kondisiawal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || comboBox1.Text.Trim() == "" )
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :" + textBox2.Text + "??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from ms_mhs where npm='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Hapus");
                    kondisiawal();

                }
            }
        }
    }
}
