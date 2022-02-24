namespace UAS_OOP_1204025
{
    partial class FormMenuUtama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuUtama));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.input = new System.Windows.Forms.ToolStripMenuItem();
            this.mahasiswa = new System.Windows.Forms.ToolStripMenuItem();
            this.prodi = new System.Windows.Forms.ToolStripMenuItem();
            this.view = new System.Windows.Forms.ToolStripMenuItem();
            this.mahasiswaview = new System.Windows.Forms.ToolStripMenuItem();
            this.prodiview = new System.Windows.Forms.ToolStripMenuItem();
            this.update = new System.Windows.Forms.ToolStripMenuItem();
            this.mahasiswaupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.prodiupdate = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksi = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiDaftarUlang = new System.Windows.Forms.ToolStripMenuItem();
            this.daftarUlangMahasiswaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.input,
            this.view,
            this.update,
            this.transaksi});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // input
            // 
            this.input.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mahasiswa,
            this.prodi});
            this.input.Name = "input";
            resources.ApplyResources(this.input, "input");
            // 
            // mahasiswa
            // 
            this.mahasiswa.Name = "mahasiswa";
            resources.ApplyResources(this.mahasiswa, "mahasiswa");
            this.mahasiswa.Click += new System.EventHandler(this.mahasiswa_Click);
            // 
            // prodi
            // 
            this.prodi.Name = "prodi";
            resources.ApplyResources(this.prodi, "prodi");
            this.prodi.Click += new System.EventHandler(this.prodi_Click);
            // 
            // view
            // 
            this.view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mahasiswaview,
            this.prodiview,
            this.daftarUlangMahasiswaToolStripMenuItem});
            this.view.Name = "view";
            resources.ApplyResources(this.view, "view");
            // 
            // mahasiswaview
            // 
            this.mahasiswaview.Name = "mahasiswaview";
            resources.ApplyResources(this.mahasiswaview, "mahasiswaview");
            this.mahasiswaview.Click += new System.EventHandler(this.mahasiswaview_Click);
            // 
            // prodiview
            // 
            this.prodiview.Name = "prodiview";
            resources.ApplyResources(this.prodiview, "prodiview");
            this.prodiview.Click += new System.EventHandler(this.prodiview_Click);
            // 
            // update
            // 
            this.update.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mahasiswaupdate,
            this.prodiupdate});
            this.update.Name = "update";
            resources.ApplyResources(this.update, "update");
            // 
            // mahasiswaupdate
            // 
            this.mahasiswaupdate.Name = "mahasiswaupdate";
            resources.ApplyResources(this.mahasiswaupdate, "mahasiswaupdate");
            this.mahasiswaupdate.Click += new System.EventHandler(this.mahasiswaupdate_Click);
            // 
            // prodiupdate
            // 
            this.prodiupdate.Name = "prodiupdate";
            resources.ApplyResources(this.prodiupdate, "prodiupdate");
            this.prodiupdate.Click += new System.EventHandler(this.prodiupdate_Click);
            // 
            // transaksi
            // 
            this.transaksi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transaksiDaftarUlang});
            this.transaksi.Name = "transaksi";
            resources.ApplyResources(this.transaksi, "transaksi");
            // 
            // transaksiDaftarUlang
            // 
            this.transaksiDaftarUlang.Name = "transaksiDaftarUlang";
            resources.ApplyResources(this.transaksiDaftarUlang, "transaksiDaftarUlang");
            this.transaksiDaftarUlang.Click += new System.EventHandler(this.transaksiDaftarUlang_Click);
            // 
            // daftarUlangMahasiswaToolStripMenuItem
            // 
            this.daftarUlangMahasiswaToolStripMenuItem.Name = "daftarUlangMahasiswaToolStripMenuItem";
            resources.ApplyResources(this.daftarUlangMahasiswaToolStripMenuItem, "daftarUlangMahasiswaToolStripMenuItem");
            this.daftarUlangMahasiswaToolStripMenuItem.Click += new System.EventHandler(this.daftarUlangMahasiswaToolStripMenuItem_Click);
            // 
            // FormMenuUtama
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenuUtama";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem input;
        public System.Windows.Forms.ToolStripMenuItem mahasiswa;
        public System.Windows.Forms.ToolStripMenuItem prodi;
        public System.Windows.Forms.ToolStripMenuItem view;
        public System.Windows.Forms.ToolStripMenuItem update;
        public System.Windows.Forms.ToolStripMenuItem transaksi;
        private System.Windows.Forms.ToolStripMenuItem mahasiswaview;
        private System.Windows.Forms.ToolStripMenuItem prodiview;
        private System.Windows.Forms.ToolStripMenuItem mahasiswaupdate;
        private System.Windows.Forms.ToolStripMenuItem prodiupdate;
        private System.Windows.Forms.ToolStripMenuItem transaksiDaftarUlang;
        private System.Windows.Forms.ToolStripMenuItem daftarUlangMahasiswaToolStripMenuItem;
    }
}

