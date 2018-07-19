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
    public partial class frmMsgBox : Form
    {
        clsFungsi Fungsi = new clsFungsi();
        static frmMsgBox newMessageBox;
        private static DialogResult _buttonResult = new DialogResult();
        public frmMsgBox()
        {
            InitializeComponent();
            nsTheme1.Text = Fungsi.versi2;
        }


        public static void Show(string txtMessage)
        {
            newMessageBox = new frmMsgBox();
            newMessageBox.btnCancel.Visible = false;
            newMessageBox.btnOK.Dock = DockStyle.Bottom;
            newMessageBox.lblMsg.Text = txtMessage;
            newMessageBox.ShowDialog();
        }

        public static DialogResult Show(string txtMessage,string Dialog)
        {
            newMessageBox = new frmMsgBox();
            newMessageBox.lblMsg.Text = txtMessage;
            newMessageBox.ShowDialog();
            return _buttonResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _buttonResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _buttonResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmMsgBox_Load(object sender, EventArgs e)
        {
            btnOK.Focus();
        }


    }
}
