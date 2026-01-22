using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Core.Views
{
    internal sealed class ViewsProvider(ICtxcConfigProvider ctxcConfigProvider) : IViewsProvider
    {
        public IReadOnlyList<ViewConfig> Views => ctxcConfigProvider.Current.Views.Views;
    }
}
