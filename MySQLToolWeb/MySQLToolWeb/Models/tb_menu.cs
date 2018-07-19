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
    public partial class tb_menu
    {
        //MENU_ID, MENU_SUB, TIPE, MENU, MENU_LINK, ICON, AKTIF
        [Key]
        public string MENU_ID { set; get; }
        public string MENU_SUB { set; get; }
        public string TIPE { set; get; }
        public string MENU { set; get; }
        public string MENU_LINK { set; get; }
        public string ICON { set; get; }
        public string AKTIF { set; get; }
    }
}