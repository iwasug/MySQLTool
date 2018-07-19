/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using Ionic.Zip;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MySQLTool
{
    class clsFungsi
    {
        public string versi2 = "Iwa S. EDP Bandung Copyright © 2016";
        public string versi = "MySQLTool v." + Assembly.GetEntryAssembly().GetName().Version.ToString();
        private static List<string> _POS;
        private static List<string> _HAPUS;
        private static List<string> _TO_BACKUP;
        public List<string> POS
        {
            set { _POS = value; }
            get { return _POS; }
        }
        public List<string> HAPUS
        {
            set { _HAPUS = value; }
            get { return _HAPUS; }
        }
        /*
        public List<string> POS = new List<string>(ConfigurationManager.AppSettings["POS"].ToLower().Split('|'));
        public List<string> HAPUS = new List<string>(ConfigurationManager.AppSettings["HAPUS"].ToLower().Split('|'));
        */
        public List<string> TO_BACKUP
        {
            set { _TO_BACKUP = value; }
            get { return _TO_BACKUP; }
        }
        /*
        public string[] DBL = ConfigurationManager.AppSettings["DBL"].Split('|');
        public string[] SOPPAGENT = ConfigurationManager.AppSettings["SOPPAGENT"].Split('|');
        public string[] HAPUS = ConfigurationManager.AppSettings["HAPUS"].Split('|');
        */
        private string GenerateMD5(string SourceText)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(SourceText);
            byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
            mD5CryptoServiceProvider.Clear();
            int a = 0;
            checked
            {
                int b = array.Length - 1;
                string text = "";
                for (int i = a; i <= b; i++)
                {
                    text += array[i].ToString("x").PadLeft(2, '0');
                }
                return text;
            }
        }

        private string Decrypt(string cipherText, string passPhrase, string saltValue)
        {
            string strHashName = "SHA1";
            int iterations = 2;
            string s = "@1B2c3D4e5F6g7H8";
            int num = 256;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            byte[] bytes2 = Encoding.ASCII.GetBytes(saltValue);
            byte[] array = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, bytes2, strHashName, iterations);
            checked
            {
                byte[] bytes3 = passwordDeriveBytes.GetBytes((int)Math.Round((double)num / 8.0));
                ICryptoTransform transform = new RijndaelManaged
                {
                    Mode = CipherMode.CBC
                }.CreateDecryptor(bytes3, bytes);
                MemoryStream memoryStream = new MemoryStream(array);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
                byte[] array2 = new byte[array.Length + 1];
                int count = cryptoStream.Read(array2, 0, array2.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(array2, 0, count);
            }
        }

        private string Encrypt(string plainText, string passPhrase, string saltValue)
        {
            string strHashName = "SHA1";
            int iterations = 2;
            string s = "@1B2c3D4e5F6g7H8";
            int num = 256;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            byte[] bytes2 = Encoding.ASCII.GetBytes(saltValue);
            byte[] bytes3 = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, bytes2, strHashName, iterations);
            byte[] bytes4 = passwordDeriveBytes.GetBytes(checked((int)Math.Round((double)num / 8.0)));
            ICryptoTransform transform = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            }.CreateEncryptor(bytes4, bytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(bytes3, 0, bytes3.Length);
            cryptoStream.FlushFinalBlock();
            byte[] inArray = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(inArray);
        }

        private string Versi(string Periode, string User)
        {
            string text = Encrypt(User + " : " + DefaultVer(User), DateTime.Parse(Periode).ToString("yyyy-MM-dd"), User);
            text = text.Replace("'", "");
            return text.Substring(10) + text.Substring(0, 10);
        }
        private string DefaultVer(string User)
        {
            string result = "";
            if (User.ToUpper().Trim() == "root".ToUpper().Trim())
            {
                result = this.Decrypt("AYBOzt4YQ4zHbTY2bRiajA==", User, "12345");
            }
            if (User.ToUpper().Trim() == "kasir".ToUpper().Trim())
            {
                result = this.Decrypt("kRUXVE+bgdwh3Ptfbiw9yg==", User, "12345");
            }
            if (User.ToUpper().Trim() == "app".ToUpper().Trim())
            {
                result = this.Decrypt("hEUSKSjtKQ8dgPIwNIU2Dg==", User, "12345");
            }
            if (User.ToUpper().Trim() == "edp".ToUpper().Trim())
            {
                result = this.Decrypt("21TRmBPTF5Vs2b3mM6FnrA==", User, "12345");
            }
            if (User.ToUpper().Trim() == "dbe".ToUpper().Trim())
            {
                result = this.Decrypt("hGBKT3Q+fgNe9sE4lU2Osw==", User, "12345");
            }
            return result;
        }

        public string GetVersi(string User)
        {
            string Periode = GetPeriode();
            return Versi(Periode.Substring(0, 4) + "-" + Periode.Substring(4, 2) + "-" + Periode.Substring(6, 2), User.ToLower());
        }

        private string GetPeriode()
        {
            string Periode = "";
            try
            {
                if (File.Exists(@"D:\BACKOFF\IDM.SECTOR.TXT"))
                {
                    Periode = File.ReadAllText(@"D:\BACKOFF\IDM.SECTOR.TXT");
                }
                else if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\IDM.SECTOR.TXT"))
                {
                    Periode = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\IDM.SECTOR.TXT");
                }
                if (Periode.Length != 8)
                {
                    if (File.Exists(@"D:\IDM\IDM.SECTOR.TXT"))
                    {
                        Periode = File.ReadAllText(@"D:\IDM\IDM.SECTOR.TXT");
                    }
                }
            }
            catch (Exception)
            {

            }
            return Periode;
        }

        public string GetServer(string Db)
        {
            return "allow user variables=true;allowzerodatetime=true;Persist Security Info=True;server=" + Ip + ";userid=" + User.ToLower() + ";password=" + Pass + ";database=" + Db + ";port=" + Port + ";pooling=false;";
        }




        private static string _ip;
        public string Ip
        {
            set { _ip = value; }
            get { return _ip; }
        }
        private static string _user;
        public string User
        {
            set { _user = value; }
            get { return _user; }
        }
        private static string _pass;
        public string Pass
        {
            set { _pass = value; }
            get { return _pass; }
        }
        private static string _port;
        public string Port
        {
            set { _port = value; }
            get { return _port; }
        }
        private static bool _istoko;
        public bool IsToko
        {
            set { _istoko = value; }
            get { return _istoko; }
        }

        private CookieContainer _cookieContainer = new CookieContainer();
        public string GetData(string Url)
        {
            int x = 30;
            UlangGET:
            x += 1;
            try
            {
                WebClient proxy = new WebClient();
                byte[] data = proxy.DownloadData(Url);
                Stream stream = new MemoryStream(data);
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (Exception err)
            {
                if (x < 30)
                {
                    Console.WriteLine(err.Message);
                    goto UlangGET;
                }
                return "ERROR " + err.ToString();
            }
        }

        public string PostData(string Url, string Data)
        {
            int x = 30;
            UlangPOST:
            x += 1;
            string ret = string.Empty;
            try
            {
                StreamWriter requestWriter;
                ServicePointManager.Expect100Continue = false;
                var webRequest = WebRequest.Create(Url) as HttpWebRequest;
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.CookieContainer = _cookieContainer;
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.KeepAlive = false;
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(Data);
                    }
                }
                HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                Stream resStream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                ret = reader.ReadToEnd();
            }
            catch (Exception err)
            {
                if (x < 30)
                {
                    Console.WriteLine(err.Message);
                    goto UlangPOST;
                }
                ret = "ERROR " + err.Message;
            }
            return ret;
        }

        public string Log(string TOKO, string NAMA, string JENIS, string IBDATA, string BINLOG, string WAKTU, string SCHEMA)
        {
            string result = "";
            try
            {
                string data = "TOKO=" + TOKO + "&NAMA=" + NAMA + "|"+ Assembly.GetEntryAssembly().GetName().Version.ToString() + "&JENIS=" + JENIS + "&IBDATA=" + IBDATA + "&BINLOG=" + BINLOG + "&WAKTU=" + WAKTU + "&SCHEMA=" + SCHEMA;
                result = PostData("http://192.168.17.217:1945/Master/Log", data);
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            return result;
        }

        public string CekVersi(string versi_server)
        {
            string msg = "NO";
            try
            {
                var version1 = new Version(versi_server);
                var version2 = new Version(Assembly.GetEntryAssembly().GetName().Version.ToString());
                var result = version1.CompareTo(version2);
                if (result > 0)
                {
                    msg = "NO";
                }
                else if (result < 0)
                {
                    msg = "OK";
                }
                else
                {
                    msg = "OK";
                }
            }
            catch (Exception)
            {
                //TracelogPanda("Proses versi", ex.Message.ToString(), "Server");
            }
            return msg;
        }

        public bool CekUpdate()
        {
            if(ConfigurationManager.AppSettings["CEK_UPDATE"].ToUpper() == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ping(string ip)
        {
            bool sts = false;
            int timeout = 1200;
            try
            {
                if (ip == "")
                {
                    sts = false;
                }
                else
                {
                    Ping pingSender = new Ping();
                    PingReply reply = pingSender.Send(ip, timeout);
                    if (reply.Status == IPStatus.Success)
                    {
                        sts = true;
                    }
                    else
                    {
                        sts = false;
                    }
                }
            }
            catch (Exception)
            {

            }
            return sts;
        }
        public bool UnzipFile(string fileZip, string folder)
        {
            try
            {
                using (ZipFile zip1 = ZipFile.Read(fileZip))
                {
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    foreach (ZipEntry e in zip1)
                    {

                        e.Extract(folder, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool HapusBinlog()
        {
            bool sts = false;
            using (MySqlConnection db = new MySqlConnection(GetServer("mysql")))
            {
                try
                {
                    db.Open();
                    string sql = "RESET MASTER;";
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    cmd.ExecuteNonQuery();
                    sts = true;
                }
                catch (Exception ex)
                {
                    //frmMsgBox.Show("ERROR HAPUS BINLOG \n\r" + ex.Message);
                }
            }
            return sts;
        }

        public void UpdateLatin1()
        {
            string sql = "SELECT DISTINCT(TABLE_NAME) AS TABEL FROM information_schema.columns WHERE table_schema='pos' AND data_type LIKE '%char%' AND character_set_name NOT LIKE '%latin1%';";
            DataTable dt = new DataTable();
            using (MySqlConnection db = new MySqlConnection(GetServer("mysql")))
            {
                try
                {
                    db.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, db);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if(dt.Rows.Count != 0)
                    {
                        foreach(DataRow dr in dt.Rows)
                        {
                            sql = "ALTER TABLE pos." + dr["TABEL"].ToString() + " CONVERT TO CHARACTER SET latin1;";
                            cmd = new MySqlCommand(sql, db);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    //frmMsgBox.Show("ERROR LATIN \n\r" + ex.Message);
                }
            }
        }

        public DataTable GETCSVTABLE(string filename, string koma)
        {
            FileInfo file = new FileInfo(filename);
            DataTable tbl = new DataTable();
            try
            {
                if (File.Exists(file.DirectoryName + "//schema.ini"))
                {
                    File.Delete(file.DirectoryName + "//schema.ini");
                }
                using (StreamReader reader = new StreamReader(filename))
                {
                    FileStream fs = new FileStream(file.DirectoryName + "//schema.ini", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("[" + file.Name + "]");
                    sw.WriteLine("Format = Delimited(" + koma + ")");
                    if (file.Name.Substring(0, 2) != "TL")
                    {
                        char K = Char.Parse(koma);
                        string B = reader.ReadLine();
                        string[] A = B.Split(K);
                        //MessageBox.Show(B);
                        int D = 1;
                        foreach (string C in A)
                        {
                            sw.WriteLine("Col" + D.ToString() + "=" + C + " Char Width 100");
                            //MessageBox.Show(C);
                            D += 1;
                        }
                    }
                    else
                    {
                        char K = Char.Parse(koma);
                        string B = reader.ReadLine();
                        string[] A = B.Split(K);
                        //MessageBox.Show(B);
                        int D = 1;
                        foreach (string C in A)
                        {
                            sw.WriteLine("Col" + D.ToString() + "=" + C + " Char Width 100");
                            //MessageBox.Show(C);
                            D += 1;
                        }
                        sw.WriteLine("Col28 = A Char Width 100");
                        sw.WriteLine("Col29 = B Char Width 100");
                        sw.WriteLine("Col30 = C Char Width 100");
                        sw.WriteLine("Col31 = D Char Width 100");
                    }
                    sw.Close();
                }
                if (koma == ",")
                {
                    var fileContents = File.ReadAllText(filename);
                    fileContents = fileContents.Replace("'", "");
                    File.WriteAllText(filename, fileContents);
                }
                using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + file.DirectoryName + "\";Extended Properties =\"Text;HDR=YES;\""))
                {
                    using (OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}]", file.Name), con))
                    {
                        con.Open();
                        using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                        {
                            adp.Fill(tbl);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                //Log(err.ToString());
                frmMsgBox.Show("GET DATATABLE CSV " + err.Message);
                //MessageBox.Show(ERR.Message);
            }
            return tbl;
        }
    }
}
