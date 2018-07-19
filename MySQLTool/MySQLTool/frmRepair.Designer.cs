namespace MySQLTool
{
    partial class frmRepair
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.nsControlButton1 = new NSControlButton();
            this.nsGroupBox1 = new NSGroupBox();
            this.btnProses = new NSButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioUpgrade = new NSRadioButton();
            this.radioCheck = new NSRadioButton();
            this.nsLabel2 = new NSLabel();
            this.comboDatabase1 = new NSComboBox();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.radioLatin = new NSRadioButton();
            this.nsTheme1.SuspendLayout();
            this.nsGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nsTheme1
            // 
            this.nsTheme1.AccentOffset = 0;
            this.nsTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.nsTheme1.Colors = new Bloom[0];
            this.nsTheme1.Controls.Add(this.txtLog);
            this.nsTheme1.Controls.Add(this.nsControlButton1);
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
            this.nsTheme1.Size = new System.Drawing.Size(565, 437);
            this.nsTheme1.SmartBounds = true;
            this.nsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "nsTheme1";
            this.nsTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.nsTheme1.Transparent = false;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(10, 151);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(545, 276);
            this.txtLog.TabIndex = 3;
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(536, 6);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 2;
            this.nsControlButton1.Text = "nsControlButton1";
            // 
            // nsGroupBox1
            // 
            this.nsGroupBox1.Controls.Add(this.btnProses);
            this.nsGroupBox1.Controls.Add(this.panel1);
            this.nsGroupBox1.Controls.Add(this.nsLabel2);
            this.nsGroupBox1.Controls.Add(this.comboDatabase1);
            this.nsGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.nsGroupBox1.DrawSeperator = false;
            this.nsGroupBox1.Location = new System.Drawing.Point(10, 40);
            this.nsGroupBox1.Name = "nsGroupBox1";
            this.nsGroupBox1.Size = new System.Drawing.Size(545, 111);
            this.nsGroupBox1.SubTitle = "Details";
            this.nsGroupBox1.TabIndex = 0;
            this.nsGroupBox1.Text = "nsGroupBox1";
            this.nsGroupBox1.Title = "Check & Repair Table";
            // 
            // btnProses
            // 
            this.btnProses.Location = new System.Drawing.Point(389, 18);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(144, 82);
            this.btnProses.TabIndex = 9;
            this.btnProses.Text = "Proses";
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioLatin);
            this.panel1.Controls.Add(this.radioUpgrade);
            this.panel1.Controls.Add(this.radioCheck);
            this.panel1.Location = new System.Drawing.Point(198, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 84);
            this.panel1.TabIndex = 8;
            // 
            // radioUpgrade
            // 
            this.radioUpgrade.Checked = false;
            this.radioUpgrade.Location = new System.Drawing.Point(14, 32);
            this.radioUpgrade.Name = "radioUpgrade";
            this.radioUpgrade.Size = new System.Drawing.Size(144, 23);
            this.radioUpgrade.TabIndex = 0;
            this.radioUpgrade.Text = "Upgrade MySQL";
            // 
            // radioCheck
            // 
            this.radioCheck.Checked = false;
            this.radioCheck.Location = new System.Drawing.Point(14, 3);
            this.radioCheck.Name = "radioCheck";
            this.radioCheck.Size = new System.Drawing.Size(161, 23);
            this.radioCheck.TabIndex = 0;
            this.radioCheck.Text = "Check / Repair MySQL";
            // 
            // nsLabel2
            // 
            this.nsLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.nsLabel2.Location = new System.Drawing.Point(23, 33);
            this.nsLabel2.Name = "nsLabel2";
            this.nsLabel2.Size = new System.Drawing.Size(169, 23);
            this.nsLabel2.TabIndex = 7;
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
            this.comboDatabase1.Location = new System.Drawing.Point(23, 62);
            this.comboDatabase1.Name = "comboDatabase1";
            this.comboDatabase1.Size = new System.Drawing.Size(169, 21);
            this.comboDatabase1.TabIndex = 6;
            // 
            // bgWork
            // 
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            this.bgWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWork_RunWorkerCompleted);
            // 
            // radioLatin
            // 
            this.radioLatin.Checked = false;
            this.radioLatin.Location = new System.Drawing.Point(14, 58);
            this.radioLatin.Name = "radioLatin";
            this.radioLatin.Size = new System.Drawing.Size(144, 23);
            this.radioLatin.TabIndex = 0;
            this.radioLatin.Text = "Upgrade Latin1";
            // 
            // frmRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 437);
            this.Controls.Add(this.nsTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRepair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRepair";
            this.Load += new System.EventHandler(this.frmRepair_Load);
            this.nsTheme1.ResumeLayout(false);
            this.nsTheme1.PerformLayout();
            this.nsGroupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSGroupBox nsGroupBox1;
        private NSLabel nsLabel2;
        private NSComboBox comboDatabase1;
        private NSButton btnProses;
        private System.Windows.Forms.Panel panel1;
        private NSRadioButton radioUpgrade;
        private NSRadioButton radioCheck;
        private NSControlButton nsControlButton1;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.TextBox txtLog;
        private NSRadioButton radioLatin;
    }
}