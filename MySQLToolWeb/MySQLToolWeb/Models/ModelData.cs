/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
namespace MySQLToolWeb.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class ModelData : DbContext
    {
        public ModelData() : base("name=DataModel")
        {

        }

        public virtual DbSet<tb_user> tb_user { get; set; }
        public virtual DbSet<tb_setting> tb_setting { get; set; }
        public virtual DbSet<tb_menu> tb_menu { get; set; }
        public virtual DbSet<tb_menu_akses> tb_menu_akses { get; set; }
        public virtual DbSet<tb_tabel> tb_tabel { get; set; }
        public virtual DbSet<vw_data> vw_data { get; set; }
        public virtual DbSet<tb_log> tb_log { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}