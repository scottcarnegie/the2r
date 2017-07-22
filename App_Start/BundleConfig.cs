using System.Web;
using System.Web.Optimization;

namespace The2r
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

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/Datatables-1.10.12/media/js/jquery.datatables.js",
                        "~/Scripts/Datatables-1.10.12/media/js/datatables.bootstrap.js",
                       "~/Scripts/Datatables-1.10.12/extensions/Responsive/js/dataTables.responsive.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/datejs").Include(
                        "~/Scripts/date.js"));

            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                        "~/Scripts/Slider/bootstrap-slider.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker_a").Include(
                        "~/Scripts/moment.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker_b").Include(
                        "~/Scripts/bootstrap-datetimepicker.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/CustomMap").Include(
                        "~/Scripts/CustomGoogleMap.js"
                        ));
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-paper.css",
                      "~/Content/DataTables-1.10.12/media/css/dataTables.bootstrap.css",
                      "~/Content/DataTables-1.10.12/extensions/Responsive/css/responsive.dataTables.css",
                      "~/Content/site.css",
                      "~/Content/Slider/bootstrap-slider.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/CustomGoogleMap.css"
                      ));

            
        }
    }
}
