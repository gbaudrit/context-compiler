using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.Plugins.Prompts;
using ContextCompiler.Abstractions.Rendering;
using ContextCompiler.Abstractions.Versioning;
using ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Extensions;
using ContextCompiler.Plugins.BuiltIn.Templates.Scriban.Templates;

using ScribanLib = global::Scriban;

namespace ContextCompiler.Plugins.BuiltIn.Templates.Scriban
{
    internal sealed class ScribanPromptTemplatePlugin(IPrompt prompt, ITemplateProvider templateProvider, IOutput output, ICtxcConfigProvider ctxcConfigProvider) : IPromptRenderingPlugin
    {
        public PluginMetadata Metadata => new PluginMetadata("builtin.prompt.render", GlobalPipelinePluginKinds.Template, PluginApiVersion.Current, 0);

        public async Task Run(CancellationToken ct)
        {
            foreach (var rendererName in ctxcConfigProvider.Current.Renderers)
            {
                await RenderTemplateAsync(prompt.ToRenderable(), rendererName, rendererName, ct);
            }
        }

        public async Task RenderTemplateAsync(IRenderable prompt, string templateName, string outputFilename, CancellationToken ct)
        {
            ITemplateDefinition templateDefinition = templateProvider.GetTemplate(templateName);

            var template = ScribanLib.Template.Parse(templateDefinition.Content) ?? throw new InvalidOperationException("Failed to parse template.");
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

            //new ScribanRenderedPromptResult() { Filename = outputFilename, RenderedText = result };
        }

    }
}

