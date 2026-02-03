using ContextCompiler.Abstractions.Configuration;

namespace ContextCompiler.Abstractions.Views
{
    public interface IViewsProvider
    {

        IReadOnlyList<ViewConfig> Views { get; }

    }
}
