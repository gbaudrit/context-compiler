using System;
using System.Collections.Generic;
using System.Text;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Rendering;

namespace ContextCompiler.Abstractions.Plugins.Prompts
{
    public interface IPromptRenderingPlugin
    {
        PluginMetadata Metadata { get; }

        ValueTask<IRenderedPromptResult> RenderTemplateAsync(IPrompt o, string templateName, string outputFilename, CancellationToken ct);
        ValueTask<IRenderedPromptResult> RenderTemplateAsync(IRenderable o, string templateName, string outputFilename, CancellationToken ct);
    }
}
