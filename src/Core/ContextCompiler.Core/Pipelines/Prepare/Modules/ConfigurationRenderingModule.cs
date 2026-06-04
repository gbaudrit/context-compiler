using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Prepare;
using ContextCompiler.Abstractions.Services.Prepare;
using ContextCompiler.Modules.Abstractions.Pipelines.Prepare;

namespace ContextCompiler.Core.Pipelines.Prepare.Modules;

internal sealed class ConfigurationRenderingModule(IConfigurationRenderer renderer) : IPreparePipelineModule
{
    public PreparePipelineModuleMetadata Metadata =>
        IPreparePipelineModule.Meta("prepare.configuration-rendering", PreparePipelineModuleKinds.ConfigurationRendering);

    public async Task<IResult<IPreparePipelineRunResult>> Run(
        IPreparePipelineRunContext context,
        CancellationToken cancellationToken)
    {
        if (context.Plan is null)
        {
            return await context.Failure("Plan must be available before rendering configuration.");
        }

        await renderer.RenderAsync(context.Plan, cancellationToken);
        return await context.Success();
    }
}
