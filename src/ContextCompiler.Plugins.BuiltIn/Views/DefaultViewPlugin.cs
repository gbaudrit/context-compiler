using System.Collections.Generic;
using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Views;

namespace ContextCompiler.Plugins.BuiltIn.Views;

public sealed class DefaultViewPlugin(IViewResultBuilder viewResultBuilder) : IViewPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.view.default", PluginKinds.View, priority: 0);
    public string ViewId => "default";

    public ValueTask<IReadOnlyList<IViewResult>> BuildAsync(ViewContext ctx, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var ir = ctx.ReasoningIr;

        var sb = new StringBuilder();
        sb.AppendLine("## Evidence");
        sb.AppendLine();
        foreach (var f in ir.Fragments)
        {
            sb.AppendLine(CultureInfo.InvariantCulture, $"### {f.Evidence.EvidenceKey}");
            sb.AppendLine();
            sb.AppendLine(f.Content);
            sb.AppendLine();
            sb.AppendLine(CultureInfo.InvariantCulture, $"_Source: `{f.Source.Path}` {(!string.IsNullOrEmpty(f.Source.Locator) ? $"({f.Source.Locator})" : "")}_");
            sb.AppendLine();
        }

        return ValueTask.FromResult<IReadOnlyList<IViewResult>>(new[] { viewResultBuilder.InitNew()
                                                                                         .WithId(ViewId)
                                                                                         .WithTitle("Default View")
                                                                                         .WithContent(sb.ToString())
                                                                                         .WithMime("text/markdown")
                                                                                         .WithFilename("view.default.md")
                                                                                         .Build() });
    }
}
