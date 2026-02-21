using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Rendering;
using ContextCompiler.Abstractions.Versioning;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Modules.BuiltIn.Templates.Scriban.Extensions;
using ContextCompiler.Modules.BuiltIn.Templates.Scriban.Templates;

using Scriban;

namespace ContextCompiler.Modules.BuiltIn.Templates.Scriban
{
    internal sealed class ScribanPromptTemplateModule(IPrompt prompt, ITemplateProvider templateProvider, IOutput output, ICtxcConfigProvider ctxcConfigProvider) : IPromptRenderingModule
    {
        public ModuleMetadata Metadata => new("builtin.prompt.render", GlobalPipelineModuleKinds.Template, ModuleApiVersion.Current, 0);

        public async Task Run(CancellationToken ct)
        {
            foreach (string rendererName in ctxcConfigProvider.Current.Renderers)
            {
                await RenderTemplateAsync(prompt.ToRenderable(), rendererName, rendererName);
            }
        }

        private async Task RenderTemplateAsync(IRenderable prompt, string templateName, string outputFilename)
        {
            ArgumentNullException.ThrowIfNull(prompt);
            ArgumentException.ThrowIfNullOrEmpty(templateName);
            ArgumentException.ThrowIfNullOrEmpty(outputFilename);
            ITemplateDefinition templateDefinition = templateProvider.GetTemplate(templateName);

            Template template = Template.Parse(templateDefinition.Content)
                                ?? throw new InvalidOperationException("Failed to parse template.");
            string result = template.HasErrors ? string.Join(Environment.NewLine, template.Messages) : await template.RenderAsync(prompt.Subject);
            // Check for any errors

            output.AddArtifact(builder =>
            {
                return builder.WithFileName(outputFilename)
                              .WithContent(result);
            });

            //new ScribanRenderedPromptResult() { Filename = outputFilename, RenderedText = result };
        }

    }
}

