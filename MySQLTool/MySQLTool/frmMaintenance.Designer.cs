namespace MySQLTool
{
    partial class frmMaintenance
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
            this.nsTheme1 = new NSTheme();
            this.nsControlButton1 = new NSControlButton();
            this.nsGroupBox5 = new NSGroupBox();
            this.btnProses = new NSButton();
            this.btnHapusBinlog = new NSButton();
            this.btnKeDrop = new NSButton();
            this.btnKeDelete = new NSButton();
            this.btnLoad = new NSButton();
            this.nsLabel2 = new NSLabel();
            this.comboDatabase1 = new NSComboBox();
            this.nsGroupBox4 = new NSGroupBox();
            this.chkAll = new NSCheckBox();
            this.listAll = new System.Windows.Forms.ListBox();
            this.nsGroupBox3 = new NSGroupBox();
            this.chkDel = new NSCheckBox();
            this.btnHapusDelete = new NSButton();
            this.listDel = new System.Windows.Forms.ListBox();
            this.nsGroupBox2 = new NSGroupBox();
            this.chkDrop = new NSCheckBox();
            this.btnHapusDrop = new NSButton();
            this.listDrop = new System.Windows.Forms.ListBox();
            this.groupProg = new NSGroupBox();
            this.pgBar1 = new NSProgressBar();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.btnHapus3bulan = new NSButton();
            this.nsTheme1.SuspendLayout();
            this.nsGroupBox5.SuspendLayout();
            this.nsGroupBox4.SuspendLayout();
            this.nsGroupBox3.SuspendLayout();
            this.nsGroupBox2.SuspendLayout();
            this.groupProg.SuspendLayout();
            this.SuspendLayout();
            // 
            // nsTheme1
            // 
            this.nsTheme1.AccentOffset = 0;
            this.nsTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.nsTheme1.Colors = new Bloom[0];
            this.nsTheme1.Controls.Add(this.nsControlButton1);
            this.nsTheme1.Controls.Add(this.nsGroupBox5);
            this.nsTheme1.Controls.Add(this.nsGroupBox4);
            this.nsTheme1.Controls.Add(this.nsGroupBox3);
            this.nsTheme1.Controls.Add(this.nsGroupBox2);
            this.nsTheme1.Controls.Add(this.groupProg);
            this.nsTheme1.Customization = "";
            this.nsTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.nsTheme1.Image = null;
            this.nsTheme1.Location = new System.Drawing.Point(0, 0);
            this.nsTheme1.Movable = true;
            this.nsTheme1.Name = "nsTheme1";
            this.nsTheme1.NoRounding = false;
            this.nsTheme1.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.nsTheme1.Sizable = true;
            this.nsTheme1.Size = new System.Drawing.Size(793, 549);
            this.nsTheme1.SmartBounds = true;
            this.nsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "nsTheme1";
            this.nsTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.nsTheme1.Transparent = false;
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(766, 3);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 0;
            this.nsControlButton1.Text = "nsControlButton1";
            // 
            // nsGroupBox5
            // 
            this.nsGroupBox5.Controls.Add(this.btnHapus3bulan);
            this.nsGroupBox5.Controls.Add(this.btnProses);
            this.nsGroupBox5.Controls.Add(this.btnHapusBinlog);
            this.nsGroupBox5.Controls.Add(this.btnKeDrop);
            this.nsGroupBox5.Controls.Add(this.btnKeDelete);
            this.nsGroupBox5.Controls.Add(this.btnLoad);
            this.nsGroupBox5.Controls.Add(this.nsLabel2);
            this.nsGroupBox5.Controls.Add(this.comboDatabase1);
            this.nsGroupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsGroupBox5.DrawSeperator = false;
            this.nsGroupBox5.Location = new System.Drawing.Point(195, 40);
            this.nsGroupBox5.Name = "nsGroupBox5";
            this.nsGroupBox5.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.nsGroupBox5.Size = new System.Drawing.Size(213, 426);
            this.nsGroupBox5.SubTitle = "Box";
            this.nsGroupBox5.TabIndex = 4;
            this.nsGroupBox5.Text = "nsGroupBox5";
            this.nsGroupBox5.Title = "Tools";
            // 
            // btnProses
            // 
            this.btnProses.Location = new System.Drawing.Point(23, 341);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(169, 65);
            this.btnProses.TabIndex = 10;
            this.btnProses.Text = "Proses";
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // btnHapusBinlog
            // 
            this.btnHapusBinlog.Location = new System.Drawing.Point(23, 255);
            this.btnHapusBinlog.Name = "btnHapusBinlog";
            this.btnHapusBinlog.Size = new System.Drawing.Size(169, 39);
            this.btnHapusBinlog.TabIndex = 9;
            this.btnHapusBinlog.Text = "Hapus Binlog";
            this.btnHapusBinlog.Click += new System.EventHandler(this.btnHapusBinlog_Click);
            // 
            // btnKeDrop
            // 
            this.btnKeDrop.Location = new System.Drawing.Point(23, 214);
            this.btnKeDrop.Name = "btnKeDrop";
            this.btnKeDrop.Size = new System.Drawing.Size(169, 23);
            this.btnKeDrop.TabIndex = 8;
            this.btnKeDrop.Text = "Ke Daftar Drop >>";
            this.btnKeDrop.Click += new System.EventHandler(this.btnKeDrop_Click);
            // 
            // btnKeDelete
            // 
            this.btnKeDelete.Location = new System.Drawing.Point(23, 185);
            this.btnKeDelete.Name = "btnKeDelete";
            this.btnKeDelete.Size = new System.Drawing.Size(169, 23);
            this.btnKeDelete.TabIndex = 7;
            this.btnKeDelete.Text = "Ke Daftar Delete >>";
            this.btnKeDelete.Click += new System.EventHandler(this.btnKeDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(23, 99);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(169, 57);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load Tabel";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // nsLabel2
            // 
            this.nsLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.nsLabel2.Location = new System.Drawing.Point(23, 43);
            this.nsLabel2.Name = "nsLabel2";
            this.nsLabel2.Size = new System.Drawing.Size(169, 23);
            this.nsLabel2.TabIndex = 5;
            this.nsLabel2.Text = "nsLabel2";
            this.nsLabel2.Value1 = "Pilih Databse ";
            this.nsLabel2.Value2 = "MySQL";
            // 
            // comboDatabase1
            // 
            this.comboDatabase1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboDatabase1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboDatabase1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDatabase1.ForeColor = System.Drawing.Color.White;
            this.comboDatabase1.FormattingEnabled = true;
            this.comboDatabase1.Location = new System.Drawing.Point(23, 72);
            this.comboDatabase1.Name = "comboDatabase1";
            this.comboDatabase1.Size = new System.Drawing.Size(169, 21);
            this.comboDatabase1.TabIndex = 4;
            // 
            // nsGroupBox4
            // 
            this.nsGroupBox4.Controls.Add(this.chkAll);
            this.nsGroupBox4.Controls.Add(this.listAll);
            this.nsGroupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.nsGroupBox4.DrawSeperator = false;
            this.nsGroupBox4.Location = new System.Drawing.Point(5, 40);
            this.nsGroupBox4.Name = "nsGroupBox4";
            this.nsGroupBox4.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.nsGroupBox4.Size = new System.Drawing.Size(190, 426);
            this.nsGroupBox4.SubTitle = "Tabel";
            this.nsGroupBox4.TabIndex = 3;
            this.nsGroupBox4.Text = "nsGroupBox4";
            this.nsGroupBox4.Title = "Semua";
            // 
            // chkAll
            // 
            this.chkAll.Checked = false;
            this.chkAll.Location = new System.Drawing.Point(8, 395);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(75, 23);
            this.chkAll.TabIndex = 3;
            this.chkAll.CheckedChanged += new NSCheckBox.CheckedChangedEventHandler(this.chkAll_CheckedChanged);
            // 
            // listAll
            // 
            this.listAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.listAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.listAll.ForeColor = System.Drawing.Color.White;
            this.listAll.FormattingEnabled = true;
            this.listAll.Location = new System.Drawing.Point(5, 40);
            this.listAll.Name = "listAll";
            this.listAll.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listAll.Size = new System.Drawing.Size(180, 340);
            this.listAll.TabIndex = 0;
            // 
            // nsGroupBox3
            // 
            this.nsGroupBox3.Controls.Add(this.chkDel);
            this.nsGroupBox3.Controls.Add(this.btnHapusDelete);
            this.nsGroupBox3.Controls.Add(this.listDel);
            this.nsGroupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.nsGroupBox3.DrawSeperator = false;
            this.nsGroupBox3.Location = new System.Drawing.Point(408, 40);
            this.nsGroupBox3.Name = "nsGroupBox3";
            this.nsGroupBox3.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.nsGroupBox3.Size = new System.Drawing.Size(190, 426);
            this.nsGroupBox3.SubTitle = "Hapus";
            this.nsGroupBox3.TabIndex = 2;
            this.nsGroupBox3.Text = "nsGroupBox3";
            this.nsGroupBox3.Title = "Daftar Tabel";
            // 
            // chkDel
            // 
            this.chkDel.Checked = false;
            this.chkDel.Location = new System.Drawing.Point(18, 394);
            this.chkDel.Name = "chkDel";
            this.chkDel.Size = new System.Drawing.Size(75, 23);
            this.chkDel.TabIndex = 3;
            this.chkDel.CheckedChanged += new NSCheckBox.CheckedChangedEventHandler(this.chkDel_CheckedChanged);
            // 
            // btnHapusDelete
            // 
            this.btnHapusDelete.Location = new System.Drawing.Point(106, 394);
            this.btnHapusDelete.Name = "btnHapusDelete";
            this.btnHapusDelete.Size = new System.Drawing.Size(75, 23);
            this.btnHapusDelete.TabIndex = 2;
            this.btnHapusDelete.Text = "Hapus";
            this.btnHapusDelete.Click += new System.EventHandler(this.btnHapusDelete_Click);
            // 
            // listDel
            // 
            this.listDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.listDel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listDel.Dock = System.Windows.Forms.DockStyle.Top;
            this.listDel.ForeColor = System.Drawing.Color.White;
            this.listDel.FormattingEnabled = true;
            this.listDel.Location = new System.Drawing.Point(5, 40);
            this.listDel.Name = "listDel";
            this.listDel.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listDel.Size = new System.Drawing.Size(180, 340);
            this.listDel.TabIndex = 1;
            // 
            // nsGroupBox2
            // 
            this.nsGroupBox2.Controls.Add(this.chkDrop);
            this.nsGroupBox2.Controls.Add(this.btnHapusDrop);
            this.nsGroupBox2.Controls.Add(this.listDrop);
            this.nsGroupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.nsGroupBox2.DrawSeperator = false;
            this.nsGroupBox2.Location = new System.Drawing.Point(598, 40);
            this.nsGroupBox2.Name = "nsGroupBox2";
            this.nsGroupBox2.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.nsGroupBox2.Size = new System.Drawing.Size(190, 426);
            this.nsGroupBox2.SubTitle = "Drop";
            this.nsGroupBox2.TabIndex = 1;
            this.nsGroupBox2.Text = "Daftar Tabel";
            this.nsGroupBox2.Title = "Daftar Tabel";
            // 
            // chkDrop
            // 
            this.chkDrop.Checked = false;
            this.chkDrop.Location = new System.Drawing.Point(8, 394);
            this.chkDrop.Name = "chkDrop";
            this.chkDrop.Size = new System.Drawing.Size(75, 23);
            this.chkDrop.TabIndex = 3;
            this.chkDrop.CheckedChanged += new NSCheckBox.CheckedChangedEventHandler(this.chkDrop_CheckedChanged);
            // 
            // btnHapusDrop
            // 
            this.btnHapusDrop.Location = new System.Drawing.Point(105, 394);
            this.btnHapusDrop.Name = "btnHapusDrop";
            this.btnHapusDrop.Size = new System.Drawing.Size(75, 23);
            this.btnHapusDrop.TabIndex = 2;
            this.btnHapusDrop.Text = "Hapus";
            this.btnHapusDrop.Click += new System.EventHandler(this.btnHapusDrop_Click);
            // 
            // listDrop
            // 
            this.listDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.listDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listDrop.Dock = System.Windows.Forms.DockStyle.Top;
            this.listDrop.ForeColor = System.Drawing.Color.White;
            this.listDrop.FormattingEnabled = true;
            this.listDrop.Location = new System.Drawing.Point(5, 40);
            this.listDrop.Name = "listDrop";
            this.listDrop.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listDrop.Size = new System.Drawing.Size(180, 340);
            this.listDrop.TabIndex = 1;
            // 
            // groupProg
            // 
            this.groupProg.Controls.Add(this.pgBar1);
            this.groupProg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupProg.DrawSeperator = false;
            this.groupProg.Location = new System.Drawing.Point(5, 466);
            this.groupProg.Name = "groupProg";
            this.groupProg.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.groupProg.Size = new System.Drawing.Size(783, 78);
            this.groupProg.SubTitle = "Ready...";
            this.groupProg.TabIndex = 0;
            this.groupProg.Text = "nsGroupBox1";
            this.groupProg.Title = "Ready..";
            // 
            // pgBar1
            // 
            this.pgBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgBar1.Location = new System.Drawing.Point(5, 40);
            this.pgBar1.Maximum = 100;
            this.pgBar1.Minimum = 0;
            this.pgBar1.Name = "pgBar1";
            this.pgBar1.Size = new System.Drawing.Size(773, 33);
            this.pgBar1.TabIndex = 0;
            this.pgBar1.Text = "nsProgressBar1";
            this.pgBar1.Value = 0;
            // 
            // bgWork
            // 
            this.bgWork.WorkerReportsProgress = true;
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            this.bgWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWork_ProgressChanged);
            this.bgWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWork_RunWorkerCompleted);
            // 
            // btnHapus3bulan
            // 
            this.btnHapus3bulan.Location = new System.Drawing.Point(23, 300);
            this.btnHapus3bulan.Name = "btnHapus3bulan";
            this.btnHapus3bulan.Size = new System.Drawing.Size(169, 23);
            this.btnHapus3bulan.TabIndex = 11;
            this.btnHapus3bulan.Text = "Hapus Data 3 Bulan";
            this.btnHapus3bulan.Click += new System.EventHandler(this.btnHapus3bulan_Click);
            // 
            // frmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 549);
            this.Controls.Add(this.nsTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMaintenance";
            this.Load += new System.EventHandler(this.frmMaintenance_Load);
            this.nsTheme1.ResumeLayout(false);
            this.nsGroupBox5.ResumeLayout(false);
            this.nsGroupBox4.ResumeLayout(false);
            this.nsGroupBox3.ResumeLayout(false);
            this.nsGroupBox2.ResumeLayout(false);
            this.groupProg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSGroupBox nsGroupBox5;
        private NSGroupBox nsGroupBox4;
        private NSGroupBox nsGroupBox3;
        private NSGroupBox nsGroupBox2;
        private NSGroupBox groupProg;
        private NSControlButton nsControlButton1;
        private System.Windows.Forms.ListBox listAll;
        private System.Windows.Forms.ListBox listDel;
        private System.Windows.Forms.ListBox listDrop;
        private NSButton btnLoad;
        private NSLabel nsLabel2;
        private NSComboBox comboDatabase1;
        private NSButton btnProses;
        private NSButton btnHapusBinlog;
        private NSButton btnKeDrop;
        private NSButton btnKeDelete;
        private System.ComponentModel.BackgroundWorker bgWork;
        private NSProgressBar pgBar1;
        private NSButton btnHapusDelete;
        private NSButton btnHapusDrop;
        private NSCheckBox chkDel;
        private NSCheckBox chkDrop;
        private NSCheckBox chkAll;
        private NSButton btnHapus3bulan;
    }
}