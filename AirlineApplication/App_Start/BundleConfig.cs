﻿using System.Web;
using System.Web.Optimization;

namespace AirlineApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                             "~/Scripts/bootstrap.js",
                             "~/Scripts/moment.js",
                             "~/Scripts/bootstrap-datetimepicker.js",
                            "~/Scripts/jquery-{version}.js",
                      "~/Scripts/bootbox.all.min.js",
                      "~/scripts/datatables/jquery.datatables.js",
                       "~/scripts/datatables/datatables.bootstrap.js",
                       "~/Scripts/underscore-min.js",
                        "~/Scripts/popper.min.js",
                         "~/Scripts/mbd.min.js",
                          "~/Scripts/mdb.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/scripts/app/app.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                       "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css",
                      "~/Content/animate.css",
                       "~/Content/mdb.lite.css"
                        ));
        }
    }
}
