using System.Web.Mvc;
using System.Web.Optimization;

namespace ThemeBuilderHelpers
{
    public class ThemeBundleResult : ActionResult
    {
        private readonly string _themeVirtualPath;
        private readonly string[] _themeFiles;
        private readonly IBundleBuilder _themeBuilder;

        public ThemeBundleResult(string themeVirtualPath, string[] themeFiles, IBundleBuilder themeBuilder)
        {
            _themeVirtualPath = themeVirtualPath;
            _themeFiles = themeFiles;
            _themeBuilder = themeBuilder;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (!BundleTable.Bundles.BundleExists(_themeVirtualPath))
            {
                BundleTable.Bundles.AddThemeBundle(_themeVirtualPath, _themeFiles, _themeBuilder);
            }

            var bundleContext = new BundleContext(context.HttpContext, BundleTable.Bundles, _themeVirtualPath);

            var response = BundleTable.Bundles.GetBundleFor(_themeVirtualPath).GenerateBundleResponse(bundleContext);

            context.RequestContext.HttpContext.Response.Cache.SetCacheability(response.Cacheability);
            context.RequestContext.HttpContext.Response.ContentType = response.ContentType;
            context.RequestContext.HttpContext.Response.Write(response.Content);
        }
        
    }
}