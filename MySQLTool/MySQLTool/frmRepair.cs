/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MySQLTool
{
    public partial class frmRepair : Form
    {
        clsFungsi Fungsi = new clsFungsi();
        private string database = "";
        private string job = "";
        public frmRepair()
        {
            InitializeComponent();
            nsTheme1.Text = Fungsi.versi2;
            this.Icon = MySQLTool.Properties.Resources.MySQL_icon;
        }

        private void Load_Schema()
        {
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("mysql")))
            {
                try
                {
                    db.Open();
                    comboDatabase1.Items.Clear();
                    string sql = "SHOW DATABASES;";
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string data = dr["Database"].ToString().ToUpper();
                            if (data != "INFORMATION_SCHEMA")
                            {
                                comboDatabase1.Items.Add(dr["Database"].ToString().ToUpper());
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    frmMsgBox.Show("GAGAL LOAD SCHEMA \n\r" + ex.Message);
                }
            }
        }

        private void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            //Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                if (e.Data != null)
                {
                    txtLog.AppendText(e.Data.Trim() + "\r\n" ?? string.Empty + "\r\n");
                    txtLog.ScrollToCaret();
                }
            }));
        }


        private void btnProses_Click(object sender, EventArgs e)
        {
            btnProses.Enabled = false;
            comboDatabase1.Enabled = false;
            database = comboDatabase1.SelectedItem.ToString();
            if (radioCheck.Checked)
            {
                job = "check";
                bgWork.RunWorkerAsync();
            }
            else if (radioUpgrade.Checked)
            {
                job = "upgrade";
                bgWork.RunWorkerAsync();
            }
            else if(radioLatin.Checked)
            {
                Fungsi.UpdateLatin1();
                frmMsgBox.Show("PROSES SELESAI");
                btnProses.Enabled = true;
                comboDatabase1.Enabled = true;
            }
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            using (Process sortProcess = new Process())
            {
                if (job == "check")
                {
                    sortProcess.StartInfo.FileName = @"mysqlCheck.exe";
                    sortProcess.StartInfo.Arguments = " -u" + Fungsi.User + " -p" + Fungsi.Pass + " --host=" + Fungsi.Ip + " --port=" + Fungsi.Port + " " + database + " --auto-repair -F";
                }
                else if (job == "upgrade")
                {
                    sortProcess.StartInfo.FileName = @"mysql_upgrade.exe";
                    sortProcess.StartInfo.Arguments = " -u" + Fungsi.User + " -p" + Fungsi.Pass + " --host=" + Fungsi.Ip + " --port=" + Fungsi.Port + "";
                }
                sortProcess.StartInfo.CreateNoWindow = true;
                sortProcess.StartInfo.UseShellExecute = false;
                sortProcess.StartInfo.RedirectStandardOutput = true;
                sortProcess.OutputDataReceived += new DataReceivedEventHandler(proc_DataReceived);
                sortProcess.Start();
                sortProcess.BeginOutputReadLine();
                while (!sortProcess.HasExited)
                {
                    Application.DoEvents();
                }
            }
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frmMsgBox.Show("PROSES SELESAI");
            btnProses.Enabled = true;
            comboDatabase1.Enabled = true;
        }

        private void frmRepair_Load(object sender, EventArgs e)
        {
            Load_Schema();
        }
    }
}
