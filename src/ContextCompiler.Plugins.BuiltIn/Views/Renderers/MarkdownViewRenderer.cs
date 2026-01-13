using System.Globalization;
using System.Text;
using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Plugins.Views.Renderers;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.BuiltIn.Views.Renderers
{
    internal sealed class MarkdownViewRenderer : IViewRendererPlugin
    {
        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            WriteIndented = true
        };

        public bool CanRender(ViewConfig def) => def.Renderer.Contains("md");

        public string OutputFileExtension => ".md";

        public string OutputMimeType => "text/markdown";

        public Task<string> RenderAsync(ViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
        {
            var sb = new StringBuilder();
            sb.AppendLine(CultureInfo.InvariantCulture, $"# View: {def.Id}");
            sb.AppendLine();
            sb.AppendLine(def.Title);
            sb.AppendLine();
            sb.AppendLine("## Evidence");
            sb.AppendLine();

            foreach (var f in fragments)
            {
                sb.AppendLine(CultureInfo.InvariantCulture, $"- **EK:** `{f.Evidence.EvidenceKey}`  ");
                sb.AppendLine(CultureInfo.InvariantCulture, $"  **ER:** `{f.Evidence.EvidenceRevision}`  ");
                sb.AppendLine(CultureInfo.InvariantCulture, $"  **Source:** `{f.Source.Path}#{f.Source.Locator}`  ");

                if (def.IncludeFragmentContent)
                {
                    var content = Deterministic.NormalizeNewlines(f.Content);
                    if (def.MaxContentChars is int max && content.Length > max)
                        content = content[..max] + "…";

                    sb.AppendLine();
                    sb.AppendLine("```");
                    sb.AppendLine(content);
                    sb.AppendLine("```");
                }

                sb.AppendLine();
            }

            return Task.FromResult(sb.ToString());
        }

    }
}
