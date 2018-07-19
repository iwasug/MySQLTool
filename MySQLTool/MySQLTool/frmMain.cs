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
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MySQLTool
{
    public partial class frmMain : Form
    {
        clsFungsi Fungsi = new clsFungsi();
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlBackup mb;
        Timer timer1;
        Timer timer2;
        BackgroundWorker bwExport;
        BackgroundWorker bwImport;
        string _currentTableName = "";
        long _totalRowsInCurrentTable = 0;
        long _totalRowsInAllTables = 0;
        long _currentRowIndexInCurrentTable = 0;
        long _currentRowIndexInAllTable = 0;
        long _totalTables = 0;
        long _currentTableIndex = 0;
        string dumpFile = "";
        Stopwatch stopwatch = new Stopwatch();
        long curBytes;
        long totalBytes;
        bool cancel = false;
        private string VersiMySQL = "";
        private string toko = "KDTK";
        public frmMain()
        {
            InitializeComponent();
            nsTheme1.Text = Fungsi.versi2;
            lblVersi.Value1 = Fungsi.versi.Substring(0, 9);
            lblVersi.Value2 = Fungsi.versi.Substring(9);
            this.Icon = MySQLTool.Properties.Resources.MySQL_icon;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if(lblFile.Text != "File...")
            {
                mb = new MySqlBackup();
                mb.ImportProgressChanged += mb_ImportProgressChanged;
                timer2 = new Timer();
                timer2.Interval = 50;
                timer2.Tick += timer2_Tick;
                bwImport = new BackgroundWorker();
                bwImport.DoWork += bwImport_DoWork;
                bwImport.RunWorkerCompleted += bwImport_RunWorkerCompleted;
                curBytes = 0;
                totalBytes = 0;
                cancel = false;
                Set_max_allowed_packet();
                string connection = Fungsi.GetServer(comboDatabase2.SelectedItem.ToString());
                conn = new MySqlConnection(connection);
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 0;
                conn.Open();
                timer2.Start();
                mb.Command = cmd;
                bwImport.RunWorkerAsync();
                stopwatch.Reset();
                stopwatch.Start();
                MyTimer.Start();
                btnCancelRestore.Enabled = true;
                btnRestore.Enabled = false;
            }
            else
            {
                frmMsgBox.Show("FILE BELUM DI PILIH");
            }
            
        }

        void bwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                mb.ImportFromFile(dumpFile);
            }
            catch (Exception ex)
            {
                frmMsgBox.Show(ex.ToString());
                cancel = true;
            }
        }

        void mb_ImportProgressChanged(object sender, ImportProgressArgs e)
        {
            if (cancel)
                mb.StopAllProcess();

            totalBytes = (long)e.TotalBytes;
            curBytes = (long)e.CurrentBytes;
        }

        void bwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer2.Stop();
            CloseConnection();
            if (cancel)
            {
                frmMsgBox.Show("Cancel by user.");
            }
            else
            {
                if (mb.LastError == null)
                {
                    MyTimer.Stop();
                    stopwatch.Stop();
                    this.Refresh();
                    btnRestore.Enabled = true;
                    btnCancelRestore.Enabled = false;
                    Fungsi.Log(toko.Substring(0, 4), toko, "RESORE", lblSizeIbdata.Value1 + lblSizeIbdata.Value2, lblSizeBinlog.Value1 + lblSizeBinlog.Value2, stopwatch.Elapsed.ToString().Substring(0, 8), comboDatabase2.SelectedItem.ToString());
                    if (Fungsi.IsToko)
                    {
                        Fungsi.HapusBinlog();
                    }
                    lblFile.Text = "File...";
                    frmMsgBox.Show("RESTORE DATABASE " + comboDatabase2.SelectedItem.ToString() + " SELESAI \n\r" + stopwatch.Elapsed.Hours + " Jam " + stopwatch.Elapsed.Minutes + " Menit " + stopwatch.Elapsed.Seconds + " Second");
                }
                else
                {
                    //MessageBox.Show("Completed with error(s)." + Environment.NewLine + Environment.NewLine + mb.LastError.ToString());
                }
                    
            }
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            if (cancel)
            {
                timer2.Stop();
                return;
            }
            double str = Math.Round(((double)curBytes / (double)totalBytes * 100));
            try
            {
                pgBar1.Value = int.Parse(str.ToString());
            }
            catch (Exception)
            {

            }
            GetIBData();
            groupProgress.Title = ToKB(curBytes) + " of " + ToKB(totalBytes);
        }

        private void GetToko()
        {
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("pos")))
            {
                try
                {
                    db.Open();
                    string sql = "SELECT CONCAT(TOKO,'-',left(NAMA,20)) FROM TOKO;";
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    toko = cmd.ExecuteScalar().ToString();
                    if(toko == "")
                    {
                        toko = "KDTK";
                    }
                    groupInfo.Title = toko;
                    sql = "SELECT ALMT FROM TOKO;";
                    cmd = new MySqlCommand(sql, db);
                    //lblAlamat.Text = cmd.ExecuteScalar().ToString();
                    //lblAlamat.Refresh();
                    groupInfo.SubTitle = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    //frmMsgBox.Show("GAGAL AMBIL TOKO \n\r" + ex.Message);
                    toko = "KDTK";
                }
            }
        }

        private void TambahTabel()
        {
            try
            {
                string KDTK = toko.Substring(0, 4).ToLower();
                var now = DateTime.Now;
                var first = new DateTime(now.Year, now.Month, 1);
                var last = now.AddDays(-1);
                //File T
                Fungsi.POS.Add(KDTK + DateTime.Now.AddMonths(-1).ToString("yyMM"));
                Fungsi.POS.Add("lawas" + DateTime.Now.AddMonths(-1).ToString("yyMM"));
                Fungsi.POS.Add("mstr" + DateTime.Now.AddMonths(-1).ToString("yyMM"));
                Fungsi.POS.Add("prod" + DateTime.Now.AddMonths(-1).ToString("yyMM"));
                Fungsi.POS.Add("stmas" + DateTime.Now.AddMonths(-1).ToString("yyMM"));
                Fungsi.POS.Add("trh" + DateTime.Now.AddMonths(-1).ToString("yyMM"));
                Fungsi.POS.Add("trh" + DateTime.Now.ToString("yyMM"));
                Fungsi.POS.Add("ist" + DateTime.Now.ToString("yyMM"));
                Fungsi.POS.Add("ist" + DateTime.Now.AddMonths(-1).ToString("yyMM"));
                //SB BULAN KEMARIN
                Fungsi.POS.Add("sb" + DateTime.Now.AddMonths(-1).ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sbe" + DateTime.Now.AddMonths(-1).ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sbd" + DateTime.Now.AddMonths(-1).ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sbde" + DateTime.Now.AddMonths(-1).ToString("yyMM") + KDTK.Substring(0, 1));

                //SOAT
                Fungsi.POS.Add("oa" + KDTK + "1711");
                Fungsi.POS.Add("soal" + KDTK);
                Fungsi.POS.Add("soat" + KDTK);

                //SN
                Fungsi.POS.Add("sn1611" + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sn1611" + KDTK.Substring(0, 1) + "_listbpb_plu");
                Fungsi.POS.Add("sn1611" + KDTK.Substring(0, 1) + "_tempdraft");
                Fungsi.POS.Add("snd1611" + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sne1611" + KDTK.Substring(0, 1));
                Fungsi.POS.Add("snde1611" + KDTK.Substring(0, 1));
                //SB BULAN SEKARANG
                Fungsi.POS.Add("sb" + DateTime.Now.ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sbe" + DateTime.Now.ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sbd" + DateTime.Now.ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("sbde" + DateTime.Now.ToString("yyMM") + KDTK.Substring(0, 1));
                //dtslh3
                Fungsi.POS.Add("dtslh" + DateTime.Now.ToString("MM").Substring(1, 1));
                Fungsi.POS.Add("dtslh" + DateTime.Now.AddMonths(-1).ToString("MM").Substring(1, 1));
                Fungsi.POS.Add("dtslh" + DateTime.Now.AddMonths(-2).ToString("MM").Substring(1, 1));
                //
                Fungsi.POS.Add("ret" + DateTime.Now.AddMonths(-1).ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("rkl" + DateTime.Now.AddMonths(-1).ToString("yyMM") + KDTK.Substring(0, 1));
                Fungsi.POS.Add("bkl" + DateTime.Now.AddMonths(-1).ToString("yyMM") + KDTK.Substring(0, 1));
                for (DateTime x = first; x <= last; x = x.AddDays(1))
                {
                    Fungsi.POS.Add("wtg" + x.ToString("MMdd"));
                    Fungsi.POS.Add("bag" + x.ToString("MMdd"));
                    Fungsi.POS.Add("sl" + x.ToString("yyMMdd"));
                    Fungsi.POS.Add("slp" + x.ToString("MMdd") + KDTK);
                    Fungsi.POS.Add("pkm" + x.ToString("MMdd") + KDTK);
                }
            }
            catch (Exception ex)
            {
                //frmMsgBox.Show("ERROR \n\r" + ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void GetIBData()
        {
            long ibd = 0;
            try
            {
                string IBData = @"D:\MySQLDataFiles\ibdata1";
                string IBData2 = @"D:\MySQL Data Files\ibdata1";
                if(File.Exists(IBData2))
                {
                    ibd = new FileInfo(IBData2).Length;
                }
                else
                {
                    ibd = new FileInfo(IBData).Length;
                }
                
            }
            catch (Exception)
            {

            }
            lblSizeIbdata.Value1 = "Size IBDATA : ";
            lblSizeIbdata.Value2 = ToKB(ibd);

        }

        private void hapus_tabel()
        {
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer(comboDatabase1.SelectedItem.ToString())))
            {
                db.Open();
                string sql = "";
                foreach (string Delete in Fungsi.HAPUS)
                {
                    try
                    {
                        sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + comboDatabase1.SelectedItem.ToString() + "' AND TABLE_NAME='" + Delete.ToLower().Trim() + "';";
                        MySqlCommand cmd = new MySqlCommand(sql, db);
                        if (cmd.ExecuteScalar().ToString() == "1")
                        {
                            sql = "truncate table " + Delete.Trim() + ";";
                            cmd = new MySqlCommand(sql, db);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        frmMsgBox.Show("ERROR \n\r" + ex.Message);
                    }
                }
            }
        }

        private void CekListTabel(string Schema)
        {
            List<string> ListTBL = new List<string>();
            List<string> BCK = new List<string>();
            //Fungsi.TO_BACKUP.li
            if (Schema == "POS")
            {
                ListTBL = Fungsi.POS;
            }
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("mysql")))
            {
                try
                {
                    db.Open();
                    string sql = "";
                    foreach (string Tabel in ListTBL)
                    {
                        string KDTK = toko.Substring(0, 4);
                        string KDTK3 = toko.Substring(1, 3);
                        string KDTK1 = toko.Substring(0, 1);
                        toko.Replace("[KDTK]", KDTK).Replace("[3KDTK]", KDTK3).Replace("[1KDTK]", KDTK1).ToLower();
                        sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '" + Schema + "' AND TABLE_NAME='" + Tabel.Trim() + "' AND TABLE_TYPE='BASE TABLE';";
                        MySqlCommand cmd = new MySqlCommand(sql, db);
                        if (cmd.ExecuteScalar().ToString() != "0")
                        {
                            BCK.Add(Tabel.Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    Fungsi.TO_BACKUP = BCK;
                    var json = JsonConvert.SerializeObject(BCK);
                    string P = AppDomain.CurrentDomain.BaseDirectory + "\\MySQLTool2Backup.json";
                    try
                    {
                        using (StreamWriter Sp = new StreamWriter(P, false))
                        {
                            Sp.WriteLine(json);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void Set_max_allowed_packet()
        {
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("mysql")))
            {
                try
                {
                    db.Open();
                    string sql = "SET GLOBAL MAX_ALLOWED_PACKET=1024*1024*1024;";
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    frmMsgBox.Show("SET max_allowed_packet A \n\r" + ex.Message);
                }
            }
        }

        private void GetInfoMySQL()
        {
            using (MySqlConnection db = new MySqlConnection(Fungsi.GetServer("mysql")))
            {
                try
                {
                    db.Open();
                    string sql = "SHOW VARIABLES WHERE VARIABLE_NAME='VERSION';";
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lblVersiMySQL.Value1 = "MySQL v.";
                            lblVersiMySQL.Value2 = dr["value"].ToString().Substring(0, 6);
                            VersiMySQL = dr["value"].ToString().Substring(0, 6);
                        }
                    }
                    sql = "SHOW BINARY LOGS;";
                    cmd = new MySqlCommand(sql, db);
                    long binlog = 0;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            binlog += long.Parse(dr["File_size"].ToString());
                        }
                        lblSizeBinlog.Value1 = "Size Binlog : ";
                        lblSizeBinlog.Value2 = ToKB(binlog);
                    }

                    /*
                    cmd = new MySqlCommand(sql, db);
                    lblAlamat.Text = cmd.ExecuteScalar().ToString();
                    lblAlamat.Refresh();
                    */
                }
                catch (Exception)
                {
                    //frmMsgBox.Show("KONEKSI GAGAL \n\r" + ex.Message);
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
                    comboDatabase2.Items.Clear();
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
                                comboDatabase2.Items.Add(dr["Database"].ToString().ToUpper());
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

        private string ToKB(long bytes)
        {
            string[] suffix = new string[] { "B", "KB", "MB", "GB", "TB" };
            float byteNumber = bytes;
            for (int i = 0; i < suffix.Length; i++)
            {
                if (byteNumber < 1000)
                    if (i == 0)
                        return string.Format("{0} {1}", byteNumber, suffix[i]);
                    else
                        return string.Format("{0:0.#0} {1}", byteNumber, suffix[i]);
                else
                    byteNumber /= 1024;
            }
            return string.Format("{0:N} {1}", byteNumber, suffix[suffix.Length - 1]);
        }

        static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnCancelBackup.Enabled = false;
            btnCancelRestore.Enabled = false;
            if (Fungsi.IsToko)
            {
                GetToko();
                TambahTabel();
            }
            else
            {
                ChkTblPenting.Visible = false;
                groupInfo.Title = "Server MySQL : " + Fungsi.Ip;
                groupInfo.SubTitle = "Server User : " + Fungsi.User + " | Port : " + Fungsi.Port;
            }
            GetInfoMySQL();
            GetIBData();
            Load_Schema();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            groupProgress.SubTitle = String.Format("Waktu : {0} ", stopwatch.Elapsed.ToString().Substring(0, 8));
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "PILIH FOLDER UNTUK BACKUP";
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                if(Fungsi.IsToko)
                {
                    
                }
                UpdateMyIni();
                mb = new MySqlBackup();
                mb.ExportProgressChanged += mb_ExportProgressChanged;
                timer1 = new Timer();
                timer1.Interval = 50;
                timer1.Tick += timer1_Tick;
                bwExport = new BackgroundWorker();
                bwExport.DoWork += bwExport_DoWork;
                bwExport.RunWorkerCompleted += bwExport_RunWorkerCompleted;
                dumpFile = fd.SelectedPath + "\\" + comboDatabase1.SelectedItem.ToString() + ".SQL";
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
                mb.ExportInfo.AddCreateDatabase = true;
                mb.ExportInfo.ExportProcedures = true;
                mb.ExportInfo.ExportTriggers = true;
                mb.ExportInfo.ExportEvents = true;
                if (Fungsi.IsToko)
                {
                    if (comboDatabase1.SelectedItem.ToString() == "POS")
                    {
                        Fungsi.UpdateLatin1();
                        hapus_tabel();
                    }
                }
                if (ChkTblPenting.Checked == true)
                {
                    CekListTabel(comboDatabase1.SelectedItem.ToString().ToUpper());
                    mb.ExportInfo.TablesToBeExportedList = Fungsi.TO_BACKUP;
                }
                if (VersiMySQL.Substring(0, 3) == "5.0")
                {
                    mb.ExportInfo.ExportViews = false;
                }
                else
                {
                    mb.ExportInfo.ExportViews = true;
                }
                if (ChkStruktur.Checked == true)
                {
                    mb.ExportInfo.ExportRows = false;
                }
                else
                {
                    mb.ExportInfo.ExportRows = true;
                }
                mb.Command = cmd;
                bwExport.RunWorkerAsync();
                stopwatch.Reset();
                stopwatch.Start();
                btnBackup.Enabled = true;
                MyTimer.Start();
                btnCancelBackup.Enabled = true;
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

            _currentRowIndexInAllTable = (long)e.CurrentRowIndexInAllTables;
            _currentRowIndexInCurrentTable = (long)e.CurrentRowIndexInCurrentTable;
            _currentTableIndex = e.CurrentTableIndex;
            _currentTableName = e.CurrentTableName;
            _totalRowsInAllTables = (long)e.TotalRowsInAllTables;
            _totalRowsInCurrentTable = (long)e.TotalRowsInCurrentTable;
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
                    MyTimer.Stop();
                    stopwatch.Stop();
                    this.Refresh();
                    btnBackup.Enabled = true;
                    btnCancelBackup.Enabled = false;
                    if (Fungsi.IsToko)
                    {
                        Fungsi.UpdateLatin1();
                    }
                    Fungsi.Log(toko.Substring(0, 4), toko, "BACKUP", lblSizeIbdata.Value1 + lblSizeIbdata.Value2, lblSizeBinlog.Value1 + lblSizeBinlog.Value2, stopwatch.Elapsed.ToString().Substring(0, 8), comboDatabase1.SelectedItem.ToString());
                    frmMsgBox.Show("BACKUP DATABASE " + comboDatabase1.SelectedItem.ToString() + " SELESAI \n\r" + stopwatch.Elapsed.Hours + " Jam " + stopwatch.Elapsed.Minutes + " Menit " + stopwatch.Elapsed.Seconds + " Second");
                }
                else
                {
                    //frmMsgBox.Show("Completed with error(s)." + Environment.NewLine + Environment.NewLine + mb.LastError.ToString());
                }
            }
            timer1.Stop();
        }

        private void btnPilihFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "MySqlBackUp Files (*.SQL)|*.SQL";
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                dumpFile = fd.FileName;
                lblFile.Text = fd.FileName;
                lblFile.Refresh();
                comboDatabase2.SelectedItem = fd.SafeFileName.Remove(fd.SafeFileName.Length - 4);
            }
        }

        private void btnUtilMaintenance_Click(object sender, EventArgs e)
        {
            frmMaintenance frm = new frmMaintenance();
            frm.ShowDialog();
        }

        private void btnUtilCheck_Click(object sender, EventArgs e)
        {
            frmRepair frm = new frmRepair();
            frm.ShowDialog();
        }

        private void btnUtilCustomBackup_Click(object sender, EventArgs e)
        {
            frmCustomBackup frm = new frmCustomBackup();
            frm.ShowDialog();
        }

        private void btnCancelBackup_Click(object sender, EventArgs e)
        {
            cancel = true;
        }

        private void btnCancelRestore_Click(object sender, EventArgs e)
        {
            cancel = true;
        }

        private void btnUtilListTabel_Click(object sender, EventArgs e)
        {
            frmListTabel frm = new frmListTabel();
            frm.ShowDialog();
        }


        private void UpdateMyIni()
        {
            string MyIni = @"c:\Program Files\indomaret\Mysql For Pos.Net\my.ini";
            if (File.Exists(MyIni))
            {
                string fileContent = File.ReadAllText(MyIni);
                bool present = fileContent.IndexOf("innodb_file_per_table") >= 0;
                string[] fileMyIni = File.ReadAllLines(MyIni);
                if (!present)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (string ini in fileMyIni)
                        {
                            if (ini.ToUpper().StartsWith("INNODB_THREAD_CONCURRENCY"))
                            {
                                sb.Append(ini);
                                sb.AppendLine();
                                sb.Append("innodb_file_per_table=1");
                                sb.AppendLine();
                            }
                            else
                            {
                                sb.Append(ini);
                                sb.AppendLine();
                            }
                        }
                        File.WriteAllText(MyIni, sb.ToString());
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private string RAM
        {
            get
            {
                string ram = "";
                try
                {
                    ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject item in moc)
                    {
                        ram = Convert.ToString(Math.Round(Convert.ToDouble(item.Properties["TotalPhysicalMemory"].Value) / 1073741824));
                    }
                }
                catch (Exception)
                {
                }
                return ram;
            }
        }

    }
}
