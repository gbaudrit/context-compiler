using ContextCompiler.Abstractions.Versioning;

namespace ContextCompiler.Modules.Abstractions
{
    public interface IGlobalPipelineModule : IModule
    {
        static ModuleMetadata Meta(string id, GlobalPipelineModuleKinds kind, int priority = 0)
        {
            return new(id, kind, ModuleApiVersion.Current, priority);
        }

        Task Run(CancellationToken cancellationToken);

        ModuleMetadata Metadata { get; }
    }
}
