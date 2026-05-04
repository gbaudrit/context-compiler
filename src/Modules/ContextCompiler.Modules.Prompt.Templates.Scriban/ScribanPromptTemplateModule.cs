using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Modules.Prompt.Templates.Scriban.Extensions;
using ContextCompiler.Modules.Prompt.Templates.Scriban.Templates;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines;

using Scriban;
using ContextCompiler.Prompting.Abstractions;

namespace ContextCompiler.Modules.Prompt.Templates.Scriban;

internal sealed class ScribanPromptTemplateModule(IOutput output, IPrompt prompt, ITemplateProvider templateProvider, IConfigProvider ctxcConfigProvider) : IPromptRenderingModule
{
    public ModuleMetadata Metadata => IGlobalPipelineModule.Meta("prompt.templates.scriban", GlobalPipelineModuleKinds.ArtifactRendering, priority: 0);

    public async Task<IResult<IGlobalPipelineRunResult>> Run(IGlobalPipelineRunContext context, CancellationToken ct)
    {
        foreach (string rendererName in ctxcConfigProvider.Current.Renderers)
        {
            await RenderTemplateAsync(prompt, rendererName, rendererName);
        }

        return await context.Success();
    }

    private async Task RenderTemplateAsync(IPrompt prompt, string templateName, string outputFilename)
    {
        ArgumentNullException.ThrowIfNull(prompt);
        ArgumentException.ThrowIfNullOrEmpty(templateName);
        ArgumentException.ThrowIfNullOrEmpty(outputFilename);
        ITemplateDefinition templateDefinition = templateProvider.GetTemplate(templateName);

        Template template = Template.Parse(templateDefinition.Content)
                            ?? throw new InvalidOperationException("Failed to parse template.");
        string result = template.HasErrors ? string.Join(Environment.NewLine, template.Messages) : await template.RenderAsync(prompt.ToRenderable().Subject);
        // Check for any errors

        output.AddArtifact(builder =>
        {
            return builder.WithFileName(outputFilename)
                          .WithContent(result)
                          .WithGeneratedBy(GetType());
        });

        //new ScribanRenderedPromptResult() { Filename = outputFilename, RenderedText = result };
    }

}

