using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BoutikOnline.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Bundle pour le css
            /*
             * <link href="css/bootstrap.min.css" rel="stylesheet">
               <link href="css/font-awesome.min.css" rel="stylesheet">
               <link href="css/prettyPhoto.css" rel="stylesheet">
               <link href="css/price-range.css" rel="stylesheet">
               <link href="css/animate.css" rel="stylesheet">
               <link href="css/main.css" rel="stylesheet">
               <link href="css/responsive.css" rel="stylesheet">
             */

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/css/bootstrap.min.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/prettyPhoto.css",
                "~/Content/css/price-range.css",
                "~/Content/css/animate.css",
                "~/Content/css/main.css",
                "~/Content/css/responsive.css",
                "~/Content/css/style.css"));

            //Bundle pour les scripts
            /*
             *<script src="js/jquery.js"></script>
              <script src="js/bootstrap.min.js"></script>
              <script src="js/jquery.scrollUp.min.js"></script>
              <script src="js/price-range.js"></script>
              <script src="js/jquery.prettyPhoto.js"></script>
              <script src="js/main.js"></script>
             */

            bundles.Add(new ScriptBundle("~/Scripts/Jquery")
            .Include("~/Scripts/jquery.js",
                     "~/Scripts/jquery.scrollUp.min.js",
                     "~/Scripts/jquery.prettyPhoto.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap")
            .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Custom")
            .Include("~/Scripts/price-range.js",
                     "~/Scripts/main.js"));
        }
    }
}