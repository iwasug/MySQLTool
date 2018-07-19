using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySQLToolWeb.Models
{
    public partial class tb_tabel
    {
        [Key]
        public string NAMA { set; get; }
        public DateTime? UPD { set; get; }
    }
}