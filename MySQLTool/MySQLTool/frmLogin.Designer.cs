namespace MySQLTool
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.nsTheme1 = new NSTheme();
            this.lblVersi = new NSLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nsGroupBox1 = new NSGroupBox();
            this.txtPass = new NSTextBox();
            this.ChkToko = new NSCheckBox();
            this.btnLogin = new NSButton();
            this.txtPort = new NSTextBox();
            this.nsLabel4 = new NSLabel();
            this.nsLabel3 = new NSLabel();
            this.txtUser = new NSTextBox();
            this.txtIp = new NSTextBox();
            this.nsLabel2 = new NSLabel();
            this.nsLabel1 = new NSLabel();
            this.nsControlButton1 = new NSControlButton();
            this.pgBar1 = new NSProgressBar();
            this.nsTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.nsGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nsTheme1
            // 
            this.nsTheme1.AccentOffset = 0;
            this.nsTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.nsTheme1.Colors = new Bloom[0];
            this.nsTheme1.Controls.Add(this.pgBar1);
            this.nsTheme1.Controls.Add(this.lblVersi);
            this.nsTheme1.Controls.Add(this.pictureBox1);
            this.nsTheme1.Controls.Add(this.nsGroupBox1);
            this.nsTheme1.Controls.Add(this.nsControlButton1);
            this.nsTheme1.Customization = "";
            this.nsTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.nsTheme1.Image = null;
            this.nsTheme1.Location = new System.Drawing.Point(0, 0);
            this.nsTheme1.Movable = true;
            this.nsTheme1.Name = "nsTheme1";
            this.nsTheme1.NoRounding = false;
            this.nsTheme1.Sizable = false;
            this.nsTheme1.Size = new System.Drawing.Size(578, 306);
            this.nsTheme1.SmartBounds = true;
            this.nsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "MySQLTool v.10.2.23";
            this.nsTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.nsTheme1.Transparent = false;
            // 
            // lblVersi
            // 
            this.lblVersi.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblVersi.Location = new System.Drawing.Point(22, 36);
            this.lblVersi.Name = "lblVersi";
            this.lblVersi.Size = new System.Drawing.Size(532, 31);
            this.lblVersi.TabIndex = 5;
            this.lblVersi.Text = "nsLabel5";
            this.lblVersi.Value1 = "NET";
            this.lblVersi.Value2 = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // nsGroupBox1
            // 
            this.nsGroupBox1.Controls.Add(this.txtPass);
            this.nsGroupBox1.Controls.Add(this.ChkToko);
            this.nsGroupBox1.Controls.Add(this.btnLogin);
            this.nsGroupBox1.Controls.Add(this.txtPort);
            this.nsGroupBox1.Controls.Add(this.nsLabel4);
            this.nsGroupBox1.Controls.Add(this.nsLabel3);
            this.nsGroupBox1.Controls.Add(this.txtUser);
            this.nsGroupBox1.Controls.Add(this.txtIp);
            this.nsGroupBox1.Controls.Add(this.nsLabel2);
            this.nsGroupBox1.Controls.Add(this.nsLabel1);
            this.nsGroupBox1.DrawSeperator = false;
            this.nsGroupBox1.Location = new System.Drawing.Point(183, 76);
            this.nsGroupBox1.Name = "nsGroupBox1";
            this.nsGroupBox1.Size = new System.Drawing.Size(371, 207);
            this.nsGroupBox1.SubTitle = "Server MySQL";
            this.nsGroupBox1.TabIndex = 3;
            this.nsGroupBox1.Text = "nsGroupBox1";
            this.nsGroupBox1.Title = "Informasi";
            // 
            // txtPass
            // 
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.Location = new System.Drawing.Point(17, 118);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Multiline = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.ReadOnly = false;
            this.txtPass.Size = new System.Drawing.Size(161, 23);
            this.txtPass.TabIndex = 9;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // ChkToko
            // 
            this.ChkToko.Checked = false;
            this.ChkToko.Location = new System.Drawing.Point(192, 147);
            this.ChkToko.Name = "ChkToko";
            this.ChkToko.Size = new System.Drawing.Size(160, 23);
            this.ChkToko.TabIndex = 8;
            this.ChkToko.Text = "MySQL Toko";
            this.ChkToko.CheckedChanged += new NSCheckBox.CheckedChangedEventHandler(this.ChkToko_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(17, 147);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(161, 47);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPort
            // 
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.Location = new System.Drawing.Point(192, 118);
            this.txtPort.MaxLength = 32767;
            this.txtPort.Multiline = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = false;
            this.txtPort.Size = new System.Drawing.Size(39, 23);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "3306";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPort.UseSystemPasswordChar = false;
            // 
            // nsLabel4
            // 
            this.nsLabel4.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold);
            this.nsLabel4.Location = new System.Drawing.Point(190, 94);
            this.nsLabel4.Name = "nsLabel4";
            this.nsLabel4.Size = new System.Drawing.Size(133, 25);
            this.nsLabel4.TabIndex = 5;
            this.nsLabel4.Text = "nsLabel1";
            this.nsLabel4.Value1 = "Port";
            this.nsLabel4.Value2 = "MySQL";
            // 
            // nsLabel3
            // 
            this.nsLabel3.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold);
            this.nsLabel3.Location = new System.Drawing.Point(16, 94);
            this.nsLabel3.Name = "nsLabel3";
            this.nsLabel3.Size = new System.Drawing.Size(133, 25);
            this.nsLabel3.TabIndex = 3;
            this.nsLabel3.Text = "nsLabel1";
            this.nsLabel3.Value1 = "Pass";
            this.nsLabel3.Value2 = "MySQL";
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Location = new System.Drawing.Point(190, 62);
            this.txtUser.MaxLength = 32767;
            this.txtUser.Multiline = false;
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = false;
            this.txtUser.Size = new System.Drawing.Size(162, 23);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "root";
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUser.UseSystemPasswordChar = false;
            // 
            // txtIp
            // 
            this.txtIp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIp.Location = new System.Drawing.Point(17, 65);
            this.txtIp.MaxLength = 32767;
            this.txtIp.Multiline = false;
            this.txtIp.Name = "txtIp";
            this.txtIp.ReadOnly = false;
            this.txtIp.Size = new System.Drawing.Size(162, 23);
            this.txtIp.TabIndex = 1;
            this.txtIp.Text = "localhost";
            this.txtIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIp.UseSystemPasswordChar = false;
            // 
            // nsLabel2
            // 
            this.nsLabel2.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold);
            this.nsLabel2.Location = new System.Drawing.Point(190, 39);
            this.nsLabel2.Name = "nsLabel2";
            this.nsLabel2.Size = new System.Drawing.Size(133, 25);
            this.nsLabel2.TabIndex = 0;
            this.nsLabel2.Text = "nsLabel1";
            this.nsLabel2.Value1 = "User";
            this.nsLabel2.Value2 = "MySQL";
            // 
            // nsLabel1
            // 
            this.nsLabel1.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold);
            this.nsLabel1.Location = new System.Drawing.Point(17, 41);
            this.nsLabel1.Name = "nsLabel1";
            this.nsLabel1.Size = new System.Drawing.Size(133, 23);
            this.nsLabel1.TabIndex = 0;
            this.nsLabel1.Text = "nsLabel1";
            this.nsLabel1.Value1 = "Server";
            this.nsLabel1.Value2 = "MySQL";
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(551, 5);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 0;
            this.nsControlButton1.Text = "nsControlButton1";
            // 
            // pgBar1
            // 
            this.pgBar1.Location = new System.Drawing.Point(22, 247);
            this.pgBar1.Maximum = 100;
            this.pgBar1.Minimum = 0;
            this.pgBar1.Name = "pgBar1";
            this.pgBar1.Size = new System.Drawing.Size(137, 23);
            this.pgBar1.TabIndex = 6;
            this.pgBar1.Text = "nsProgressBar1";
            this.pgBar1.Value = 0;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 306);
            this.Controls.Add(this.nsTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.nsTheme1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.nsGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSControlButton nsControlButton1;
        private NSGroupBox nsGroupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NSLabel nsLabel1;
        private NSTextBox txtIp;
        private NSLabel nsLabel2;
        private NSTextBox txtUser;
        private NSLabel nsLabel3;
        private NSLabel nsLabel4;
        private NSTextBox txtPort;
        private NSButton btnLogin;
        private NSCheckBox ChkToko;
        private NSLabel lblVersi;
        private NSTextBox txtPass;
        private NSProgressBar pgBar1;
    }
}