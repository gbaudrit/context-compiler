using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Abstractions.Plugins;

public interface IViewPlugin : IPlugin
{
    string ViewId { get; }
    ValueTask<IReadOnlyList<IViewResult>> BuildAsync(ViewContext ctx, CancellationToken ct);
}

public sealed record ViewContext(
    ViewsConfig Config,
    IReasoningIr ReasoningIr,
    IReadOnlyDictionary<string, object>? Inputs = null,
    bool EmitJson = true,
    bool EmitMarkdown = true
);



