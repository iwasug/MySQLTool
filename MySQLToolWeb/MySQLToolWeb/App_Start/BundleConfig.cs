using System.Web;
using System.Web.Optimization;

namespace MySQLToolWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-select.min.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/bootstrap-session-timeout.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                    "~/Scripts/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/iwa").Include(
                        "~/Scripts/iwa.js"));

            bundles.Add(new ScriptBundle("~/bundles/serializeToJSON").Include(
                        "~/Scripts/jquery.serializeToJSON.js"));

            bundles.Add(new ScriptBundle("~/bundles/flexigrid").Include(
                      "~/Scripts/flexigrid.js"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/bootstrap-theme.min.css",
                     "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/bootstrap-select.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));
        }
    }
}
