using System.Text.Json;

using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.GlobalPipeline;
using ContextCompiler.Abstractions.Plugins.Prompts;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Abstractions.Rendering;
using ContextCompiler.Abstractions.Versioning;
using ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Extensions;
using ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates;

using ScribanLib = global::Scriban;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban
{
    internal sealed class ScribanPromptTemplatePlugin(ITemplateProvider templateProvider, IOutput output) : IPromptRenderingPlugin
    {
        public PluginMetadata Metadata => new PluginMetadata("builtin.prompt.render", PluginKinds.Template, PluginApiVersion.Current, 0);

        public async ValueTask<IRenderedPromptResult> RenderTemplateAsync(IPrompt prompt, string templateName, string outputFilename, CancellationToken ct)
        {
            return await RenderTemplateAsync(prompt.ToRenderable(), templateName, outputFilename, ct);
        }

        public async ValueTask<IRenderedPromptResult> RenderTemplateAsync(IRenderable prompt, string templateName, string outputFilename, CancellationToken ct)
        {
            ITemplateDefinition templateDefinition = templateProvider.GetTemplate(templateName);

            var template = ScribanLib.Template.Parse(templateDefinition.Content);

            if (template is null)
            {
                throw new InvalidOperationException("Failed to parse template.");

            }

            string result;
            // Check for any errors
            if (template.HasErrors)
            {
                result = string.Join(Environment.NewLine, template.Messages);
            }
            else
            {
                result = await template.RenderAsync(prompt.Subject);
            }

            output.AddArtifact(builder =>
            {
                return builder.WithFileName(outputFilename)
                              .WithContent(result);
            });

            return new ScribanRenderedPromptResult() { Filename = outputFilename, RenderedText = result };
        }

    }
}

