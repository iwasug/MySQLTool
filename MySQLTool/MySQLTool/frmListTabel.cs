/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MySQLTool
{
    public partial class frmListTabel : Form
    {
        clsFungsi Fungsi = new clsFungsi();
        public frmListTabel()
        {
            InitializeComponent();
            nsTheme1.Text = Fungsi.versi2;
            this.Icon = MySQLTool.Properties.Resources.MySQL_icon;
        }

        private void frmListTabel_Load(object sender, EventArgs e)
        {
            foreach (string penting in Fungsi.POS)
            {
                ListPenting.Items.Add(penting);
            }
            ListPenting.Sorted = true;
            foreach (string hapus in Fungsi.HAPUS)
            {
                ListHapus.Items.Add(hapus);
            }
            ListHapus.Sorted = true;
        }
    }
}
