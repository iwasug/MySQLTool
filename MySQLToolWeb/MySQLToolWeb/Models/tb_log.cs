/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySQLToolWeb.Models
{
    public partial class tb_log
    {
        //TOKO, NAMA, JENIS, IBDATA, BINLOG, TANGGAL, WAKTU, SCHEMA, UPD
        //TOKO, NAMA, JENIS, IBDATA, BINLOG, TANGGAL, WAKTU, SCHEMA, UPD
        [Key]
        public string TOKO { set; get; }
        public string NAMA { set; get; }
        public string JENIS { set; get; }
        public string IBDATA { set; get; }
        public string BINLOG { set; get; }
        public DateTime? TANGGAL { set; get; }
        public string WAKTU { set; get; }
        public string SCHEMA { set; get; }
        public DateTime? UPD { set; get; }
    }
}