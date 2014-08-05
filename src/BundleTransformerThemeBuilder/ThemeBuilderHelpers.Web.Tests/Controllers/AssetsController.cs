using System;
using System.Web.Mvc;
using ThemeBuilderHelpers.Web.Tests.ExampleCode;

namespace ThemeBuilderHelpers.Web.Tests.Controllers
{
    public class AssetsController : Controller
    {
        private static readonly string[] ThemeFiles = {"~/Content/less/theme.less"};

        [Route("bundles/css/{id}")]
        public ThemeBundleResult Theme(string id)
        {
            // Validate theme id at this point.
            if (id != "theme")
                throw new ArgumentOutOfRangeException("id","Invalid theme");

            var themeVirtualPath = string.Format("~/bundles/css/{0}", id);

            return new ThemeBundleResult(themeVirtualPath, ThemeFiles, new ExampleThemeBuilder());
        }
    }
}