using System.Web.Optimization;

namespace ThemeBuilderHelpers.Web.Tests
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/content/preboot.css").Include("~/content/site.css"));
        }
    }
}