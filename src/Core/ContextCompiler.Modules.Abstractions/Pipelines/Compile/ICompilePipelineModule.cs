using ContextCompiler.Abstractions.Common;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions.Pipelines.Compile
{
    public interface ICompilePipelineModule : IModule
    {
        static ModuleMetadata Meta(string id, CompilePipelineModuleKinds kind, int priority = 0)
        {
            return new(id, kind, ModuleApiVersion.Current, priority);
        }

        Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken);

        ModuleMetadata Metadata { get; }
    }
}
