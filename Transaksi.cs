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
    public partial class Transaksi : Form
    {
        koneksidb konn = new koneksidb();
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        private DataSet ds;
        private MySqlDataAdapter da;
        private MySqlDataReader rd;
        double number1 = 0;
        double result = 0;
        public Transaksi()
        {
            InitializeComponent();
        }
        void kondisiawal()
        {
            label17.Text = "0";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

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
                textBox3.Text = rd[2].ToString();

                prodi();

            }
        }

        void prodi()
        {

            MySqlDataReader rd;
            MySqlConnection conn = konn.GetConn();
            conn.Open();

            cmd1 = new MySqlCommand("select * from ms_prodi where kode_prodi='" + textBox3.Text + "'", conn);
            cmd1.CommandType = CommandType.Text;
            rd = cmd1.ExecuteReader();
            rd.Read();

            if (rd.HasRows)


            {

                label17.Text = rd[3].ToString();


            }
        }

        void hitung()
        {

        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            kondisiawal();
            separator();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                mahasiswa();
            }

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            prodi();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bagilimapuluh();
        }

        void bagilimapuluh()
        {
            textBox5.Text = (Double.Parse(label17.Text) * 0.5).ToString();
            textBox6.Text = (Double.Parse(label17.Text) - Double.Parse(textBox5.Text)).ToString();
            separator();
        }
        void bagidualima()
        {
            textBox5.Text = (Double.Parse(label17.Text) * 0.25).ToString();
            textBox6.Text = (Double.Parse(label17.Text) - Double.Parse(textBox5.Text)).ToString();
            separator();
        }
        void bagisepuluh()
        {
            textBox5.Text = (Double.Parse(label17.Text) * 0.1).ToString();
            textBox6.Text = (Double.Parse(label17.Text) - Double.Parse(textBox5.Text)).ToString();
            
            separator();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bagidualima();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bagisepuluh();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua terisi");
            }
            else
            {
                string npm = textBox1.Text.Trim();
                double totalbiaya = double.Parse(textBox6.Text, NumberStyles.Currency);

                string grade = string.Empty;
                if (radioButton1.Checked)
                {
                    grade = "A";
                }
                else if (radioButton2.Checked)
                {
                    grade = "B";
                }
                else if (radioButton3.Checked)
                {
                    grade = "C";
                }
                MySqlConnection conn = konn.GetConn();
                cmd = new MySqlCommand("INSERT INTO tr_daftar_ulang (npm, grade, total_biaya) VALUES(@NPM, @Grade, @Total_Biaya)");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@NPM", npm);
                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@Total_Biaya", totalbiaya);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Transaksi Daftar Ulang Berhasil Ditambah");
                kondisiawal();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kondisiawal();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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


            if (!string.IsNullOrEmpty(textBox5.Text))
            {

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                int valueBefore = Int32.Parse(textBox5.Text, System.Globalization.NumberStyles.AllowThousands);
                textBox5.Text = String.Format(culture, "{0:N0}", valueBefore);
                textBox5.Select(textBox5.Text.Length, 0);
            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        void separator()
        {


            if (!string.IsNullOrEmpty(textBox5.Text))
            {

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                int valueBefore = Int32.Parse(textBox5.Text, System.Globalization.NumberStyles.AllowThousands);
                textBox5.Text = String.Format(culture, "{0:N0}", valueBefore);
                textBox5.Select(textBox5.Text.Length, 0);
            }


        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            separator();
        }

        private void textBox5_Validated(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_Validated(object sender, EventArgs e)
        {
            separator();
        }

        

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text))
            {

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                int valueBefore = Int32.Parse(textBox6.Text, System.Globalization.NumberStyles.AllowThousands);
                textBox6.Text = String.Format(culture, "{0:N0}", valueBefore);
                textBox6.Select(textBox6.Text.Length, 0);

            }
        }
    }
}
