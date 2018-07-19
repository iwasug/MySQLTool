/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using MySQLToolWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySQLToolWeb.Controllers
{
    public class ReportController : Controller
    {
        private ModelData _DB = new ModelData();
        private clsFungsi Fungsi = new clsFungsi();
        private string SQL = "";
        // GET: Report
        public ActionResult Binlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BinlogList()
        {
            int page = int.Parse(Request.Form["page"]);
            int rp = int.Parse(Request.Form["rp"]);
            string qtype = Request.Form["qtype"].ToString();
            string query = Request.Form["query"].ToString();
            string sortname = Request.Form["sortname"].ToString();
            string sortorder = Request.Form["sortorder"].ToString();
            string TABLE = "vwbinlog";
            string SORT = "";
            string WHERE = "";
            int START = ((page - 1) * rp);
            string LIMIT = "LIMIT " + START + ", " + rp + " ";
            if (!string.IsNullOrEmpty(sortname) && !string.IsNullOrEmpty(sortorder))
            {
                SORT = "ORDER BY " + sortname + " " + sortorder;
            }
            if (!string.IsNullOrEmpty(qtype) && !string.IsNullOrEmpty(query))
            {
                WHERE = " WHERE RECID !='1' AND " + qtype + " LIKE '%" + query + "%' ";
            }
            SQL = "SELECT * FROM " + TABLE + " " + WHERE + "  " + SORT + " " + LIMIT;
            var DBList = _DB.Database.SqlQuery<vw_data>(SQL).ToList();
            SQL = "SELECT * FROM " + TABLE + ";";
            var Count = _DB.Database.SqlQuery<vw_data>(SQL).ToList();
            var flexgrid = new
            {
                page = page,
                total = Count.Count(),
                rows = DBList
                .Select(x => new
                {
                    id = x.TOKO,
                    cell = new { x.NAMA, x.TOKO, x.GB }
                }
                )

            };
            return Json(flexgrid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IBData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IBDataList()
        {
            int page = int.Parse(Request.Form["page"]);
            int rp = int.Parse(Request.Form["rp"]);
            string qtype = Request.Form["qtype"].ToString();
            string query = Request.Form["query"].ToString();
            string sortname = Request.Form["sortname"].ToString();
            string sortorder = Request.Form["sortorder"].ToString();
            string TABLE = "vwibdata";
            string SORT = "";
            string WHERE = "";
            int START = ((page - 1) * rp);
            string LIMIT = "LIMIT " + START + ", " + rp + " ";
            if (!string.IsNullOrEmpty(sortname) && !string.IsNullOrEmpty(sortorder))
            {
                SORT = "ORDER BY " + sortname + " " + sortorder;
            }
            if (!string.IsNullOrEmpty(qtype) && !string.IsNullOrEmpty(query))
            {
                WHERE = " WHERE RECID !='1' AND " + qtype + " LIKE '%" + query + "%' ";
            }
            SQL = "SELECT * FROM " + TABLE + " " + WHERE + "  " + SORT + " " + LIMIT;
            var DBList = _DB.Database.SqlQuery<vw_data>(SQL).ToList();
            SQL = "SELECT * FROM " + TABLE + ";";
            var Count = _DB.Database.SqlQuery<vw_data>(SQL).ToList();
            var flexgrid = new
            {
                page = page,
                total = Count.Count(),
                rows = DBList
                .Select(x => new
                {
                    id = x.TOKO,
                    cell = new { x.NAMA, x.TOKO,x.GB }
                }
                )

            };
            return Json(flexgrid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogBackup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogBackupList()
        {
            int page = int.Parse(Request.Form["page"]);
            int rp = int.Parse(Request.Form["rp"]);
            string qtype = Request.Form["qtype"].ToString();
            string query = Request.Form["query"].ToString();
            string sortname = Request.Form["sortname"].ToString();
            string sortorder = Request.Form["sortorder"].ToString();
            string TABLE = "tb_log";
            string SORT = "";
            string WHERE = "";
            int START = ((page - 1) * rp);
            string LIMIT = "LIMIT " + START + ", " + rp + " ";
            if (!string.IsNullOrEmpty(sortname) && !string.IsNullOrEmpty(sortorder))
            {
                SORT = "ORDER BY " + sortname + " " + sortorder;
            }
            if (!string.IsNullOrEmpty(qtype) && !string.IsNullOrEmpty(query))
            {
                WHERE = " WHERE RECID !='1' AND " + qtype + " LIKE '%" + query + "%' ";
            }
            SQL = "SELECT * FROM " + TABLE + " " + WHERE + "  " + SORT + " " + LIMIT;
            var s = SQL;
            var DBList = _DB.Database.SqlQuery<tb_log>(SQL).ToList();
            SQL = "SELECT * FROM " + TABLE + ";";
            var Count = _DB.Database.SqlQuery<tb_log>(SQL).ToList();
            var flexgrid = new
            {
                page = page,
                o = s,
                total = Count.Count(),
                rows = DBList
                .Select(x => new
                {
                    ////TOKO, NAMA, JENIS, IBDATA, BINLOG, TANGGAL, WAKTU, SCHEMA
                    id = x.TOKO,
                    cell = new { x.NAMA, x.TOKO, x.JENIS,x.IBDATA,x.BINLOG,x.TANGGAL,x.WAKTU,x.SCHEMA }
                }
                )

            };
            return Json(flexgrid, JsonRequestBehavior.AllowGet);
        }
    }
}