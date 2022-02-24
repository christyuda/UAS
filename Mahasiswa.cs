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
    public partial class Mahasiswa : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        public Mahasiswa()
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
        void kondisiawal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            kodemahasiswaotomatis();
        }
        void kodemahasiswaotomatis()
        {
            long prodi;
            string urutan;
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select npm from ms_mhs where npm in(select max(npm) from ms_mhs) order by npm desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                prodi = Convert.ToInt64(rd[0].ToString().Substring(rd["npm"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + prodi;
                urutan = "120" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "120001";
            }
            rd.Close();
            textBox1.Text = urutan;
            conn.Close();
        }

        private void Mahasiswa_Load(object sender, EventArgs e)
        {
            munculprogramstudi();
            kondisiawal();
            kodemahasiswaotomatis();

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
                //string sDate = tanggal.SelectionStart.ToString("yyyy\\/MM\\/dd");
                cmd = new MySqlCommand("insert into ms_mhs values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Prodi berhasil ditambah");
                kondisiawal();
                kodemahasiswaotomatis();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
