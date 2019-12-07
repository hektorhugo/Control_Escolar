using System.Web;
using System.Web.Optimization;

namespace ControlEscolar
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Content/DataTables/jquery.dataTables.min.js",
                        "~/Content/DataTables/dataTables.responsive.min.js",
                        "~/Content/DataTables/dataTables.buttons.min.js",
                        "~/Content/DataTables/buttons.html5.min.js",
                        "~/Content/DataTables/buttons.flash.min.js",
                        "~/Content/DataTables/buttons.print.min.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                         "~/Scripts/Main.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/DataTables/css/responsive.dataTables.min.css",
                      "~/Content/DataTables/css/buttons.bootstrap.min.css"));
        }
    }
}
