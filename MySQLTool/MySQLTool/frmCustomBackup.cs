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
    public partial class frmCustomBackup : Form
    {
        clsFungsi Fungsi = new clsFungsi();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlBackup mb;
        Timer timer1;
        BackgroundWorker bwExport;
        string dumpFile = "";
        Stopwatch stopwatch = new Stopwatch();
        bool cancel = false;
        string _currentTableName = "";
        int _totalRowsInCurrentTable = 0;
        int _totalRowsInAllTables = 0;
        int _currentRowIndexInCurrentTable = 0;
        int _currentRowIndexInAllTable = 0;
        int _totalTables = 0;
        int _currentTableIndex = 0;
        public frmCustomBackup()
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

        private void frmCustomBackup_Load(object sender, EventArgs e)
        {
            Load_Schema();
            btnCancel.Enabled = false;
        }

        private void txtCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindMyString(txtCari.Text);
            }
        }

        private void FindMyString(string searchString)
        {
            if (searchString != string.Empty)
            {
                ListTabel.Items.Clear();
                using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("mysql")))
                {
                    try
                    {
                        db.Open();
                        string sql = "";
                        sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + comboDatabase1.SelectedItem.ToString() + "' AND TABLE_TYPE='BASE TABLE' AND TABLE_NAME LIKE '%" + searchString + "%';";
                        MySqlCommand cmd = new MySqlCommand(sql, db);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string data = dr["TABLE_NAME"].ToString();
                                ListTabel.Items.Add(data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                if (comboDatabase1.SelectedIndex != -1)
                {
                    Load_Tabel(comboDatabase1.SelectedItem.ToString());
                }
                else
                {
                    frmMsgBox.Show("DATABASE BELUM DI PILIH");
                }
            }
        }

        private void Load_Tabel(string Schema)
        {
            ListTabel.Items.Clear();
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
                            ListTabel.Items.Add(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void chkAll_CheckedChanged(object sender)
        {
            if (chkAll.Checked)
            {
                for (int a = 0; a < ListTabel.Items.Count; a++)
                {
                    ListTabel.SetItemChecked(a, true);
                }
                chkAll.Text = "UnCheck All";
            }
            else
            {
                for (int a = 0; a < ListTabel.Items.Count; a++)
                {
                    ListTabel.SetItemChecked(a, false);
                }
                chkAll.Text = "Check All";
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (comboDatabase1.SelectedIndex != -1)
            {
                Load_Tabel(comboDatabase1.SelectedItem.ToString());
            }
            else
            {
                frmMsgBox.Show("DATABASE BELUM DI PILIH");
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.SQL|*.SQL|*.*|*.*";
            saveFileDialog.Title = "SIMPAN FILE BACKUP ";
            DialogResult result = saveFileDialog.ShowDialog();
            /*
            saveFileDialog.ShowDialog();
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "PILIH FOLDER UNTUK BACKUP";
            DialogResult result = fd.ShowDialog();
            */
            if (result == DialogResult.OK)
            {
                mb = new MySqlBackup();
                mb.ExportProgressChanged += mb_ExportProgressChanged;
                timer1 = new Timer();
                timer1.Interval = 50;
                timer1.Tick += timer1_Tick;
                bwExport = new BackgroundWorker();
                bwExport.DoWork += bwExport_DoWork;
                bwExport.RunWorkerCompleted += bwExport_RunWorkerCompleted;
                dumpFile = saveFileDialog.FileName;
                string connection = Fungsi.GetServer(comboDatabase1.SelectedItem.ToString());
                cancel = false;
                _currentTableName = "";
                _totalRowsInCurrentTable = 0;
                _totalRowsInAllTables = 0;
                _currentRowIndexInCurrentTable = 0;
                _currentRowIndexInAllTable = 0;
                _totalTables = 0;
                _currentTableIndex = 0;
                conn = new MySqlConnection(connection);
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 0;
                conn.Open();
                timer1.Start();
                mb.ExportInfo.IntervalForProgressReport = 5;
                mb.ExportInfo.GetTotalRowsBeforeExport = false;
                mb.ExportInfo.AddCreateDatabase = CheckBox_database.Checked;
                mb.ExportInfo.ExportProcedures = CheckBox_view.Checked;
                mb.ExportInfo.ExportTriggers = CheckBox_view.Checked;
                mb.ExportInfo.ExportEvents = CheckBox_view.Checked;
                mb.ExportInfo.ExportViews = CheckBox_view.Checked;
                if (CheckBox_struktur.Checked)
                {
                    mb.ExportInfo.ExportRows = false;
                }
                else
                {
                    mb.ExportInfo.ExportRows = true;
                }
                mb.ExportInfo.RowsExportMode = RowsDataExportMode.InsertIgnore;
                List<string> list = new List<string>();
                int a = ListTabel.CheckedItems.Count - 1;
                for (int i = 0; i <= a; i++)
                {
                    list.Add(ListTabel.CheckedItems[i].ToString());
                }
                if (rInclude.Checked == true)
                {
                    mb.ExportInfo.TablesToBeExportedList = list;
                }
                else
                {
                    mb.ExportInfo.ExcludeTables = list;
                }
                mb.Command = cmd;
                bwExport.RunWorkerAsync();
                stopwatch.Reset();
                stopwatch.Start();
                MyTimer.Start();
                btnBackup.Enabled = false;
                btnCancel.Enabled = true;
            }
        }

        void bwExport_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                mb.ExportToFile(dumpFile);
            }
            catch (Exception ex)
            {
                cancel = true;
                CloseConnection();
                frmMsgBox.Show(ex.ToString());
            }
        }

        void mb_ExportProgressChanged(object sender, ExportProgressArgs e)
        {
            if (cancel)
            {
                // Calling mb to halt
                mb.StopAllProcess();
                return;
            }

            _currentRowIndexInAllTable = (int)e.CurrentRowIndexInAllTables;
            _currentRowIndexInCurrentTable = (int)e.CurrentRowIndexInCurrentTable;
            _currentTableIndex = e.CurrentTableIndex;
            _currentTableName = e.CurrentTableName;
            _totalRowsInAllTables = (int)e.TotalRowsInAllTables;
            _totalRowsInCurrentTable = (int)e.TotalRowsInCurrentTable;
            _totalTables = e.TotalTables;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (cancel)
            {
                timer1.Stop();
                return;
            }
            groupProgress.Title = _currentTableIndex + " of " + _totalTables + " Backup Tabel : " + _currentTableName;
            double str = Math.Round(((double)_currentTableIndex / (double)_totalTables * 100));
            try
            {
                pgBar1.Value = int.Parse(str.ToString());
            }
            catch (Exception)
            {

            }
        }

        void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }

            if (cmd != null)
                cmd.Dispose();
        }

        void bwExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseConnection();
            if (cancel)
            {
                MyTimer.Stop();
                stopwatch.Stop();
                frmMsgBox.Show("Cancel by user.");
            }
            else
            {
                if (mb.LastError == null)
                {
                    /*
                    pbRowInAllTable.Value = pbRowInAllTable.Maximum;
                    pbRowInCurTable.Value = pbRowInCurTable.Maximum;
                    pbTable.Value = pbTable.Maximum;
                    */
                    MyTimer.Stop();
                    stopwatch.Stop();
                    this.Refresh();
                    btnBackup.Enabled = true;
                    btnCancel.Enabled = false;
                    frmMsgBox.Show("BACKUP DATABASE " + comboDatabase1.SelectedItem.ToString() + " SELESAI \n\r" + stopwatch.Elapsed.Hours + " Jam " + stopwatch.Elapsed.Minutes + " Menit " + stopwatch.Elapsed.Seconds + " Second");
                }
                else
                    frmMsgBox.Show("Completed with error(s)." + Environment.NewLine + Environment.NewLine + mb.LastError.ToString());
            }
            timer1.Stop();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            groupProgress.SubTitle = String.Format("Waktu : {0} ", stopwatch.Elapsed.ToString().Substring(0, 8));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel = true;
        }
    }
}
