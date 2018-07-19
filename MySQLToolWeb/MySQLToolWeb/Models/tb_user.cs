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
    public partial class tb_user
    {
        public string RECID { set; get; }
        [Key]
        public string USERNAME { set; get; }
        public string PASSWORD { set; get; }
        public string NAMA { set; get; }
        public string LEVEL { set; get; }
        public DateTime? UPD { set; get; }
    }
}