using System.Web;
using System.Web.Optimization;

namespace AdminApps
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/core/jquery.min.js",
                        "~/assets/js/core/popper.min.js",
                        "~/assets/js/plugins/perfect-scrollbar.jquery.min.js",
                        "~/assets/js/plugins/chartist.min.js",
                        "~/assets/js/material-dashboard.min.js?v=2.1.0",
                        "~/assets/demo/demo.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/assets/js/core/bootstrap-material-design.min.js",
                      "~/assets/js/plugins/bootstrap-notify.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                  "~/Scripts/angular.js",
                    "~/Scripts/angular-route.js",
                       "~/Scripts/angular-ui-router.js",
                "~/Apps/js/app.js",
             "~/Apps/js/app.config.js",
                "~/Apps/js/admin/adminroute.js",
              "~/Apps/js/admin/adminservice.js",
                "~/Apps/js/admin/admincontroller.js",
                 "~/Apps/js/petugas/petugasroute.js",
              "~/Apps/js/petugas/petugasservice.js",
                "~/Apps/js/petugas/petugascontroller.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/material-dashboard.css",
                      "~/assets/demo/demo.css"));
        }
    }
}
