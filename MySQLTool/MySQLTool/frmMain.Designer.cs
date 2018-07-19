namespace MySQLTool
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.nsTheme1 = new NSTheme();
            this.nsTabControl1 = new NSTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancelBackup = new NSButton();
            this.btnBackup = new NSButton();
            this.ChkTblPenting = new NSCheckBox();
            this.ChkStruktur = new NSCheckBox();
            this.nsLabel2 = new NSLabel();
            this.comboDatabase1 = new NSComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnPilihFile = new NSButton();
            this.btnCancelRestore = new NSButton();
            this.btnRestore = new NSButton();
            this.nsLabel1 = new NSLabel();
            this.comboDatabase2 = new NSComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUtilMaintenance = new NSButton();
            this.btnUtilCheck = new NSButton();
            this.btnUtilCustomBackup = new NSButton();
            this.btnUtilListTabel = new NSButton();
            this.lblVersi = new NSLabel();
            this.nsControlButton1 = new NSControlButton();
            this.groupProgress = new NSGroupBox();
            this.pgBar1 = new NSProgressBar();
            this.groupInfo = new NSGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSizeIbdata = new NSLabel();
            this.lblVersiMySQL = new NSLabel();
            this.lblSizeBinlog = new NSLabel();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.nsTheme1.SuspendLayout();
            this.nsTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupProgress.SuspendLayout();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nsTheme1
            // 
            this.nsTheme1.AccentOffset = 0;
            this.nsTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.nsTheme1.Colors = new Bloom[0];
            this.nsTheme1.Controls.Add(this.nsTabControl1);
            this.nsTheme1.Controls.Add(this.lblVersi);
            this.nsTheme1.Controls.Add(this.nsControlButton1);
            this.nsTheme1.Controls.Add(this.groupProgress);
            this.nsTheme1.Controls.Add(this.groupInfo);
            this.nsTheme1.Customization = "";
            this.nsTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.nsTheme1.Image = null;
            this.nsTheme1.Location = new System.Drawing.Point(0, 0);
            this.nsTheme1.Movable = true;
            this.nsTheme1.Name = "nsTheme1";
            this.nsTheme1.NoRounding = false;
            this.nsTheme1.Padding = new System.Windows.Forms.Padding(20, 40, 20, 20);
            this.nsTheme1.Sizable = false;
            this.nsTheme1.Size = new System.Drawing.Size(708, 314);
            this.nsTheme1.SmartBounds = true;
            this.nsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "nsTheme1";
            this.nsTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.nsTheme1.Transparent = false;
            // 
            // nsTabControl1
            // 
            this.nsTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.nsTabControl1.Controls.Add(this.tabPage1);
            this.nsTabControl1.Controls.Add(this.tabPage2);
            this.nsTabControl1.Controls.Add(this.tabPage3);
            this.nsTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.nsTabControl1.ItemSize = new System.Drawing.Size(28, 115);
            this.nsTabControl1.Location = new System.Drawing.Point(222, 63);
            this.nsTabControl1.Multiline = true;
            this.nsTabControl1.Name = "nsTabControl1";
            this.nsTabControl1.SelectedIndex = 0;
            this.nsTabControl1.Size = new System.Drawing.Size(466, 156);
            this.nsTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.nsTabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage1.Controls.Add(this.btnCancelBackup);
            this.tabPage1.Controls.Add(this.btnBackup);
            this.tabPage1.Controls.Add(this.ChkTblPenting);
            this.tabPage1.Controls.Add(this.ChkStruktur);
            this.tabPage1.Controls.Add(this.nsLabel2);
            this.tabPage1.Controls.Add(this.comboDatabase1);
            this.tabPage1.Location = new System.Drawing.Point(119, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(343, 148);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Backup";
            // 
            // btnCancelBackup
            // 
            this.btnCancelBackup.Location = new System.Drawing.Point(198, 75);
            this.btnCancelBackup.Name = "btnCancelBackup";
            this.btnCancelBackup.Size = new System.Drawing.Size(126, 50);
            this.btnCancelBackup.TabIndex = 5;
            this.btnCancelBackup.Text = "Cancel";
            this.btnCancelBackup.Click += new System.EventHandler(this.btnCancelBackup_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(198, 17);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(126, 50);
            this.btnBackup.TabIndex = 5;
            this.btnBackup.Text = "Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // ChkTblPenting
            // 
            this.ChkTblPenting.Checked = false;
            this.ChkTblPenting.Location = new System.Drawing.Point(15, 102);
            this.ChkTblPenting.Name = "ChkTblPenting";
            this.ChkTblPenting.Size = new System.Drawing.Size(169, 23);
            this.ChkTblPenting.TabIndex = 4;
            this.ChkTblPenting.Text = "Tabel Penting Only";
            // 
            // ChkStruktur
            // 
            this.ChkStruktur.Checked = false;
            this.ChkStruktur.Location = new System.Drawing.Point(15, 73);
            this.ChkStruktur.Name = "ChkStruktur";
            this.ChkStruktur.Size = new System.Drawing.Size(169, 23);
            this.ChkStruktur.TabIndex = 4;
            this.ChkStruktur.Text = "Struktur Only";
            // 
            // nsLabel2
            // 
            this.nsLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.nsLabel2.Location = new System.Drawing.Point(15, 17);
            this.nsLabel2.Name = "nsLabel2";
            this.nsLabel2.Size = new System.Drawing.Size(169, 23);
            this.nsLabel2.TabIndex = 3;
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
            this.comboDatabase1.Location = new System.Drawing.Point(15, 46);
            this.comboDatabase1.Name = "comboDatabase1";
            this.comboDatabase1.Size = new System.Drawing.Size(169, 21);
            this.comboDatabase1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage2.Controls.Add(this.lblFile);
            this.tabPage2.Controls.Add(this.btnPilihFile);
            this.tabPage2.Controls.Add(this.btnCancelRestore);
            this.tabPage2.Controls.Add(this.btnRestore);
            this.tabPage2.Controls.Add(this.nsLabel1);
            this.tabPage2.Controls.Add(this.comboDatabase2);
            this.tabPage2.Location = new System.Drawing.Point(119, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(343, 148);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Restore";
            // 
            // lblFile
            // 
            this.lblFile.ForeColor = System.Drawing.Color.White;
            this.lblFile.Location = new System.Drawing.Point(15, 43);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(171, 36);
            this.lblFile.TabIndex = 9;
            this.lblFile.Text = "File...";
            // 
            // btnPilihFile
            // 
            this.btnPilihFile.Location = new System.Drawing.Point(15, 17);
            this.btnPilihFile.Name = "btnPilihFile";
            this.btnPilihFile.Size = new System.Drawing.Size(169, 23);
            this.btnPilihFile.TabIndex = 8;
            this.btnPilihFile.Text = "Pilih File ......";
            this.btnPilihFile.Click += new System.EventHandler(this.btnPilihFile_Click);
            // 
            // btnCancelRestore
            // 
            this.btnCancelRestore.Location = new System.Drawing.Point(198, 75);
            this.btnCancelRestore.Name = "btnCancelRestore";
            this.btnCancelRestore.Size = new System.Drawing.Size(126, 50);
            this.btnCancelRestore.TabIndex = 6;
            this.btnCancelRestore.Text = "Cancel";
            this.btnCancelRestore.Click += new System.EventHandler(this.btnCancelRestore_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(198, 17);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(126, 50);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // nsLabel1
            // 
            this.nsLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.nsLabel1.Location = new System.Drawing.Point(15, 82);
            this.nsLabel1.Name = "nsLabel1";
            this.nsLabel1.Size = new System.Drawing.Size(169, 23);
            this.nsLabel1.TabIndex = 1;
            this.nsLabel1.Text = "nsLabel1";
            this.nsLabel1.Value1 = "Pilih Databse ";
            this.nsLabel1.Value2 = "MySQL";
            // 
            // comboDatabase2
            // 
            this.comboDatabase2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.comboDatabase2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboDatabase2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDatabase2.ForeColor = System.Drawing.Color.White;
            this.comboDatabase2.FormattingEnabled = true;
            this.comboDatabase2.Location = new System.Drawing.Point(15, 111);
            this.comboDatabase2.Name = "comboDatabase2";
            this.comboDatabase2.Size = new System.Drawing.Size(169, 21);
            this.comboDatabase2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(119, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(343, 148);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Utility";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnUtilMaintenance, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUtilCheck, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUtilCustomBackup, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUtilListTabel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 142);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnUtilMaintenance
            // 
            this.btnUtilMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUtilMaintenance.Location = new System.Drawing.Point(3, 3);
            this.btnUtilMaintenance.Name = "btnUtilMaintenance";
            this.btnUtilMaintenance.Size = new System.Drawing.Size(162, 65);
            this.btnUtilMaintenance.TabIndex = 0;
            this.btnUtilMaintenance.Text = "Maintenance Tabel";
            this.btnUtilMaintenance.Click += new System.EventHandler(this.btnUtilMaintenance_Click);
            // 
            // btnUtilCheck
            // 
            this.btnUtilCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUtilCheck.Location = new System.Drawing.Point(171, 3);
            this.btnUtilCheck.Name = "btnUtilCheck";
            this.btnUtilCheck.Size = new System.Drawing.Size(163, 65);
            this.btnUtilCheck.TabIndex = 1;
            this.btnUtilCheck.Text = "Check & Repair Tabel";
            this.btnUtilCheck.Click += new System.EventHandler(this.btnUtilCheck_Click);
            // 
            // btnUtilCustomBackup
            // 
            this.btnUtilCustomBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUtilCustomBackup.Location = new System.Drawing.Point(3, 74);
            this.btnUtilCustomBackup.Name = "btnUtilCustomBackup";
            this.btnUtilCustomBackup.Size = new System.Drawing.Size(162, 65);
            this.btnUtilCustomBackup.TabIndex = 2;
            this.btnUtilCustomBackup.Text = "Custom Backup";
            this.btnUtilCustomBackup.Click += new System.EventHandler(this.btnUtilCustomBackup_Click);
            // 
            // btnUtilListTabel
            // 
            this.btnUtilListTabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUtilListTabel.Location = new System.Drawing.Point(171, 74);
            this.btnUtilListTabel.Name = "btnUtilListTabel";
            this.btnUtilListTabel.Size = new System.Drawing.Size(163, 65);
            this.btnUtilListTabel.TabIndex = 3;
            this.btnUtilListTabel.Text = "List Tabel Penting & Hapus";
            this.btnUtilListTabel.Click += new System.EventHandler(this.btnUtilListTabel_Click);
            // 
            // lblVersi
            // 
            this.lblVersi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVersi.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblVersi.Location = new System.Drawing.Point(222, 40);
            this.lblVersi.Name = "lblVersi";
            this.lblVersi.Size = new System.Drawing.Size(466, 23);
            this.lblVersi.TabIndex = 4;
            this.lblVersi.Text = "nsLabel1";
            this.lblVersi.Value1 = "NET";
            this.lblVersi.Value2 = "SEAL";
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(681, 4);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 3;
            this.nsControlButton1.Text = "nsControlButton1";
            // 
            // groupProgress
            // 
            this.groupProgress.Controls.Add(this.pgBar1);
            this.groupProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupProgress.DrawSeperator = false;
            this.groupProgress.Location = new System.Drawing.Point(222, 219);
            this.groupProgress.Name = "groupProgress";
            this.groupProgress.Padding = new System.Windows.Forms.Padding(10, 35, 10, 10);
            this.groupProgress.Size = new System.Drawing.Size(466, 75);
            this.groupProgress.SubTitle = "Ready...";
            this.groupProgress.TabIndex = 1;
            this.groupProgress.Text = "nsGroupBox2";
            this.groupProgress.Title = "Ready...";
            // 
            // pgBar1
            // 
            this.pgBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgBar1.Location = new System.Drawing.Point(10, 35);
            this.pgBar1.Maximum = 100;
            this.pgBar1.Minimum = 0;
            this.pgBar1.Name = "pgBar1";
            this.pgBar1.Size = new System.Drawing.Size(446, 30);
            this.pgBar1.TabIndex = 0;
            this.pgBar1.Text = "nsProgressBar1";
            this.pgBar1.Value = 0;
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.pictureBox1);
            this.groupInfo.Controls.Add(this.lblSizeIbdata);
            this.groupInfo.Controls.Add(this.lblVersiMySQL);
            this.groupInfo.Controls.Add(this.lblSizeBinlog);
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupInfo.DrawSeperator = false;
            this.groupInfo.Location = new System.Drawing.Point(20, 40);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(202, 254);
            this.groupInfo.SubTitle = "Details";
            this.groupInfo.TabIndex = 0;
            this.groupInfo.Text = "nsGroupBox1";
            this.groupInfo.Title = "GroupBox";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblSizeIbdata
            // 
            this.lblSizeIbdata.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeIbdata.Location = new System.Drawing.Point(17, 216);
            this.lblSizeIbdata.Name = "lblSizeIbdata";
            this.lblSizeIbdata.Size = new System.Drawing.Size(166, 23);
            this.lblSizeIbdata.TabIndex = 2;
            this.lblSizeIbdata.Text = "nsLabel5";
            this.lblSizeIbdata.Value1 = "IB";
            this.lblSizeIbdata.Value2 = "DATA";
            // 
            // lblVersiMySQL
            // 
            this.lblVersiMySQL.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersiMySQL.Location = new System.Drawing.Point(17, 197);
            this.lblVersiMySQL.Name = "lblVersiMySQL";
            this.lblVersiMySQL.Size = new System.Drawing.Size(166, 23);
            this.lblVersiMySQL.TabIndex = 1;
            this.lblVersiMySQL.Text = "nsLabel4";
            this.lblVersiMySQL.Value1 = "VERSI";
            this.lblVersiMySQL.Value2 = "MYSQL";
            // 
            // lblSizeBinlog
            // 
            this.lblSizeBinlog.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeBinlog.Location = new System.Drawing.Point(17, 177);
            this.lblSizeBinlog.Name = "lblSizeBinlog";
            this.lblSizeBinlog.Size = new System.Drawing.Size(166, 23);
            this.lblSizeBinlog.TabIndex = 0;
            this.lblSizeBinlog.Text = "nsLabel3";
            this.lblSizeBinlog.Value1 = "BIN";
            this.lblSizeBinlog.Value2 = "LOG";
            // 
            // MyTimer
            // 
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 314);
            this.Controls.Add(this.nsTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.nsTheme1.ResumeLayout(false);
            this.nsTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupProgress.ResumeLayout(false);
            this.groupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSGroupBox groupProgress;
        private NSGroupBox groupInfo;
        private NSControlButton nsControlButton1;
        private NSTabControl nsTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private NSLabel lblVersi;
        private NSLabel nsLabel1;
        private NSComboBox comboDatabase2;
        private NSLabel nsLabel2;
        private NSComboBox comboDatabase1;
        private NSCheckBox ChkTblPenting;
        private NSCheckBox ChkStruktur;
        private NSButton btnCancelBackup;
        private NSButton btnBackup;
        private NSButton btnCancelRestore;
        private NSButton btnRestore;
        private NSButton btnPilihFile;
        private System.Windows.Forms.Label lblFile;
        private NSProgressBar pgBar1;
        private NSLabel lblSizeIbdata;
        private NSLabel lblVersiMySQL;
        private NSLabel lblSizeBinlog;
        private System.Windows.Forms.Timer MyTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private NSButton btnUtilMaintenance;
        private NSButton btnUtilCheck;
        private NSButton btnUtilCustomBackup;
        private NSButton btnUtilListTabel;
    }
}