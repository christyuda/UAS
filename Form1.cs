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
    public partial class FormMenuUtama : Form
    {
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        //public DataTable dt;
        int result;
        private string url = "server=localhost;userid=root;password=;database=uas";
        public MySqlConnection GetConn()
        {
            MySqlConnection Conn = new MySqlConnection(url);
            return Conn;
        }

        public static FormMenuUtama MENU;
        MenuStrip mnstrip;
        Prodi frmprodi;
        Mahasiswa frmmahasiswa;
        ViewMahasiswa frmviewmahasiswa;
        ViewProdi frmviewprodi;
        Update_Mahasiswa frmupdatemahasiswa;
        UpdateProdi frmupdateprodi;
        Transaksi frmtransaksi;
        ViewTransaksi frmtransaksidaftarulang;


        void frmprodi_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmprodi = null;
        }

        void frmmahasiswa_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmmahasiswa = null;
        }
        void frmviewprodi_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmviewprodi = null;
        }
        void frmviewmahasiswa_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmviewmahasiswa = null;
        }
        void frmupdatemahasiswa_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmupdatemahasiswa = null;
        }

        void frmupdateprodi_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmupdateprodi = null;
        }

        void frmtransaksi_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmtransaksi = null;
        }
        void frmtransaksidaftarulang_fromClosed(object sender, FormClosedEventArgs e)

        {
            frmtransaksidaftarulang = null;
        }






        public FormMenuUtama()
        {
             
       
            InitializeComponent();
        }

        private void prodi_Click(object sender, EventArgs e)
        {
            if (frmprodi == null)
            {
                frmprodi = new Prodi();
                frmprodi.FormClosed += new FormClosedEventHandler(frmprodi_fromClosed);
                frmprodi.ShowDialog();
            }
            else
            {
                frmprodi.Activate();
            }
        }

        private void mahasiswa_Click(object sender, EventArgs e)
        {
            if (frmmahasiswa == null)
            {
                frmmahasiswa = new Mahasiswa();
                frmmahasiswa.FormClosed += new FormClosedEventHandler(frmmahasiswa_fromClosed);
                frmmahasiswa.ShowDialog();
            }
            else
            {
                frmmahasiswa.Activate();
            }

        }

        

        private void mahasiswaview_Click(object sender, EventArgs e)
        {
            if (frmviewmahasiswa == null)
            {
                frmviewmahasiswa = new ViewMahasiswa();
                frmviewmahasiswa.FormClosed += new FormClosedEventHandler(frmviewmahasiswa_fromClosed);
                frmviewmahasiswa.ShowDialog();
            }
            else
            {
                frmviewmahasiswa.Activate();
            }
        }

        private void transaksiDaftarUlang_Click(object sender, EventArgs e)
        {
            if (frmtransaksi == null)
            {
                frmtransaksi = new Transaksi();
                frmtransaksi.FormClosed += new FormClosedEventHandler(frmtransaksi_fromClosed);
                frmtransaksi.ShowDialog();
            }
            else
            {
                frmtransaksi.Activate();
            }
        }

        private void mahasiswaupdate_Click(object sender, EventArgs e)
        {
            if (frmupdatemahasiswa == null)
            {
                frmupdatemahasiswa = new Update_Mahasiswa();
                frmupdatemahasiswa.FormClosed += new FormClosedEventHandler(frmupdatemahasiswa_fromClosed);
                frmupdatemahasiswa.ShowDialog();
            }
            else
            {
                frmviewprodi.Activate();
            }
        }

        private void prodiview_Click(object sender, EventArgs e)
        {
            if (frmviewprodi == null)
            {
                frmviewprodi = new ViewProdi();
                frmviewprodi.FormClosed += new FormClosedEventHandler(frmviewprodi_fromClosed);
                frmviewprodi.ShowDialog();
            }
            else
            {
                frmviewprodi.Activate();
            }
        }

        private void prodiupdate_Click(object sender, EventArgs e)
        {
            
                if (frmupdateprodi == null)
            {
                frmupdateprodi = new UpdateProdi();
                frmupdateprodi.FormClosed += new FormClosedEventHandler(frmupdateprodi_fromClosed);
                frmupdateprodi.ShowDialog();
            }
            else
            {
                frmupdateprodi.Activate();
            }
        }

        private void daftarUlangMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmtransaksidaftarulang == null)
            {
                frmtransaksidaftarulang = new ViewTransaksi();
                frmtransaksidaftarulang.FormClosed += new FormClosedEventHandler(frmtransaksidaftarulang_fromClosed);
                frmtransaksidaftarulang.ShowDialog();
            }
            else
            {
                frmtransaksidaftarulang.Activate();
            }
        }
    }
}
