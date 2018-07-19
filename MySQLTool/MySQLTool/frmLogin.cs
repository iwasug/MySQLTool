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
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace MySQLTool
{
    public partial class frmLogin : Form
    {
        clsFungsi Fungsi = new clsFungsi();
        private string sql = "";
        public frmLogin()
        {
            InitializeComponent();
            nsTheme1.Text = Fungsi.versi2;
            lblVersi.Value1 = Fungsi.versi.Substring(0,9);
            lblVersi.Value2 = Fungsi.versi.Substring(9);
            this.Icon = MySQLTool.Properties.Resources.MySQL_icon;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            Fungsi.Ip = txtIp.Text.Trim();
            Fungsi.User = txtUser.Text.Trim();
            Fungsi.Port = txtPort.Text.Trim();
            Fungsi.Pass = txtPass.Text.Trim();
            txtPass.Text = txtPass.Text.Trim();
            if(Fungsi.IsToko)
            {
                Fungsi.Pass = Fungsi.GetVersi(Fungsi.User);
            }
            string server = Fungsi.GetServer("mysql");
            DataTable dt = new DataTable();
            try
            {
                //MessageBox.Show(server);
                using (MySqlConnection db = new MySqlConnection(server))
                {
                    db.Open();
                    sql = "show databases where `database` IN('POS','DBL','SOPPAGENT');";
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count == 3)
                    {
                        Fungsi.IsToko = true;
                    }
                    else
                    {
                        Fungsi.IsToko = false;
                    }
                }
                //MessageBox.Show("KONEKSI OK");
                frmMain Main = new frmMain();
                Main.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                frmMsgBox.Show("KONEKSI GAGAL \n\r" + ex.ToString());
            }
        }


        private void ChkToko_CheckedChanged(object sender)
        {
            if (ChkToko.Checked == true)
            {
                txtUser.Text = "root";
                txtPort.Text = "3306";
                Fungsi.IsToko = true;
            }
            else
            {
                Fungsi.IsToko = false;
            }
        }

        private void GetSetting()
        {
            if (Fungsi.ping("192.168.17.217"))
            {

                //string Penting = Fungsi.GetData("http://192.168.17.217:1945/master/GetTabelPenting").Trim();
                //string Hapus = Fungsi.GetData("http://192.168.17.217:1945/master/GetTabelHapus").Trim();
                string Tabel = Fungsi.GetData("http://192.168.17.217:1945/master/GetTabel").Trim();
                if (Tabel.ToUpper().Substring(0, 4) != "ERRO")
                {
                    string P = AppDomain.CurrentDomain.BaseDirectory + "\\MySQLTool.json";
                    //string H = AppDomain.CurrentDomain.BaseDirectory + "\\Hapus.ini";
                    try
                    {
                        using (StreamWriter Sp = new StreamWriter(P, false))
                        {
                            Sp.WriteLine(Tabel);
                        }
                    }
                    catch
                    {

                    }
                }
            }
            string P1 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\MySQLTool.json");
            JObject o = JObject.Parse(P1);
            //MessageBox.Show(o["hapus"].ToString());
            //var jarray = JsonConvert.DeserializeObject<List<string>>(o["hapus"].ToString());
            Fungsi.HAPUS = JsonConvert.DeserializeObject<List<string>>(o["hapus"].ToString());
            Fungsi.POS = JsonConvert.DeserializeObject<List<string>>(o["penting"].ToString());
            //MessageBox.Show(Fungsi.POS.Count.ToString());
            //JsonSchema schema1 = JsonSchema.Parse(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Tabel.json"));
            //MessageBox.Show(P1);
            //Tabel m = JsonConvert.DeserializeObject<Tabel>(P1);
            //MessageBox.Show(m.penting[0]);
            //string H1 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Hapus.ini");
            //Fungsi.POS = new List<string>(P1.ToLower().Split('|'));
            //Fungsi.HAPUS = new List<string>(H1.ToLower().Split('|'));

        }

        WebClient webClient = new WebClient();
        private string FL = "";
        private void Download(string file)
        {
            FL = file;
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("http://192.168.17.217:1945/FILE/" + file), AppDomain.CurrentDomain.BaseDirectory + "\\" + file);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pgBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (Rename("MySQLTool.exe"))
            {
                if (Fungsi.UnzipFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + FL, AppDomain.CurrentDomain.BaseDirectory))
                {
                    Restart();
                }
                Restart();
            }
        }

        private void Restart()
        {
            try
            {
                StringBuilder rd = new StringBuilder();
                rd.Append(@"@ECHO OFF");
                rd.Append("\r\n");
                rd.Append("Taskkill /f /im MySQLTool.exe");
                rd.Append("\r\n");
                rd.Append("call MySQLTool.exe");
                rd.Append("\r\n");
                rd.Append(@"exit");
                rd.Append("\r\n");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Restart.bat", rd.ToString());
                Process proc = new Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "\\Restart.bat";
                proc.Start();
                proc.Close();
            }
            catch (Exception)
            {
                //tracelog("PROSES RUN CMD", err.ToString());
            }
        }

        private bool Rename(string file)
        {
            int a = 1;
            ulangCopy:
            a += 1;
            try
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + file))
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\" + file + "_UPD"))
                    {
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\" + file + "_UPD");
                    }
                    File.Move(AppDomain.CurrentDomain.BaseDirectory + "\\" + file, AppDomain.CurrentDomain.BaseDirectory + "\\" + file + "_UPD");
                }
                return true;
            }
            catch (Exception)
            {
                if (a <= 20)
                {
                    goto ulangCopy;
                }
                return false;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if(Fungsi.CekUpdate())
            {
                if (Fungsi.ping("192.168.17.217"))
                {
                    string[] versi = Fungsi.GetData("http://192.168.17.217:1945/master/GetVersi").Split('|');
                    if (Fungsi.CekVersi(versi[0]) == "NO")
                    {
                        DialogResult dialogResult = frmMsgBox.Show("ADA VERSI TERBARU V." + versi[0] + " APA MAU DI UPDATE", "");
                        if (dialogResult == DialogResult.OK)
                        {
                            Download(versi[1]);
                        }
                    }
                }
            }

            GetSetting();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login();
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
    }
}
