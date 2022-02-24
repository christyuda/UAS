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
    public partial class UpdateProdi : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public UpdateProdi()
        {
            InitializeComponent();
        }

        void prodi()
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd = new MySqlCommand("select * from ms_prodi where kode_prodi='" + tbkdprodi.Text + "'", conn);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();
            rd.Read();

            if (rd.HasRows)


            {
                tbkdprodi.Text = rd[0].ToString();
                tbnamaprodi.Text = rd[1].ToString();
                tbsingkatan.Text = rd[2].ToString();
                tbbiayakuliah.Text = rd[3].ToString();


            }
        }
        void kondisiawal()
        {
            tbkdprodi.Text = "";
            tbnamaprodi.Text = "";
            tbsingkatan.Text = "";
            tbbiayakuliah.Text = "";
            


        }
        private void UpdateProdi_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbkdprodi.Text.Trim() == "" || tbnamaprodi.Text.Trim() == "" || tbsingkatan.Text.Trim() == "" || tbbiayakuliah.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();

                cmd = new MySqlCommand("Update ms_prodi set nama_prodi='" + tbnamaprodi.Text + "',singkatan='" + tbsingkatan.Text + "',biaya_kuliah='" + tbbiayakuliah.Text + "'  where kode_prodi='" + tbkdprodi.Text + "'", conn);
                //cmd1 = new MySqlCommand("Update stokin set namabarang='" + textBox2.Text + "',pemasok='" + comboBox3.Text + "',hargabeli='" + textBox5.Text + "',jumlahbarang='" + textBox3.Text + "',level_barang='" + comboBox1.Text + "',satuan='" + comboBox2.Text + "',tanggal='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where idbarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                //cmd1.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Ganti");
                kondisiawal();
            }
        }

        private void tbkdprodi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                prodi();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbkdprodi.Text.Trim() == "" || tbnamaprodi.Text.Trim() == "" || tbsingkatan.Text.Trim() == "" || tbbiayakuliah.Text.Trim() == "" )
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                if (MessageBox.Show("APAKAH YAKIN AKAN MENGHAPUS DATA INI :" + tbnamaprodi.Text + "??", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection conn = konn.GetConn();

                    cmd = new MySqlCommand("DELETE from ms_prodi where kode_prodi='" + tbkdprodi.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Hapus");
                    kondisiawal();
                    
                }
            }

        }
    }
}
