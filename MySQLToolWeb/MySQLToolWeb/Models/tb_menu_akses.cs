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
    public partial class tb_menu_akses
    {
        //MENU_ID, MENU_SUB, TIPE, MENU, MENU_LINK, ICON, AKTIF
        [Key]
        public string LEVEL { set; get; }
        public string MENU_SUB { set; get; }
    }
}