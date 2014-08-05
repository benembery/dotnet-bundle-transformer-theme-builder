using System.Web.Optimization;

namespace ThemeBuilderHelpers
{
    internal interface IThemeBuilder
    {
        string GetThemeVariables(BundleContext context);
    }
}