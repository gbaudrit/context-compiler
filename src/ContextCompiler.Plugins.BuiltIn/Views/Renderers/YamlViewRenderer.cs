using System.Globalization;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Plugins.Views.Renderers;
using ContextCompiler.Abstractions.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Views.Renderers
{
    internal sealed class YamlViewRenderer(ILogger<YamlViewRenderer> logger) : IViewRendererPlugin
    {
        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            WriteIndented = true
        };

        public bool CanRender(ViewConfig def) => def.Renderer.Contains("yaml");

        public string OutputFileExtension => ".yaml";
        public string OutputMimeType => "application/x-yaml";

        public Task<string> RenderAsync(ViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
        {
            logger.LogInformation("Rendering YAML view for '{ViewId}' with {FragmentCount} fragments", def.Id, fragments.Count);

            var sb = new StringBuilder();
            sb.AppendLine(CultureInfo.InvariantCulture, $"- id: {def.Id}");
            sb.AppendLine(CultureInfo.InvariantCulture, $"  title: {def.Title}");
            sb.AppendLine("  - evidences:");

            foreach (var f in fragments)
            {
                sb.AppendLine(CultureInfo.InvariantCulture, $"    - ek: \"{f.Evidence.EvidenceKey}\"  ");
                sb.AppendLine(CultureInfo.InvariantCulture, $"      ek: \"{f.Evidence.EvidenceRevision}\"  ");
                sb.AppendLine(CultureInfo.InvariantCulture, $"      source: \"{f.Source.Path.Replace("\\","/")}#{f.Source.Locator}\"  ");

                if (def.IncludeFragmentContent)
                {
                    sb.AppendLine("      content: |");
                    var content = f.Content;
                    if (def.MaxContentChars is int max && content.Length > max)
                        content = content[..max] + "…";

                    sb.AppendLine(IndentMultiline(content, 8));
                }
            }

            return Task.FromResult(sb.ToString());
        }

        private static string IndentMultiline(string text, int spaces)
        {
            var indent = new string(' ', spaces);

            return string.Join(
                Environment.NewLine,
                text.Split(Environment.NewLine)
                    .Select(line => indent + line)
            );
        }

    }
}
