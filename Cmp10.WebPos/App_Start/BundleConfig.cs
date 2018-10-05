using System.Web.Optimization;

namespace Cmp10.WebPos
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/Core/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/Core/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/Core/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/Core/bootstrap.js", "~/Scripts/Core/respond.js", "~/Scripts/Core/jquery-ui.js", "~/Scripts/Core/jquery.unobtrusive-ajax.min.js", "~/Scripts/Core/FullMsg.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css", "~/Content/jquery-ui.css"));
            //BundleTable.EnableOptimizations = true;
        }
    }
}
