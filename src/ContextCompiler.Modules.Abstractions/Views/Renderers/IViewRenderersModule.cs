using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Modules.Abstractions.Views.Renderers
{
    public interface IViewRenderersModule
    {
        ValueTask<IReadOnlyList<IViewResult>> RenderAsync(IViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
