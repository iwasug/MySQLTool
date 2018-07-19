/***********************DO-NOT-REMOVE******************************* 

Copyright (c) 2016 Iwa Sugriwa
Email : iwasugriwa@hotmail.com / netbarrons@gmail.com
Phone : 082316115700

***********************DO-NOT-REMOVE*******************************/
using MySQLToolWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySQLToolWeb.Controllers
{
    public class MasterController : Controller
    {
        private ModelData _DB = new ModelData();
        private clsFungsi Fungsi = new clsFungsi();
        private string SQL = "";
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TabelPenting()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PentingList()
        {
            int page = int.Parse(Request.Form["page"]);
            int rp = int.Parse(Request.Form["rp"]);
            string qtype = Request.Form["qtype"].ToString();
            string query = Request.Form["query"].ToString();
            string sortname = Request.Form["sortname"].ToString();
            string sortorder = Request.Form["sortorder"].ToString();
            string TABLE = "TB_PENTING";
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
            SQL = "SELECT * FROM " + TABLE + " " + WHERE + "  " + SORT + " " + LIMIT;
            var DBList = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            SQL = "SELECT * FROM " + TABLE + ";";
            var Count = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            var flexgrid = new
            {
                page = page,
                total = Count.Count(),
                rows = DBList
                .Select(x => new
                {
                    id = x.NAMA,
                    cell = new { x.NAMA, x.UPD }
                }
                )

            };
            return Json(flexgrid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult PentingADD(tb_tabel tabel)
        {
            string result = "GAGAL";
            try
            {
                if (ModelState.IsValid)
                {
                    SQL = "INSERT INTO TB_PENTING (NAMA, UPD) VALUES ('" + tabel.NAMA.ToLower() + "',NOW()) ON DUPLICATE KEY UPDATE UPD=NOW();";
                    //SQL = "INSERT INTO TB_PENTING (NAMA, UPD) VALUES ('" + Nama.ToLower() + "',NOW()) ON DUPLICATE KEY UPDATE UPD=NOW();";
                    _DB.Database.ExecuteSqlCommand(SQL);
                    result = "OK";
                    /*
                    string[] a = ("100itempareto|_kosong|_ppnbm|_ppnbm_2|_pro_temp01|_pro_temp02|_tlog01|_tlog02|_trhtemp|absen_kd|alokasi_seasonal|apka_callerid|apka_customer|apka_pesanan|apka_pesanan_detil|asam_bulan|asppass|atk_config|atk_cons|atk_ktgplastik|atk_log|atk_masterplastik|atk_mstran|atk_pbatk|atk_prodmast|atk_rumus|atk_stmast|atk_templpp|avg_sls|avg_sls_temp|bank|barcode|basticker|batas|batas_retur|batelurcatcod|bayar|bcx_temp|beritaacara|beritaacara_penukaran|beritaacara_penukarandetil|bincard|bln_akt|bpjs_log|bpjs_tran|bracket|bracket2|bracket_temp|brx_fbx_main_temp|brx_fbx_tdkmain_temp|brx_fbx_temp|brx_temp|buah|cabang_task|cabang_unit|cancel|ccard|cekplanogram|checklist|closing_detail|const|const_asm|custmast|custom|danakas|dcmast|dcp_boxplu|del_temp|dept|dept_lhso|dhx_temp|disc_istore|disc_istore_harian|diversity_tbldetailnc|diversity_tblhapusnc|diversity_tbllayanan|diversity_tbllogharga|diversity_tblnc|diversity_tbloption|diversity_tblsj|diversity_tblttb|diversity_tblversi|divisi|edcmas|elpiji|emailnrb|event_spd|eventdetail|eventdetail_barang|eventmast|expired_main|expired_main_old|fbx_main_temp|fbx_temp|fee|filterplu|fixed_tb|fixed_tb_new|fixtabel|fstruk|grmast|hadiah|hapus_prod|hari_libur|hari_libur_temp|hasil_his_pb|hbx_temp|his_barcode_tat|his_pbdc|his_prodmast|his_retur_roti|his_spd|his_stmast|his_stmast_rst|his_stock|his_switching|his_tk|his_tkn|his_token|hisptagnr|hitung_his_pb|hrgbeli|hrgbeli_new|hrn_rak|hsprodmast|icard_config|icard_fee|icard_jeniskartu|icard_member|icard_pushmember|icard_tipetransaksi|icard_trans|idelivery_pembayaran|idelivery_tipe_pembayaran|idmcard_bin_t|idmcard_dtl_t|idmcard_hdh_t|idmcard_hdr_t|idmsql|if_temp|ikiosk_gameonline|ikiosk_idmcard|ikiosk_kai|ikiosk_listrik|ikiosk_paymentpoint|ikiosk_pdam|ikiosk_pelni|ikiosk_penjualan_voucher|ikiosk_pertunjukan|ikiosk_pesan_ambil|ikiosk_pesan_antar|ikiosk_settlement|ikiosk_topupidmcard|ikiosk_txtravel|ikupon01|ikupon02|imr_tahandana|indomog_tracelog|indomog_translog|indomog_voucher|initial|initialbarcode|inputaktualkas|ipaket_coverage|ipaket_log|ipaket_tran|ipulsa_config|ipulsa_logipulsa|ipulsa_logpush|ipulsa_transaksi|ist1603|ist1604|itemharam|itemso|itmbalance|itmtran|jadwal_monitoring|jdwlso|jual01|jual02|kai_cnfg|kai_jdwl|kai_stsn|kai_tran|kai_trce|kailog|kapdisp_temp|karton|karton_new|kat|kbi_log|kejutan|kodeposmast|kodeposmast_temp|konsy|kontainer|konversi_buah|konversi_plu|konversidbf|ktgr_new|kupon|lawas|listgudang|listrik_transaksi|lockso|log_ba_gembok|log_ba_tat|log_lpptk|log_monitor|logelec|loggv|logshift|lokasi|lpm_temp|mandiri|mbr|merk|mindo|mobil_promo_matriks|mobil_promo_prioritas|mstkop|mstran|mstran_asam|mstrasio|mtran|mtran_asam|mtran_valid|mu_temp|nbr_buah|nbr_dry|newprod|nhb_temp|nokjt|npb_d|npb_h|npb_k|nrakktgr|oldtag|paai_gambar|paai_kodepos|paai_mapkey|paai_pembayaran|paai_prodmast|paai_stok|paai_timezone|paai_transaksi_detail|paai_transaksi_summary|pass|passtoko|paymentpoint_log|paymentpoint_tran|paymentpoint_voucher|payout|pb_gab|pb_gab_his|pbbuah_temp|pbe_tempx|pbenkriplog|pbkonsy|pbkonsy_new|pbmast|pbro_temp|pbsc_temp|pbsg_temp|pbsl_temp|pbslro_temp|pbsr_temp|pd_temp|pdam_log|pdam_tran|pdam_voucher|pelni_jdwl|pelni_pelabuhan|pelni_tran|pelni_trce|pelnilog|perform|periode_nkl_f|periode_nkl_n|periode_nkl_r|pertunjukan_jadwal01|pertunjukan_jadwal02|pertunjukan_log|pertunjukan_tran|pertunjukan_trce|pertunjukanwahana_jadwal01|pertunjukanwahana_jadwal02|perubahan_posisi|perubahan_ptag|pesan|pesan_nasional|pesanantar_prodmast|pfe_pbe|pfe_tempx|pkm_dg_kapdisp|pkm_new|pointreward_addpoint_2|pointreward_detail|pointreward_detail_2|pointreward_hist|pointreward_hist_2|pointreward_tran|pointreward_tran_2|pomast|pos2_cin_temp|pos2_dbt_temp|pos2_edc_temp|pos_net_qtysales|pos_net_stockout|pos_net_transaksi|pos_net_trhyymm|pos_net_verifikasipasstoko|posrt|posrt_absenping|posrt_task|posrt_task_id|posrt_tracelog|pprominusstock01|pprominusstock02|pr_temp|prc_tmp|prctag|prctag_hargabaru|prctag_main|prdcd_rak_main_temp|pricetag_matriks|prm_recid1_prodmast_rak_temp|prmtemp|prod|prodmast|prodmast_before|prodmast_main|prodmast_mp|prodmast_new|prodmast_rak|prodtmp|program_setting|promo|promo_matriks|promo_prioritas|promosi|promosi_double|promosi_ho_today|promosi_lokal_today|promosi_new|promosi_single|promotk_group_t|promotk_hdr_t|promotk_jpemb_t|promotk_jpromosi_t|promotk_plubnd_dtl_t|promotk_plubnd_hdr_t|promotk_pluhadiah_t|promotk_plukecuali_t|promotk_plupromosi_t|promotk_plusponsor_t|promotk_supp_t|promotk_tpromosi_t|promotk_typetoko_t|promotk_voucher_t|protect|protect_depo|psnambil_options|psnambil_produk|psnambil_rhblog|psnambil_transaksi|psnambil_transdetil|psnambil_ubahtrans|ptag|ptag_nr|ptag_nr_hist|ptag_nr_hist_old|ptag_nr_nrak_mjd_nktgr_temp|ptag_old|ptag_promo_marketing|ptag_promo_marketing_temp|ptag_temp|pu_temp|querysales|raillink_cnfg|raillink_jdwl|raillink_stsn|raillink_tran|raillink_trce|raillinklog|rak|rak_a|rak_b|rak_before|rak_before_groupby|rak_expired|rak_groupby|rak_mp|rak_new|rak_old|rak_temp|recipe|recvitem|refretur|rekap_retnondesc|ret1602t|ret1603t|retur_bayar|retur_khusus|rh_1|rkash_1|rkb_table|rkl1602t|rkl1603t|rlog|rrak_account|rrak_barrak|rrak_cetak_periode|rrak_id_pelanggan|rrak_id_pelanggan_pam|rrak_id_pelanggan_telpon|rrak_mrrak|rrak_optionrrak|rrak_pengaturan|rrak_rrak|rrak_rrak2|rrak_rrak3|rrak_rrak4|rrak_trend|sales_buah|sales_dry|sales_telur|seasonal|seasonal_temp|selisih|serah|settingemail|settingemail_temp|sewa|sjalan|slmast|slowmoving|slowmoving_temp|sls_tart|so_tdk_display|sotemp_1511t|spdmast|spec_hardware|sponsor|sticker_detil|sticker_header|stmast|stmast_rst|stockol|stockol_id|sumtable|supfax|supmast|supmast_before|sw_temp|switchmast|sysmenu|syspar|syswebcabang|tat_temp|tatmast|tb_rasio|tb_rasio_new|tb_rasionew|tbl_div|tbl_fix|tbl_ofc|tbl_ss|tblnonplu|tblweek|tcash_translog|tcashout|tcsh|telkomvision_log|telkomvision_tran|telkomvision_trce|telkomvision_voucher|temp_ctkreg|temp_filet|temp_his_pbbh_total|temp_his_pbdc_total|temp_lpptk|temp_npb_d_out_total|temp_npbbh_d_out_total|temp_pkm_pb_dc|temp_prodmas|temp_stockout1|temp_stockout2|temp_stockoutpareto|temp_waktusopertoko|temp_waktusoperuser|tempceksoid|tempso|tempsobaru|tlog|tlog_double|tmpmrrak|tmpprm|toko|toko_cab|toko_checklist|toko_kunjungan|toko_new|toko_tat|toko_unit|tot_struk|tph_new|tracelog|tracelog_cms|tracelog_edc_2|tracelog_posnet|transtokolog|trpr_promo|ttd_d|ttd_h|tua_muda|txtravel_log|txtravel_tran|ty01|ty02|typecus|userso|userso_temp|usersodcp|vgo_cnfg|vgo_mintatrx|vgo_translog|vir_bacaprod|vir_bacaprod_cek_ftrstk|vir_callcntr|vir_prefcell|vir_prefix|virtualwarning|voucherhotel_jadwal01|voucherhotel_jadwal02|vwrrak2|websotemp|westernunion_ambiluang|westernunion_country|westernunion_id_type|westernunion_kirimuang|westernunion_log|westernunion_mexicocity_state|westernunion_occupation|westernunion_province_idr|westernunion_purpose_of_transaction|westernunion_regency_idr|westernunion_source_of_funds|westernunion_trx_wu|westernunion_us_state|wtran|wtran_bkl|wtran_in|wtran_in_temp").Split('|');
                    foreach(string Nama in a)
                    {
                        SQL = "INSERT INTO TB_PENTING (NAMA, UPD) VALUES ('" + Nama.Trim() + "',NOW()) ON DUPLICATE KEY UPDATE UPD=NOW();";
                        _DB.Database.ExecuteSqlCommand(SQL);
                        result = "OK";
                    }
                    */
                }
            }
            catch (Exception err)
            {
                result = err.ToString();
            }
            return Json(new { status = result });
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult PentingDEL(string NAMA)
        {
            string result = "GAGAL";
            try
            {
                SQL = "DELETE FROM TB_PENTING WHERE NAMA='" + NAMA + "';";
                _DB.Database.ExecuteSqlCommand(SQL);
                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TabelDelete()
        {
            /*
            string[] a = ("his_prodmast|his_stmast|tracelog|tracelog_cms|his_stmast_rst|posrt_tracelog|his_pbdc|his_stock|his_switching|log_monitor").Split('|');
            foreach (string Nama in a)
            {
                 SQL = "INSERT INTO TB_HAPUS(NAMA, UPD) VALUES ('" + Nama.ToLower() + "',NOW()) ON DUPLICATE KEY UPDATE UPD=NOW();";
                _DB.Database.ExecuteSqlCommand(SQL);
            }
            */
            return View();
        }

        [HttpPost]
        public ActionResult DeleteList()
        {
            int page = int.Parse(Request.Form["page"]);
            int rp = int.Parse(Request.Form["rp"]);
            string qtype = Request.Form["qtype"].ToString();
            string query = Request.Form["query"].ToString();
            string sortname = Request.Form["sortname"].ToString();
            string sortorder = Request.Form["sortorder"].ToString();
            string TABLE = "TB_HAPUS";
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
            var DBList = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            SQL = "SELECT * FROM " + TABLE + ";";
            var Count = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            var flexgrid = new
            {
                page = page,
                total = Count.Count(),
                rows = DBList
                .Select(x => new
                {
                    id = x.NAMA,
                    cell = new { x.NAMA, x.UPD }
                }
                )

            };
            return Json(flexgrid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult DeleteADD(tb_tabel tabel)
        {
            string result = "GAGAL";
            try
            {
                if (ModelState.IsValid)
                {
                    SQL = "INSERT INTO TB_HAPUS (NAMA, UPD) VALUES ('" + tabel.NAMA.ToLower() + "',NOW()) ON DUPLICATE KEY UPDATE UPD=NOW();";
                    _DB.Database.ExecuteSqlCommand(SQL);
                    result = "OK";
                }
            }
            catch (Exception err)
            {
                result = err.ToString();
            }
            return Json(new { status = result });
        }

        [HttpPost]
        [AjaxValidateAntiForgeryToken]
        public JsonResult DeleteDEL(string NAMA)
        {
            string result = "GAGAL";
            try
            {
                SQL = "DELETE FROM TB_HAPUS WHERE NAMA='" + NAMA + "';";
                _DB.Database.ExecuteSqlCommand(SQL);
                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        public string GetTabelPenting()
        {
            string result = "";
            SQL = "SELECT * FROM TB_PENTING";
            var DBList = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            foreach(var tabel in DBList)
            {
                result += "|" + tabel.NAMA;
            }
            return result.Substring(1);
        }

        public JsonResult GetTabel()
        {
            SQL = "SELECT * FROM TB_PENTING";
            var penting = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            var n = from x in penting select x.NAMA;
            SQL = "SELECT * FROM TB_HAPUS";
            var hapus = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            var m = from x in hapus select x.NAMA;
            return Json( new { penting = n.ToList(),hapus = m.ToList() },JsonRequestBehavior.AllowGet);
        }

        public string GetTabelHapus()
        {
            string result = "";
            SQL = "SELECT * FROM TB_HAPUS";
            var DBList = _DB.Database.SqlQuery<tb_tabel>(SQL).ToList();
            foreach (var tabel in DBList)
            {
                result += "|" + tabel.NAMA;
            }
            return result.Substring(1);
        }

        public string GetVersi()
        {
            string result = Fungsi.GetSetting("VERSI") + "|" + Fungsi.GetSetting("FILE");
            return result;
        }

        public JsonResult Log(string TOKO, string NAMA, string JENIS, string IBDATA, string BINLOG, string WAKTU, string SCHEMA)
        {
            string result = "";
            try
            {
                string IP = this.Request.ServerVariables["REMOTE_ADDR"];
                SQL = "INSERT INTO TB_LOG(TOKO, NAMA, JENIS, IBDATA, BINLOG, TANGGAL, WAKTU, `SCHEMA`, UPD, IP) ";
                SQL += "VALUES ('" + TOKO + "','" + NAMA + "','" + JENIS + "','" + IBDATA + "','" + BINLOG + "',CURDATE(),'" + WAKTU + "','" + SCHEMA + "',NOW(),'" + IP + "') ";
                SQL += "ON DUPLICATE KEY UPDATE UPD=NOW(),WAKTU='" + WAKTU + "';";
                _DB.Database.ExecuteSqlCommand(SQL);
                result = "OK";
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            return Json(result);
        }

        public ActionResult SysMenu()
        {
            return View();
        }
        
    }
}