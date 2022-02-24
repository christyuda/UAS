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
    public partial class ViewMahasiswa : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public ViewMahasiswa()
        {
            InitializeComponent();
        }

        void datamahasiswa()
        {
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("SELECT * FROM ms_mhs;", conn);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);

            da.Fill(ds, "ms_mhs");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ms_mhs";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewMahasiswa_Load(object sender, EventArgs e)
        {
            datamahasiswa();
            cari();
        }

        void cari()
        {
            MySqlConnection conn = konn.GetConn();
            try
            {

                conn.Open();
                cmd = new MySqlCommand("select * from ms_mhs where npm LIKE '%" + textBox1.Text + "%' or nama_mhs LIKE '%" + textBox1.Text + "%' ", conn);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);

                da.Fill(ds, "ms_mhs");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "ms_mhs";
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
