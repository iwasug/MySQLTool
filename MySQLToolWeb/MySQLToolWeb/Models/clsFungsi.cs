/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MySQLToolWeb.Models
{
    public class clsFungsi
    {
        private static string server = ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString.ToString();
        private ModelData _DB = new ModelData();
        private string SQL = "";
        public string Versi
        {
            get { return "MySQLTools Web v." + Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public string Level
        {
            get { return HttpContext.Current.Session["Level"].ToString(); }
        }

        public string User
        {
            get { return HttpContext.Current.Session["Username"].ToString(); }
        }


        public string KonversiTabel(string path)
        {
            try
            {
                const Int32 BufferSize = 128;
                using (var fileStream = File.OpenRead(path))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        SQL = "INSERT INTO TB_PENTING(NAMA, UPD) VALUES('" + line + "',NOW()) ";
                        SQL += "ON DUPLICATE KEY UPDATE UPD=NOW();";
                        _DB.Database.ExecuteSqlCommand(SQL);
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public MySqlConnection GetKoneksi()
        {
            MySqlConnection db = new MySqlConnection(server);
            return db;
        }
        public string GenerateMD5(string SourceText)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(SourceText);
            byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
            mD5CryptoServiceProvider.Clear();
            int arg_2B_0 = 0;
            checked
            {
                int num = array.Length - 1;
                string text = "";
                for (int i = arg_2B_0; i <= num; i++)
                {
                    text += array[i].ToString("x").PadLeft(2, '0');
                }
                return text;
            }
        }
        public bool IsValid(string _username, string _password)
        {
            bool result = false;
            string pass = GenerateMD5(_password);
            var User = from u in _DB.tb_user where u.USERNAME == _username && u.PASSWORD == pass select u;
            if (User.Count() != 0)
            {
                foreach (var DetailUser in User)
                {
                    HttpContext.Current.Session["Username"] = DetailUser.USERNAME;
                    HttpContext.Current.Session["Nama"] = DetailUser.NAMA;
                    HttpContext.Current.Session["Level"] = DetailUser.LEVEL;
                    HttpContext.Current.Session.Timeout = 120;
                }
                //SQL = "INSERT INTO TB_LOG(IP, WAKTU,COUNTER,USERNAME,NAMA) VALUES ('" + GetUserIP() + "',NOW(),'1','" + _username + "','" + HttpContext.Current.Session["Nama"] + "') ON DUPLICATE KEY UPDATE WAKTU=NOW(),COUNTER=COUNTER+1,USERNAME='" + _username + "',NAMA='" + HttpContext.Current.Session["Nama"] + "'; ";
                //_DB.Database.ExecuteSqlCommand(SQL);
                result = true;
            }
            return result;
        }

        public void Logout()
        {
            HttpContext.Current.Session["Username"] = null;
            HttpContext.Current.Session["Nama"] = null;
            HttpContext.Current.Session["Level"] = null;
        }

        public string GetSetting(string Kode)
        {
            var query = (from a in _DB.tb_setting where a.KODE == Kode select new { a.ISI }).Single();
            return query.ISI;
        }

        public void UpdSetting(string Kode)
        {
            string isi = (GetSetting(Kode) + 1);
            _DB.tb_setting
            .Where(x => Kode.Contains(x.KODE))
            .ToList()
            .ForEach(a => a.ISI = isi);
            _DB.SaveChanges();
        }

        public string[] Bulan = new string[] { "JANUARI", "FEBRUARI", "MARET", "APRIL", "JUNI", "JULI", "AGUSTUS", "SEPTEMBER", "OKTOBER", "NOVEMBER", "DESEMBER" };

        private string GetUserIP()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public string BaseUrl
        {
            get
            {
                string almt = "";
                if (HttpContext.Current.Request.ServerVariables["SERVER_PORT"] == "443")
                {
                    almt = "https://";
                }
                else
                {
                    almt = "http://";
                }
                HttpContext context = HttpContext.Current;
                string baseUrl = context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/');
                return almt + baseUrl;
            }
        }
        public DataSet GetDataSet(string SQL, string TBL)
        {
            MySqlConnection db = GetKoneksi();
            DataSet DataSet = new DataSet();
            try
            {
                db.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(SQL, db);
                adp.Fill(DataSet, TBL);
            }
            catch (Exception exx)
            {
                //Tracelog("PROSES GET DATASET", exx.Message);
            }
            finally
            {
                db.Close();
            }
            return DataSet;
        }

        public DataTable GetDataTable(string SQL)
        {
            MySqlConnection db = GetKoneksi();
            DataTable DataSet = new DataTable();
            try
            {
                db.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(SQL, db);
                adp.Fill(DataSet);
            }
            catch (Exception exx)
            {
                //Tracelog("PROSES GET DATATABLE", exx.Message);
            }
            finally
            {
                db.Close();
            }
            return DataSet;
        }
    }
}