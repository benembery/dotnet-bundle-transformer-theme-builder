using System.Linq;
using System.Web.Optimization;
using BundleTransformer.Core.Bundles;

namespace ThemeBuilderHelpers
{
    public static class BundleCollectionExtensions
    {
        public static bool BundleExists(this BundleCollection bundles, string virtualPath)
        {
            return bundles.Any(x => x.Path == virtualPath);
        }

        public static void AddThemeBundle(this BundleCollection bundles, string themeVirtualPath, string[] themeFiles, IBundleBuilder themeBuilder)
        {
            var themeBundle = new CustomStyleBundle(themeVirtualPath).Include(themeFiles);
            themeBundle.Builder = themeBuilder;

            bundles.Add(themeBundle);
        }
    }
}