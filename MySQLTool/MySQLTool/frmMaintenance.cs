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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MySQLTool
{
    public partial class frmMaintenance : Form
    {
        clsFungsi Fungsi = new clsFungsi();
        private string Database = "";
        private string SQL = "";
        private List<string> Drp = new List<string>();
        public frmMaintenance()
        {
            InitializeComponent();
            nsTheme1.Text = Fungsi.versi2;
            this.Icon = MySQLTool.Properties.Resources.MySQL_icon;
            if(!Fungsi.IsToko)
            {
                btnHapus3bulan.Visible = false;
            }
        }

        private void Load_listAll(string Schema)
        {
            listDel.Items.Clear();
            listAll.Items.Clear();
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("mysql")))
            {
                try
                {
                    db.Open();
                    string sql = "";
                    sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + Schema + "' AND TABLE_TYPE='BASE TABLE';";
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string data = dr["TABLE_NAME"].ToString();
                            listAll.Items.Add(data);
                        }
                    }
                    if (Fungsi.IsToko)
                    {
                        if (Schema == "POS")
                        {
                            foreach (string Del in Fungsi.HAPUS)
                            {
                                listDel.Items.Add(Del);
                            }
                            foreach (string tabel in Fungsi.POS)
                            {
                                listAll.Items.Remove(tabel);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //frmMsgBox.Show("CEK LIST TABLE TOKO \n\r" + ex.Message);
                    MessageBox.Show(ex.ToString());
                }
            }
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
                            if (data != "INFORMATION_SCHEMA" && data != "")
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (comboDatabase1.SelectedIndex != -1)
            {
                Load_listAll(comboDatabase1.SelectedItem.ToString());
            }
            else
            {
                frmMsgBox.Show("DATABASE BELUM DI PILIH");
            }
        }

        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            Load_Schema();
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            Drp.Clear();
            int a = 0;
            int b = 0;
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer(Database)))
            {
                a = listDrop.Items.Count + listDel.Items.Count;
                db.Open();
                string sql = "";
                foreach (string Delete in listDel.Items)
                {
                    b += 1;
                    try
                    {
                        sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + Database + "' AND TABLE_NAME='" + Delete + "' AND TABLE_TYPE='BASE TABLE';";
                        MySqlCommand cmd = new MySqlCommand(sql, db);
                        if (cmd.ExecuteScalar().ToString() != "0")
                        {
                            sql = "truncate table " + Delete + ";";
                            cmd = new MySqlCommand(sql, db);
                            cmd.ExecuteNonQuery();
                            lbStatus = "HAPUS TABLE " + Delete;
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMsgBox.Show("ERROR \n\r" + ex.Message);
                    }
                    bgWork.ReportProgress(int.Parse(Math.Round((double)b / (double)a * 100).ToString()));
                }

                foreach (string Drop in listDrop.Items)
                {
                    b += 1;
                    try
                    {
                        sql = "drop table if exists `" + Drop + "`;";
                        MySqlCommand cmd = new MySqlCommand(sql, db);
                        cmd.ExecuteNonQuery();
                        //listDrop.Items.Remove(Drop);
                        //delDrop(Drop);
                        lbStatus = "DROP TABLE " + Drop;
                        Drp.Add(Drop);
                    }
                    catch (Exception ex)
                    {
                        //frmMsgBox.Show("ERROR \n\r" + ex.Message);
                    }
                    bgWork.ReportProgress(int.Parse(Math.Round((double)b / (double)a * 100).ToString()));
                }
            }
        }

        private void bgWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar1.Value = e.ProgressPercentage;
            groupProg.SubTitle = "Progress...." + pgBar1.Value.ToString() + " %";
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnProses.Enabled = true;
            comboDatabase1.Enabled = true;
            foreach (string drp in Drp)
            {
                listDrop.Items.Remove(drp);
            }
            lbStatus = "PROSES BERES";
            frmMsgBox.Show("PROSES BERES");
        }

        private string _lbStatus;
        private string lbStatus
        {
            get
            {
                return this._lbStatus;
            }
            set
            {
                this._lbStatus = value;
                this.UpdatelbStatus();
            }
        }
        private void UpdatelbStatus()
        {
            bool invokeRequired = this.InvokeRequired;
            if (invokeRequired)
            {
                this.Invoke(new MethodInvoker(this.UpdatelbStatus));
            }
            else
            {
                groupProg.Title = this.lbStatus;
            }
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            btnProses.Enabled = false;
            comboDatabase1.Enabled = false;
            Database = comboDatabase1.SelectedItem.ToString();
            bgWork.RunWorkerAsync();
        }

        private void btnKeDelete_Click(object sender, EventArgs e)
        {
            while (listAll.SelectedItems.Count > 0)
            {
                listDel.Items.Add(listAll.SelectedItems[0].ToString());
                listAll.Items.Remove(listAll.SelectedItems[0].ToString());
            }
        }

        private void btnKeDrop_Click(object sender, EventArgs e)
        {
            while (listAll.SelectedItems.Count > 0)
            {
                listDrop.Items.Add(listAll.SelectedItems[0].ToString());
                listAll.Items.Remove(listAll.SelectedItems[0].ToString());
            }
        }

        private void chkDel_CheckedChanged(object sender)
        {
            if (chkDel.Checked == true)
            {
                for (int i = 0; i < listDel.Items.Count; i++)
                {
                    listDel.SetSelected(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listDel.Items.Count; i++)
                {
                    listDel.SetSelected(i, false);
                }
            }
        }

        private void chkDrop_CheckedChanged(object sender)
        {
            if (chkDrop.Checked == true)
            {
                for (int i = 0; i < listDrop.Items.Count; i++)
                {
                    listDrop.SetSelected(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listDrop.Items.Count; i++)
                {
                    listDrop.SetSelected(i, false);
                }
            }
        }

        private void btnHapusDelete_Click(object sender, EventArgs e)
        {
            while (listDel.SelectedItems.Count > 0)
            {
                listDel.Items.Remove(listDel.SelectedItems[0].ToString());
            }
        }

        private void btnHapusDrop_Click(object sender, EventArgs e)
        {
            while (listDrop.SelectedItems.Count > 0)
            {
                listAll.Items.Add(listDrop.SelectedItems[0].ToString());
                listDrop.Items.Remove(listDrop.SelectedItems[0].ToString());
            }
        }

        private void chkAll_CheckedChanged(object sender)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < listAll.Items.Count; i++)
                {
                    listAll.SetSelected(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listAll.Items.Count; i++)
                {
                    listAll.SetSelected(i, false);
                }
            }
        }

        private void btnHapusBinlog_Click(object sender, EventArgs e)
        {
            if(Fungsi.HapusBinlog())
            {
                frmMsgBox.Show("HAPUS BINLOG SELESAI");
            }
        }


        private void btnHapus3bulan_Click(object sender, EventArgs e)
        {
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("POS")))
            {
                db.Open();
                MySqlCommand cmd = new MySqlCommand();
                using (DataTable dt = Fungsi.GETCSVTABLE(Application.StartupPath + "\\3bulan.csv", ","))
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        string tabel = dr["tabel"].ToString();
                        string colom = dr["kolom_tgl"].ToString();
                        try
                        {
                            SQL = "DELETE QUICK FROM " + tabel + " WHERE EXTRACT(YEAR_MONTH FROM " + colom + ") < EXTRACT(YEAR_MONTH FROM (DATE_SUB(CURDATE(), INTERVAL 2 MONTH)));";
                            //frmMsgBox.Show(SQL);
                            cmd = new MySqlCommand(SQL, db);
                            cmd.CommandTimeout = 0;
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            //frmMsgBox.Show(ex.Message + "\n\r" + SQL);
                        }
                    }
                }
                frmMsgBox.Show("HAPUS DATA 3 BULAN OK");
            }
        }
    }
}
