using System.Web.Optimization;

namespace ThemeBuilderHelpers.Web.Tests.ExampleCode
{
    public class ExampleThemeBuilder : ThemeBuilder
    {
        public override string GetThemeVariables(BundleContext context)
        {
            return string.Format("themeColour={0}", "#999");
        }
    }
}