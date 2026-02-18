using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Plugins.Abstractions.Views.Renderers
{
    public interface IViewRenderersPlugin
    {
        ValueTask<IReadOnlyList<IViewResult>> RenderAsync(IViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
