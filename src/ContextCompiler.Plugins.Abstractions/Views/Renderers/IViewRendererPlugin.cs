using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.Abstractions.Views.Renderers
{
    public interface IViewRendererPlugin
    {
        string OutputFileExtension { get; }
        string OutputMimeType { get; }

        bool CanRender(IViewConfig def);
        Task<string> RenderAsync(IViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
