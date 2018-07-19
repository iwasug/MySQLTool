/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using MySQLToolWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

namespace MySQLToolWeb.Controllers
{
    public class HomeController : Controller
    {
        private ModelData _DB = new ModelData();
        private clsFungsi Fungsi = new clsFungsi();
        private string SQL = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Versi = Fungsi.Versi;
            return View();
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult Login(tb_user user)
        {
            Thread.Sleep(2000);
            string sts = "GAGAL";
            if (!string.IsNullOrEmpty(user.USERNAME) || !string.IsNullOrEmpty(user.PASSWORD))
            {
                if (Fungsi.IsValid(user.USERNAME, user.PASSWORD))
                {
                    sts = "OK";
                }
                else
                {
                    sts = "GAGAL";
                }
            }
            return Json(new { status = sts });
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            Fungsi.Logout();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserList()
        {
            int page = int.Parse(Request.Form["page"]);
            int rp = int.Parse(Request.Form["rp"]);
            string qtype = Request.Form["qtype"].ToString();
            string query = Request.Form["query"].ToString();
            string sortname = Request.Form["sortname"].ToString();
            string sortorder = Request.Form["sortorder"].ToString();
            string TABLE = "TB_USER";
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
                WHERE = " WHERE " + qtype + " LIKE '%" + query + "%' ";
            }
            SQL = "SELECT * FROM " + TABLE + " " + WHERE + " " + SORT + " " + LIMIT;
            var DBList = _DB.Database.SqlQuery<tb_user>(SQL).ToList();
            var flexgrid = new
            {
                page = page,
                total = _DB.tb_user.Count(),
                rows = DBList
                .Select(x => new
                {
                    //KODE, NAMA, ALAMAT, TLP
                    id = x.USERNAME,
                    cell = new { x.USERNAME, x.NAMA, x.LEVEL, x.PASSWORD }
                }
                )

            };
            return Json(flexgrid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult UserADD(tb_user USR)
        {
            Thread.Sleep(1000);
            string result = "GAGAL";
            try
            {
                USR.UPD = DateTime.Now;
                USR.RECID = "";
                USR.PASSWORD = Fungsi.GenerateMD5(USR.PASSWORD);
                if (ModelState.IsValid)
                {
                    _DB.tb_user.Add(USR);
                    _DB.SaveChanges();
                    //_DB.Database.ExecuteSqlCommand("INSERT INTO TB_SATUAN VALUES ('" + Nama + "','" + Ket + "');");
                    result = "OK";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return Json(new { status = result });
        }
        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult UserEDIT(tb_user USR)
        {
            Thread.Sleep(1000);
            string result = "GAGAL";
            try
            {
                USR.UPD = DateTime.Now;
                USR.RECID = "";
                if (ModelState.IsValid)
                {
                    _DB.Entry(USR).State = EntityState.Modified;
                    _DB.SaveChanges();
                    result = "OK";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return Json(new { status = result });
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult UserDEL(string USR)
        {
            Thread.Sleep(1000);
            string result = "GAGAL";
            try
            {
                //_DB.bengkel_user.Remove(_DB.bengkel_user.Single(r => r.USERNAME == User));
                //_DB.SaveChanges();
                tb_user tb_user = _DB.tb_user.Find(USR);
                _DB.tb_user.Remove(tb_user);
                _DB.SaveChanges();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GantiPass()
        {
            return View();
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult SavePASS(string USER, string PASSLAMA, string PASSBARU)
        {
            Thread.Sleep(1000);
            string result = "GAGAL";
            try
            {
                //_DB.bengkel_user.Remove(_DB.bengkel_user.Single(r => r.USERNAME == User));
                //_DB.SaveChanges();
                //SQL = "DELETE FROM TB_TEMP_" + Session["Username"] + " WHERE PLU='" + PLU + "' AND LOKASI='" + LOKASI + "';";
                //var List = (from c in _DB.tb_user where c.USERNAME == USER && c.PASSWORD == Fungsi.GenerateMD5(PASSLAMA) select c).ToList();
                SQL = "Select * from TB_USER WHERE PASSWORD='" + Fungsi.GenerateMD5(PASSLAMA) + "' AND USERNAME='" + USER + "';";
                var List = _DB.Database.SqlQuery<tb_user>(SQL).ToList();
                if (List.Count == 0)
                {
                    result = "PASSWORD LAMA SALAH";
                }
                else
                {
                    string PASS = Fungsi.GenerateMD5(PASSBARU);
                    //DOCNO, PLU, RTYPE, LOKASI, QTY, DIBUAT, DARI, KE, TANGGAL, APPROVE, TANGGAL_APPROVE, DIAPPROVE, DITERIMA, KETERANGAN
                    SQL = "UPDATE TB_USER SET PASSWORD='" + PASS + "' WHERE USERNAME ='" + USER + "';";
                    _DB.Database.ExecuteSqlCommand(SQL);
                    result = "OK";
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadFileCSV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFileCSV(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 4; //Size = 4 MB
                    string[] AllowedFileExtensions = new string[] { ".csv" };
                    if (!AllowedFileExtensions.Contains
                    (file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/File"), fileName);
                        file.SaveAs(path);
                        ViewBag.Message = Fungsi.KonversiTabel(path);
                        ModelState.Clear();
                    }
                }
            }
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 4; //Size = 4 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf", ".zip" };
                    if (!AllowedFileExtensions.Contains
                    (file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/File"), fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        ViewBag.Message = "File uploaded successfully. File path :   ~/File/" + fileName;
                    }
                }
            }
            return View();
        }



    }
}