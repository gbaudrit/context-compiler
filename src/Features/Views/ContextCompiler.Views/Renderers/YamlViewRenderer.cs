using System.Globalization;
using System.Text;

using ContextCompiler.Abstractions.Compiled;
using ContextCompiler.Abstractions.Configuration.Sections;
using ContextCompiler.Modules.Abstractions.Views.Renderers;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Views.Renderers;

internal sealed class YamlViewRenderer(ILogger<YamlViewRenderer> logger) : IViewRendererModule
{
    public bool CanRender(IViewConfigSection def)
    {
        return def.Renderers.Contains("yaml");
    }

    public string OutputFileExtension => ".yaml";
    public string OutputMimeType => "application/x-yaml";

    public Task<string> RenderAsync(IViewConfigSection def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
    {
        logger.LogInformation("Rendering YAML view for '{ViewId}' with {FragmentCount} fragments", def.Id, fragments.Count);

        StringBuilder sb = new();
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- id: {def.Id}");
        _ = sb.AppendLine(CultureInfo.InvariantCulture, $"  title: {def.Title}");
        _ = sb.AppendLine("  - evidence:");

        foreach (IFragment f in fragments)
        {
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"    - ek: \"{f.Evidence.EvidenceKey}\"  ");
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"      er: \"{f.Evidence.EvidenceRevision}\"  ");
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"      rek: \"{f.Evidence.RelativeEvidenceKey}\"  ");
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"      rer: \"{f.Evidence.RelativeEvidenceRevision}\"  ");
            _ = sb.AppendLine(CultureInfo.InvariantCulture, $"      source: \"{f.Source.Path.Replace("\\", "/")}#{f.Source.Locator}\"  ");

            if (def.IncludeFragmentContent)
            {
                _ = sb.AppendLine("      content: |");
                string content = f.Content;
                if (def.MaxContentChars is int max && content.Length > max)
                {
                    content = content[..max] + "…";
                }

                _ = sb.AppendLine(IndentMultiline(content, 8));
            }
        }

        return Task.FromResult(sb.ToString());
    }

    private static string IndentMultiline(string text, int spaces)
    {
        string indent = new(' ', spaces);

        return string.Join(
            Environment.NewLine,
            text.Split(Environment.NewLine)
                .Select(line => indent + line)
        );
    }

}
