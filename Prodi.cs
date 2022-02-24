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
using System.Globalization;

namespace UAS_OOP_1204025
{
    public partial class Prodi : Form
    {

        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        Decimal rupiah;
        

        public Prodi()
              
        {
            InitializeComponent();
        }

        void kondisiawal()
        {
            tbkdprodi.Text = "";
            tbnamaprodi.Text = "";
            tbsingkatan.Text = "";
            tbbiayakuliah.Text = "";
            kodeprodiotomatis();
            

        }
        void convertrupiah()
        {
            

           

        }
        void kodeprodiotomatis()
        {
            long prodi;
            string urutan;
            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new MySqlCommand("select kode_prodi from ms_prodi where kode_prodi in(select max(kode_prodi) from ms_prodi) order by kode_prodi desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                prodi = Convert.ToInt64(rd[0].ToString().Substring(rd["kode_prodi"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + prodi;
                urutan = "PRD" + joinstr.Substring(joinstr.Length - 3, 3);

            }
            else
            {
                urutan = "PRD001";
            }
            rd.Close();
            tbkdprodi.Text = urutan;
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            kondisiawal();
        }

        private void Prodi_Load(object sender, EventArgs e)
        {
            kondisiawal();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (tbkdprodi.Text.Trim() == "" || tbnamaprodi.Text.Trim() == "" || tbsingkatan.Text.Trim() == "" || tbbiayakuliah.Text.Trim() == "" )
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                MySqlConnection conn = konn.GetConn();
                //string sDate = tanggal.SelectionStart.ToString("yyyy\\/MM\\/dd");
                cmd = new MySqlCommand("insert into ms_prodi values('" + tbkdprodi.Text + "','" + tbnamaprodi.Text + "','" + tbsingkatan.Text + "','" + tbbiayakuliah.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Prodi berhasil ditambah");
                kondisiawal();
                kodeprodiotomatis();
            }
        }

        private void tbkdprodi_TextChanged(object sender, EventArgs e)
        {
            convertrupiah();
        }

        

        private void tbbiayakuliah_LostFocus(object sender, EventArgs e)
        {
            tbbiayakuliah.Text = string.Format("{0:#,##0.00}", double.Parse(tbbiayakuliah.Text));
        }

        private void tbbiayakuliah_Leave(object sender, EventArgs e)
        {
            tbbiayakuliah.Text = string.Format("{0:#,##0.00}", double.Parse(tbbiayakuliah.Text));
        }

        void titik()
        { 
        
            
        }

        private void tbbiayakuliah_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbbiayakuliah.Text))
            {
                
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                int valueBefore = Int32.Parse(tbbiayakuliah.Text, System.Globalization.NumberStyles.AllowThousands);
                tbbiayakuliah.Text = String.Format(culture, "{0:N0}", valueBefore);
                tbbiayakuliah.Select(tbbiayakuliah.Text.Length, 0);
            }
        }

        private void tbbiayakuliah_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbkdprodi_KeyPress(object sender, KeyPressEventArgs e)
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
