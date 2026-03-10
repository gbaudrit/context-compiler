using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.ReasoningIR;
using ContextCompiler.Abstractions.Views;
using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.BuiltIn.Views;

public sealed class DefaultViewModule(IViewResultBuilder viewResultBuilder) : IViewModule
{
    public ModuleMetadata Metadata => BuiltInMetadata.Meta("builtin.view.default", GlobalPipelineModuleKinds.View, priority: 0);
    public string ViewId => "default";

    public ValueTask<IReadOnlyList<IViewResult>> BuildAsync(ViewContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        IReasoningIr ir = ctx.ReasoningIr;

        StringBuilder sb = new();
        _ = sb.AppendLine("## Evidence");
        _ = sb.AppendLine();
        foreach (IFragment f in ir.Fragments)
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"### {f.Evidence.EvidenceKey}");
            _ = sb.AppendLine();
            _ = sb.AppendLine(f.Content);
            _ = sb.AppendLine();
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"_Source: `{f.Source.Path}` {(!string.IsNullOrEmpty(f.Source.Locator) ? $"({f.Source.Locator})" : "")}_");
            _ = sb.AppendLine();
        }

        return ValueTask.FromResult<IReadOnlyList<IViewResult>>([ viewResultBuilder.InitNew()
                                                                                         .WithId(ViewId)
                                                                                         .WithTitle("Default View")
                                                                                         .WithContent(sb.ToString())
                                                                                         .WithMime("text/markdown")
                                                                                         .WithFilename("view.default.md")
                                                                                         .WithRendererType(GetType())
                                                                                         .Build() ]);
    }
}
