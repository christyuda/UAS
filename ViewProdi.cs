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
    public partial class ViewProdi : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public ViewProdi()
        {
            InitializeComponent();
        }
        void dataprodi()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM ms_prodi;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "ms_prodi");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ms_prodi";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        private void ViewProdi_Load(object sender, EventArgs e)
        {
            dataprodi();
        }


        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {

                conn.Open();
                cmd = new MySqlCommand("select * from ms_prodi where kode_prodi LIKE '%" + textBox1.Text + "%' or nama_prodi LIKE '%" + textBox1.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "ms_prodi");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "ms_prodi";
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
    }
}
