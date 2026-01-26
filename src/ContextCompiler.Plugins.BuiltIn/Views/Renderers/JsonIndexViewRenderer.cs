using System.Text.Json;

using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Plugins.Views.Renderers;
using ContextCompiler.Abstractions.ReasoningIR;

using Microsoft.Extensions.Logging;

namespace ContextCompiler.Plugins.BuiltIn.Views.Renderers
{
    internal sealed class JsonIndexViewRenderer(ILogger<JsonIndexViewRenderer> logger) : IViewRendererPlugin
    {
        private static readonly JsonSerializerOptions JsonOpts = new()
        {
            WriteIndented = true
        };

        public bool CanRender(ViewConfig def) => def.Renderer.Contains("index.json");

        public string OutputFileExtension => ".json";
        public string OutputMimeType => "application/json";

        public Task<string> RenderAsync(ViewConfig def, IReadOnlyList<IFragment> fragments, CancellationToken ct)
        {
            logger.LogInformation("Rendering JSON index view for '{ViewId}' with {FragmentCount} fragments", def.Id, fragments.Count);

            var model = new
            {
                contractVersion = "1.0",
                viewId = def.Id,
                title = def.Title,
                fragments = fragments.Select(f => new
                {
                    ek = f.Evidence.EvidenceKey,
                    er = f.Evidence.EvidenceRevision,
                    source = new { path = f.Source.Path, locator = f.Source.Locator },
                    tags = f.Tags,
                }).ToArray()
            };

            return Task.FromResult(JsonSerializer.Serialize(model, JsonOpts));
        }

    }
}
