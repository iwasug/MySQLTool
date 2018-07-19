namespace MySQLTool
{
    partial class frmCustomBackup
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
            this.nsTheme1 = new NSTheme();
            this.ListTabel = new System.Windows.Forms.CheckedListBox();
            this.groupProgress = new NSGroupBox();
            this.pgBar1 = new NSProgressBar();
            this.btnCancel = new NSButton();
            this.btnBackup = new NSButton();
            this.nsGroupBox1 = new NSGroupBox();
            this.nsGroupBox3 = new NSGroupBox();
            this.CheckBox_view = new NSCheckBox();
            this.CheckBox_struktur = new NSCheckBox();
            this.CheckBox_create = new NSCheckBox();
            this.CheckBox_database = new NSCheckBox();
            this.nsGroupBox2 = new NSGroupBox();
            this.eExclude = new NSRadioButton();
            this.rInclude = new NSRadioButton();
            this.txtCari = new NSTextBox();
            this.chkAll = new NSCheckBox();
            this.btnLoad = new NSButton();
            this.nsLabel1 = new NSLabel();
            this.nsLabel2 = new NSLabel();
            this.comboDatabase1 = new NSComboBox();
            this.nsControlButton1 = new NSControlButton();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.nsTheme1.SuspendLayout();
            this.groupProgress.SuspendLayout();
            this.nsGroupBox1.SuspendLayout();
            this.nsGroupBox3.SuspendLayout();
            this.nsGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nsTheme1
            // 
            this.nsTheme1.AccentOffset = 0;
            this.nsTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.nsTheme1.Colors = new Bloom[0];
            this.nsTheme1.Controls.Add(this.nsControlButton1);
            this.nsTheme1.Controls.Add(this.ListTabel);
            this.nsTheme1.Controls.Add(this.groupProgress);
            this.nsTheme1.Controls.Add(this.nsGroupBox1);
            this.nsTheme1.Customization = "";
            this.nsTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.nsTheme1.Image = null;
            this.nsTheme1.Location = new System.Drawing.Point(0, 0);
            this.nsTheme1.Movable = true;
            this.nsTheme1.Name = "nsTheme1";
            this.nsTheme1.NoRounding = false;
            this.nsTheme1.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);
            this.nsTheme1.Sizable = true;
            this.nsTheme1.Size = new System.Drawing.Size(836, 521);
            this.nsTheme1.SmartBounds = true;
            this.nsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "nsTheme1";
            this.nsTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.nsTheme1.Transparent = false;
            // 
            // ListTabel
            // 
            this.ListTabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ListTabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListTabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTabel.ForeColor = System.Drawing.Color.White;
            this.ListTabel.FormattingEnabled = true;
            this.ListTabel.HorizontalScrollbar = true;
            this.ListTabel.Location = new System.Drawing.Point(10, 162);
            this.ListTabel.MultiColumn = true;
            this.ListTabel.Name = "ListTabel";
            this.ListTabel.Size = new System.Drawing.Size(816, 271);
            this.ListTabel.TabIndex = 3;
            // 
            // groupProgress
            // 
            this.groupProgress.Controls.Add(this.pgBar1);
            this.groupProgress.Controls.Add(this.btnCancel);
            this.groupProgress.Controls.Add(this.btnBackup);
            this.groupProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupProgress.DrawSeperator = false;
            this.groupProgress.Location = new System.Drawing.Point(10, 433);
            this.groupProgress.Name = "groupProgress";
            this.groupProgress.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.groupProgress.Size = new System.Drawing.Size(816, 78);
            this.groupProgress.SubTitle = "Ready...";
            this.groupProgress.TabIndex = 1;
            this.groupProgress.Text = "nsGroupBox1";
            this.groupProgress.Title = "Ready..";
            // 
            // pgBar1
            // 
            this.pgBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgBar1.Location = new System.Drawing.Point(155, 40);
            this.pgBar1.Maximum = 100;
            this.pgBar1.Minimum = 0;
            this.pgBar1.Name = "pgBar1";
            this.pgBar1.Size = new System.Drawing.Size(656, 33);
            this.pgBar1.TabIndex = 2;
            this.pgBar1.Text = "nsProgressBar1";
            this.pgBar1.Value = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(80, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBackup.Location = new System.Drawing.Point(5, 40);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 33);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // nsGroupBox1
            // 
            this.nsGroupBox1.Controls.Add(this.nsGroupBox3);
            this.nsGroupBox1.Controls.Add(this.nsGroupBox2);
            this.nsGroupBox1.Controls.Add(this.txtCari);
            this.nsGroupBox1.Controls.Add(this.chkAll);
            this.nsGroupBox1.Controls.Add(this.btnLoad);
            this.nsGroupBox1.Controls.Add(this.nsLabel1);
            this.nsGroupBox1.Controls.Add(this.nsLabel2);
            this.nsGroupBox1.Controls.Add(this.comboDatabase1);
            this.nsGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.nsGroupBox1.DrawSeperator = false;
            this.nsGroupBox1.Location = new System.Drawing.Point(10, 40);
            this.nsGroupBox1.Name = "nsGroupBox1";
            this.nsGroupBox1.Size = new System.Drawing.Size(816, 122);
            this.nsGroupBox1.SubTitle = "";
            this.nsGroupBox1.TabIndex = 0;
            this.nsGroupBox1.Text = "nsGroupBox1";
            this.nsGroupBox1.Title = "Custom Backup";
            // 
            // nsGroupBox3
            // 
            this.nsGroupBox3.Controls.Add(this.CheckBox_view);
            this.nsGroupBox3.Controls.Add(this.CheckBox_struktur);
            this.nsGroupBox3.Controls.Add(this.CheckBox_create);
            this.nsGroupBox3.Controls.Add(this.CheckBox_database);
            this.nsGroupBox3.DrawSeperator = false;
            this.nsGroupBox3.Location = new System.Drawing.Point(484, 17);
            this.nsGroupBox3.Name = "nsGroupBox3";
            this.nsGroupBox3.Size = new System.Drawing.Size(307, 89);
            this.nsGroupBox3.SubTitle = "Option";
            this.nsGroupBox3.TabIndex = 14;
            this.nsGroupBox3.Text = "nsGroupBox3";
            this.nsGroupBox3.Title = "";
            // 
            // CheckBox_view
            // 
            this.CheckBox_view.Checked = false;
            this.CheckBox_view.Location = new System.Drawing.Point(17, 54);
            this.CheckBox_view.Name = "CheckBox_view";
            this.CheckBox_view.Size = new System.Drawing.Size(115, 23);
            this.CheckBox_view.TabIndex = 0;
            this.CheckBox_view.Text = "Backup View";
            // 
            // CheckBox_struktur
            // 
            this.CheckBox_struktur.Checked = false;
            this.CheckBox_struktur.Location = new System.Drawing.Point(154, 54);
            this.CheckBox_struktur.Name = "CheckBox_struktur";
            this.CheckBox_struktur.Size = new System.Drawing.Size(115, 23);
            this.CheckBox_struktur.TabIndex = 0;
            this.CheckBox_struktur.Text = "Struktur Only";
            // 
            // CheckBox_create
            // 
            this.CheckBox_create.Checked = false;
            this.CheckBox_create.Location = new System.Drawing.Point(154, 25);
            this.CheckBox_create.Name = "CheckBox_create";
            this.CheckBox_create.Size = new System.Drawing.Size(128, 23);
            this.CheckBox_create.TabIndex = 0;
            this.CheckBox_create.Text = "Add Drop / Create";
            // 
            // CheckBox_database
            // 
            this.CheckBox_database.Checked = false;
            this.CheckBox_database.Location = new System.Drawing.Point(17, 25);
            this.CheckBox_database.Name = "CheckBox_database";
            this.CheckBox_database.Size = new System.Drawing.Size(115, 23);
            this.CheckBox_database.TabIndex = 0;
            this.CheckBox_database.Text = "Add Database";
            // 
            // nsGroupBox2
            // 
            this.nsGroupBox2.Controls.Add(this.eExclude);
            this.nsGroupBox2.Controls.Add(this.rInclude);
            this.nsGroupBox2.DrawSeperator = false;
            this.nsGroupBox2.Location = new System.Drawing.Point(335, 17);
            this.nsGroupBox2.Name = "nsGroupBox2";
            this.nsGroupBox2.Size = new System.Drawing.Size(143, 89);
            this.nsGroupBox2.SubTitle = "Selection Mode";
            this.nsGroupBox2.TabIndex = 13;
            this.nsGroupBox2.Text = "nsGroupBox2";
            this.nsGroupBox2.Title = "";
            // 
            // eExclude
            // 
            this.eExclude.Checked = false;
            this.eExclude.Location = new System.Drawing.Point(18, 54);
            this.eExclude.Name = "eExclude";
            this.eExclude.Size = new System.Drawing.Size(108, 23);
            this.eExclude.TabIndex = 0;
            this.eExclude.Text = "Exclude";
            // 
            // rInclude
            // 
            this.rInclude.Checked = false;
            this.rInclude.Location = new System.Drawing.Point(18, 25);
            this.rInclude.Name = "rInclude";
            this.rInclude.Size = new System.Drawing.Size(108, 23);
            this.rInclude.TabIndex = 0;
            this.rInclude.Text = "Include";
            // 
            // txtCari
            // 
            this.txtCari.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCari.Location = new System.Drawing.Point(192, 54);
            this.txtCari.MaxLength = 32767;
            this.txtCari.Multiline = false;
            this.txtCari.Name = "txtCari";
            this.txtCari.ReadOnly = false;
            this.txtCari.Size = new System.Drawing.Size(137, 23);
            this.txtCari.TabIndex = 12;
            this.txtCari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCari.UseSystemPasswordChar = false;
            this.txtCari.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCari_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.Checked = false;
            this.chkAll.Location = new System.Drawing.Point(192, 83);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(105, 23);
            this.chkAll.TabIndex = 11;
            this.chkAll.Text = "Check All";
            this.chkAll.CheckedChanged += new NSCheckBox.CheckedChangedEventHandler(this.chkAll_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(17, 83);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(169, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load Tabel";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // nsLabel1
            // 
            this.nsLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.nsLabel1.Location = new System.Drawing.Point(192, 27);
            this.nsLabel1.Name = "nsLabel1";
            this.nsLabel1.Size = new System.Drawing.Size(137, 23);
            this.nsLabel1.TabIndex = 9;
            this.nsLabel1.Text = "nsLabel2";
            this.nsLabel1.Value1 = "Cari";
            this.nsLabel1.Value2 = "Tabel";
            // 
            // nsLabel2
            // 
            this.nsLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.nsLabel2.Location = new System.Drawing.Point(17, 27);
            this.nsLabel2.Name = "nsLabel2";
            this.nsLabel2.Size = new System.Drawing.Size(169, 23);
            this.nsLabel2.TabIndex = 9;
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
            this.comboDatabase1.Location = new System.Drawing.Point(17, 56);
            this.comboDatabase1.Name = "comboDatabase1";
            this.comboDatabase1.Size = new System.Drawing.Size(169, 21);
            this.comboDatabase1.TabIndex = 8;
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(811, 4);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 4;
            this.nsControlButton1.Text = "nsControlButton1";
            // 
            // MyTimer
            // 
            this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
            // 
            // frmCustomBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 521);
            this.Controls.Add(this.nsTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomBackup";
            this.Text = "frmCustomBackup";
            this.Load += new System.EventHandler(this.frmCustomBackup_Load);
            this.nsTheme1.ResumeLayout(false);
            this.groupProgress.ResumeLayout(false);
            this.nsGroupBox1.ResumeLayout(false);
            this.nsGroupBox3.ResumeLayout(false);
            this.nsGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSGroupBox nsGroupBox1;
        private NSGroupBox groupProgress;
        private System.Windows.Forms.CheckedListBox ListTabel;
        private NSLabel nsLabel2;
        private NSComboBox comboDatabase1;
        private NSButton btnLoad;
        private NSCheckBox chkAll;
        private NSTextBox txtCari;
        private NSLabel nsLabel1;
        private NSGroupBox nsGroupBox2;
        private NSButton btnBackup;
        private NSGroupBox nsGroupBox3;
        private NSButton btnCancel;
        private NSProgressBar pgBar1;
        private NSRadioButton rInclude;
        private NSRadioButton eExclude;
        private NSCheckBox CheckBox_view;
        private NSCheckBox CheckBox_struktur;
        private NSCheckBox CheckBox_create;
        private NSCheckBox CheckBox_database;
        private NSControlButton nsControlButton1;
        private System.Windows.Forms.Timer MyTimer;
    }
}