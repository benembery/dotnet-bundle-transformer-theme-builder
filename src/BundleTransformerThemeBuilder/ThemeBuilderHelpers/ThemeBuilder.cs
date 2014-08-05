using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using BundleTransformer.Core.Transformers;
using BundleTransformer.Less.Translators;

namespace ThemeBuilderHelpers
{
    public abstract class ThemeBuilder : IBundleBuilder, IThemeBuilder
    {
        public string BuildBundleContent(Bundle bundle, BundleContext context, IEnumerable<BundleFile> files)
        {
            var lessTranslator = bundle.Transforms.OfType<StyleTransformer>()
                .Where(x => x != null)
                .Select(x => x.Translators.OfType<LessTranslator>().FirstOrDefault())
                .FirstOrDefault();

            if (lessTranslator == null)
            {
                return string.Empty;
            }

            lessTranslator.GlobalVariables = GetThemeVariables(context);

            return string.Empty;
        }

        /// <summary>
        /// Retrieve the theme variables 
        /// </summary>
        /// <param name="context">The Bundle Context for the theme we are buidling</param>
        /// <returns></returns>
        public abstract string GetThemeVariables(BundleContext context);
    }
}
