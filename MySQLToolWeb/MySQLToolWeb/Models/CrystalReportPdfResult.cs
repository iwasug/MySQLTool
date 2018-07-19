/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Web;
using System.Web.Mvc;
namespace MySQLToolWeb.Models
{
    class CrystalReportPdfResult : ActionResult
    {
        private readonly byte[] _contentBytes;
        private clsFungsi Fungsi = new clsFungsi();
        public CrystalReportPdfResult(string reportPath, object dataSet, string type = null, string parameter = null)
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(reportPath);
            reportDocument.SetDataSource(dataSet);
            reportDocument.SetParameterValue("User", HttpContext.Current.Session["Username"]);
            //reportDocument.SetParameterValue("Cabang", Fungsi.GetDesc("GDG"));
            _contentBytes = StreamToBytes(reportDocument.ExportToStream(ExportFormatType.PortableDocFormat));
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.ApplicationInstance.Response;
            response.Clear();
            response.Buffer = false;
            response.ClearContent();
            response.ClearHeaders();
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.ContentType = "application/pdf";
            using (var stream = new MemoryStream(_contentBytes))
            {
                stream.WriteTo(response.OutputStream);
                stream.Flush();
            }
        }

        private static byte[] StreamToBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
