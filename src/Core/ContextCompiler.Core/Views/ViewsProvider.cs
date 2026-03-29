using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Core.Views
{
    internal sealed class ViewsProvider(IConfigProvider ctxcConfigProvider) : IViewsProvider
    {
        public IReadOnlyList<IViewConfigSection> Views => ctxcConfigProvider.Current.Views.Views;
    }
}
