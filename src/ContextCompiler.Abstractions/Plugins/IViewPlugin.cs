using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Abstractions.Plugins;

public interface IViewPlugin : IPlugin
{
    string ViewId { get; }
    Task<ViewResult> BuildAsync(ViewContext ctx, CancellationToken ct);
}

public sealed record ViewContext(
    string RootPath,
    IReasoningIr ReasoningIr,
    IReadOnlyDictionary<string, object>? Inputs = null
);

public sealed record ViewResult(
    string ViewId,
    string Title,
    string RenderedMarkdown,
    IReadOnlyDictionary<string, string>? Metadata = null
);
