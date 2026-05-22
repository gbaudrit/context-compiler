using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Pipelines;
using ContextCompiler.Abstractions.Storage;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.Prompts;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Modules.Templates.Scriban.Extensions;
using ContextCompiler.Prompting.Modules.Templates.Scriban.Templates;

using Scriban;

namespace ContextCompiler.Prompting.Modules.Templates.Scriban;

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
            return builder.WithName(outputFilename)
                          .InStore(StoreKeys.Output)
                          .WithContent(result)
                          .WithGeneratedBy(GetType());
        });

        //new ScribanRenderedPromptResult() { Filename = outputFilename, RenderedText = result };
    }

}

