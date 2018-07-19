namespace MySQLTool
{
    partial class frmListTabel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nsGroupBox1 = new NSGroupBox();
            this.nsGroupBox2 = new NSGroupBox();
            this.ListPenting = new System.Windows.Forms.ListBox();
            this.ListHapus = new System.Windows.Forms.ListBox();
            this.nsTheme1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.nsGroupBox1.SuspendLayout();
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
            this.nsTheme1.Controls.Add(this.tableLayoutPanel1);
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
            this.nsTheme1.Size = new System.Drawing.Size(554, 471);
            this.nsTheme1.SmartBounds = true;
            this.nsTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.nsTheme1.TabIndex = 0;
            this.nsTheme1.Text = "nsTheme1";
            this.nsTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.nsTheme1.Transparent = false;
            // 
            // nsControlButton1
            // 
            this.nsControlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nsControlButton1.ControlButton = NSControlButton.Button.Close;
            this.nsControlButton1.Location = new System.Drawing.Point(526, 3);
            this.nsControlButton1.Margin = new System.Windows.Forms.Padding(0);
            this.nsControlButton1.MaximumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.MinimumSize = new System.Drawing.Size(18, 20);
            this.nsControlButton1.Name = "nsControlButton1";
            this.nsControlButton1.Size = new System.Drawing.Size(18, 20);
            this.nsControlButton1.TabIndex = 1;
            this.nsControlButton1.Text = "nsControlButton1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.nsGroupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nsGroupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 357F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 421);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nsGroupBox1
            // 
            this.nsGroupBox1.Controls.Add(this.ListPenting);
            this.nsGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsGroupBox1.DrawSeperator = false;
            this.nsGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.nsGroupBox1.Name = "nsGroupBox1";
            this.nsGroupBox1.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.nsGroupBox1.Size = new System.Drawing.Size(261, 415);
            this.nsGroupBox1.SubTitle = "Penting";
            this.nsGroupBox1.TabIndex = 0;
            this.nsGroupBox1.Text = "nsGroupBox1";
            this.nsGroupBox1.Title = "List Tabel";
            // 
            // nsGroupBox2
            // 
            this.nsGroupBox2.Controls.Add(this.ListHapus);
            this.nsGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nsGroupBox2.DrawSeperator = false;
            this.nsGroupBox2.Location = new System.Drawing.Point(270, 3);
            this.nsGroupBox2.Name = "nsGroupBox2";
            this.nsGroupBox2.Padding = new System.Windows.Forms.Padding(5, 40, 5, 5);
            this.nsGroupBox2.Size = new System.Drawing.Size(261, 415);
            this.nsGroupBox2.SubTitle = "Hapus / Delete";
            this.nsGroupBox2.TabIndex = 1;
            this.nsGroupBox2.Text = "nsGroupBox2";
            this.nsGroupBox2.Title = "List Tabel";
            // 
            // ListPenting
            // 
            this.ListPenting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ListPenting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListPenting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListPenting.ForeColor = System.Drawing.Color.White;
            this.ListPenting.FormattingEnabled = true;
            this.ListPenting.Location = new System.Drawing.Point(5, 40);
            this.ListPenting.Name = "ListPenting";
            this.ListPenting.Size = new System.Drawing.Size(251, 370);
            this.ListPenting.TabIndex = 1;
            // 
            // ListHapus
            // 
            this.ListHapus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ListHapus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListHapus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListHapus.ForeColor = System.Drawing.Color.White;
            this.ListHapus.FormattingEnabled = true;
            this.ListHapus.Location = new System.Drawing.Point(5, 40);
            this.ListHapus.Name = "ListHapus";
            this.ListHapus.Size = new System.Drawing.Size(251, 370);
            this.ListHapus.TabIndex = 1;
            // 
            // frmListTabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 471);
            this.Controls.Add(this.nsTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListTabel";
            this.Text = "frmListTabel";
            this.Load += new System.EventHandler(this.frmListTabel_Load);
            this.nsTheme1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.nsGroupBox1.ResumeLayout(false);
            this.nsGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NSTheme nsTheme1;
        private NSControlButton nsControlButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private NSGroupBox nsGroupBox2;
        private System.Windows.Forms.ListBox ListHapus;
        private NSGroupBox nsGroupBox1;
        private System.Windows.Forms.ListBox ListPenting;
    }
}