using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Plugins.Views.Renderers
{
    public interface IViewRendererPlugin
    {
        string OutputFileExtension { get; }
        string OutputMimeType { get; }

        bool CanRender(ViewConfig def);
        Task<string> RenderAsync(ViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct);
    }
}
