namespace MySQLTool
{
    partial class frmMsgBox
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
            this.nsGroupBox1 = new NSGroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnOK = new NSButton();
            this.btnCancel = new NSButton();
            this.nsTheme1.SuspendLayout();
            this.nsGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nsTheme1
            // 
            this.nsTheme1.AccentOffset = 0;
            this.nsTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nsTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.nsTheme1.Colors = new Bloom[0];
            this.nsTheme1.Controls.Add(this.nsGroupBox1);
            this.nsTheme1.Customization = "";
            this.nsTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.nsTheme1.Image = null;
            this.nsTheme1.Location = new System.Drawing.Point(0, 0);
            this.nsTheme1.Movable = true;
            this.nsTheme1.Name = "nsTheme1";
            this.nsTheme1.NoRounding = false;
            this.nsTheme1.Padding = new System.Windows.Forms.Padding(30, 40, 30, 30);
            this.nsTheme1.Sizable = true;
            this.nsTheme1.Size = new System.Drawing.Size(381, 337);
            this.nsTheme1.SmartBounds = true;
            this.nsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "nsTheme1";
            this.nsTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.nsTheme1.Transparent = false;
            // 
            // nsGroupBox1
            // 
            this.nsGroupBox1.Controls.Add(this.lblMsg);
            this.nsGroupBox1.Controls.Add(this.btnOK);
            this.nsGroupBox1.Controls.Add(this.btnCancel);
            this.nsGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsGroupBox1.DrawSeperator = false;
            this.nsGroupBox1.Location = new System.Drawing.Point(30, 40);
            this.nsGroupBox1.Name = "nsGroupBox1";
            this.nsGroupBox1.Size = new System.Drawing.Size(321, 267);
            this.nsGroupBox1.SubTitle = "";
            this.nsGroupBox1.TabIndex = 0;
            this.nsGroupBox1.Text = "nsGroupBox1";
            this.nsGroupBox1.Title = "";
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(11, 38);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(299, 174);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "lblMsg";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(11, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(143, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 337);
            this.Controls.Add(this.nsTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMsgBox";
            this.Load += new System.EventHandler(this.frmMsgBox_Load);
            this.nsTheme1.ResumeLayout(false);
            this.nsGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSGroupBox nsGroupBox1;
        private System.Windows.Forms.Label lblMsg;
        private NSButton btnOK;
        private NSButton btnCancel;
    }
}