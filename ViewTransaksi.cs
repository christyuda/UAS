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
    public partial class ViewTransaksi : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public ViewTransaksi()
        {
           
            InitializeComponent();
        }

        void datadaftarulangmahasiswa()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM tr_daftar_ulang;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "tr_daftar_ulang");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tr_daftar_ulang";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        private void ViewTransaksi_Load(object sender, EventArgs e)
        {
            datadaftarulangmahasiswa();
        }
        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {

                conn.Open();
                cmd = new MySqlCommand("select * from tr_daftar_ulang where npm LIKE '%" + textBox1.Text + "%' or grade LIKE '%" + textBox1.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "tr_daftar_ulang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "tr_daftar_ulang";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cari();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("TRANSAKSI dihapus?", "APAKAH DATA INGIN DIHAPUS", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["total_biaya"].FormattedValue.ToString();
                MySqlConnection conn = konn.GetConn();
                conn.Open();
                MySqlCommand com = new MySqlCommand("Delete from tr_daftar_ulang where total_biaya='" + id + "'", conn);
                com.ExecuteNonQuery();
                MessageBox.Show("DATA TRANSAKSI BERHASIL DIHAPUS");
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = konn.GetConn();
            MySqlCommand com = new MySqlCommand(" Select * from tr_daftar_ulang", conn);
            MySqlDataAdapter d = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
