using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySQLToolWeb.Models
{
    public class vw_data
    {
        //TOKO, NAMA, GB
        [Key]
        public string TOKO { set; get; }
        public string NAMA { set; get; }
        public string GB { set; get; }
    }
}